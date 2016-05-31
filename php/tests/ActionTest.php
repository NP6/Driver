<?php

class ActionTest extends PHPUnit_Framework_TestCase
{
    private $_xkey;
    private $_driver;

    private $_smsCampaign;
    private $_testConfig;

    /*
    * driver creation is tested in another file
    */
    public function __construct()
    {
        $this->_xkey = 'xkey';
        $this->_driver = new Driver(['xKey' => $this->_xkey, 'url' => 'http://127.0.0.1:8888/']);
        $this->_smsCampaign = [
            'type'              => 'smsCampaign',
            'name'              => 'SMS Campaign from Driver (php)',
            'description'       => 'This is a description',
            'informations'      => [],
            'scheduler'         => [],
            'content'           => []
        ];
        $this->_smsCampaign['informations'] = [
            'folder'            => null,
            'category'          => null
        ];
        $this->_smsCampaign['scheduler'] = [
            'type'              => 'asap'
        ];
        $this->_smsCampaign['content'] = [
            'textContent'       => 'This is a sms content'
        ];
        $this->_testConfig = [
            'fortest'           => true,
            'campaignAnalyser'  => false,
            'testSegments'      => [14091],
            'mediaForTest'      => null,
            'textandHtml'       => false,
            'comments'          => null
        ];
    }

    /*
    * Test with valide arguments
    */

    /*
    * It should create a campaign
    */
    public function testCreateValide()
    {
        $response = $this->_driver->action->create($this->_smsCampaign);
        $this->assertEquals($response['statusCode'], 200);
        return $response['body']['id'];
    }
    /**
     * It should update an existing campaign
     *
     * @depends testCreateValide
     */
    public function testUpdateValide($smsCampaignId)
    {
        $this->_smsCampaign['name'] = 'Updated';
        $response = $this->_driver->action->update($smsCampaignId, $this->_smsCampaign);
        $this->assertEquals($response['statusCode'], 200);
        return $smsCampaignId;
    }
    /**
     * It should launch the campaign's test phase
     *
     * @depends testUpdateValide
     */
    public function testTestValide($smsCampaignId)
    {
        $response = $this->_driver->action->test($smsCampaignId, $this->_testConfig);
        $this->assertEquals($response['statusCode'], 204);
        return $smsCampaignId;
    }
    /**
     * It should get the campaign we created thanks to its ID
     *
     * @depends testCreateValide
     */
    public function testGetValide($smsCampaignId)
    {
        $response = $this->_driver->action->get($smsCampaignId);
        $this->assertEquals($response['statusCode'], 200);
    }
    /**
     * It should list all the actions
     */
    public function testListAll()
    {
        $response = $this->_driver->action->listAll();
        $this->assertEquals($response['statusCode'], 200);
    }
    /**
     * It should validate the campaign that we previously tested
     *
     * @depends testTestValide
     */
    public function testValidateValide($smsCampaignId)
    {
        $this->_testConfig['fortest'] = false;
        $response = null;
        do {
            $response = $this->_driver->action->get($smsCampaignId);
            if ($response != 200) break;
        } while ($response->body['state'] != 38); // state: waiting for validation
        $response = $this->_driver->action->validate($smsCampaignId, $this->_testConfig);
        $this->assertEquals($response['statusCode'], 204);
    }
    /**
     * It should create a campaign and then delete it
     */
    public function testDeleteValide()
    {
        $response = $this->_driver->action->create($this->_smsCampaign);
        $this->assertEquals($response['statusCode'], 200);

        $smsCampaignId = $response['body']['id'];

        $response = $this->_driver->action->delete($smsCampaignId);
        $this->assertEquals($response['statusCode'], 204);
    }

    /*
    * Test with bad arguments
    */

}

?>
