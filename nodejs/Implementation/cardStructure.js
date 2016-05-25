'use strict';

var Field = require('../src/field.js')

function CardStructure(driver) {
  this._driver = driver;
}

/**
 * getUnicityId() get unicity ID
 *
 * @return {Promise} response
 */
CardStructure.prototype.getUnicityId = function() {
  return new Promise((resolve, reject) => {
    if (this._unicity === undefined) {
      this.getFieldsMap().then((fields) => {
        if (response.statusCode === 200) {
          if (!this._unicity) {
            reject('Error: Your unicity is not defined');
          }
          resolve(this._unicity);
        }
        reject('Unexpected status code: ' + response.statusCode);
      });
    } else {
      resolve(this._unicity);
    }
  });
};

/**
 * getFieldsMap() get each fields name and ID
 *
 * @return {Promise} response
 */
CardStructure.prototype.getFieldsMap = function() {
  return new Promise((resolve, reject) => {
    if (this._fields === undefined) {
      this._driver.field.list().then((response) => {
        if (response.statusCode === 200) {
          this._fields = {};
          for (var i = 0, len = response.body.length; i < len; ++i) {
            let field = response.body[i];
            this._fields[field.name] = field.id;
            if (field.isUnicity) {
              this._unicity = field.id;
            }
          }
          resolve(this._fields);
        }
        reject('Unexpected status code: ' + response.statusCode);
      });
    } else {
      resolve(this._fields);
    }
  });
}

module.exports = CardStructure;
