var url = require('url');

function Field(driver) {
  this._driver = driver;
  this._url = url.resolve(driver._url, 'fields/');
}

/**
 * list() create a new request
 * that list all fields from the API
 *
 * @return {Promise} response
 */
Field.prototype.list = function() {
  return this._driver._request.execute({
    url: this._url,
    method: 'GET'
  });
};

module.exports = Field;
