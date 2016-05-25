var chai = require('chai');
var assert = require('chai').assert;
var chaiAsPromised = require('chai-as-promised');
var expect = require('chai').expect;
var nock = require('nock');
var Wrapper = require('../Implementation/wrapper.js');

chai.use(chaiAsPromised);

var wrapper = new Wrapper({
  xkey: 'xkey'
});

var mailCampaign = {
  type: 'mailCampaign',
  description: 'MailCampaignFromApi (Nodejs)',
  scheduler: {
    segments: {
      selected: [14105]
    },
    type: 'asap'
  },
  name: 'MailCampaignFromApi (Nodejs)',
  content: {
    text: 'Text message',
    html: 'Html messag',
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
};

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

var testInfo = {
  fortest: true,
  campaignAnalyser: false,
  testSegments: [14091],
  textandHtml: false,
};

var validationInfo = {
    fortest: false,
    campaignAnalyser: false,
    mediaForTest: ''
};

var campaignId = '12AB3';
var nockUrl = nock(wrapper.driver._url);

describe('Wrapper', function() {
  describe('#createCampaign', function() {
    it('should create a Mailcampaign', function() {
      nockUrl.post('/actions/')
      .reply(200, {
        id: '12AB3'
      });

      return wrapper.createCampaign(mailCampaign).then(function(response) {
        expect(response.statusCode).to.equal(200);
        expect(response.body.id).to.equal('12AB3');
      });
    });

    it('should create a SMScampaign', function() {
      nockUrl.post('/actions/')
      .reply(200, {
        id: '12AB3'
      });

      return wrapper.createCampaign(smsCampaign).then(function(response) {
        expect(response.statusCode).to.equal(200);
        expect(response.body.id).to.equal('12AB3');
      });
    });

    it('should create a campaign and test it', function() {
      nockUrl.post('/actions/')
      .reply(200, {
        id: '12AB3'
      });
      nockUrl.post('/actions/12AB3/validation')
      .reply(204);
      
      
      return wrapper.createAndTestCampaign(mailCampaign, testInfo).then(function(response) {
        expect(response.statusCode).to.equal(204);
      });
    });

    it('should fail to create the campaign (no parameter)', function() {
      nockUrl.post('/actions/')
      .reply(400);

      return wrapper.createCampaign().catch(function(error) {
        nock.cleanAll();
        assert(error);
      });
    });

    it('should fail to create the campaign (wrong paramter)', function() {
      nockUrl.post('/actions/')
      .reply(400);

      return wrapper.createCampaign('wrong paramter').catch(function(response) {
        expect(response.statusCode).to.equal(400);
      });
    });

    it('should fail to create the campaign (wrong json)', function() {
      nockUrl.post('/actions/')
      .reply(400);

      return wrapper.createCampaign(mailCampaign).catch(function(response) {
        expect(response.statusCode).to.equal(400);
      });
    });
  });

  describe('#createCampaignAndTestIt', function() {
    it('should send the campaign\'s test phase', function() {
      nockUrl.post('/actions/12AB3/validation')
      .reply(204);

      return wrapper.testCampaign(campaignId, testInfo).then(function(response) {
        expect(response.statusCode).to.equal(204);
      });
    });
  });

  describe('#validateCampaign', function() {
    it('should validate the campaign', function() {
      nockUrl.post('/actions/12AB3/validation')
      .reply(204);
      
      return wrapper.validateCampaign(campaignId).then(function(response) {
        expect(response.statusCode).to.equal(204);
      });
    });

    it('should failed to validate (wrong id)', function() {
      nockUrl.post('/actions/wrong%20id/validation')
      .reply(400);

      return wrapper.validateCampaign('wrong id').catch(function(response) {
        expect(response.statusCode).to.equal(400);
      });
    });

    it('should failed to validate (already validate)', function() {
      nockUrl.post('/actions/12AB3/validation')
      .reply(409);

      return wrapper.validateCampaign(campaignId, validationInfo).catch(function(response) {
        expect(response.statusCode).to.equal(409);
      });
    });

  });
});
