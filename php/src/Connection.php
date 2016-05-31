<?php

class Connection
{
    private $_xKey;
    private $_url;
    /**
     * @param string $xKey
     * @param string $url
     */
    public function __construct($xKey, $url)
    {
        $this->_xKey = $xKey;
        $this->_url = $url;
    }
    /**
     * @param string $route
     *
     * @return array
     */
    public function request($route, $method, $data=null, $import=false)
    {
        $header = [
            'X-Key: ' . $this->_xKey,
        ];
        if (!$import)
        {
            array_push($header, 'Content-Type: application/json');
            if ($data)
            {
                array_push($header, 'Content-Length: ' . strlen($data));
            }
        }
        else
        {
            array_push($header, 'Content-Disposition: form-data; filename=' . $data['data']->getPostFilename());
        }

        $options = [
            CURLOPT_HTTPHEADER      => $header,
            CURLOPT_TIMEOUT         => 10,
            CURLOPT_CUSTOMREQUEST   => $method,
            CURLOPT_URL             => $this->_url . $route,
            CURLOPT_POSTFIELDS      => $data,
            CURLOPT_RETURNTRANSFER  => true,
        ];

        $ch = curl_init();

        curl_setopt_array($ch, $options);

        $output = curl_exec($ch);

        $info = curl_getinfo($ch);

        curl_close($ch);

        $response = [
            'body'                  => json_decode($output, true),
            'statusCode'            => $info['http_code']
        ];
        return ($response);
    }
}

?>
