package implementation;

import org.json.JSONArray;
import org.json.JSONObject;
import route.Driver;

import java.io.FileNotFoundException;
import java.util.HashMap;
import java.util.Map;

import static route.Utils.isInteger;

public class Wrapper {

    private Driver _driver;
    private Map<String, String> _fields;
    private String _unicity;

    /**
     * Constructor
     *
     * @param config    configuration for the driver
     */
    public Wrapper(JSONObject config) {
        this._driver = new Driver(config);
        this._fields = new HashMap<String, String>();
        this._unicity = null;
    }

    /**
     * Create a segment
     *
     * @param segment   Segment you want to create
     * @return          Response
     */
    public JSONObject createSegment(JSONObject segment) {
        return this._driver.segment.create(segment);
    }

    /**
     * Create a campaign
     *
     * @param action    Action you want to create
     * @return          Response
     */
    public JSONObject createCampaign(JSONObject action) {
        return this._driver.action.create(action);
    }

    /**
     * Create a target or update its value if it already exist
     *
     * @param target    Target you want to create (or update)
     * @return          Response
     */
    public JSONObject createOrModifyTarget(JSONObject target) {
        String unicity = this.getUnicityId();
        JSONObject normalizeTarget = this.normalizeTarget(target);

        JSONObject response = this._driver.target.find(normalizeTarget.getString(unicity));
        if (response.getInt("statusCode") == 404) {
            return this._driver.target.create(normalizeTarget);
        } else if (response.getInt("statusCode") == 200) {
            return this._driver.target.update(response.getJSONObject("body").getString("id"), normalizeTarget);
        }
        return response;
    }

    /**
     * Create a campaign, then test it with giving test options
     *
     * @param campaign      Campaign you want to create
     * @param testOptions   Tests parameters
     * @return              Response
     */
    public JSONObject createAndTestCampaign(JSONObject campaign, JSONObject testOptions) {
        JSONObject response = this._driver.action.create(campaign);

        if (response.getInt("statusCode") != 200)
        {
            return response;
        }
        String campaignId = response.getJSONObject("body").getString("id");
        response = this._driver.action.test(campaignId, testOptions);
        response.put("body", new JSONObject("{'id': '" + campaignId + "'}"));
        return response;
    }

    /**
     * Validate a campaign
     *
     * @param campaignId        Campaign's id you want to validate
     * @param validateOptions   Validate parameters
     * @return                  Response
     */
    public JSONObject validateCampaign(String campaignId, JSONObject validateOptions) {
        return this._driver.action.validate(campaignId, validateOptions);
    }

    /**
     * Create and execute an import
     *
     * @param Import        Import you want to create
     * @param filepath      Path to your file
     * @return              Response
     * @throws FileNotFoundException
     */
    public JSONObject Import(JSONObject Import, String filepath) throws FileNotFoundException {
        JSONObject response = this._driver.imports.create(Import);
        if (response.getInt("statusCode") == 200)
        {
            Integer id = response.getJSONObject("body").getInt("id");
            return this._driver.imports.execute(id.toString(), filepath);
        }
        return response;
    }

    /**
     * Create a target and add it to a segment
     *
     * @param targetObject  Target you want to create
     * @param segmentId     Segment's id in which you want to add the target
     * @return              Response
     */
    public JSONObject createTargetAndAddToSegment(JSONObject targetObject, String segmentId) {
        JSONObject response = this.createOrModifyTarget(targetObject);

        if (response.getInt("statusCode") != 200) {
            return response;
        }
        String targetId = response.getJSONObject("body").getString("id");
        return  this._driver.segment.addToSegment(segmentId, targetId);
    }

    /**
     * Create a target (or update it) and send it a message
     *
     * @param target            Target you want to create (or update)
     * @param actionId          Message's id
     * @param messageContent    Custom message content
     * @return                  Response
     */
    public JSONObject addTargetAndSendMessage(JSONObject target, String actionId, JSONObject messageContent) {
        JSONObject response = createOrModifyTarget(target);
        if (response.getInt("statusCode") != 200) {
            return response;
        }
        String targetId = response.getJSONObject("body").getString("id");
        return this._driver.send.message(actionId, targetId, messageContent);
    }

    /**
     * Create a target (or update it) and send it a message
     *
     * @param target        Target you want to create (or update)
     * @param actionId      Message's id
     * @return              Response
     */
    public JSONObject addTargetAndSendMessage(JSONObject target, String actionId) {
        return this.addTargetAndSendMessage(target, actionId, null);
    }

    /**
     * Retrieve the unicity ID
     *
     * @return      Unicity ID
     */
    private String getUnicityId() {
        if (this._unicity == null) {
            JSONObject response = this._driver.field.list();

            if (response.getInt("statusCode") != 200) {
                throw new IllegalStateException("Unable to retrieve all fields");
            }
            JSONArray fields = response.getJSONArray("body");
            for (int i = 0, len = fields.length(); i < len; ++i) {
                JSONObject field = fields.getJSONObject(i);
                this._fields.put(field.getString("name"), field.get("id").toString());
                if (field.getBoolean("isUnicity")) {
                    this._unicity = field.get("id").toString();
                }
            }
            if (this._unicity == null) {
                throw new IllegalStateException("You haven't set any unicity type");
            }
            return this._unicity;
        }
        return this._unicity;
    }

    /**
     * Convert field name to its ID value
     *
     * @param target    Target to normalize
     * @return          Normalized target
     */
    private JSONObject normalizeTarget(JSONObject target) {
        JSONObject newTarget = new JSONObject();

        for (Object keyset : target.keySet()) {
            String key = keyset.toString();
            if (!isInteger(key)) {
                if (!this._fields.containsKey(key)) {
                    throw new IllegalArgumentException("The field named " + key + " doesn't exist");
                }
                newTarget.put(this._fields.get(key), target.getString(key));
            } else {
                newTarget.put(key, target.getString(key));
            }

        }
        return newTarget;
    }
}
