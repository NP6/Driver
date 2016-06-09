package route;

import org.json.JSONObject;
import org.junit.Test;

import static org.junit.Assert.assertEquals;

public class DriverTest {

    private Driver driver;

    @Test
    public void testConstuctor() {
        JSONObject config = new JSONObject();

        config.put("xkey", "my_xkey");
        config.put("url", "my_url");
        this.driver = new Driver(config);
        assertEquals(this.driver.getXKey(), "my_xkey");
        assertEquals(this.driver.getUrl(), "my_url");
    }

    @Test
    public void testBadDriver() {
        JSONObject config = new JSONObject();

        config.put("xkey", "my_xkey");
        config.put("url", "http://thats-a.badurl");
        this.driver = new Driver(config);
        JSONObject response = driver.target.list();
        assertEquals(response.getInt("statusCode"), 400);
    }
}