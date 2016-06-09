package route;

import org.json.JSONObject;
import org.junit.Before;
import org.junit.Test;

import static org.junit.Assert.assertEquals;

public class SendTest {

    private Driver driver;
    private JSONObject message = new JSONObject("{" +
            "'content': {\n" +
            "   'html': 'PLEASE REPORT TO SOMEONE IF YOU RECEIVED THIS EMAIL',\n" +
            "   'text': 'PLEASE REPORT TO SOMEONE IF YOU RECEIVED THIS EMAIL'\n" +
            "},\n" +
            "'header': {\n" +
            "   'subject': 'subject of the message',\n" +
            "   'mailFrom': 'mail@address.com',\n" +
            "   'replyTo': 'mail@return.com'\n" +
            "}\n" +
            "}");
    private String messageId = "000QF0";
    private String targetId = "000OG3XW";

    @Before
    public void setUp() {
        JSONObject config = new JSONObject();

        config.put("xkey", "my_xkey");
        config.put("url", "http://127.0.0.1:8888/");
        driver = new Driver(config);
    }

    @Test
    public void testSend() {
        JSONObject response = this.driver.send.message(messageId, targetId);
        assertEquals(response.getInt("statusCode"), 204);
    }

    @Test
    public void testSendWithNewContent() {
        JSONObject response = this.driver.send.message(messageId, targetId, message);
        assertEquals(response.getInt("statusCode"), 204);
    }

}
