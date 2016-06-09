package route;

import org.json.JSONObject;

public class Segment {

    private Connection _connection;
    private String _route;

    /**
     * Constructor
     *
     * @param connection    class that help to request API
     */
    public Segment(Connection connection) {
        this._connection = connection;
        this._route = "segments/";
    }

    /**
     * Create a segment
     *
     * @param segment   Target you want to create
     * @return          Response
     */
    public JSONObject create(JSONObject segment) {
        if (segment == null) {
            throw new IllegalArgumentException("Parameter is null");
        }

        return this._connection.request(this._route, "POST", segment);
    }

    /**
     * Update a target
     *
     * @param id        Target's id
     * @param segment   Target you want to update
     * @return          Response
     */
    public JSONObject update(String id, JSONObject segment) {
        if (segment == null) {
            throw new IllegalArgumentException("Parameter is null");
        }

        return this._connection.request(this._route + id, "PUT", segment);
    }

    /**
     * Get a target
     *
     * @param id    Target's id
     * @return      Response
     */
    public JSONObject get(String id) {
        if (id == null) {
            throw new IllegalArgumentException("Parameter is null");
        }

        return this._connection.request(this._route + id, "GET");
    }

    /**
     * List all segment
     *
     * @return      Response
     */
    public JSONObject list() {
        return this._connection.request(this._route, "GET");
    }

    /**
     * Delete a segment
     * @param id    Target's id
     * @return      Response
     */
    public JSONObject delete(String id) {
        if (id == null) {
            throw new IllegalArgumentException("Parameter is null");
        }

        return this._connection.request(this._route + id, "DELETE");
    }

    /**
     * Add a target to a segment
     *
     * @param segmentId     Segment's id
     * @param targetId      Target's id
     * @return              Response
     */
    public JSONObject addToSegment(String segmentId, String targetId) {
        if (segmentId == null || targetId == null) {
            throw new IllegalArgumentException("Parameter is null");
        }

        return this._connection.request("targets/" + targetId + "/segments/" + segmentId, "POST");
    }

    /**
     * Remove a target from a segment
     *
     * @param segmentId     Segment's id
     * @param targetId      Target's id
     * @return              Response
     */
    public JSONObject remove(String segmentId, String targetId) {
        if (segmentId == null || targetId == null) {
            throw new IllegalArgumentException("Parameter is null");
        }

        return this._connection.request("targets/" + targetId + "/segments/" + segmentId, "DELETE");
    }
}
