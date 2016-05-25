var chai = require('chai');
var chaiAsPromised = require('chai-as-promised');
var expect = require('chai').expect;
var assert = require('chai').assert;
var nock = require('nock');
var Wrapper = require('../Implementation/wrapper.js');

chai.use(chaiAsPromised);

var wrapper = new Wrapper({
  xkey: 'xkey'
});

var target = {
  8631: 'Mme',
  'prénom': 'Test Node',
  'email': 'NodeWrapper@test.com',
};

var targetId = '000GLHFF';

var actionId = '000QF0';

var actionContent = {
  content: {
    html:	'html message',
    text:	'text message'
  },
  header: {
    subject: 'subject of the message',
    mailFrom:	'mail@address.com',
    replyTo: 'mail@return.com'
  }
};

var segmentId = '12345';
var nockUrl = nock(wrapper.driver._url);

describe('Wrapper => Target', function() {
  beforeEach(function() {
    nockUrl.get('/targets?unicity=NodeWrapper@test.com')
    .reply(200, {
      id: '000GLHFF'
    });
  });
  
  afterEach(function() {
    nock.cleanAll();
  });
  
  describe('#createOrModifyTarget', function() {    
    it('should fail to create a Target (wrong paramter)', function() {
      nockUrl.post('/targets/')
      .reply(400)
      .put('/targets/000GLHFF')
      .reply(400);

      return wrapper.createOrModifyTarget('wrong parameter').catch(function(error) {
        assert(error);
      });
    });

    it('should fail to create a Target (no parameter)', function() {
      nockUrl.post('/targets/')
      .reply(400)
      .put('/targets/000GLHFF')
      .reply(400);

      return wrapper.createOrModifyTarget().catch(function(error) {
        assert(error);
      });
    });

    it('should create a Target', function() {
      nockUrl.post('/targets/')
      .reply(200, {
        id: '000GLHFF'
      })
      .put('/targets/000GLHFF')
      .reply(200, {
        id: '000GLHFF'
      })
      .get('/fields/')
      .reply(200, [
        {id: 12345, name: 'email', isUnicity: true},
        {id: 23456, name: 'prénom', isUnicity: false},
        {id: 34567, name: 'civilité', isUnicity: false},
      ]);

      return wrapper.createOrModifyTarget(target).then(function(response) {
        expect(response.statusCode).to.equal(200);
        expect(response.body.id).to.equal('000GLHFF');
      });
    });

    it('should update the previous Target and delete it', function() {
      nockUrl.post('/targets/')
      .reply(200, {
        id: '000GLHFF'
      })
      .put('/targets/000GLHFF')
      .reply(200, {
        id: '000GLHFF'
      });

      return wrapper.createOrModifyTarget(target).then(function(response) {
        expect(response.statusCode).to.equal(200);
        expect(response.body.id).to.equal('000GLHFF')
      });
    });
  });

  describe('#addTargetAndSendMessage', function() {
    it('should modify a Target and send a message to it', function() {
      nockUrl.post('/targets/')
      .reply(200, {
        id: '000GLHFF'
      })
      .put('/targets/000GLHFF')
      .reply(200, {
        id: '000GLHFF'
      })
      .post('/actions/000QF0/targets/000GLHFF')
      .reply(204);

      return wrapper.addTargetAndSendMessage(target, actionId).then(function(response) {
        expect(response.statusCode).to.equal(204);
      });
    });

    it('should modify a Target and send a message with a different content to it', function() {
      nockUrl.post('/targets/')
      .reply(200, {
        id: '000GLHFF'
      })
      .put('/targets/000GLHFF')
      .reply(200, {
        id: '000GLHFF'
      })
      .post('/actions/000QF0/targets/000GLHFF')
      .reply(204);
      
      return wrapper.addTargetAndSendMessage(target, actionId, actionContent).then(function(response) {
        expect(response.statusCode).to.equal(204);
      });
    });
  });

  describe('#createTargetAndAddToSegment', function() {
    it('should create a Target and add to the segment', function() {
      nockUrl.post('/targets/')
      .reply(200, {
        id: '000GLHFF'
      })
      .put('/targets/000GLHFF')
      .reply(200, {
        id: '000GLHFF'
      })
      .post('/targets/000GLHFF/segments/12345')
      .reply(204);

      return wrapper.createTargetAndAddToSegment(target, segmentId).then(function(response) {
        expect(response.statusCode).to.equal(204);
      });
    });

    it('sould update the target and add to the segment', function() {
      nockUrl.post('/targets/')
      .reply(200, {
        id: '000GLHFF'
      })
      .put('/targets/000GLHFF')
      .reply(200, {
        id: '000GLHFF'
      })
      .post('/targets/000GLHFF/segments/12345')
      .reply(204);

      return wrapper.createTargetAndAddToSegment(target, segmentId).then(function(response) {
        expect(response.statusCode).to.equal(204);
      });
    });

    it('should update the target but failed to add to the segment (wrong segment id)', function() {
      nockUrl.post('/targets/')
      .reply(200, {
        id: '000GLHFF'
      })
      .put('/targets/000GLHFF')
      .reply(200, {
        id: '000GLHFF'
      })
      .post('/targets/000GLHFF/segments/wrong%20id')
      .reply(599);

      return wrapper.createTargetAndAddToSegment(target, 'wrong id').catch(function(response) {
        expect(response.statusCode).to.equal(599);
      });
    });

  });
});
