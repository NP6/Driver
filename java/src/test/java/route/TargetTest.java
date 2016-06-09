package route;

import static org.junit.Assert.*;
import org.json.JSONObject;
import org.junit.Before;
import org.junit.Test;

public class TargetTest {

    private Driver driver;
    private JSONObject target = new JSONObject("{8631: 'Mr'," +
            "8630: 'Test Java'," +
            "8628: 'testJAVA@test.com'}");
    private JSONObject targetUpdate = new JSONObject("{8631: 'Mr'," +
            "8630: 'Test Java Update'," +
            "8628: 'test@test.com'}");
    private String id = "000OG3XX";

    @Before
    public void setUp() {
        JSONObject config = new JSONObject();

        config.put("xkey", "my_xkey");
        config.put("url", "http://127.0.0.1:8888/");
        driver = new Driver(config);
    }

    @Test
    public void testCreate() {
        JSONObject response = this.driver.target.create(this.target);
        assertEquals(response.getInt("statusCode"), 200);
    }

    @Test
    public void testUpdate() {
        JSONObject response = this.driver.target.update(this.id, this.targetUpdate);
        assertEquals(response.getInt("statusCode"), 200);
    }

    @Test
    public void testGet() {
        JSONObject response = this.driver.target.get(this.id);
        assertEquals(response.getInt("statusCode"), 200);
    }

    @Test
    public void testList() {
        JSONObject response = this.driver.target.list();
        assertEquals(response.getInt("statusCode"), 200);
    }

    @Test
    public void testFind() {
        JSONObject response = this.driver.target.find("test@test.com");
        assertEquals(response.getInt("statusCode"), 200);
    }

    @Test
    public void testDelete() {
        JSONObject response = this.driver.target.delete(this.id);
        assertEquals(response.getInt("statusCode"), 204);
    }
}
