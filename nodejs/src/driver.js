var Request = require('./request.js');
var Action = require('./action.js');
var Segment = require('./segment.js');
var Target = require('./target.js');
var Send = require('./send.js');
var Field = require('./field.js');
var Import = require('./import.js');
var configFile = require('./config.json');

function Driver(config) {
  if (!config) {
    throw new TypeError('Missing parameter');
  }

  this._xkey = config.xkey;
  this._url = config.baseUrl || configFile.baseUrl;
  this._request = new Request(this._xkey);
}

function defineEntity(name, Entity) {
  Object.defineProperty(Driver.prototype, name, {
    get: function() {
      var entity = new Entity(this);
      Object.defineProperty(this, name, {
        value: entity
      });
      return entity;
    }
  });
}

defineEntity('action', Action);
defineEntity('segment', Segment);
defineEntity('target', Target);
defineEntity('send', Send);
defineEntity('field', Field);
defineEntity('import', Import);

module.exports = Driver;
