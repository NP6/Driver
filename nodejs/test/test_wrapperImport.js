var chai = require('chai');
var chaiAsPromised = require('chai-as-promised');
var expect = require('chai').expect;
var assert = require('chai').assert;
var nock = require('nock');
var Wrapper = require('../Implementation/wrapper.js');

chai.use(chaiAsPromised);

var wrapper = new Wrapper({
  xkey: 'xkey'
});

var manualImport = {
  'name': 'Manual Import from Wrapper',
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

var filepath = '../assets/import.csv';
var nockUrl = nock(wrapper.driver._url);

describe('Wrapper => import', function() {
  describe('#import', function() {
    it('should create a import and execute it', function() {
      nockUrl.post('/imports/')
      .reply(200, {
        id: '12345'
      })
      .post('/imports/12345/executions')
      .reply(200, {
        state: 0
      });
      

      return wrapper.import(manualImport, filepath).then(function(response) {
        expect(response.statusCode).to.equal(200);
        expect(response.body.state).to.equal(0);
      });
    });
  });
});
