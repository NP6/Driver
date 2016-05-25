var chai = require('chai');
var assert = require('chai').assert;
var chaiAsPromised = require('chai-as-promised');
var expect = require('chai').expect;
var nock = require('nock');
var Driver = require('../src/driver.js');

chai.use(chaiAsPromised);

var driver = new Driver({
  xkey: 'xkey'
});

var autoImport = {
  'name': 'Nom de votre Import automatique',
  'binding': 8330,
  'source': {
    'type': 'ftp'
  },
  'scheduler': {
    'type': 'periodic',
    'name': 'Nom du scheduler',
    'frequency': {
      'occurs': {
        'type': 'daily'
      },
      'periodicity': {
        'type': 'once',
        'value': {
          'hour': 6,
          'minute': 0,
          'second': 0
        }
      }
    },
    'validity': {
      'start': {
        'year': 2016,
        'month': 12,
        'date': 1,
        'hour': 0,
        'minute': 0,
        'second': 0
      },
      'end': {
        'year': 2017,
        'month': 10,
        'date': 1,
        'hour': 0,
        'minute': 0,
        'second': 0
      }
    }
  },
  'features': [{
    'type': 'segmentation',
    'segmentId': 14091,
    'emptyExisitingSegment': false
  }, {
    'type': 'duplicate',
    'rules': {
      'ignore': true
    }
  }, {
    'type': 'report',
    'sendFinalReport': true,
    'sendErrorReport': true,
    'contactGuids': ['044EAE5A'],
    'groupIds': []
  }, {
    'type': 'database',
    'updateExisting': true,
    'crushData': true
  }]
};

var manualImport = {
  'name': 'Manual Import nodeJS',
  'features': [{
    'type': 'segmentation',
    'segmentId': 14098,
    'emptyExisitingSegment': false
  }, {
    'type': 'duplicate',
    'rules': {
      'ignore': true
    }
  }, {
    'type': 'report',
    'sendFinalReport': true,
    'sendErrorReport': true,
    'contactGuids': ['044EAE5A'],
    'groupIds': []
  }, {
    'type': 'database',
    'updateExisting': true,
    'crushData': false
  }],
  'binding': 8330
};

var nockUrl = nock(driver._url);

var importId = '12345';

describe('Import', function() {
  it('should create an automatic Import', function() {
    nockUrl.post('/imports/')
    .reply(200, {
      id: '12345'
    });

    return driver.import.create(autoImport).then(function(response) {
      expect(response.statusCode).to.equal(200);
      expect(response.body.id).to.equal('12345');
    });
  });
  
  it('should create a manual Import', function() {
    nockUrl.post('/imports/')
    .reply(200, {
      id: '12345'
    });

    return driver.import.create(manualImport).then(function(response) {
      expect(response.statusCode).to.equal(200);
      expect(response.body.id).to.equal('12345');
    });
  });
  
  it('should execute a manual Import', function() {
    nockUrl.post('/imports/12345/executions')
    .reply(200, {
      state: 0
    });

    return driver.import.execute(importId, '../assets/import.csv').then(function(response) {
      expect(response.statusCode).to.equal(200);
      expect(response.body.state).to.equal(0);
    });
  });
  
  it('should list all existing Import', function() {
    nockUrl.get('/imports/')
    .reply(200, [
      {id: '12345'},
      {id: '14725'},
      {id: '15978'},
    ]);

    return driver.import.list().then(function(response) {
      expect(response.statusCode).to.equal(200);
      expect(response.body.length).to.equal(3);
    });
  });
  
  it('should delete an existing Import', function() {
    nockUrl.delete('/imports/12345')
    .reply(204);

    return driver.import.delete(importId).then(function(response) {
      expect(response.statusCode).to.equal(204);
    });
  });
});
