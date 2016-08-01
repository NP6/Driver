## Models

### Table of Contents

1. [Reminder](#Reminder)
1. [Action](#Action)
  1. [Mail campaign](#Mail campaign)
  1. [SMS campaign](#SMS campaign)
  1. [Mail message](#Mail message)
  1. [SMS message](#SMS message)
  1. [Test](#Test)
  1. [Validate](#Validate)
1. [Field](#Field)
1. [Message](#Message)
1. [Segment](#Segment)
1. [Target](#Target)

## Reminder

We want to remind you that these models are given to you as it, if you want more precise information on which fields are available go to our [documentation](https://backoffice.mailperformance.com/doc/).

## Action

### Mail campaign
```javascript
{
  type: 'mailCampaign',
  name: 'campaign\'s name',
  description: 'campaign\'s description',
  scheduler: {
    segments: {
      selected: []
    },
    type: 'asap'
  },
  content: {
    text: 'Text message',
    html: 'Html message',
    subject: 'Subject of the message',
    headers: {
      from: {
        label: 'label',
        prefix: 'prefix'
      },
      reply: 'address@reply.com'
    }
  },
  informations: {
    folder: null,
    category: null
  }
}
```
### SMS campaign
```javascript
{
  type: 'smsCampaign',
  name: 'campaign\'s name',
  description: 'campaign\'s description',
  informations: {
    folder: null,
    category: null
  },
  scheduler: {type: 'asap'},
  content: {textContent: 'Text message / max 160'}
}
```
### Mail message
```javascript
{
  type: 'mailMessage',
  name: 'message\'s name',
  description: 'message\'s description',
  content: {
    text: 'Text message',
    html: 'Html message',
    subject: 'Subject of the message',
    headers: {
      from: {
        label: 'label',
        prefix: 'prefix'
      },
      reply: 'address@reply.com'
    }
  },
  informations: {
    folder: null,
    category: null
  }
}
```
### SMS message
```javascript
{
  type: 'smsMessage',
  name: 'message\'s name',
  description: 'message\'s description',
  informations: {
    folder: null,
    category: null
  },
  content: {textContent: 'Text message / max 160'}
}
```
### Test
```javascript
{
  fortest: true,
  campaignAnalyser: false,
  testSegments: [],
  textandHtml: false,
}
```
### Validate
```javascript
{
  fortest: false,
  campaignAnalyser: false,
  testSegments: null,
  mediaForTest: null,
}
```
## Field
```javascript
{
  'type': 'field type',
  'name': 'field name',
  'isUnicity': false,
  'isMandatory': false,
  'constraint': {
    'operator': 1,
    'value': '15'
  }
}
```
## Message
```javascript
{
  content: {
    html:	'html message',
    text:	'text message'
  },
  header: {
    subject: 'subject of the message',
    mailFrom:	'mail@address.com',
    replyTo: 'mail@return.com'
  }
}
```
## Segment
```javascript
{
  name: 'segment\'s name',
  description: 'segment\'s description',
  isTest: true,
  type: 'segment type',
  expiration: '2026-08-08T12:11:00Z'
}
```
## Target
```javascript
{
  1234: 'Mr',
  1234: 'Test',
  1234: 'test@test.com',
}
```

Note: If you're using the `Wrapper`, you can use target like following
```javascript
{
  'civility': 'Mr',
  'name': 'Test',
  'email': 'test@test.com',
}
```
