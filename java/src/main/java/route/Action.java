package route;

import org.json.JSONObject;

public class Action {

    private Connection _connection;
    private String _route;

    /**
     * Constructor
     *
     * @param connection    class that help to request API
     */
    public Action(Connection connection) {
        this._connection = connection;
        this._route = "actions/";
    }

    /**
     * Create an action
     *
     * @param action    Action you want to create
     * @return          Response
     */
    public JSONObject create(JSONObject action) {
        if (action == null) {
            throw new IllegalArgumentException("Parameter is null");
        }

        return this._connection.request(this._route, "POST", action);
    }

    /**
     * Update an action
     *
     * @param id        Action's id
     * @param action    Action you want to update
     * @return          Response
     */
    public JSONObject update(String id, JSONObject action) {
        if (action == null) {
            throw new IllegalArgumentException("Parameter is null");
        }

        return this._connection.request(this._route + id, "PUT", action);
    }

    /**
     * Get an action
     *
     * @param id    Action's id
     * @return      Response
     */
    public JSONObject get(String id) {
        if (id == null) {
            throw new IllegalArgumentException("Parameter is null");
        }

        return this._connection.request(this._route + id, "GET");
    }

    /**
     * List all actions
     *
     * @return      Response
     */
    public JSONObject list() {
        return this._connection.request(this._route, "GET");
    }

    /**
     * Delete an action
     *
     * @param id    Action's id
     * @return      Response
     */
    public JSONObject delete(String id) {
        if (id == null) {
            throw new IllegalArgumentException("Parameter is null");
        }

        return this._connection.request(this._route + id, "DELETE");
    }

    /**
     * Validate an action
     *
     * @param actionId      Action's id
     * @param validation    Parameters for validation
     * @return              Response
     */
    public JSONObject validate(String actionId, JSONObject validation) {
        if (actionId == null || validation == null) {
            throw new IllegalArgumentException("Parameter is null");
        }

        return this._connection.request(this._route + actionId + "/validation", "POST", validation);
    }

    /**
     * Test an action
     *
     * @param actionId      Action's id
     * @param test          Parameters for test
     * @return              Response
     */
    public JSONObject test(String actionId, JSONObject test) {
        if (actionId == null || test == null) {
            throw new IllegalArgumentException("Parameter is null");
        }

        return this._connection.request(this._route + actionId + "/validation", "POST", test);
    }
}
