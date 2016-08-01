Info
--

Toute les fonctions renvoient un objet de cette forme:

```csharp
public class NResponse
{
    public HttpStatusCode StatusCode { get; set; }
    public JToken Body { get; set; }
}
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
```csharp
var config = new Dictionary<string, string>();

config["xKey"] = "YOUR XKEY";

Driver driver = new Driver(config);
```

Chaque route est disponible grâce à sa classe associé. Par exemple pour créer une cible:
```csharp
driver.Target.Create(...);
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

```csharp
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

#### Passer la campagne en phase de Test:

```csharp
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

#### Valider la campagne:

```csharp
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

```csharp
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

#### Ajout d'une cible à un ségment:

```csharp
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

## Cible

Méthodes disponibles:
  + `create`
  + `update`
  + `get`
  + `list`
  + `delete`

[Modèle pour cible](../../docs/fr/models.md#Cible)

#### Ajouter une cible:

```csharp
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

#### Mettre à jour une cible:

```csharp
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

#### Envoyer un message à une cible:

```csharp
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

#### Envoyer un message en changeant sont contenus à une cible:

```csharp
String actionId = "XXXXX";
String targetId = "XXXXXX";
MessageModel message = new MessageModel(); // Mettez le JSON ici

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
