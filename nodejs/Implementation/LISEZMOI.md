Utilisation
--

#### Base:

Créer un driver avec une xkey:
```
var Driver = require('./driver.js');

var driver = new Driver({
  xkey: 'votre xkey'
});
```

#### Ajouter une cible:

Créer une cible (ou la mettre à jour si elle existe déjà):
```
var Wrapper = require('./wrapper.js');

var wrapper = new Wrapper({
  xkey: 'votre xkey'
});

var target = {
  1234: 'Mr',
  1234: 'Test',
  1234: 'test@test.com',
};

wrapper.createOrModifyTarget(target).then(function(response) {
  // code ...
}).catch(function(error) {
  // erreur ...
});
```

#### Ajouter une cible et envoyer un message:

Créer une cible (ou la mettre à jour si elle existe déjà) et envoyer un message à cette cible:
```
var Wrapper = require('./wrapper.js');

var wrapper = new Wrapper({
  xkey: 'votre xkey'
});

var target = {
  1234: 'Mr',
  1234: 'Test',
  1234: 'test@test.com',
};

var actionId = 'XXXXX';

wrapper.addTargetAndSendMessage(target, actionId).then(function(response) {
  // code ...
}).catch(function(error) {
  // erreur ...
});
```

#### Création de campagne:

Créer une campagne:
```
var Wrapper = require('./wrapper.js');

var wrapper = new Wrapper({
  xkey: 'votre xkey'
});

var smsCampaign = {
  type: 'smsCampaign',
  name: 'SMSCampaignFromApi (nodeJS)',
  description: 'SMSCampaignFromApi (nodeJS)',
  informations: {
    folder: null,
    category: null
  },
  scheduler: {type: 'asap'},
  content: {textContent: 'Text message / max 160'}
};

wrapper.createCampaign(smsCampaign).then(function(response) {
  // code ...
}).catch(function(error) {
  // erreur ...
});
```

#### Création de segment:

Créer un segment statique:
```
var Wrapper = require('./wrapper.js');

var wrapper = new Wrapper({
  xkey: 'votre xkey'
});

var segment = {
  name: 'My lovely segment',
  description: 'This is my first segment',
  type: 'static',
  expiration: '2026-08-08T12:11:00Z',
  isTest: true
};

wrapper.createSegment(segment).then(function(response) {
  // code ...
}).catch(function(error) {
  // erreur ...
});
```

#### Validation de campagne:

Valider une campagne (requiert de connaitre son ID):
```
var Wrapper = require('./wrapper.js');

var wrapper = new Wrapper({
  xkey: 'votre xkey'
});
var campaignId = 1234;

wrapper.validateCampaign(campaignId).then(function(response) {
  // code ...
}).catch(function(error) {
  // erreur ...
});
```

### Création d'une cible, puis l'ajoute à un segment

Créer une cible (ou la mettre à jour si elle existe déjà), puis l'ajoute à un segment:
```
var Wrapper = require('./wrapper.js');

var wrapper = new Wrapper({
  xkey: 'votre xkey'
});
var segmentId = 1234;

var target = {
  'civilité': 'Mr',
  'prénom': 'Test',
  'email': 'test@test.com',
};

wrapper.createTargetAndAddToSegment(target, segmentId).then(function(response) {
  // code ...
}).catch(function(error) {
  // erreur ...
});
```

### Création d'une campagne, puis lancement de la phase de test

Créer une campagne puis lancer la phase de test:
```
var Wrapper = require('./wrapper.js');

var wrapper = new Wrapper({
  xkey: 'votre xkey'
});

wrapper.createAndTestCampaign(mailCampaign, testconfig).then(function(response) {
  // code ...
}).catch(function(error) {
  // erreur ...
});
```

### Import

Lancer un import manuel:
```
var Wrapper = require('./wrapper.js');

var wrapper = new Wrapper({
  xkey: 'votre xkey'
});

wrapper.import(importConfig, filepath).then(function(response) {
  // code ...
}).catch(function(error) {
  // erreur ...
});
```
