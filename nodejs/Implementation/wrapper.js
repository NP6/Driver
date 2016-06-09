'use strict';

var Driver = require('../src/driver.js');
var CardStructure = require('./cardStructure.js');

function Wrapper(config) {
  this._driver = new Driver(config);
  this._cardStructure = new CardStructure(this._driver);
}

Object.defineProperty(Wrapper.prototype, 'driver', {
  get: function() {
    return this._driver;
  }
});
/**
 * createOrModifyTarget()
 * Create a new Target or modify it if it already exists
 *
 * @param {Object} targetObject
 * @return {Promise} response
 */
Wrapper.prototype.createOrModifyTarget = function(targetObject) {
  var target;

  return this._normalizeTarget(targetObject)
  .then((targetNormalize) => {
    target = targetNormalize;
    return this._cardStructure.getUnicityId();
  })
  .then((unicityId) => {
    return this.driver.target.find(target[unicityId]);
  })
  .then((response) => {
    if (response.statusCode === 200) {
      return this.driver.target.update(response.body.id, target);
    }
  })
  .catch((error) => {
    if (error.statusCode === 404) {
      return this.driver.target.create(target);
    }
    throw error;
  });
};
/**
 * addTargetAndSendMessage()
 * Create a new Target or modify
 * it if it already exists and send a message to it
 *
 * @param {Object} targetObject
 * @param {String} actionId
 * @param {Object} messageContent
 * @return {Promise} response
 */
Wrapper.prototype.addTargetAndSendMessage = function(targetObject, actionId, messageContent) {
  return this.createOrModifyTarget(targetObject)
  .then((response) => {
    if (response.statusCode === 200) {
      var targetId = response.body.id;
      return this.driver.send.message(actionId, targetId, messageContent);
    }
    throw response;
  });
};
/**
 * createCampaign()
 * Create a new Campaign Action
 *
 * @param {Object} actionObject
 * @return {Promise} response
 */
Wrapper.prototype.createCampaign = function(actionObject) {
  return this.driver.action.create(actionObject);
};
/**
 * createSegment()
 * Create a new Segment
 *
 * @param {Object} segmentObject
 * @return {Promise} response
 */
Wrapper.prototype.createSegment = function(segmentObject) {
  return this.driver.segment.create(segmentObject);
};
/**
 * createTargetAndAddToSegments()
 * Create a new Target or modify
 * it if it already exists and add it to a segment
 *
 * @param {Object} targetObject
 * @param {String} segmentId
 * @return {Promise} response
 */
Wrapper.prototype.createTargetAndAddToSegment = function(targetObject, segmentId) {
  return this.createOrModifyTarget(targetObject)
  .then((response) => {
    if (response.statusCode === 200) {
      var targetId = response.body.id;
      return this.driver.segment.addToSegment(targetId, segmentId);
    }
    throw response;
  });
};
/**
 * validateCampaign()
 * Validate a Campaign Action
 *
 * @param {String} campaignId
 * @param {Object} validationObject
 * @return {Promise} response
 */
Wrapper.prototype.validateCampaign = function(campaignId, validationObject) {
  return this.driver.action.validate(campaignId, validationObject);
};
/**
 * testCampaign()
 * Test a Campaign Action
 *
 * @param {String} campaignId
 * @param {Object} testconfig
 * @return {Promise} response
 */
Wrapper.prototype.testCampaign = function(campaignId, testconfig) {
  return this.driver.action.test(campaignId, testconfig);
};
/**
 * createAndTestCampaign()
 * Create and Test a Campaign Action
 *
 * @param {Object} actionObject
 * @param {Object} testconfig
 * @return {Promise} response
 */
Wrapper.prototype.createAndTestCampaign = function(actionObject, testconfig) {
  return this.driver.action.create(actionObject)
  .then((response) => {
    if (response.statusCode === 200) {
      var targetId = response.body.id;
      return this.driver.action.test(targetId, testconfig);
    }
    throw response;
  });
};
/**
 * import()
 * Create and Execute an import
 *
 * @param {Object} importConfig
 * @param {String} filepath
 * @return {Promise} response
 */
Wrapper.prototype.import = function(importConfig, filepath) {
  return this.driver.import.create(importConfig)
  .then((response) => {
    if (response.statusCode === 200) {
      return this.driver.import.execute(response.body.id, filepath);
    }
    throw response;
  });
};

/**
* normalizeTarget() is a private method that convert field
* name to its ID value
*
* @param {Object} target
* @return {Promise} normalizetarget
*/
Wrapper.prototype._normalizeTarget = function(target) {
  return new Promise((resolve, reject) => {
    if (typeof target !== 'object') {
      reject(new TypeError('Parameter should be an object'));
    }
    var keys = Object.keys(target);
    var newTarget = {};

    this._cardStructure.getFieldsMap()
    .then(function(fields) {
      for (var i = 0, len = keys.length; i < len; ++i) {
        let key = keys[i];
        if (isNaN(key)) {
          newTarget[fields[key]] = target[key];
        } else {
          newTarget[key] = target[key];
        }
      }
      resolve(newTarget);
    });
  });
};

module.exports = Wrapper;
