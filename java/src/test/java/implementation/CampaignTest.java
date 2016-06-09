package implementation;

import static org.junit.Assert.*;
import org.json.JSONObject;
import org.junit.Before;
import org.junit.Test;

public class CampaignTest {

    private Wrapper wrapper;
    private JSONObject mailCampaign = new JSONObject("{\n" +
            "  'type': 'mailCampaign',\n" +
            "  'description': 'MailCampaignFromApi (JAVA)',\n" +
            "  'scheduler': {\n" +
            "    'segments': {\n" +
            "      'selected': [14105]\n" +
            "    },\n" +
            "    'type': 'asap'\n" +
            "  },\n" +
            "  'name': 'MailCampaignFromApi (JAVA)',\n" +
            "  'content': {\n" +
            "    'text': 'Text message',\n" +
            "    'html': 'Html messag',\n" +
            "    'subject': 'Subject of the message',\n" +
            "    'headers': {\n" +
            "      'from': {\n" +
            "        'label': 'label',\n" +
            "        'prefix': 'prefix'\n" +
            "      },\n" +
            "      'reply': 'address@reply.com'\n" +
            "    }\n" +
            "  },\n" +
            "  'informations': {\n" +
            "    'folder': null,\n" +
            "   'category': null\n" +
            "  }\n" +
            "}");
    private JSONObject testConfig = new JSONObject("{\n" +
            "'fortest': true,\n" +
            "'campaignAnalyser': false,\n" +
            "'testSegments': [14091],\n" +
            "'mediaForTest': null,\n" +
            "'textandHtml': false,\n" +
            "'comments': null\n" +
            "}");
    private JSONObject validateConfig = new JSONObject("{\n" +
            "'fortest': false,\n" +
            "'campaignAnalyser': false,\n" +
            "'testSegments': null,\n" +
            "'mediaForTest': null,\n" +
            "'textandHtml': false,\n" +
            "'comments': null\n" +
            "}");
    private String mailCampaignId = "000QEU";

    @Before
    public void setUp() {
        JSONObject config = new JSONObject();

        config.put("xkey", "my_xkey");
        config.put("url", "http://127.0.0.1:8888/");
        wrapper = new Wrapper(config);
    }

    @Test
    public void testCreateCampaign() {
        JSONObject response = this.wrapper.createCampaign(this.mailCampaign);
        assertEquals(response.getInt("statusCode"), 200);
    }

    @Test
    public void testCreateCampaignFail() {
        try {
            JSONObject response = this.wrapper.createCampaign(null);
        } catch (IllegalArgumentException e) {
            assertEquals(e.getMessage(), "Parameter is null");
        }
    }

    @Test
    public void testCreateAndTestCampaign() {
        JSONObject response = this.wrapper.createAndTestCampaign(this.mailCampaign, this.testConfig);
        assertEquals(response.getInt("statusCode"), 204);
        assertEquals(response.getJSONObject("body").getString("id"), "000QEU");
    }

    @Test
    public void testValidateCampaign() {
        JSONObject response = this.wrapper.validateCampaign(this.mailCampaignId, this.validateConfig);
        assertEquals(response.getInt("statusCode"), 204);
    }
}
