package route;

import org.json.JSONObject;

/**
 * Class to manage the route /targets
 */
public class Target {

    private Connection _connection;
    private String _route;

    /**
     * Constructor
     *
     * @param connection    class that help to request API
     */
    public Target(Connection connection) {
        this._connection = connection;
        this._route = "targets/";
    }

    /**
     * Create a target
     *
     * @param target    Target you want to create
     * @return          Response
     */
    public JSONObject create(JSONObject target) {
        if (target == null) {
            throw new IllegalArgumentException("Parameter is null");
        }

        return this._connection.request(this._route, "POST", target);
    }

    /**
     * Update a target
     *
     * @param id        Target's id
     * @param target    Target you want to update
     * @return          Response
     */
    public JSONObject update(String id, JSONObject target) {
        if (target == null) {
            throw new IllegalArgumentException("Parameter is null");
        }

        return this._connection.request(this._route + id, "PUT", target);
    }

    /**
     * Get a target
     *
     * @param id        Target's id
     * @return          Response
     */
    public JSONObject get(String id) {
        if (id == null) {
            throw new IllegalArgumentException("Parameter is null");
        }

        return this._connection.request(this._route + id, "GET");
    }

    /**
     * List all targets
     *
     * @return          Response
     */
    public JSONObject list() {
        return this._connection.request(this._route, "GET");
    }

    /**
     * Delete a target
     *
     * @param id        Target's id
     * @return          Response
     */
    public JSONObject delete(String id) {
        if (id == null) {
            throw new IllegalArgumentException("Parameter is null");
        }

        return this._connection.request(this._route + id, "DELETE");
    }

    /**
     * Find a target thanks to its unicity
     *
     * @param unicity   Target's unicity
     * @return          Response
     */
    public JSONObject find(String unicity) {
        if (unicity == null) {
            throw new IllegalArgumentException("Parameter is null");
        }

        return this._connection.request("targets?unicity=" + unicity, "GET");
    }
}
