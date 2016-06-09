Info
--

All of the function return an object that is composed like this:

```java
JSONObject response = new JSONObject();

response.put("statusCode", connection.getResponseCode());
response.put("body", result);
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
```java
JSONObject config = new JSONObject();

config.put("xkey", "YOUR XKEY");

Driver driver = new Driver(config);
```

Each route is available with his own class. For exemple to create a target:
```java
driver.target.create(...);
```
This is a list of available routes:
  + `action`
  + `field`
  + `segment`
  + `target`

[You can find all models here](../../../../../docs/en/models.md)

## Action

Available methods:
  + `create`
  + `update`
  + `get`
  + `list`
  + `delete`
  + `test`
  + `validate`

[Action model](../../../../../docs/en/models.md#Action)

###### Creation of a campaign:

```java
JSONObject response = driver.action.create(campaign);
if (response.getInt("statusCode") != 200) {
  // code
} else {
  // error
}
```

###### Put the campaign on Test phase:

```java
JSONObject response = driver.action.test(campaignId, testObject);
if (response.getInt("statusCode") != 200) {
  // code
} else {
  // error
}
```

###### Validate the campaign:

```java
JSONObject response = driver.action.validate(campaignId, validateObject);
if (response.getInt("statusCode") != 204) {
  // code
} else {
  // error
}
```

## Field

Available methods:
  + `list`

[Field model](../../../../../docs/en/models.md#Field)

## Segment

Available methods:
  + `create`
  + `update`
  + `get`
  + `list`
  + `delete`

[Segment model](../../../../../docs/en/models.md#Segment)

###### Creation of a static segment:

```java
JSONObject response = driver.segment.create(segment);
if (response.getInt("statusCode") != 200) {
  // code
} else {
  // error
}
```

###### Adding a target to a segment:

```java
String segmentId = "XXXXX";
String targetId = "XXXXXX";

JSONObject response = driver.segment.addToSegment(segmentId, targetId);
if (response.getInt("statusCode") != 204) {
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

[Target model](../../../../../docs/en/models.md#Target)

###### Add a Target:

```java
JSONObject response = driver.target.create(target);
if (response.getInt("statusCode") != 200) {
  // code
} else {
  // error
}
```

###### Update a Target:

```java
JSONObject response = driver.target.update(id, targetUpdate);
if (response.getInt("statusCode") != 200) {
  // code
} else {
  // error
}
```

###### Send a message to a Target:

```java
String actionId = "XXXXX";
String targetId = "XXXXXX";

JSONObject response = driver.send.message(actionId, targetId);
if (response.getInt("statusCode") != 204) {
  // code
} else {
  // error
}
```

###### Send a message with a different content to a Target:

```java
String actionId = "XXXXX";
String targetId = "XXXXXX";
JSONObject message = new JSONObject("{ }"); // Put the JSON there

JSONObject response = driver.send.message(actionId, targetId, message);
if (response.getInt("statusCode") != 204) {
  // code
} else {
  // error
}
```
