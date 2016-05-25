var url = require('url');

function Target(driver) {
  this._driver = driver;
  this._url = url.resolve(driver._url, 'targets/');
}

/**
 * create() create a new request
 * that create a new target in the API
 *
 * @param {Object} target
 * @return {Promise} response
 */
Target.prototype.create = function(target) {
  if (!target) {
    Promise.reject(new TypeError('Parameter is undefined'));
  }

  return this._driver._request.execute({
    url: this._url,
    method: 'POST',
    json: target
  });
};

/**
 * update() create a new request
 * that update a target in the API
 *
 * @param {String} id
 * @param {Object} targetInfo
 * @return {Promise} response
 */
Target.prototype.update = function(id, targetInfo) {
  if (!targetInfo) {
    Promise.reject(new TypeError('Parameter is undefined'));
  }

  return this._driver._request.execute({
    url: this._url + id,
    method: 'PUT',
    json: targetInfo
  });
};

/**
 * delete() create a new request
 * that delete a target in the API
 *
 * @param {String} id
 * @return {Promise} response
 */
Target.prototype.delete = function(id) {
  return this._driver._request.execute({
    url: this._url + id,
    method: 'DELETE'
  });
};

/**
 * get() create a new request
 * that get a target from API
 *
 * @param {String} id
 * @return {Promise} response
 */
Target.prototype.get = function(id) {
  return this._driver._request.execute({
    url: this._url + id,
    method: 'GET'
  });
};

/**
 * find() create a new request
 * that get a target from API
 *
 * @param {String} unicity
 * @return {Promise} response
 */
Target.prototype.find = function(unicity) {
  return this._driver._request.execute({
    url: this._url.slice(0, -1) + '?unicity=' + unicity,
    method: 'GET'
  });
};

/**
 * list() create a new request
 * that list all target from API
 *
 * @return {Promise} response
 */
Target.prototype.list = function() {
  return this._driver._request.execute({
    url: this._url,
    method: 'GET'
  });
};

module.exports = Target;
