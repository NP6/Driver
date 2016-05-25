## Modèles

### Sommaire

1. [Action](#Action)
  1. [Campagne mail](#Campagne mail)
  1. [Campagne SMS](#Campagne SMS)
  1. [Message mail](#Message mail)
  1. [Message SMS](#Message SMS)
  1. [Test](#Test)
  1. [Validation](#Validation)
1. [Champs](#Champs)
1. [Message](#Message)
1. [Segment](#Segment)
1. [Cible](#Cible)

## Action

### Campagne mail
```
{
  type: 'mailCampaign',
  name: 'nom de la campagne',
  description: 'description de la campaign',
  scheduler: {
    segments: {
      selected: []
    },
    type: 'asap'
  },
  content: {
    text: 'Message text',
    html: 'Message HTML',
    subject: 'Sujet du message',
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
### Campagne SMS
```
{
  type: 'smsCampaign',
  name: 'nom de la campagne',
  description: 'description de la campagne',
  informations: {
    folder: null,
    category: null
  },
  scheduler: {type: 'asap'},
  content: {textContent: 'Message / max 160'}
}
```
### Message mail
```
{
  type: 'mailMessage',
  name: 'nom du message',
  description: 'description du message',
  content: {
    text: 'Message text',
    html: 'Message HTML',
    subject: 'Sujet du message',
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
### Message SMS
```
{
  type: 'smsMessage',
  name: 'nom du message',
  description: 'description du message',
  informations: {
    folder: null,
    category: null
  },
  content: {textContent: 'Message / max 160'}
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
### Validation
```
{
  fortest: false,
  campaignAnalyser: false,
  testSegments: null,
  mediaForTest: null,
}
```

## Champs
```
{
  'type': 'type du champs',
  'name': 'nom du champ',
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
    html:	'Message HTML',
    text:	'Message text'
  },
  header: {
    subject: 'sujet du message',
    mailFrom:	'mail@address.com',
    replyTo: 'mail@return.com'
  }
}
```
## Segment
```
{
  name: 'nom du segment',
  description: 'sdescription du segment',
  isTest: true,
  type: 'type de segment',
  expiration: '2026-08-08T12:11:00Z'
}
```
## Cible
```
{
  1234: 'Mr',
  1234: 'Test',
  1234: 'test@test.com',
}
```

Note: Si vous utilisez le `Wrapper` vous pouvez utiliser les cibles de la manière suivante
```
{
  'civilité': 'Mr',
  'nom': 'Test',
  'email': 'test@test.com',
}
```
