package route;

import org.json.JSONObject;

/**
 *  Driver class that contains all availables routes
 */
public class Driver {

    protected String _xkey;
    protected String _url;
    protected Connection _connection;

    public Segment segment;
    public Action action;
    public Target target;
    public Import imports;
    public Send send;
    public Field field;

    /**
     * Constructor
     *
     * @param config    contains configuration for driver
     * @throws IllegalArgumentException
     */
    public Driver(JSONObject config) throws IllegalArgumentException {
        if (config == null) {
            throw new IllegalArgumentException("Parameter cannot be null");
        }

        this._url = config.has("url") ? config.getString("url") : "http://v8.mailperformance.com/";
        this._xkey = config.getString("xkey");
        this._connection = new Connection(this._xkey, this._url);
        this.segment = new Segment(this._connection);
        this.action = new Action(this._connection);
        this.target = new Target(this._connection);
        this.imports = new Import(this._connection);
        this.send = new Send(this._connection);
        this.field = new Field(this._connection);
    }

    public String getUrl() {
        return this._url;
    }

    public String getXKey() {
        return this._xkey;
    }
}