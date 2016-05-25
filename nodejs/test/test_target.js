var chai = require('chai');
var chaiAsPromised = require('chai-as-promised');
var expect = require('chai').expect;
var nock = require('nock');
var Driver = require('../src/driver.js');

chai.use(chaiAsPromised);

var driver = new Driver({
  xkey: 'xkey'
});

var target = {
  8631: 'Mr',
  8630: 'Test Node',
  8628: 'Node@test.com'
};

var targetUnicity = 'Node@test.com';

var targetId = '000MGKMG';

var segmentId = '12345';

var nockUrl = nock(driver._url);

describe('Target', function() {
  it('should create a Target', function() {
    nockUrl.post('/targets/')
    .reply(200, {
      id: '000MGKMG'
    });
    
    return driver.target.create(target).then(function(response) {
      expect(response.statusCode).to.equal(200);
      expect(response.body.id).to.equal('000MGKMG');
    });
  });

  it('should fail to create a Target with wrong values', function() {
    nockUrl.post('/targets/')
    .reply(409);
    
    return driver.target.create(target).catch(function(response) {
      expect(response.statusCode).to.equal(409);
    });
  });

  it('should modify an existing Target', function() {
    nockUrl.put('/targets/000MGKMG')
    .reply(200, {
      id: '000MGKMG'
    });

    return driver.target.update(targetId, target).then(function(response) {
      expect(response.statusCode).to.equal(200);
      expect(response.body.id).to.equal('000MGKMG');
    });
  });

  it('should fail to modify an existing Target with wrong values', function() {
    nockUrl.put('/targets/000MGKMG')
    .reply(409);

    return driver.target.update(targetId, target).catch(function(response) {
      expect(response.statusCode).to.equal(409);
    });
  });

  it('should get an existing Target thanks to its Unicity character', function() {
    nockUrl.get('/targets?unicity=Node@test.com')
    .reply(200, {
      id: '000MGKMG'
    });

    return driver.target.find(targetUnicity).then(function(response) {
      expect(response.statusCode).to.equal(200);
      expect(response.body.id).to.equal('000MGKMG');
    });
  });

  it('should get an existing Target thanks to its ID', function() {
    nockUrl.get('/targets/000MGKMG')
    .reply(200, {
      id: '000MGKMG'
    });

    return driver.target.get(targetId).then(function(response) {
      expect(response.statusCode).to.equal(200);
    });
  });

  it('should list all existing Target', function() {
    nockUrl.get('/targets/')
    .reply(200, [
      {id: '000MGKMG'},
      {id: '000MGKMH'},
      {id: '000MGKMI'},
      {id: '000MGKMK'},
     ]);

    return driver.target.list().then(function(response) {
      expect(response.statusCode).to.equal(200);
      expect(response.body.length).to.equal(4);
    });
  });

  it('should delete an existing Target', function() {
    nockUrl.delete('/targets/000MGKMG')
    .reply(204);
    
    return driver.target.delete(targetId).then(function(response) {
      expect(response.statusCode).to.equal(204);
    });
  });
});
