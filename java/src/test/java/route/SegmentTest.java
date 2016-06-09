package route;

import org.json.JSONObject;
import org.junit.Before;
import org.junit.Test;

import static org.junit.Assert.assertEquals;

public class SegmentTest {

    private Driver driver;
    private JSONObject segment = new JSONObject("{'name': 'Segment static (JAVA)',\n" +
            "'description': 'From Driver',\n" +
            "'isTest': true,\n" +
            "'type': 'static',\n" +
            "'expiration': '2026-08-08T12:11:00Z'}");
    private JSONObject segmentUpdate = new JSONObject("{'name': 'Segment static (JAVA)',\n" +
            "'description': 'From Driver UPDATED',\n" +
            "'isTest': true,\n" +
            "'type': 'static',\n" +
            "'expiration': '2026-08-08T12:11:00Z'}");
    private String id = "15890";
    private String targetId = "000OGLYL";

    @Before
    public void setUp() {
        JSONObject config = new JSONObject();

        config.put("xkey", "my_xkey");
        config.put("url", "http://127.0.0.1:8888/");
        driver = new Driver(config);
    }

    @Test
    public void testCreate() {
        JSONObject response = this.driver.segment.create(this.segment);
        assertEquals(response.getInt("statusCode"), 200);
    }

    @Test
    public void testUpdate() {
        JSONObject response = this.driver.segment.update(this.id, this.segmentUpdate);
        assertEquals(response.getInt("statusCode"), 200);
    }

    @Test
    public void testGet() {
        JSONObject response = this.driver.segment.get(this.id);
        assertEquals(response.getInt("statusCode"), 200);
    }

    @Test
    public void testList() {
        JSONObject response = this.driver.segment.list();
        assertEquals(response.getInt("statusCode"), 200);
    }

    @Test
    public void testAddTarget() {
        JSONObject response = this.driver.segment.addToSegment(this.id, this.targetId);
        assertEquals(response.getInt("statusCode"), 204);
    }

    @Test
    public void testRemoveTarget() {
        JSONObject response = this.driver.segment.remove(this.id, this.targetId);
        assertEquals(response.getInt("statusCode"), 204);
    }

    @Test
    public void testDelete() {
        JSONObject response = this.driver.segment.delete(this.id);
        assertEquals(response.getInt("statusCode"), 204);
    }
}
