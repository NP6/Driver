package route;

import org.json.JSONObject;

public class Field {

    private Connection _connection;
    private String _route;

    /**
     * Constructor
     *
     * @param connection    class that help to request API
     */
    public Field(Connection connection) {
        this._connection = connection;
        this._route = "fields/";
    }

    /**
     * List all fields
     *
     * @return      Response
     */
    public JSONObject list() {
        return this._connection.request(this._route, "GET");
    }
}
