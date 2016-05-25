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

Object.defineProperty(Driver.prototype, 'action', {
  get: function() {
    return this._action || (this._action = new Action(this));
  }
});
Object.defineProperty(Driver.prototype, 'segment', {
  get: function() {
    return this._segment || (this._segment = new Segment(this));
  }
});
Object.defineProperty(Driver.prototype, 'target', {
  get: function() {
    return this._target || (this._target = new Target(this));
  }
});
Object.defineProperty(Driver.prototype, 'send', {
  get: function() {
    return this._send || (this._send = new Send(this));
  }
});
Object.defineProperty(Driver.prototype, 'field', {
  get: function() {
    return this._field || (this._field = new Field(this));
  }
});
Object.defineProperty(Driver.prototype, 'import', {
  get: function() {
    return this._import || (this._import = new Import(this));
  }
});

module.exports = Driver;
