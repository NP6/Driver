var url = require('url');

function Send(driver) {
  this._driver = driver;
  this._url = url.resolve(driver._url, 'actions/');
}

/**
 * message() create a new request
 * that send a message to a target
 *
 * @param {String} actionId
 * @param {String} targetId
 * @param {Object} content
 * @return {Promise} response
 */
Send.prototype.message = function(actionId, targetId, content) {
  return this._driver._request.execute({
    url: this._url + actionId + '/targets/' + targetId,
    method: 'POST',
    json: content
  });
};

module.exports = Send;
