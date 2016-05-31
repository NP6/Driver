<?php

class SendTest extends PHPUnit_Framework_TestCase
{
    private $_xkey;
    private $_driver;

    private $_message;
    private $_messageId;
    private $_targetId;

    /*
    * driver creation is tested in another file
    */
    public function __construct()
    {
        $this->_xkey = 'xkey';
        $this->_driver = new Driver(['xKey' => $this->_xkey, 'url' => 'http://127.0.0.1:8888/']);
        $this->_message = [
            'content'       => [
                'html'      => 'PLEASE REPORT TO SOMEONE IF YOU RECEIVED THIS EMAIL',
                'text'      => 'PLEASE REPORT TO SOMEONE IF YOU RECEIVED THIS EMAIL'
            ],
            'header'        => [
                'subject'   => 'subject of the message',
                'mailFrom'  => 'mail@address.com',
                'replyTo'   => 'mail@return.com'
            ]
        ];
        $this->_messageId = '000QF0';
        $this->_targetId = '000OG3XW';
    }
    /**
     * It should send a message to a target
     *
     */
    public function testMessageSending()
    {
        $response = $this->_driver->send->message($this->_messageId, $this->_targetId);
        $this->assertEquals($response['statusCode'], 204);
    }
    /**
     * It should send a message with a different
     * content then the one in it to a target
     *
     */
    public function testMessageSendingWithDifferentContent()
    {
        $response = $this->_driver->send->message($this->_messageId, $this->_targetId, $this->_message);
        $this->assertEquals($response['statusCode'], 204);
    }
}

?>
