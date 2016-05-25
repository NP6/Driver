var request = require('request');
var path = require('path');
var mime = require('mime');

function Request(xkey) {
  this._xkey = xkey;
}

/**
* execute() use request module to make a request
* with paramter in @param req object
*
* @param {Object} req
* @return {Promise} response
*/
Request.prototype.execute = function(req) {
  var config;

  if (req.filename && req.data) {
    config = this.createImportConfig(req);
  } else {
    config = this.createConfig(req);
  }
  return new Promise((resolve, reject) => {
    request(config, function(err, httpResponse, body) {
      if (err || httpResponse.statusCode >= 400) {
        reject({
          statusCode: err ? 400 : httpResponse.statusCode,
          body: err || body
        });
      }
      resolve({
        statusCode: httpResponse.statusCode,
        body: body.length ? JSON.parse(body) : {}
      });
    });
  });
};

/**
* createHeader() create a header with default value
*
* @param {int} packetLength
* @return {Object} header
*/
Request.prototype.createHeader = function(packetLength) {
  return {
    'X-Key': this._xkey,
    'Content-Type': 'application/json',
    'Content-Length': packetLength
  };
};

/**
* createConfig() create a object with default value
*
* @param {Object} request
* @return {Object} config
*/
Request.prototype.createConfig = function(request) {
  var config = {
    url: request.url,
    method: request.method,
    headers: this.createHeader(0)
  };
  if (request.json) {
    var requestJSON = JSON.stringify(request.json);
    config.headers = this.createHeader(requestJSON.length);
    config.body = requestJSON;
  }
  return config;
};

/**
* createConfig() create a object with default value
* for import request
*
* @param {Object} request
* @return {Object} config
*/
Request.prototype.createImportConfig = function(request) {
  var config = {
    url: request.url,
    method: request.method,
    headers: {
      'X-Key': this._xkey,
      'Content-Type': 'application/octet-stream',
      'Content-Disposition': 'form-data; filename=' + path.basename(request.filename)
    },
    formData: {
      data: {
        value: request.data,
        options: {
          filename: path.basename(request.filename),
          contentType: mime.lookup(request.filename)
        }
      }
    }
  };
  return config;
};

module.exports = Request;
