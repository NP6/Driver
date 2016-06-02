<?php

spl_autoload_register(function ($class_name) {
    include __DIR__ . '/../src/' . $class_name . '.php';
});

class Wrapper
{
    private $_driver;
    private $_fields;
    private $_unicity;

    /**
     * @param array $config
     */
    public function __construct($config)
    {
        $this->_driver = new Driver($config);
        $this->_fields = [];
    }
    /**
     * @return Driver
     */
    public function getDriver()
    {
        return $this->_driver;
    }
    /**
     * @param array $target
     * @return array
     */
    public function createSegment($target)
    {
        return $this->_driver->segment->create($target);
    }
    /**
     * @param array $action
     * @return array
     */
    public function createCampaign($action)
    {
        return $this->_driver->action->create($action);
    }
    /**
     * @param array $target
     * @return array
     */
    public function createOrModifyTarget($target)
    {
        $unicityId = $this->getUnicityId();
        $normalizeTarget = $this->normalizeTarget($target);

        $response = $this->_driver->target->find($normalizeTarget[$unicityId]);
        if ($response['statusCode'] == 404)
            return $this->_driver->target->create($normalizeTarget);
        else if ($response['statusCode'] == 200)
            return $this->_driver->target->update($response['body']['id'], $normalizeTarget);
        return $response;
    }
    /**
     * @param array $target
     * @param string $actionId
     * @param array $messageContent
     * @return array
     */
    public function addTargetAndSendMessage($target, $actionId, $messageContent=null)
    {
        $response = $this->createOrModifyTarget($target);
        if ($response['statusCode'] != 200)
        {
            return $response;
        }
        $targetId = $response['body']['id'];
        return $this->_driver->send->message($actionId, $targetId, $messageContent);
    }
    /**
     * createAndTestCampaign() create a campaign,
     * retrieve it's ID and then launch the test phase
     *
     * @param array $campaign
     * @param array $testOptions
     * @return array $response
     */
    public function createAndTestCampaign($campaign, $testOptions)
    {
        $response = $this->_driver->action->create($campaign);

        if ($response['statusCode'] != 200)
        {
            return $response;
        }
        $campaignId = $response['body']['id'];
        $response = $this->_driver->action->test($campaignId, $testOptions);
        $response['body'] = [
            'id'    => $campaignId
        ];
        return $response;
    }
    /**
     * createTargetAndAddToSegment() create a target,
     * and add it to the segment provided by its ID
     *
     * @param array $targetObject
     * @param string $segmentId
     * @return array $response
     */
    public function createTargetAndAddToSegment($targetObject, $segmentId)
    {
        $response = $this->createOrModifyTarget($targetObject);

        if ($response['statusCode'] != 200)
        {
            return $response;
        }
        $targetId = $response['body']['id'];
        $response = $this->_driver->segment->addToSegment($segmentId, $targetId);
        return $response;
    }

    /**
     * validateCampaign() validate the campaign provided by its ID
     *
     * @param string $campaignId
     * @param array $validateOptions
     * @return array $response
     */
    public function validateCampaign($campaignId, $validateOptions)
    {
        return $this->_driver->action->validate($campaignId, $validateOptions);
    }

    /**
     * import() create and execute an import
     *
     * @param array $import
     * @param string $filepath
     * @return array $response
     */
    public function import($import, $filepath)
    {
        $response = $this->_driver->import->create($import);
        if ($response['statusCode'] === 200)
        {
            return $this->_driver->import->execute($response['body']['id'], $filepath);
        }
    }

    /*
    ** Private methodes
    */

    /**
     * Get the unicity id
     *
     * @return integer
     */
    private function getUnicityId()
    {
        if (!$this->_unicity)
        {
            $response = $this->_driver->field->listAll();

            if ($response['statusCode'] != 200)
                throw new Exception('Unable to retrieve all fields');
            for ($i = 0, $len = count($response['body']); $i < $len; $i++)
            {
                $field = $response['body'][$i];
                $this->_fields[$field['name']] = $field['id'];
                if ($field['isUnicity'])
                    $this->_unicity = $field['id'];
            }
            if (!$this->_unicity)
                throw new Exception('You haven\'t set any uncity type');
            return $this->_unicity;
        }
        return $this->unicity;
    }
    /**
     *
     * @param array $target
     * @return array
     */
    private function normalizeTarget($target)
    {
        $newTarget = [];
        foreach ($target as $key => $value)
        {
            if (!is_int($key)) {
                if (!isset($this->_fields[$key])) 
                    throw new Exception("The field named $key doesn't exist");
                $newTarget[$this->_fields[$key]] = $value;
            }
            else
                $newTarget[$key] = $value;
        }
        return $newTarget;
    }
}

?>
