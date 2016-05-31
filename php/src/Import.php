<?php

class Import
{
    private $_connection;
    private $_route;
    /**
     * @param string $connection
     */
    public function __construct($connection)
    {
        $this->_connection = $connection;
        $this->_route = 'imports/';
    }
    /**
     * Create an import
     *
     * @param array $import
     * @return array
     */
    public function create($import)
    {
        if (!$import)
        {
            throw new Exception('Parameter undefined');
        }

        $data = json_encode($import);

        return $this->_connection->request($this->_route, 'POST', $data);
    }
    /**
     * Execute a manual import
     *
     * @param string $importId
     * @param string $filePath
     * @return array
     */
    public function execute($id, $filePath)
    {
        $valid = false;
        $validExt = [
            'txt',
            'csv',
            'zip',
            'tar.gz',
            'tgz',
            'gz'
        ];
        $validExtLength = count($validExt);
        if (!$id || !$filePath)
        {
            throw new Exception('Parameter undefined');
        }

        $fileParts = pathinfo($filePath);

        if (!$fileParts || !isset($fileParts['extension']))
        {
            throw new Exception('There was a problem with your file');
        }

        for ($i = 0; $i < $validExtLength; $i++)
        {
            if ($validExt[$i] == $fileParts['extension'])
            {
                $valid = true;
            }
        }

        if (!$valid)
        {
            throw new Exception('Wrong type of file');
        }

        $routeUrl = $this->_route . $id . '/executions';

        $finfo = finfo_open(FILEINFO_MIME_TYPE);

        $contentType = finfo_file($finfo, $filePath);

        finfo_close($finfo);

        $cfile = curl_file_create($filePath, $contentType, $fileParts['basename']);

        $data = ['data' => $cfile];

        return $this->_connection->request($routeUrl, 'POST', $data, true);
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
     * Delete an import
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

}

?>
