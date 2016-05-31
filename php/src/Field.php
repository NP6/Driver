<?php

class Field
{
    private $_connection;
    private $_route;

    /**
     * @param Connection $connection
     */
    public function __construct($connection)
    {
        $this->_connection = $connection;
        $this->_route = 'fields/';
    }
    /**
     * List all fields
     *
     * @return array
     */
    public function listAll()
    {
        return $this->_connection->request($this->_route, 'GET');
    }
}

?>
