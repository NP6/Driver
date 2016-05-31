<?php

class CampaignTest extends PHPUnit_Framework_TestCase
{
    private $_xkey;
    private $_wrapper;

    private $_smsMessage;
    private $_testOptions;
    private $_segmentId;
    private $_target;
    private $_validateOptions;
    private $_campaignId;

    public function __construct()
    {
        $this->_xkey = 'xkey';
        $this->_wrapper = new Wrapper(['xKey' => $this->_xkey, 'url' => 'http://127.0.0.1:8888/']);
        $this->_smsMessage = [
            'type'              => 'smsCampaign',
            'name'              => 'SMSMessage test wrapper',
            'description'       => 'SMSMessage tmp (nodeJS)',
            'informations'      => [
                'folder'        => null,
                'category'      => null
            ],
            'content'           => [
                'textContent'   => 'Message text.'
            ],
            'scheduler'         => [
                'type'          => 'asap'
            ]
        ];
        $this->_testOptions = [
            'fortest'           => false,
            'campaignAnalyser'  => false,
            'textandHtml'       => false
        ];
        $this->_validateOptions = [
            'fortest'           => true,
            'campaignAnalyser'  => false,
            'testSegments'      => [14091],
            'textandHtml'       => false
        ];
        $this->_target = [
            8631                => 'Mr',
            8630                => 'Test php',
            8628                => 'test@test.com'
        ];
        $this->_segmentId = '14091';
        $this->_campaignId = '000QEU';
    }

    /**
     * It should create and test a campaign
     */
    public function testCreateAndTestCampaignValide()
    {
        $response = $this->_wrapper->createAndTestCampaign($this->_smsMessage, $this->_testOptions);
        $this->assertEquals($response['statusCode'], 204);
        $this->_wrapper->getDriver()->action->delete($response['body']['id']);
    }

    /**
     * It should create a target and add it to a segment
     */
    public function testCreateTargetAndAddToSegment()
    {
        $response = $this->_wrapper->createTargetAndAddToSegment($this->_target, $this->_segmentId);
        $this->assertEquals($response['statusCode'], 204);
    }

    /**
     * It should create a target and add it to a segment
     */
    public function testValidateCampaign()
    {
        $response = $this->_wrapper->validateCampaign($this->_campaignId, $this->_validateOptions);
        $this->assertEquals($response['statusCode'], 204);
    }
}

?>
