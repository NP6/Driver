Utilisation
--

#### Base:

Créer un driver avec une xkey:
```php
$driver = new Driver([
    'xkey'  => 'votre xkey'
  ]);
```

#### Ajouter une cible:

Créer une cible (ou la mettre à jour si elle existe déjà):
```php
$wrapper = new Wrapper([
    'xkey'  => 'votre xkey'
  ]);

$target = [
  1234  => 'Mr',
  1234  => 'Test',
  1234  => 'test@test.com',
];

$response = $wrapper->createOrModifyTarget(target);
if ($response['statusCode'] == 200) {
  // code ...
} else {
  // erreur
}
```

#### Ajouter une cible et envoyer un message:

Créer une cible (ou la mettre à jour si elle existe déjà) et envoyer un message à cette cible:
```php
$wrapper = new Wrapper([
    'xkey'  => 'votre xkey'
  ]);

$target = [
  1234  => 'Mr',
  1234  => 'Test',
  1234  => 'test@test.com',
];

$actionId = 'XXXXX';

$response = $wrapper->addTargetAndSendMessage(target, actionId);
if ($response['statusCode'] == 200) {
  // code ...
} else {
  // erreur
}
```

#### Création de campagne:

Créer une campagne:
```php
$wrapper = new Wrapper([
    'xkey'  => 'votre xkey'
  ]);

$smsCampaign = [
  'type'          => 'smsCampaign',
  'name'          => 'SMSCampaignFromApi',
  'description'   => 'SMSCampaignFromApi',
  'informations'  => [
    'folder'    => null,
    'category'  => null
  ],
  'scheduler'     => [
    'type'  => 'asap'
  ],
  'content'       => [
    'textContent' => 'Text message / max 160'
  ]
];

$response = $wrapper->createCampaign(smsCampaign);
if ($response['statusCode'] == 200) {
  // code ...
} else {
  // erreur
}
```

#### Création de segment:

Créer un segment statique:
```php
$wrapper = new Wrapper([
    'xkey'  => 'votre xkey'
  ]);

$segment = [
  'name'        => 'My lovely segment',
  'description' => 'This is my first segment',
  'type'        => 'static',
  'expiration'  => '2026-08-08T12:11:00Z',
  'isTest'      => true
];

$response = $wrapper->createSegment(segment);
if ($response['statusCode'] == 200) {
  // code ...
} else {
  // erreur
}
```

#### Validation de campagne:

Valider une campagne (requiert de connaitre son ID):
```php
$wrapper = new Wrapper([
    'xkey'  => 'votre xkey'
  ]);
$campaignId = 1234;

$response = $wrapper->validateCampaign(campaignId);
if ($response['statusCode'] == 200) {
  // code ...
} else {
  // erreur
}
```

### Création d'une cible, puis l'ajoute à un segment

Créer une cible (ou la mettre à jour si elle existe déjà), puis l'ajoute à un segment:
```php
$wrapper = new Wrapper([
    'xkey' => 'votre xkey'
  ]);
$segmentId = 1234;

$target = [
  'civilité'  => 'Mr',
  'prénom'    => 'Test',
  'email'     => 'test@test.com',
];

$response = $wrapper->createTargetAndAddToSegment(target, segmentId);
if ($response['statusCode'] == 200) {
  // code ...
} else {
  // erreur
}
```

### Création d'une campagne, puis lancement de la phase de test

Créer une campagne puis lancer la phase de test:
```php
$wrapper = new Wrapper([
    'xkey'  => 'votre xkey'
  ]);
$response = $wrapper->createAndTestCampaign(mailCampaign, testconfig);
if ($response['statusCode'] == 200) {
  // code ...
} else {
  // erreur
}
```

### Import

Lancer un import manuel:
```php
$wrapper = new Wrapper([
    'xkey'  => 'votre xkey'
  ]);

$response = $wrapper->import(importConfig, filepath);
if ($response['statusCode'] == 200) {
  // code ...
} else {
  // erreur
}
```
