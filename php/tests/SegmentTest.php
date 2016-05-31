<?php

class SegmentTest extends PHPUnit_Framework_TestCase
{
    private $_xkey;
    private $_driver;

    private $_segment;
    private $_targetId;

    /*
    * driver creation is tested in another file
    */
    public function __construct()
    {
        $this->_xkey = 'xkey';
        $this->_driver = new Driver(['xKey' => $this->_xkey, 'url' => 'http://127.0.0.1:8888/']);
        $this->_segment = [
            'name'          => 'Segment static (php)',
            'description'   => 'From Driver',
            'isTest'        => true,
            'type'          => 'static',
            'expiration'    => '2026-08-08T12:11:00Z'
        ];
        $this->_targetId = '000OGAW7';
    }

    /*
    * Test with valide arguments
    */

    /*
    * It should create a segment
    */
    public function testCreateValide()
    {
        $response = $this->_driver->segment->create($this->_segment);
        $this->assertEquals($response['statusCode'], 200);
        return $response['body']['id'];
    }
    /**
     * It should update an existing segment
     *
     * @depends testCreateValide
     */
    public function testUpdateValide($segmentId)
    {
        $this->_segment['name'] = 'Segment static (php) Updated';
        $response = $this->_driver->segment->update($segmentId, $this->_segment);
        $this->assertEquals($response['statusCode'], 200);
        return $segmentId;
    }
    /**
     * It should add a target to the we've cerated
     *
     * @depends testUpdateValide
     */
    public function testAddToSegmentValide($segmentId)
    {
        $response = $this->_driver->segment->addToSegment($segmentId, $this->_targetId);
        $this->assertEquals($response['statusCode'], 204);
        return $segmentId;
    }
    /**
     * It should remove the target from the segment we've created
     *
     * @depends testAddToSegmentValide
     */
    public function testRemoveValide($segmentId)
    {
        $response = $this->_driver->segment->remove($segmentId, $this->_targetId);
        $this->assertEquals($response['statusCode'], 204);
        return $segmentId;
    }
    /**
     * It should get the segment we created thanks to its ID
     *
     * @depends testRemoveValide
     */
    public function testGetValide($segmentId)
    {
        $response = $this->_driver->segment->get($segmentId);
        $this->assertEquals($response['statusCode'], 200);
        return $segmentId;
    }
    /**
     * It should list all the segments
     */
    public function testListAll()
    {
        $response = $this->_driver->segment->listAll();
        $this->assertEquals($response['statusCode'], 200);
    }
    /**
     * It should delete the segment
     *
     * @depends testGetValide
     */
    public function testDeleteValide($segmentId)
    {
        $response = $this->_driver->segment->delete($segmentId);
        $this->assertEquals($response['statusCode'], 204);
    }

    /*
    * Test with bad arguments
    */

}

?>
