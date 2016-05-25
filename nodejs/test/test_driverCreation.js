var assert = require('chai').assert;
var should = require('chai').should();
var Driver = require('../src/driver.js');

const XKEY = 'xkey';

describe('Driver', function() {
  it('should create a Driver', function() {
    var driver = new Driver({
      xkey: XKEY
    });
  });

  it('should create a Driver and print the xKey', function() {
    var driver = new Driver({
      xkey: XKEY
    });
    assert.equal(XKEY, driver._xkey);
  });

  it('should not create a Driver without passing the xKey', function() {
    try {
      var driver = new Driver();
    } catch (error) {
      assert(error);
    }
  });
});
