package implementation;

import org.json.JSONObject;
import org.junit.Before;
import org.junit.Test;

import static org.junit.Assert.assertEquals;

public class SegmentTest {

    private Wrapper wrapper;
    private JSONObject segment = new JSONObject("{\n" +
            "'name': 'Segment static (JAVA)',\n" +
            "'description': 'From Driver',\n" +
            "'isTest': true,\n" +
            "'type': 'static',\n" +
            "'expiration': '2026-08-08T12:11:00Z'" +
            "}");

    @Before
    public void setUp() {
        JSONObject config = new JSONObject();

        config.put("xkey", "my_xkey");
        config.put("url", "http://127.0.0.1:8888/");
        wrapper = new Wrapper(config);
    }

    @Test
    public void testCreateSegment() {
        JSONObject response = this.wrapper.createSegment(this.segment);
        assertEquals(response.getInt("statusCode"), 200);
    }
}
