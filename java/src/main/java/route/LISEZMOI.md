Info
--

Toute les fonctions renvoient un objet de cette forme:

```java
JSONObject response = new JSONObject();

response.put("statusCode", connection.getResponseCode());
response.put("body", result);
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
```java
JSONObject config = new JSONObject();

config.put("xkey", "YOUR XKEY");

Driver driver = new Driver(config);
```

Chaque route est disponible grâce à sa classe associé. Par exemple pour créer une cible:
```java
driver.target.create(...);
```

Voici la liste des routes disponibles
  + `action`
  + `field`
  + `segment`
  + `target`

[Tout les modèles sont disponible ici](../../../../../docs/fr/models.md)

## Action

Méthodes disponibles:
  + `create`
  + `update`
  + `get`
  + `list`
  + `delete`
  + `test`
  + `validate`

[Modèle pour action](../../../../../docs/fr/models.md#Action)

#### Création de campagne:

```java
JSONObject response = driver.action.create(campaign);
if (response.getInt("statusCode") != 200) {
  // code
} else {
  // error
}
```

#### Passer la campagne en phase de Test:

```java
JSONObject response = driver.action.test(campaignId, testObject);
if (response.getInt("statusCode") != 200) {
  // code
} else {
  // error
}
```

#### Valider la campagne:

```java
JSONObject response = driver.action.validate(campaignId, validateObject);
if (response.getInt("statusCode") != 204) {
  // code
} else {
  // error
}
```

## Champ

Méthodes disponibles:
  + `list`

[Modèle pour champ](../../../../../docs/fr/models.md#Champs)

## Segment

Méthodes disponibles:
  + `create`
  + `update`
  + `get`
  + `list`
  + `delete`

[Modèle pour segment](../../../../../docs/fr/models.md#Segment)

#### Création d'un ségment statique:

```java
JSONObject response = driver.segment.create(segment);
if (response.getInt("statusCode") != 200) {
  // code
} else {
  // error
}
```

#### Ajout d'une cible à un ségment:

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

## Cible

Méthodes disponibles:
  + `create`
  + `update`
  + `get`
  + `list`
  + `delete`

[Modèle pour cible](../../../../../docs/fr/models.md#Cible)

#### Ajouter une cible:

```java
JSONObject response = driver.target.create(target);
if (response.getInt("statusCode") != 200) {
  // code
} else {
  // error
}
```

#### Mettre à jour une cible:

```java
JSONObject response = driver.target.update(id, targetUpdate);
if (response.getInt("statusCode") != 200) {
  // code
} else {
  // error
}
```

#### Envoyer un message à une cible:

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

#### Envoyer un message en changeant sont contenus à une cible:

```java
String actionId = "XXXXX";
String targetId = "XXXXXX";
JSONObject message = new JSONObject("{ }"); // Mettez le JSON ici

JSONObject response = driver.send.message(actionId, targetId, message);
if (response.getInt("statusCode") != 204) {
  // code
} else {
  // error
}
```
