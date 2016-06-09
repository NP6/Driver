package route;

import org.json.JSONObject;

public class Send {

    private Connection _connection;
    private String _route;

    /**
     * Constructor
     *
     * @param connection    class that help to request API
     */
    public Send(Connection connection) {
        this._connection = connection;
        this._route = "actions/";
    }

    /**
     * Send a message to a target
     *
     * @param actionId  Action's id
     * @param targetId  Target's id
     * @param content   Custom content for message
     * @return          Response
     */
    public JSONObject message(String actionId, String targetId, JSONObject content) {
        if (actionId == null || targetId == null) {
            throw new IllegalArgumentException("Null parameter");
        }

        return this._connection.request(this._route + actionId + "/targets/" + targetId, "POST", content);
    }

    /**
     * Send a message to a target
     *
     * @param actionId  Action's id
     * @param targetId  Target's id
     * @return          Response
     */
    public JSONObject message(String actionId, String targetId) {
        return message(actionId, targetId, null);
    }
}
