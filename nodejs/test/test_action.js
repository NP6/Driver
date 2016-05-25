var chai = require('chai');
var chaiAsPromised = require('chai-as-promised');
var assert = require('chai').assert;
var expect = require('chai').expect;
var nock = require('nock');
var request = require('request');
var Driver = require('../src/driver.js');

chai.use(chaiAsPromised);

var driver = new Driver({
  xkey: 'xkey'
});

var smsMessage = {
  type: 'smsMessage',
  name: 'SMSMessage (nodeJS)',
  description: 'SMSMessage (nodeJS)',
  informations: {folder: null, category: null},
  content: {textContent: 'Message text.'},
};

var badSmsMessage = {
  type: 'smsMessage',
  name: 'SMSMessage tmp (nodeJS)',
  description: 1,
  informations: {folder: null, category: null},
  content: {textContent: 'Message text.'},
};

var actionId = '12AB3';

var nockUrl = nock(driver._url);

describe('Action', function() {
  it('should create an SMSMessage', function() {
    nockUrl.post('/actions/')
    .reply(200, {
      id: '12AB3'
    });

    return driver.action.create(smsMessage).then(function(response) {
      expect(response.statusCode).to.equal(200);
      expect(response.body.id).to.equal('12AB3');
    });
  });

  it('should fail to create an Action with wrong values', function() {
    nockUrl.post('/actions/')
    .reply(400);
    
    return driver.action.create(badSmsMessage).catch(function(error) {
      expect(error.statusCode).to.equal(400);
    });
  });

  it('should modify an existing Action', function() {
    nockUrl.put('/actions/12AB3')
    .reply(200, {
      id: '12AB3'
    });

    return driver.action.update(actionId, smsMessage).then(function(response) {
      expect(response.statusCode).to.equal(200);
    });
  });

  it('should fail to modify an existing Action with wrong values', function() {
    nockUrl.put('/actions/12AB3')
    .reply(400);

    return driver.action.update(actionId, badSmsMessage).catch(function(error) {
      expect(error.statusCode).to.equal(400);
    });
  });

  it('should get an existing Action', function() {
    nockUrl.get('/actions/12AB3')
    .reply(200, {
      id: '12AB3'
    });

    return driver.action.get(actionId).then(function(response) {
      expect(response.statusCode).to.equal(200);
      expect(response.body.id).to.equal('12AB3');
    });
  });

  it('should list all existing Target', function() {
    nockUrl.get('/actions/')
    .reply(200, [
      {id: '12AB3'},
      {id: '23CD4'},
      {id: '34CD5'},
      {id: '45CD6'}
    ]);

    return driver.action.list().then(function(response) {
      expect(response.statusCode).to.equal(200);
      expect(response.body.length).to.equal(4);
    });
  });

  it('should delete an existing Action', function() {
    nockUrl.delete('/actions/12AB3')
    .reply(204);

    return driver.action.delete(actionId).then(function(response) {
      expect(response.statusCode).to.equal(204);
    });
  });
});
