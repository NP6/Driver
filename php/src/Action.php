<?php

class Action
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
     * Create an action
     *
     * @param array $action
     * @return array
     */
    public function create($action)
    {
        if (!$action)
        {
            throw new Exception('Parameter is undefined');
        }

        $data = json_encode($action);

        return $this->_connection->request($this->_route, 'POST', $data);
    }
    /**
     * Update an action
     *
     * @param string $id
     * @param array $action
     * @return array
     */
    public function update($id, $action)
    {
        if (!$action || !$id)
        {
            throw new Exception('Parameter is undefined');
        }

        $routeUrl = $this->_route . $id;

        $data = json_encode($action);

        return $this->_connection->request($routeUrl, 'PUT', $data);
    }
    /**
     * Get a action
     *
     * @param string $id
     * @return array
     */
    public function get($id)
    {
        if (!$id)
        {
            throw new Exception('Parameter is undefined');
        }
        return $this->_connection->request($this->_route . $id, 'GET');
    }
    /**
     * List all action
     *
     * @return array
     */
    public function listAll()
    {
        return $this->_connection->request($this->_route, 'GET');
    }
    /**
     * Delete a action
     *
     * @param string $id
     * @return array
     */
    public function delete($id)
    {
        if (!$id)
        {
            throw new Exception('Parameter is undefined');
        }
        $routeUrl = $this->_route . $id;
        return $this->_connection->request($routeUrl, 'DELETE');
    }
    /**
     * Validate an Action
     *
     * @param string $actionId
     * @param array $validationArg
     * @return array
     */
    public function validate($actionId, $validationArg)
    {
        if (!$actionId || !$validationArg)
        {
            throw new Exception('Parameter are undefined');
        }

        $data = json_encode($validationArg);

        $routeUrl = $this->_route . $actionId . '/validation';

        return $this->_connection->request($routeUrl, 'POST', $data);
    }
    /**
     * Test an Action
     *
     * @param string $actionId
     * @param array $validationArg
     * @return array
     */
    public function test($actionId, $validationArg)
    {
        if (!$actionId || !$validationArg)
        {
            throw new Exception('Parameter are undefined');
        }

        $data = json_encode($validationArg);

        $routeUrl = $this->_route . $actionId . '/validation';

        return $this->_connection->request($routeUrl, 'POST', $data);
    }
}

?>
