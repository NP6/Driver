var url = require('url');
var path = require('path');
var fs = require('fs');

function Import(driver) {
  this._driver = driver;
  this._url = url.resolve(driver._url, 'imports/');
}

/**
 * create() create a new request
 * that create a new Import
 *
 * @param {Object} imports
 * @return {Promise} response
 */
Import.prototype.create = function(imports) {
  return this._driver._request.execute({
    url: this._url,
    method: 'POST',
    json: imports
  });
};

/**
 * execute() create a new request
 * that execute an Import given its id
 * and the file that will be import
 *
 * @param {String} id
 * @param {String} file
 * @return {Promise} response
 */
Import.prototype.execute = function(id, file) {
  var extension = path.extname(file);
  var valid = false;
  var validExt = [
    '.txt',
    '.csv',
    '.zip',
    '.tar.gz',
    '.tgz',
    '.gz'
  ];

  for (var i = 0, len = validExt.length; i < len; i++) {
    if (validExt[i] === extension) {
      valid = true;
    }
  }

  if (!valid) {
    Promise.reject(new TypeError('Wrong type of file'));
  }

  return new Promise((resolve, reject) => {
    fs.readFile(file, (err, result) => {
      if (err) {
        throw new TypeError(err.message);
      }

      resolve(this._driver._request.execute({
        url: this._url + id + '/executions',
        method: 'POST',
        filename: file,
        data: result
      }));
    });
  });
};

/**
 * list() create a new request
 * that list all Import
 *
 * @return {Promise} response
 */
Import.prototype.list = function() {
  return this._driver._request.execute({
    url: this._url,
    method: 'GET'
  });
};

/**
 * delete() create a new request
 * that delete an Import
 *
 * @param {String} id
 * @return {Promise} response
 */
Import.prototype.delete = function(id) {
  return this._driver._request.execute({
    url: this._url + id,
    method: 'DELETE'
  });
};

module.exports = Import;
