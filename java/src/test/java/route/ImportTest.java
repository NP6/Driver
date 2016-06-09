package route;

import org.json.JSONObject;
import org.junit.Before;
import org.junit.Test;

import java.io.FileNotFoundException;

import static org.junit.Assert.assertEquals;

public class ImportTest {

    private Driver driver;
    private JSONObject importJson = new JSONObject("{\n" +
            "  'name': 'Manual Import JAVA',\n" +
            "  'features': [{\n" +
            "    'type': 'segmentation',\n" +
            "    'segmentId': 14098,\n" +
            "    'emptyExisitingSegment': false\n" +
            "  }, {\n" +
            "    'type': 'duplicate',\n" +
            "    'rules': {\n" +
            "      'ignore': true\n" +
            "    }\n" +
            "  }, {\n" +
            "    'type': 'report',\n" +
            "    'sendFinalReport': true,\n" +
            "    'sendErrorReport': true,\n" +
            "    'contactGuids': ['044EAE5A'],\n" +
            "    'groupIds': []\n" +
            "  }, {\n" +
            "    'type': 'database',\n" +
            "    'updateExisting': true,\n" +
            "    'crushData': false\n" +
            "  }],\n" +
            "  'binding': 8330\n" +
            "}");
    private String id = "12978";

    @Before
    public void setUp() {
        JSONObject config = new JSONObject();

        config.put("xkey", "my_xkey");
        config.put("url", "http://127.0.0.1:8888/");
        driver = new Driver(config);
    }

    @Test
    public void testCreate() {
        JSONObject response = this.driver.imports.create(this.importJson);
        assertEquals(response.getInt("statusCode"), 200);
    }

    @Test
    public void testExecute() throws FileNotFoundException {
        JSONObject response = this.driver.imports.execute(id, "../assets/import.csv");
        assertEquals(response.getInt("statusCode"), 200);
    }

    @Test
    public void testGet() {
        JSONObject response = this.driver.imports.get(this.id);
        assertEquals(response.getInt("statusCode"), 200);
    }

    @Test
    public void testList() {
        JSONObject response = this.driver.imports.list();
        assertEquals(response.getInt("statusCode"), 200);
    }

}
