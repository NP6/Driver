Info
--

Toute les fonctions renvoient un objet de cette forme:

```javascript
var response = {
  statusCode: httpResponse.statusCode,
  body: JSON.parse(body)
};
```

Où `statusCode` est le code HTTP de la réponse et `body` est un objet contenant la réponse de la requête.

## Table of Contents

  1. [Base](#Basics)
  1. [Action](#Action)
  1. [Champ](#Champ)
  1. [Segment](#Segment)
  1. [Cible](#Cible)

## Base:

Créer un driver avec une xkey:
```javascript
var Driver = require('./driver.js');

var driver = new Driver("my_xkey");
```

Chaque route est disponible grâce à sa classe associé. Par exemple pour créer une cible:
```javascript
driver.target.create(...);
```

Voici la liste des routes disponibles
  + `action`
  + `field`
  + `segment`
  + `target`

[Tout les modèles sont disponible ici](../../docs/fr/models.md)

## Action

Méthodes disponibles:
  + `create`
  + `update`
  + `get`
  + `list`
  + `delete`
  + `test`
  + `validate`

[Modèle pour action](../../docs/fr/models.md#Action)

#### Création de campagne:

```javascript
driver.action.create(smsCampaign).then(function(response) {
  // code ...
}).catch(function(error) {
  // erreur ...
});
```

#### Passer la campagne en phase de Test:

```javascript
driver.action.test(campaignId, testObject).then(function(response) {
  // code ...
}).catch(function(error) {
  // erreur ...
});
```

#### Valider la campagne:

```javascript
driver.action.validate(campaignId, validateObject).then(function(response) {
  // code ...
}).catch(function(error) {
  // erreur ...
});
```

## Champ

Méthodes disponibles:
  + `list`

[Modèle pour champ](../../docs/fr/models.md#Champs)

## Segment

Méthodes disponibles:
  + `create`
  + `update`
  + `get`
  + `list`
  + `delete`

[Modèle pour segment](../../docs/fr/models.md#Segment)

#### Création d'un ségment statique:

```javascript
driver.segment.create(segment).then(function(response) {
  // code ...
}).catch(function(error) {
  // erreur ...
});
```

#### Ajout d'une cible à un ségment:

```javascript
var targetId = 'XXXXXX';
var segmentId = 'XXXXXX';

driver.segment.addToSegment(targetId, segmentId).then(function(response) {
  // code ...
}).catch(function(error) {
  // erreur ...
});
```

## Cible

Méthodes disponibles:
  + `create`
  + `update`
  + `get`
  + `list`
  + `delete`

[Modèle pour cible](../../docs/fr/models.md#Cible)

#### Ajouter une cible:

```javascript
driver.target.create(target).then(function(response) {
  // code ...
}).catch(function(error) {
  // erreur ...
});
```

#### Mettre à jour une cible:

```javascript
driver.target.update(targetId, target).then(function(response) {
  // code ...
}).catch(function(error) {
  // erreur ...
});
```

#### Envoyer un message à une cible:

```javascript
var actionId = 'XXXXX';
var targetId = 'XXXXXX';

driver.send.message(actionId, targetId).then(function(response) {
  // code ...
}).catch(function(error) {
  // erreur ...
});
```

#### Envoyer un message en changeant sont contenus à une cible:

```javascript
var actionId = 'XXXXX';
var targetId = 'XXXXXX';

driver.send.message(actionId, targetId, messageContent).then(function(response) {
  // code ...
}).catch(function(error) {
  // erreur ...
});
```
