Info
--

Toute les fonctions renvoient un objet de cette forme:

```php
$response = [
  statusCode  => httpResponse.statusCode,
  body        => JSON.parse(body)
];
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
```php
$driver = new Driver([
    'xkey'  => 'your xKey'
  ]);
```

Chaque route est disponible grâce à sa classe associé. Par exemple pour créer une cible:
```php
$driver->target->create(...);
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

```php
$response = driver->action->create(smsCampaign);
if ($response['statusCode'] == 200) {
  // code
} else {
  // error
}
```

#### Passer la campagne en phase de Test:

```php
$response = driver->action->test(campaignId, testObject);
if ($response['statusCode'] == 204) {
  // code
} else {
  // error
}
```

#### Valider la campagne:

```php
$response = driver->action->validate(campaignId, validateObject);
if ($response['statusCode'] == 200) {
  // code
} else {
  // error
}
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

```php
$response = driver->segment->create(segment);
if ($response['statusCode'] == 200) {
  // code
} else {
  // error
}
```

#### Ajout d'une cible à un ségment:

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

## Cible

Méthodes disponibles:
  + `create`
  + `update`
  + `get`
  + `list`
  + `delete`

[Modèle pour cible](../../docs/fr/models.md#Cible)

#### Ajouter une cible:

```php
$response = driver->target->create(target);
if ($response['statusCode'] == 200) {
  // code
} else {
  // error
}
```

#### Mettre à jour une cible:

```php
$response = driver->target->update(target);
if ($response['statusCode'] == 200) {
  // code
} else {
  // error
}
```

#### Envoyer un message à une cible:

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

#### Envoyer un message en changeant sont contenus à une cible:

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
