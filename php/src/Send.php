<?php

class Send
{
    private $_connection;
    private $_route;
    /**
     * @param string $connection
     */
    public function __construct($connection)
    {
        $this->_connection = $connection;
        $this->_route = 'actions/';
    }
    /**
     * Send a message to a target
     *
     * @param string $actionId
     * @param string $targetId
     * @param array $content
     * @return array
     */
    public function message($actionId, $targetId, $content=null)
    {
        $data = null;
        if (!$actionId || !$targetId)
        {
            throw new Exception('Parameter undefined');
        }

        if ($content)
        {
            $data = json_encode($content);
        }

        $routeUrl = $this->_route . $actionId . '/targets/' . $targetId;

        return $this->_connection->request($routeUrl, 'POST', $data);
    }
}

?>
