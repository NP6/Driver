Info
--

All of the function return an object that is composed like this:

```chsharp
public class NResponse
{
    public HttpStatusCode StatusCode { get; set; }
    public JToken Body { get; set; }
}
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
```chsharp
var config = new Dictionary<string, string>();

config["xKey"] = "YOUR XKEY";

Driver driver = new Driver(config);
```

Each route is available with his own class. For exemple to create a target:
```chsharp
driver.Target.Create(...);
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

```chsharp
NResponse response = driver.Action.Create(campaign);
if (response.StatusCode == (HttpStatusCode)200)
{
  // code
}
else
{
  // error
}
```

###### Put the campaign on Test phase:

```chsharp
NResponse response = driver.Action.Test(campaignId, testObject);
if (response.StatusCode == (HttpStatusCode)200)
{
  // code
}
else
{
  // error
}
```

###### Validate the campaign:

```chsharp
NResponse response = driver.Action.Validate(campaignId, validateObject);
if (response.StatusCode == (HttpStatusCode)204)
{
  // code
}
else
{
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

```chsharp
NResponse response = driver.Segment.Create(segment);
if (response.StatusCode == (HttpStatusCode)200)
{
  // code
}
else
{
  // error
}
```

###### Adding a target to a segment:

```chsharp
string segmentId = "XXXXX";
string targetId = "XXXXXX";

NResponse response = driver.Segment.AddToSegment(segmentId, targetId);
if (response.StatusCode == (HttpStatusCode)204)
{
  // code
}
else
{
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

```chsharp
NResponse response = driver.Target.Create(target);
if (response.StatusCode == (HttpStatusCode)200)
{
  // code
}
else
{
  // error
}
```

###### Update a Target:

```chsharp
NResponse response = driver.Target.Update(id, targetUpdate);
if (response.StatusCode == (HttpStatusCode)200)
{
  // code
}
else
{
  // error
}
```

###### Send a message to a Target:

```chsharp
String actionId = "XXXXX";
String targetId = "XXXXXX";

NResponse response = driver.Send.Message(actionId, targetId);
if (response.StatusCode == (HttpStatusCode)204)
{
  // code
}
else
{
  // error
}
```

###### Send a message with a different content to a Target:

```chsharp
String actionId = "XXXXX";
String targetId = "XXXXXX";
MessageModel message = new MessageModel(); // Put the JSON there

NResponse response = driver.Send.Message(actionId, targetId, message);
if (response.StatusCode == (HttpStatusCode)204)
{
  // code
}
else
{
  // error
}
```
