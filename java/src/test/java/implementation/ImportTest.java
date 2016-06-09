package implementation;

import org.json.JSONObject;
import org.junit.Before;
import org.junit.Test;

import java.io.File;
import java.io.IOException;

import static org.junit.Assert.assertEquals;

public class ImportTest {

    private Wrapper wrapper;
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

    private String path = "../assets/import.csv";

    @Before
    public void setUp() {
        JSONObject config = new JSONObject();

        config.put("xkey", "my_xkey");
        config.put("url", "http://127.0.0.1:8888/");
        wrapper = new Wrapper(config);
    }
    
    @Test
    public void testImport() throws Exception {
        JSONObject response = this.wrapper.Import(this.importJson, this.path);
        assertEquals(response.getInt("statusCode"), 200);
    }
}