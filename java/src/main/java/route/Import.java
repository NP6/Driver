package route;

import org.apache.commons.io.FilenameUtils;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;

public class Import {

    private Connection _connection;
    private String _route;

    /**
     * Constructor
     *
     * @param connection    class that help to request API
     */
    public Import(Connection connection) {
        this._connection = connection;
        this._route = "imports/";
    }

    /**
     * Create an import
     *
     * @param importJson    Import you want to create
     * @return              Response
     */
    public JSONObject create(JSONObject importJson) {
        if (importJson == null) {
            throw new IllegalArgumentException("Null parameter");
        }

        return this._connection.request(this._route, "POST", importJson);
    }

    /**
     * Execute an import
     *
     * @param id            Id of the import you want to execute
     * @param filePath      File path that you'll import
     * @return              Response
     * @throws FileNotFoundException
     */
    public JSONObject execute(String id, String filePath) throws FileNotFoundException {
        Boolean valid = false;
        String[] validExt = {
                "txt",
                "csv",
                "zip",
                "tar.gz",
                "tgz",
                "gz"
        };
        String fileExt = FilenameUtils.getExtension(filePath);
        if (id == null || filePath == null) {
            throw new IllegalArgumentException("Null parameter");
        }

        for (String ext:validExt) {
            if (ext.equals(fileExt)) {
                valid = true;
            }
        }

        if (!valid)
        {
            throw new IllegalArgumentException("Wrong type of file");
        }

        BufferedReader br = new BufferedReader(new FileReader(filePath));
        String sCurrentLine;
        String fileContent = "";

        try {
            while ((sCurrentLine = br.readLine()) != null) {
                fileContent += sCurrentLine + "\n";
            }
        } catch (IOException e) {
            throw new IllegalStateException("Unable to read file: " + e);
        } finally {
            Utils.close(br);
        }

        JSONObject importJson = new JSONObject();

        importJson.put("filename", "toto.csv");
        importJson.put("fileContent", fileContent);

        String routeUrl = this._route + id + "/executions";

        return this._connection.request(routeUrl, "POST", importJson, true);
    }

    /**
     * Get an import
     *
     * @param       id Id of the import you want to get
     * @return      Response
     */
    public JSONObject get(String id) {
        if (id == null) {
            throw new IllegalArgumentException("Parameter is null");
        }

        return this._connection.request(this._route + id, "GET");
    }

    /**
     * List all import
     *
     * @return      Response
     */
    public JSONObject list() {
        return this._connection.request(this._route, "GET");
    }

    /**
     * Delete an import
     *
     * @param id    Import's id
     * @return      Response
     */
    public JSONObject delete(String id) {
        if (id == null) {
            throw new IllegalArgumentException("Null parameter");
        }

        return this._connection.request(this._route, "DELETE");
    }
}
