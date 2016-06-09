package route;

import static org.junit.Assert.*;
import org.json.JSONObject;
import org.junit.Before;
import org.junit.Test;

public class ActionTest {

    private Driver driver;
    private JSONObject smsMessage = new JSONObject("{\n" +
            "'type': 'smsMessage',\n" +
            "'name': 'SMSMessage (JAVA)',\n" +
            "'description': 'SMSMessage (JAVA)',\n" +
            "'informations': {'folder': null, 'category': null},\n" +
            "'content': {'textContent': 'Message text.'},\n" +
            "}");
    private JSONObject smsMessageUpdate = new JSONObject("{\n" +
            "'type': 'smsMessage',\n" +
            "'name': 'SMSMessage (JAVA) Update',\n" +
            "'description': 'SMSMessage (JAVA)',\n" +
            "'informations': {'folder': null, 'category': null},\n" +
            "'content': {'textContent': 'Message text.'},\n" +
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
    private String id = "000TKE";

    @Before
    public void setUp() {
        JSONObject config = new JSONObject();

        config.put("xkey", "my_xkey");
        config.put("url", "http://127.0.0.1:8888/");
        driver = new Driver(config);
    }

    @Test
    public void testCreate() {
        JSONObject response = this.driver.action.create(this.smsMessage);
        assertEquals(response.getInt("statusCode"), 200);
    }

    @Test
    public void testUpdate() {
        JSONObject response = this.driver.action.update(this.id, this.smsMessageUpdate);
        assertEquals(response.getInt("statusCode"), 200);
    }

    @Test
    public void testGet() {
        JSONObject response = this.driver.action.get(this.id);
        assertEquals(response.getInt("statusCode"), 200);
    }

    @Test
    public void testList() {
        JSONObject response = this.driver.action.list();
        assertEquals(response.getInt("statusCode"), 200);
    }

    @Test
    public void testTest() {
        JSONObject response = this.driver.action.test(this.id, this.testConfig);
        assertEquals(response.getInt("statusCode"), 204);
    }

    @Test
    public void testValidate() {
        JSONObject response = this.driver.action.validate(this.id, this.validateConfig);
        assertEquals(response.getInt("statusCode"), 204);
    }

    @Test
    public void testDelete() {
        JSONObject response = this.driver.action.delete(this.id);
        assertEquals(response.getInt("statusCode"), 204);
    }
}
