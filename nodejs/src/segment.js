var url = require('url');

function Segment(driver) {
  this._driver = driver;
  this._url = url.resolve(driver._url, 'V1/segments/');
}

/**
 * create() create a new request
 * that create a new segment in the API
 *
 * @param {Object} segment
 * @return {Promise} response
 */
Segment.prototype.create = function(segment) {
  if (!segment) {
    Promise.reject(new TypeError('Parameter is undefined'));
  }

  return this._driver._request.execute({
    url: this._url,
    method: 'POST',
    json: segment
  });
};

/**
 * update() create a new request
 * that update a segment in the API
 *
 * @param {String} id
 * @param {Object} segmentInfo
 * @return {Promise} response
 */
Segment.prototype.update = function(id, segmentInfo) {
  if (!segmentInfo) {
    Promise.reject(new TypeError('Parameter is undefined'));
  }

  return this._driver._request.execute({
    url: this._url + id,
    method: 'PUT',
    json: segmentInfo
  });
};

/**
 * delete() create a new request
 * that delete a segment in the API
 *
 * @param {String} id
 * @return {Promise} response
 */
Segment.prototype.delete = function(id) {
  return this._driver._request.execute({
    url: url.resolve(this._driver._url, 'segments/' + id),
    method: 'DELETE'
  });
};

/**
 * get() create a new request
 * that get a segment from API
 *
 * @param {String} id
 * @return {Promise} response
 */
Segment.prototype.get = function(id) {
  return this._driver._request.execute({
    url: this._url + id,
    method: 'GET'
  });
};

/**
 * list() create a new request
 * that list all segment from API
 *
 * @return {Promise} response
 */
Segment.prototype.list = function() {
  return this._driver._request.execute({
    url: this._url,
    method: 'GET'
  });
};

/**
 * addToSegment() create a new request
 * that add a target to a segment
 *
 * @param {String} targetId
 * @param {String} segmentId
 * @return {Promise} response
 */
Segment.prototype.addToSegment = function(targetId, segmentId) {
  return this._driver._request.execute({
    url: url.resolve(this._driver._url, 'targets/' + targetId + '/segments/' + segmentId),
    method: 'POST'
  });
};

/**
 * remove() create a new request
 * that remove a target from a segment
 *
 * @param {String} targetId
 * @param {String} segmentId
 * @return {Promise} response
 */
Segment.prototype.remove = function(targetId, segmentId) {
  return this._driver._request.execute({
    url: url.resolve(this._driver._url, 'targets/' + targetId + '/segments/' + segmentId),
    method: 'DELETE'
  });
};

module.exports = Segment;
