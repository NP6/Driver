Utilisation
--

#### Base:

Créer un driver avec une xkey:
```chsharp
var config = new Dictionary<string, string>();

config["xKey"] = "YOUR XKEY";

Wrapper wrapper = new Wrapper(config);
```

#### Ajouter une cible:

Créer une cible (ou la mettre à jour si elle existe déjà):
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

#### Ajouter une cible et envoyer un message:

Créer une cible (ou la mettre à jour si elle existe déjà) et envoyer un message à cette cible:
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

#### Création de campagne:

Créer une campagne:
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

#### Création de segment:

Créer un segment statique:
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

#### Validation de campagne:

Valider une campagne (requiert de connaitre son ID):
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

### Création d'une cible, puis l'ajoute à un segment

Créer une cible (ou la mettre à jour si elle existe déjà), puis l'ajoute à un segment:
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

### Création d'une campagne, puis lancement de la phase de test

Créer une campagne puis lancer la phase de test:
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

Lancer un import manuel:
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
