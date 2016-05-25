var chai = require('chai');
var assert = require('chai').assert;
var chaiAsPromised = require('chai-as-promised');
var expect = require('chai').expect;
var nock = require('nock');
var Wrapper = require('../Implementation/wrapper.js');

chai.use(chaiAsPromised);

var wrapper = new Wrapper({
  xkey: 'xkey'
});

var staticSegment = {
  name: 'SegmentStatic Wrapper (nodeJS)',
  description: 'SegmentStatic Wrapper (nodeJS)',
  isTest: true,
  type: 'static',
  expiration: '2026-08-08T12:11:00Z'
};

var staticSegmentId = undefined;

var dynamicSegment = {
  name: 'SegmentDynamic Wrapper (nodeJS)',
  description: 'SegmentDynamic Wrapper (nodeJS)',
  isTest: true,
  type: 'dynamic',
  expiration: '2026-08-08T12:11:00Z'
};

var dynamicSegmentId = undefined;

var nockUrl = nock(wrapper.driver._url);

describe('Wrapper', function() {
  it('should create a Static Segment', function() {
    nockUrl.post('/V1/segments/')
    .reply(200, {
      id: '12345'
    });
    
    return wrapper.createSegment(staticSegment).then(function(response) {
      staticSegmentId = response.body.id;
      expect(response.statusCode).to.equal(200);
    });
  });

  it('should create a Dynamic Segment', function() {
    nockUrl.post('/V1/segments/')
    .reply(200, {
      id: '12345'
    });

    return wrapper.createSegment(dynamicSegment).then(function(response) {
      dynamicSegmentId = response.body.id;
      expect(response.statusCode).to.equal(200);
    });
  });
});
