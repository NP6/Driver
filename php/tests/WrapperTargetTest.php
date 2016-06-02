<?php 

class WrapperTargetTest extends PHPUnit_Framework_TestCase
{
    private $_wrapper;
    
    private $_target;
    
    public function __construct()
    {
        $this->_xkey = 'my_xkey';
        $this->_wrapper = new Wrapper(['xkey' => $this->_xkey,
                                        'url' => 'http://127.0.0.1:8888/']);
        $this->_target = [
            'civilité'    => 'Mr',
            8630    => 'Test php',
            8628    => 'test@test.com'
        ];
    }
    
    /**
    * It should create (or update) the target
    * Fields are set using their name (and not their ID)
    */
    public function testCreateTargetOrUpdateValid()
    {
        $response = $this->_wrapper->createOrModifyTarget($this->_target);
        $this->assertEquals($response['statusCode'], 200);
    }
    
    /**
    * It should not create (or update) the target
    * because we set a wrong field name
    */
    public function testCreateTargetOrUpdateInvalid()
    {
        $target = [
            'wrong'    => 'Mr',
            8630    => 'Test php',
            8628    => 'test@test.com'
        ];

        try {        
            $response = $this->_wrapper->createOrModifyTarget($target);
        } catch (Exception $e) {
            $this->assertEquals($e->getMessage(), "The field named wrong doesn't exist");
        }
    }
}

?>