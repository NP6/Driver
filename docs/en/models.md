## Models

### Table of Contents

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

## Action

### Mail campaign
```
{
  type: 'mailCampaign',
  name: 'campaign's name',
  description: 'campaign's description',
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
```
{
  type: 'smsCampaign',
  name: 'campaign's name',
  description: 'campaign's description',
  informations: {
    folder: null,
    category: null
  },
  scheduler: {type: 'asap'},
  content: {textContent: 'Text message / max 160'}
}
```
### Mail message
```
{
  type: 'mailMessage',
  name: 'message's name',
  description: 'message's description',
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
```
{
  type: 'smsMessage',
  name: 'message's name',
  description: 'message's description',
  informations: {
    folder: null,
    category: null
  },
  content: {textContent: 'Text message / max 160'}
}
```
### Test
```
{
  fortest: true,
  campaignAnalyser: false,
  testSegments: [],
  textandHtml: false,
}
```
### Validate
```
{
  fortest: false,
  campaignAnalyser: false,
  testSegments: null,
  mediaForTest: null,
}
```
## Field
```
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
```
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
```
{
  name: 'segment's name',
  description: 'segment's description',
  isTest: true,
  type: 'segment type',
  expiration: '2026-08-08T12:11:00Z'
}
```
## Target
```
{
  1234: 'Mr',
  1234: 'Test',
  1234: 'test@test.com',
}
```

Note: If you're using the `Wrapper`, you can use target like following
```
{
  'civility': 'Mr',
  'name': 'Test',
  'email': 'test@test.com',
}
```