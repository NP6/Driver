package implementation;

import org.json.JSONObject;
import org.junit.Before;
import org.junit.Test;

import java.io.IOException;

import static org.junit.Assert.assertEquals;

public class TargetTest {

    private Wrapper wrapper;
    private JSONObject target = new JSONObject("{\n" +
            "'civilité': 'Mr',\n" +
            "8630: 'Doe',\n" +
            "8628: 'test@test.com'\n" +
            "}");
    private String segmentId = "14091";
    private String actionId = "000QF0";

    @Before
    public void setUp() {
        JSONObject config = new JSONObject();

        config.put("xkey", "my_xkey");
        config.put("url", "http://127.0.0.1:8888/");
        wrapper = new Wrapper(config);
    }

    @Test
    public void testCreateOrModifyTarget() {
        JSONObject response = this.wrapper.createOrModifyTarget(this.target);
        assertEquals(response.getInt("statusCode"), 200);
    }

    @Test
    public void testCreateTargetAndAddToSegment() {
        JSONObject response = this.wrapper.createTargetAndAddToSegment(this.target, this.segmentId);
        assertEquals(response.getInt("statusCode"), 204);
    }

    @Test
    public void testAddTargetAndSendMessage() {
        JSONObject response = this.wrapper.addTargetAndSendMessage(target, actionId);
        assertEquals(response.getInt("statusCode"), 204);
    }
}
