var chai = require('chai');
var chaiAsPromised = require('chai-as-promised');
var expect = require('chai').expect;
var assert = require('chai').assert;
var nock = require('nock');
var Driver = require('../src/driver.js');

chai.use(chaiAsPromised);

var driver = new Driver({
  xkey: 'xkey'
});

var segment = {
  name: 'SegmentStatic (nodeJS)',
  description: 'SegmentStatic (nodeJS)',
  isTest: true,
  type: 'static',
  expiration: '2026-08-08T12:11:00Z'
};

var segmentId = '12345';

var targetId = '000OGAW7';

var nockUrl = nock(driver._url);

describe('Segment', function() {
  it('should create a Static Segment', function() {
    nockUrl.post('/V1/segments/')
    .reply(200, {
      id: '12345'
    });

    return driver.segment.create(segment).then(function(response) {
      expect(response.statusCode).to.equal(200);
      expect(response.body.id).to.equal('12345');
    });
  });

  it('should fail to create an Segment with wrong values', function() {
    nockUrl.post('/V1/segments/')
    .reply(400);

    return driver.segment.create(segment).catch(function(error) {
      expect(error.statusCode).to.equal(400);
    });
  });

  it('should modify an existing Segment', function() {
    nockUrl.put('/V1/segments/12345')
    .reply(200, {
      id: '12345'
    });

    return driver.segment.update(segmentId, segment).then(function(response) {
      expect(response.statusCode).to.equal(200);
      expect(response.body.id).to.equal('12345');
    });
  });

  it('should fail to modify an existing Segment with wrong values', function() {
    nockUrl.put('/V1/segments/12345')
    .reply(599);

    return driver.segment.update(segmentId, segment).catch(function(error) {
      expect(error.statusCode).to.equal(599);
    });
  });

  it('should get an existing Segment', function() {
    nockUrl.get('/V1/segments/12345')
    .reply(200, {
      id: '12345'
    });

    return driver.segment.get(segmentId).then(function(response) {
      expect(response.statusCode).to.equal(200);
      expect(response.body.id).to.equal('12345');
    });
  });

  it('should get a list of all Segment', function() {
    nockUrl.get('/V1/segments/')
    .reply(200, [
      {id: '12345'},
      {id: '23456'},
      {id: '34567'},
      {id: '45678'},
      {id: '56789'}
    ]);

    return driver.segment.list().then(function(response) {
      expect(response.statusCode).to.equal(200);
      expect(response.body.length).to.equal(5);
    });
  });

  it('should add a Target to a given Segment', function() {
    nockUrl.post('/targets/000OGAW7/segments/12345')
    .reply(204);

    return driver.segment.addToSegment(targetId, segmentId)
      .then(function(response) {
      expect(response.statusCode).to.equal(204);
    });
  });

  it('should delete an existing Segment', function() {
    nockUrl.delete('/segments/12345')
    .reply(204);

    return driver.segment.delete(segmentId).then(function(response) {
      expect(response.statusCode).to.equal(204);
    });
  });
});
