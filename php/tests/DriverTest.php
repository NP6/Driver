<?php

class DriverTest extends PHPUnit_Framework_TestCase
{
    private $_xkey;
    private $_driver;

    public function __construct()
    {
        $this->_xkey = 'xkey';
    }

    /*
    * It should create a Driver
    */
    public function testDriverConstructor()
    {
        $this->_driver = new Driver([
            'xKey' => $this->_xkey
        ]);
        $this->assertEquals($this->_driver->getXKey(), $this->_xkey);
    }
}

?>
