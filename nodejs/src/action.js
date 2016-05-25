var url = require('url');

function Action(driver) {
  this._driver = driver;
  this._url = url.resolve(driver._url, 'actions/');
}

/**
 * create() create a new request
 * that create a new action in the API
 *
 * @param {Object} action
 * @return {Promise} response
 */
Action.prototype.create = function(action) {
  if (!action) {
    Promise.reject(new TypeError('Parameter is undefined'));
  }

  return this._driver._request.execute({
    url: this._url,
    method: 'POST',
    json: action
  });
};

/**
 * update() create a new request
 * that update an action in the API
 *
 * @param {String} id
 * @param {Object} actionInfo
 * @return {Promise} response
 */
Action.prototype.update = function(id, actionInfo) {
  if (!actionInfo) {
    Promise.reject(new TypeError('Parameter is undefined'));
  }

  return this._driver._request.execute({
    url: this._url + id,
    method: 'PUT',
    json: actionInfo
  });
};

/**
 * delete() create a new request
 * that delete an action in the API
 *
 * @param {String} id
 * @return {Promise} response
 */
Action.prototype.delete = function(id) {
  return this._driver._request.execute({
    url: this._url + id,
    method: 'DELETE'
  });
};

/**
 * get() create a new request
 * that get an action from API
 *
 * @param {String} id
 * @return {Promise} response
 */
Action.prototype.get = function(id) {
  return this._driver._request.execute({
    url: this._url + id,
    method: 'GET'
  });
};

/**
 * addToSegment() create a new request
 * that validate an action
 *
 * @param {String} actionId
 * @param {String} validationArg
 * @return {Promise} response
 */
Action.prototype.validate = function(actionId, validationArg) {
  if (!actionId) {
    Promise.reject(new TypeError('Parameter is undefined'));
  }

  return this._driver._request.execute({
    url: this._url + actionId + '/validation',
    method: 'POST',
    json: validationArg
  });
};

/**
 * addToSegment() create a new request
 * that put an action on Test phase
 *
 * @param {String} actionId
 * @param {String} testArg
 * @return {Promise} response
 */
Action.prototype.test = function(actionId, testArg) {
  if (!actionId) {
    Promise.reject(new TypeError('Parameter is undefined'));
  }

  return this._driver._request.execute({
    url: this._url + actionId + '/validation',
    method: 'POST',
    json: testArg
  });
};

/**
 * list() create a new request
 * that list all action from API
 *
 * @return {Promise} response
 */
Action.prototype.list = function() {
  return this._driver._request.execute({
    url: this._url,
    method: 'GET'
  });
};

module.exports = Action;
