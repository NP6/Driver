<?php

class Segment
{
    private $_connection;
    private $_route;
    /**
     * @param string $connection
     */
    public function __construct($connection)
    {
        $this->_connection = $connection;
        $this->_route = 'segments/';
    }
    /**
     * Create a segment
     *
     * @param array $segment
     * @return array
     */
    public function create($segment)
    {
        if (!$segment)
        {
            throw new Exception('Parameter is undefined');
        }

        $data = json_encode($segment);

        return $this->_connection->request($this->_route, 'POST', $data);
    }
    /**
     * Update a segment
     *
     * @param array $segment
     * @param string $id
     * @return array
     */
    public function update($id, $segment)
    {
        if (!$segment || !$id)
        {
            throw new Exception('Parameter is undefined');
        }

        $routeUrl = $this->_route . $id;

        $data = json_encode($segment);

        return $this->_connection->request($routeUrl, 'PUT', $data);
    }
    /**
     * Get a segment
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
     * List all segment
     *
     * @return array
     */
    public function listAll()
    {
        return $this->_connection->request($this->_route, 'GET');
    }
    /**
     * Delete a segment
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
     * Add a Target to a Segment
     *
     * @param string $segmentId
     * @param string $targetId
     * @return array
     */
    public function addToSegment($segmentId, $targetId)
    {
        if (!$segmentId || !$targetId)
        {
            throw new Exception('Parameter are undefined');
        }
        $routeUrl = 'targets/' . $targetId . '/segments/' . $segmentId;
        return $this->_connection->request($routeUrl, 'POST');
    }
    /**
     * Remove a Target from a Segment
     *
     * @param string $segmentId
     * @param string $targetId
     * @return array
     */
    public function remove($segmentId, $targetId)
    {
        if (!$segmentId || !$targetId)
        {
            throw new Exception('Parameter are undefined');
        }
        $routeUrl = 'targets/' . $targetId . '/segments/' . $segmentId;
        return $this->_connection->request($routeUrl, 'DELETE');
    }
}

?>
