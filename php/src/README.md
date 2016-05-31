Info
--

All of the function return an object that is composed like this:

```php
$response = [
  statusCode  => httpResponse.statusCode,
  body        => JSON.parse(body)
];
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
```php
$driver = new Driver([
    'xkey'  => 'your xKey'
  ]);
```

Each route is available with his own class. For exemple to create a target:
```php
$driver->target->create(...);
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

```php
$response = driver->action->create(smsCampaign);
if ($response['statusCode'] == 200) {
  // code
} else {
  // error
}
```

###### Put the campaign on Test phase:

```php
$response = driver->action->test(campaignId, testObject);
if ($response['statusCode'] == 204) {
  // code
} else {
  // error
}
```

###### Validate the campaign:

```php
$response = driver->action->validate(campaignId, validateObject);
if ($response['statusCode'] == 200) {
  // code
} else {
  // error
}
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

```php
$response = driver->segment->create(segment);
if ($response['statusCode'] == 200) {
  // code
} else {
  // error
}
```

###### Adding a target to a segment:

```php
$targetId = 'XXXXXX';
$segmentId = 'XXXXXX';

$response = driver->segment->addToSegment(targetId, segmentId);
if ($response['statusCode'] == 204) {
  // code
} else {
  // error
}
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

```php
$response = driver->target->create(target);
if ($response['statusCode'] == 200) {
  // code
} else {
  // error
}
```

###### Update a Target:

```php
$response = driver->target->update(target);
if ($response['statusCode'] == 200) {
  // code
} else {
  // error
}
```

###### Send a message to a Target:

```php
$actionId = 'XXXXX';
$targetId = 'XXXXXX';

$response = driver->send->message(actionId, targetId);
if ($response['statusCode'] == 204) {
  // code
} else {
  // error
}
```

###### Send a message with a different content to a Target:

```php
$actionId = 'XXXXX';
$targetId = 'XXXXXX';

$response = driver->send->message(actionId, targetId, messageContent);
if ($response['statusCode'] == 204) {
  // code
} else {
  // error
}
```
