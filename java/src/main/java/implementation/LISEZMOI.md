Utilisation
--

#### Base:

Créer un driver avec une xkey:
```java
JSONObject config = new JSONObject();

config.put("xkey", "votre xkey");

Wrapper driver = new Wrapper(config);
```

#### Ajouter une cible:

Créer une cible (ou la mettre à jour si elle existe déjà):
```java
JSONObject target = new JSONObject();

target.put(1234, "Mr");
target.put(1234, "Test");
target.put(1234, "test@test.com");

JSONObject response = wrapper.create(target);
if (response.getInt("statusCode") != 200) {
  // code
} else {
  // erreur
}
```

#### Ajouter une cible et envoyer un message:

Créer une cible (ou la mettre à jour si elle existe déjà) et envoyer un message à cette cible:
```java
JSONObject target = new JSONObject();

String actionId = "XXXXX";

target.put(1234, "Mr");
target.put(1234, "Test");
target.put(1234, "test@test.com");

JSONObject response = wrapper.addTargetAndSendMessage(target, actionId);
if (response.getInt("statusCode") != 200) {
  // code
} else {
  // erreur
}
```

#### Création de campagne:

Créer une campagne:
```java
JSONObject smsCampaign = new JSONObject();

smsCampaign.put("type", "smsCampaign");
smsCampaign.put("name", "SMSCampaignFromApi");
smsCampaign.put("description", "SMSCampaignFromApi");

JSONObject informations = new JSONObject();
informations.put("folder", NULL);
informations.put("category", NULL);

smsCampaign.put("informations", informations);

JSONObject scheduler = new JSONObject();
scheduler.put("type", "asap");

smsCampaign.put("scheduler", scheduler);

JSONObject content = new JSONObject();
content.put("textContent", "Text message / max 160");

smsCampaign.put("content", content);

JSONObject response = wrapper.createCampaign(smsCampaign);
if (response.getInt("statusCode") != 200) {
  // code
} else {
  // erreur
}
```

#### Création de segment:

Créer un segment statique:
```java
JSONObject segment = new JSONObject();

segment.put("name", "My lovely segment");
segment.put("description", "This is my first segment");
segment.put("type", "static");
segment.put("expiration", "2026-08-08T12:11:00Z");
segment.put("isTest", true);

JSONObject response = wrapper.createSegment(segment);
if (response.getInt("statusCode") != 200) {
  // code
} else {
  // erreur
}
```

#### Validation de campagne:

Valider une campagne (requiert de connaitre son ID):
```java
String campaignId = "1234";

JSONObject validateObject = new JSONObject();

validateObject.put("fortest", false);
validateObject.put("campaignAnalyser", false);
validateObject.put("testSegments", null);
validateObject.put("mediaForTest", null);
validateObject.put("textandHtml", false);
validateObject.put("comments", null);

JSONObject response = wrapper.validateCampaign(campaignId, validateObject);
if (response.getInt("statusCode") != 200) {
  // code
} else {
  // erreur
}
```

### Création d'une cible, puis l'ajoute à un segment

Créer une cible (ou la mettre à jour si elle existe déjà), puis l'ajoute à un segment:
```java
String segmentId = "1234";

JSONObject target = new JSONObject();

target.put("civilité", "Mr");
target.put("prénom", "Test");
target.put("email", "test@test.com");

JSONObject response = wrapper.createTargetAndAddToSegment(target, segmentId);
if (response.getInt("statusCode") != 204) {
  // code
} else {
  // erreur
}
```

### Création d'une campagne, puis lancement de la phase de test

Créer une campagne puis lancer la phase de test:
```java
JSONObject smsCampaign = new JSONObject();

smsCampaign.put("type", "smsCampaign");
smsCampaign.put("name", "SMSCampaignFromApi");
smsCampaign.put("description", "SMSCampaignFromApi");

JSONObject informations = new JSONObject();
informations.put("folder", NULL);
informations.put("category", NULL);

smsCampaign.put("informations", informations);

JSONObject scheduler = new JSONObject();
scheduler.put("type", "asap");

smsCampaign.put("scheduler", scheduler);

JSONObject content = new JSONObject();
content.put("textContent", "Text message / max 160");

smsCampaign.put("content", content);

JSONObject testconfig = new JSONObject();

testconfig.put("fortest", true);
testconfig.put("campaignAnalyser", false);
testconfig.put("testSegments", [12345]);
testconfig.put("mediaForTest", null);
testconfig.put("textandHtml", false);
testconfig.put("comments", null);

JSONObject response = wrapper.createAndTestCampaign(smsCampaign, testconfig);
if (response.getInt("statusCode") != 200) {
  // code
} else {
  // erreur
}
```

### Import

Lancer un import manuel:
```java
String filepath = "./assets/import.csv"

JSONObject importConfig = new JSONObject();

importConfig.put("name", "Manual Import JAVA");

JSONObject segmentation = new JSONObject();

segmentation.put("type", "segmentation");
segmentation.put("segmentId", 14098);
segmentation.put("emptyExisitingSegment", false);

JSONObject rules = new JSONObject();
rules.put("ignore", true);

JSONObject duplicate = new JSONObject();
duplicate.put("type", "duplicate");
duplicate.put("rules", rules);

JSONObject report = new JSONObject();
report.put("type", "report");
report.put("sendFinalReport", true);
report.put("sendErrorReport", true);
report.put("contactGuids", ["0123ABC"]);
report.put("groupIds", []);

JSONObject database = new JSONObject();
database.put("type", "database");
database.put("updateExisting", true);
database.put("crushData", false);

JSONArray features = new JSONArray();
features.put(segmentation);
features.put(duplicate);
features.put(report);
features.put(database);

importConfig.put("features", features);
importConfig.put("binding", 1234);

JSONObject response = wrapper.Import(importConfig, filepath);
if (response.getInt("statusCode") != 200) {
  // code
} else {
  // erreur
}
```
