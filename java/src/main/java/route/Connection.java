package route;

import org.apache.commons.io.IOUtils;
import org.json.JSONObject;
import org.json.JSONTokener;

import java.io.*;
import java.net.HttpURLConnection;
import java.net.URL;

import java.util.logging.*;

class Connection {

    private String _xkey;
    private String _url;
    private HttpURLConnection _connection;

    private static Logger logger = Logger.getLogger("route.Connection");

    Connection(String xkey, String url) {
        this._xkey = xkey;
        this._url = url;
    }

    JSONObject request(String route, String method, JSONObject data, Boolean importData) {
        JSONObject response = new JSONObject();
        int statusCode;

        this.init(route, method);
        if ("POST".equals(method) && data == null) {
            data = new JSONObject();
        }
        if (importData != null && importData) {
            this._connection.setRequestProperty("Content-Type", "application/octet-stream");
            this._connection.setRequestProperty("Content-Disposition", "form-data; filename=\"" + data.getString("filename") + "\"");
            this._connection.setRequestProperty("Content-Transfer-Encoding", "binary");
            this._connection.setDoOutput(true);
            this.send(data.getString("fileContent"));
        } else if (data != null) {
            this._connection.setRequestProperty("Content-Type", "application/json");
            this._connection.setRequestProperty("Content-Length", String.valueOf(data.toString().length()));
            this._connection.setDoOutput(true);
            this.send(data.toString());
        }

        try {
            statusCode = this._connection.getResponseCode();
        } catch (IOException e) {
            statusCode = 400;
            logger.log(Level.WARNING, "Unable to get the HTTP response code, so it will be set to 400.", e);
        }
        Object result = readResponse(statusCode);

        this.closeConnection();

        response.put("statusCode", statusCode);
        response.put("body", result);

        return response;
    }

    JSONObject request(String route, String method, JSONObject data) {
        return request(route, method, data, null);
    }

    JSONObject request(String route, String method) {
        return request(route, method, null, null);
    }

    private void init(String route, String method) {
        try {
            URL url = new URL(this._url + route);
            this._connection = (HttpURLConnection) url.openConnection();

            this._connection.setRequestMethod(method);
            this._connection.setRequestProperty("X-Key", this._xkey);
        } catch (IOException e) {
            throw new IllegalStateException("Unable to initiate the connection.", e);
        }
    }

    private void closeConnection() {
        this._connection.disconnect();
    }

    private void send(String data) {
        OutputStreamWriter os = null;

        try {
            os = new OutputStreamWriter(this._connection.getOutputStream());
            os.write(data);
            os.flush();
        } catch (IOException e) {
            throw new IllegalStateException("Unable to create OutpoutStream.", e);
        } finally {
            Utils.close(os);
        }
    }

    private Object readResponse(int statusCode) {
        Object response = new JSONObject();
        InputStream in = null;

        try {
            if (statusCode >= 400) {
                in = new BufferedInputStream(this._connection.getErrorStream());
            } else {
                in = new BufferedInputStream(this._connection.getInputStream());
            }
            String input = IOUtils.toString(in, "UTF-8");
            if (!"".equals(input)) {
                response = new JSONTokener(input).nextValue();
            }
        } catch (IOException e) {
            // When there is no body, IOException will be catch here
            // If no body, just return a empty JSONObject
        } finally {
            Utils.close(in);
        }
        return response;
    }
}
