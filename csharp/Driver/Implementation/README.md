Usage
--

#### Basics:

Create a driver with a xkey:
```chsharp
JSONObject config = new JSONObject();

config.put("xkey", "votre xkey");

Wrapper driver = new Wrapper(config);
```

#### Add a Target:

Create a target (or update it if it already exists):
```chsharp
var target = new JsonObject
{
    {"1234", "test@test.com"},
    {"1234", "Test"},
    {"1234", "Mr"}
};

NResponse response = wrapper.CreateOrModifyTarget(target);

if (response.StatusCode == (HttpStatusCode)200)
{
  // code
}
else
{
  // error
}
```

#### Add a Target and send a message:

Create a target (or update it if it already exist) and send a message to this target:
```chsharp
string actionId = "XXXXX";

var target = new JsonObject
{
    {"1234", "test@test.com"},
    {"1234", "Test"},
    {"1234", "Mr"}
};

NResponse response = wrapper.AddTargetAndSendMessage(target, actionId);

if (response.StatusCode == (HttpStatusCode)200)
{
  // code
}
else
{
  // error
}
```

#### Creation of a campaign:

Create a campaign:
```chsharp
IActionModel action = new MailCampaignModel()
{
    Name = "Mail Campaign Test (C#)"
};

NResponse response = wrapper.CreateCampaign(action);

if (response.StatusCode == (HttpStatusCode)200)
{
  // code
}
else
{
  // error
}
```
#### Creation of a segment:

Create a static segment:
```chsharp
SegmentModel segment = new SegmentModel()
{
    Name = "My lovely segment",
    Description = "This is my first segment",
    IsTest = true,
    Type = "static",
    Expiration = "2026-08-08T12:11:00Z"
};

NResponse response = wrapper.CreateSegment(segment)

if (response.StatusCode == (HttpStatusCode)200)
{
  // code
}
else
{
  // error
}
```

#### Campaign validation:

Validate a campaign (require the campaign ID):

```chsharp
string campaignId = "1234";

ValidationModel validation = new ValidationModel()
{
    Fortest = false,
    CampaignAnalyser = false,
    TestSegments = null,
    MediaForTest = null,
    TextandHtml = true,
    Comments = null
};

NResponse response = wrapper.ValidateCampaign(campaignId, validation)

if (response.StatusCode == (HttpStatusCode)200)
{
  // code
}
else
{
  // error
}
```

### Target creation, then add it to a segment

Create a target (or update it if it already exist), and then add it to the segment:

```chsharp
string segmentId = "1234";

JsonObject target = new JsonObject();

target.Add("civilité", "Mr");
target.Add("prénom", "Test");
target.Add("email", "test@test.com");

NResponse response = wrapper.CreateTargetAndAddToSegment(target, segmentId);

if (response.StatusCode == (HttpStatusCode)204)
{
  // code
}
else
{
  // error
}
```

### Campaign creation, and then test it

Create a campaign and launch the test phase

```chsharp
IActionModel campaign = new MailCampaignModel()
{
    Name = "Mail Campaign Test"
};

TestModel test = new TestModel()
{
    Fortest = true,
    CampaignAnalyser = false,
    TestSegments = new int[] { 12345 },
    TextandHtml = false,
};

NResponse response = wrapper.CreateAndTestCampaign(campaign, test)

if (response.StatusCode == (HttpStatusCode)200)
{
  // code
}
else
{
  // error
}
```

### Import

Launch manual import:
```chsharp
string filepath = "./assets/import.csv"

ImportModel import = new ImportModel()
{
    Name = "Manual Import",
    Features = new Feature[]
    {
        new Feature() {
            Type = "segmentation",
            SegmentId = 12345,
            EmptyExistingSegment = false
        },
        new Feature() {
            Type = "duplicate",
            Rules = new Rule() { Ignore = true }
        },
        new Feature() {
            Type = "report",
            SendFinalReport = true,
            SendErrorReport = true,
            ContactGuids = new string[] {"01234ABC"},
        },
        new Feature() {
            Type = "database",
            UpdateExisting = true,
            CrushData = false,
        }
    },
    Binding = 1234
};

NResponse response = wrapper.Import(importConfig, filepath);

if (response.StatusCode == (HttpStatusCode)200)
{
  // code
}
else
{
  // error
}
```
