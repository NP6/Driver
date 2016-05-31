<?php

class TargetTest extends PHPUnit_Framework_TestCase
{
    private $_xkey;
    private $_driver;

    private $target;

    /*
    * driver creation is tested in another file
    */
    public function __construct()
    {
        $this->_xkey = 'xkey';
        $this->_driver = new Driver(['xKey' => $this->_xkey, 'url' => 'http://127.0.0.1:8888/']);
        $this->target = [
            8631    => 'Mr',
            8630    => 'Test php',
            8628    => 'test@test.com'
        ];
    }

    /*
    * Test with valide arguments
    */

    /**
     * It should create a target
     */
    public function testCreateValide()
    {
        $response = $this->_driver->target->create($this->target);
        $this->assertEquals($response['statusCode'], 200);
        return $response['body']['id'];
    }
    /**
     * It should update an existing target
     *
     * @depends testCreateValide
     */
    public function testUpdateValide($targetId)
    {
        $this->target[8630] = 'Test PHP (Updated)';
        $response = $this->_driver->target->update($targetId, $this->target);
        $this->assertEquals($response['statusCode'], 200);
        return $targetId;
    }
    /**
     * It should get the target we created thanks to its ID
     *
     * @depends testCreateValide
     */
    public function testGetValide($targetId)
    {
        $response = $this->_driver->target->get($targetId);
        $this->assertEquals($response['statusCode'], 200);
        return $targetId;
    }
    /**
     * It should list all the targets
     */
    public function testListAll()
    {
        $response = $this->_driver->target->listAll();
        $this->assertEquals($response['statusCode'], 200);
    }
    /**
     * It should find the target we created
     *
     * @depends testGetValide
     */
    public function testFindValide($targetId)
    {
        $response = $this->_driver->target->find('test@test.com');
        $this->assertEquals($response['statusCode'], 200);
        $this->assertEquals($response['body']['fields'][8628], $this->target[8628]);
        return $targetId;
    }
    /**
     * It should delete the target
     *
     * @depends testFindValide
     */
    public function testDeleteValide($targetId)
    {
        $response = $this->_driver->target->delete($targetId);
        $this->assertEquals($response['statusCode'], 204);
    }

    /*
    * Test with bad arguments
    */

}

?>
