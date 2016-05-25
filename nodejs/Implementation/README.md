Usage
--

#### Basics:

Create a driver with a xkey:
```
var Driver = require('./driver.js');

var driver = new Driver({
  xkey: 'your xkey'
});
```

#### Add a Target:

Create a target (or update it if it already exists):
```
var Wrapper = require('./wrapper.js');

var wrapper = new Wrapper({
  xkey: 'your xkey'
});

var target = {
  1234: 'Mr',
  1234: 'Test',
  1234: 'test@test.com',
};

wrapper.createOrModifyTarget(target).then(function(response) {
  // code ...
}).catch(function(error) {
  // error ...
});
```

#### Add a Target and send a message:

Create a target (or update it if it already exist) and send a message to this target:
```
var Wrapper = require('./wrapper.js');

var wrapper = new Wrapper({
  xkey: 'your xkey'
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
  // error ...
});
```

#### Creation of a campaign:

Create a campaign:
```
var Wrapper = require('./wrapper.js');

var wrapper = new Wrapper({
  xkey: 'your xkey'
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
  // error ...
});
```
#### Creation of a segment:

Create a static segment:
```
var Wrapper = require('./wrapper.js');

var wrapper = new Wrapper({
  xkey: 'your xkey'
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
  // error ...
});
```

#### Campaign validation:

Validate a campaign (require the campaign ID):

```
var Wrapper = require('./wrapper.js');

var wrapper = new Wrapper({
  xkey: 'your xkey'
});
var campaignId = 1234;

wrapper.validateCampaign(campaignId).then(function(response) {
  // code ...
}).catch(function(error) {
  // error ...
});
```

### Target creation, then add it to a segment

Create a target (or update it if it already exist), and then add it to the segment:

```
var Wrapper = require('./wrapper.js');

var wrapper = new Wrapper({
  xkey: 'your xkey'
});
var segmentId = 1234;

var target = {
  'civility': 'Mr',
  'firstname': 'Test',
  'email': 'test@test.com',
};

wrapper.createTargetAndAddToSegment(target, segmentId).then(function(response) {
  // code ...
}).catch(function(error) {
  // error ...
});
```

### Campaign creation, and then test it

Create a campaign and launch the test phase

```
var Wrapper = require('./wrapper.js');

var wrapper = new Wrapper({
  xkey: 'your xkey'
});

wrapper.createAndTestCampaign(mailCampaign, testconfig).then(function(response) {
  // code ...
}).catch(function(error) {
  // error ...
});
```

### Import

Launch manual import:
```
var Wrapper = require('./wrapper.js');

var wrapper = new Wrapper({
  xkey: 'your xkey'
});

wrapper.import(importConfig, filepath).then(function(response) {
  // code ...
}).catch(function(error) {
  // error ...
});
```
