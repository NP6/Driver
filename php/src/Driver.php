<?php

spl_autoload_register(function ($class_name) {
    include __DIR__ . '/' . $class_name . '.php';
});

/**
 * Driver class that contain everything.
 */
class Driver
{
    private $_xKey;
    private $_url;
    private $_connection;
    public $segment;
    public $target;
    public $action;
    public $send;
    public $import;
    /**
     * @param string $xKey
     */
    public function __construct($config)
    {
        $this->_xKey = $config['xKey'];
        $this->_url = (isset($config['url'])) ? $config['url'] : 'https://backoffice.mailperformance.com/';
        $this->_connection = new Connection($this->_xKey, $this->_url);
        $this->segment = new Segment($this->_connection);
        $this->target = new Target($this->_connection);
        $this->action = new Action($this->_connection);
        $this->send = new Send($this->_connection);
        $this->import = new Import($this->_connection);
        $this->field = new Field($this->_connection);
    }
    /**
     * @return string
     */
    public function getUrl()
    {
        return $this->_url;
    }
    /**
     * @return string
     */
    public function getXKey()
    {
        return $this->_xKey;
    }
}

?>
