<?php

class ImportTest extends PHPUnit_Framework_TestCase
{
    private $_xkey;
    private $_driver;

    private $_manualImport;
    private $_autoImport;
    private $_importPath;

    /*
    * driver creation is tested in another file
    */
    public function __construct()
    {
        $this->_xkey = 'xkey';
        $this->_driver = new Driver(['xKey' => $this->_xkey, 'url' => 'http://127.0.0.1:8888/']);
        $this->_manualImport = [
            'name'                          => 'Manual Import PHP',
            'features'                      => [
                [
                    'type'                  => 'segmentation',
                    'segmentId'             => 14098,
                    'emptyExisitingSegment' => false
                ], [
                    'type'                  => 'duplicate',
                    'rules'                 => [
                        'ignore'            => true
                    ]
                ], [
                    'type'                  => 'report',
                    'sendFinalReport'       => true,
                    'sendErrorReport'       => true,
                    'contactGuids'          => ['044EAE5A'],
                    'groupIds'              => []
                ], [
                    'type'                  => 'database',
                    'updateExisting'        => true,
                    'crushData'             => false
                ]
            ],
            'binding'                       => 8330
        ];
        $this->_autoImport = [
            'name'                          => 'Auto Import PHP',
            'binding'                       => 8330,
            'source'                        => [
                'type'                      => 'ftp'
            ],
            'scheduler'                     => [
                'type'                      => 'periodic',
                'name'                      => 'Nom du scheduler',
                'frequency'                 => [
                    'occurs'                => [
                        'type'              => 'daily'
                    ],
                    'periodicity'           => [
                        'type'              => 'once',
                        'value'             => [
                            'hour'          => 6,
                            'minute'        => 0,
                            'second'        => 0
                        ]
                    ]
                ],
                'validity'                  => [
                    'start'                 => [
                        'year'              => 2016,
                        'month'             => 12,
                        'date'              => 1,
                        'hour'              => 0,
                        'minute'            => 0,
                        'second'            => 0
                    ],
                    'end'=> [
                        'year'              => 2017,
                        'month'             => 10,
                        'date'              => 1,
                        'hour'              => 0,
                        'minute'            => 0,
                        'second'            => 0
                    ]
                ]
            ],
            'features'=> [
                [
                    'type'                  => 'segmentation',
                    'segmentId'             => 14091,
                    'emptyExisitingSegment' => false
                ], [
                    'type'                  => 'duplicate',
                    'rules'                 => [
                        'ignore'            => true
                    ]
                ], [
                    'type'                  => 'report',
                    'sendFinalReport'       => true,
                    'sendErrorReport'       => true,
                    'contactGuids'          => ['044EAE5A'],
                    'groupIds'              => []
                ], [
                    'type'                  => 'database',
                    'updateExisting'        => true,
                    'crushData'             => true
                ]
            ]
        ];
        $this->_importPath = __DIR__ . '/../../assets/import.csv';
    }
    /**
     * It should create an Auto Import
     *
     */
    public function testCreateAutoImport()
    {
        $response = $this->_driver->import->create($this->_autoImport);
        $this->assertEquals($response['statusCode'], 200);
        return $response['body']['id'];
    }
    /**
     * It should create a Manual Import
     *
     */
    public function testCreateManualImport()
    {
        $response = $this->_driver->import->create($this->_manualImport);
        $this->assertEquals($response['statusCode'], 200);
        return $response['body']['id'];
    }
    /**
     * It should execute a Manual Import
     *
     * @depends testCreateManualImport
     */
    public function testExecuteManualImport($importId)
    {
        $response = $this->_driver->import->execute($importId, $this->_importPath);
        $this->assertEquals($response['statusCode'], 200);
        return $importId;
    }
    /**
     * It should list all Import
     *
     */
    public function testListImport()
    {
        $response = $this->_driver->import->listAll();
        $this->assertEquals($response['statusCode'], 200);
    }
    /**
     * It should delete the two Imports
     *
     * @depends testCreateAutoImport
     * @depends testExecuteManualImport
     */
    public function testDeleteImport($autoId, $manualId)
    {
        $response = $this->_driver->import->delete($autoId);
        $this->assertEquals($response['statusCode'], 204);
        $response = $this->_driver->import->delete($manualId);
        $this->assertEquals($response['statusCode'], 204);
    }
}

?>
