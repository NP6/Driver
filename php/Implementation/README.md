Usage
--

#### Basics:

Create a driver with a xkey:
```php
$driver = new Driver([
    'xkey'  => 'your xkey'
  ]);
```

#### Add a Target:

Create a target (or update it if it already exists):
```php
$wrapper = new Wrapper([
    'xkey'  => 'your xkey'
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
  // error
}
```

#### Add a Target and send a message:

Create a target (or update it if it already exist) and send a message to this target:
```php
$wrapper = new Wrapper([
    'xkey'  => 'your xkey'
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
  // error
}
```

#### Creation of a campaign:

Create a campaign:
```php
$wrapper = new Wrapper([
    'xkey'  => 'your xkey'
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
  // error
}
```
#### Creation of a segment:

Create a static segment:
```php
$wrapper = new Wrapper([
    'xkey'  => 'your xkey'
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
  // error
}
```

#### Campaign validation:

Validate a campaign (require the campaign ID):

```php
$wrapper = new Wrapper([
    'xkey'  => 'your xkey'
  ]);
$campaignId = 1234;

$response = $wrapper->validateCampaign(campaignId);
if ($response['statusCode'] == 200) {
  // code ...
} else {
  // error
}
```

### Target creation, then add it to a segment

Create a target (or update it if it already exist), and then add it to the segment:

```php
$wrapper = new Wrapper([
    'xkey' => 'your xkey'
  ]);
$segmentId = 1234;

$target = [
  'civility'  => 'Mr',
  'firstname' => 'Test',
  'email'     => 'test@test.com',
];

$response = $wrapper->createTargetAndAddToSegment(target, segmentId);
if ($response['statusCode'] == 200) {
  // code ...
} else {
  // error
}
```

### Campaign creation, and then test it

Create a campaign and launch the test phase

```php
$wrapper = new Wrapper([
    'xkey'  => 'your xkey'
  ]);
$response = $wrapper->createAndTestCampaign(mailCampaign, testconfig);
if ($response['statusCode'] == 200) {
  // code ...
} else {
  // error
}
```

### Import

Launch manual import:
```php
$wrapper = new Wrapper([
    'xkey'  => 'your xkey'
  ]);

$response = $wrapper->import(importConfig, filepath);
if ($response['statusCode'] == 200) {
  // code ...
} else {
  // error
}
```
