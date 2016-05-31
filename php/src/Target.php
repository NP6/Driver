<?php

class Target
{
    private $_connection;
    private $_route;
    /**
     * @param string $connection
     */
    public function __construct($connection)
    {
        $this->_connection = $connection;
        $this->_route = 'targets/';
    }
    /**
     * Create a target
     *
     * @param array $target
     * @return array
     */
    public function create($target)
    {
        if (!$target)
        {
            throw new Exception('Parameter is undefined');
        }

        $data = json_encode($target);

        return $this->_connection->request($this->_route, 'POST', $data);
    }
    /**
     * Update a target
     *
     * @param array $target
     * @return array
     */
    public function update($id, $target)
    {
        if (!$target || !$id)
        {
            throw new Exception('Parameter is undefined');
        }

        $data = json_encode($target);

        return $this->_connection->request($this->_route . $id, 'PUT', $data);
    }
    /**
     * Get a target
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
     * List all target
     *
     * @return array
     */
    public function listAll()
    {
        return $this->_connection->request($this->_route, 'GET');
    }
    /**
     * Delete a target
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
     * Find a target thanks to its unicity
     *
     * @param string $unicity
     * @return array
     */
    public function find($unicity)
    {
        if (!$unicity)
        {
            throw new Exception('Parameter is undefined');
        }
        $routeUrl = 'targets?unicity=' . $unicity;
        return $this->_connection->request($routeUrl, 'GET');
    }
}

?>
