Info
--

All of the function returns a promise. On success, response is composed like this:

```javascript
var response = {
  statusCode: httpResponse.statusCode,
  body: JSON.parse(body)
};
```

Where `statusCode` is the HTTP code and `body` an object that is the response of the request.

## Table of Contents

  1. [Basics](#Basics)
  1. [Action](#Action)
  1. [Field](#Field)
  1. [Segment](#Segment)
  1. [Target](#Target)

## Basics:

Create a driver with a xkey:
```javascript
var Driver = require('./driver.js');

var driver = new Driver("my_xkey");
```

Each route is available with his own class. For exemple to create a target:
```javascript
driver.target.create(...);
```
This is a list of available routes:
  + `action`
  + `field`
  + `segment`
  + `target`

[You can find all models here](../../docs/en/models.md)

## Action

Available methods:
  + `create`
  + `update`
  + `get`
  + `list`
  + `delete`
  + `test`
  + `validate`

[Action model](../../docs/en/models.md#Action)

###### Creation of a campaign:

```javascript
driver.action.create(smsCampaign).then(function(response) {
  // code ...
}).catch(function(error) {
  // something went wrong ...
});
```

###### Put the campaign on Test phase:

```javascript
driver.action.test(campaignId, testObject).then(function(response) {
  // code ...
}).catch(function(error) {
  // something went wrong ...
});
```

###### Validate the campaign:

```javascript
driver.action.validate(campaignId, validateObject).then(function(response) {
  // code ...
}).catch(function(error) {
  // something went wrong ...
});
```

## Field

Available methods:
  + `list`

[Field model](../../docs/en/models.md#Field)

## Segment

Available methods:
  + `create`
  + `update`
  + `get`
  + `list`
  + `delete`

[Segment model](../../docs/en/models.md#Segment)

###### Creation of a static segment:

```javascript
driver.segment.create(segment).then(function(response) {
  // code ...
}).catch(function(error) {
  // something went wrong ...
});
```

###### Adding a target to a segment:

```javascript
var targetId = 'XXXXXX';
var segmentId = 'XXXXXX';

driver.segment.addToSegment(targetId, segmentId).then(function(response) {
  // code ...
}).catch(function(error) {
  // something went wrong ...
});
```

## Target

Available methods:
  + `create`
  + `update`
  + `get`
  + `list`
  + `delete`

[Target model](../../docs/en/models.md#Target)

###### Add a Target:

```javascript
driver.target.create(target).then(function(response) {
  // code ...
}).catch(function(error) {
  // something went wrong ...
});
```

###### Update a Target:

```javascript
driver.target.update(targetId, target).then(function(response) {
  // code ...
}).catch(function(error) {
  // something went wrong ...
});
```

###### Send a message to a Target:

```javascript
var actionId = 'XXXXX';
var targetId = 'XXXXXX';

driver.send.message(actionId, targetId).then(function(response) {
  // code ...
}).catch(function(error) {
  // something went wrong ...
});
```

###### Send a message with a different content to a Target:

```javascript
var actionId = 'XXXXX';
var targetId = 'XXXXXX';

driver.send.message(actionId, targetId, messageContent).then(function(response) {
  // code ...
}).catch(function(error) {
  // something went wrong ...
});
```
