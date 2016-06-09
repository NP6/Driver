package route;

import java.io.Closeable;
import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;

public class Utils {

    private static Logger logger = Logger.getLogger("route.Utils");

    /**
     * Better to way test if string is interger, than use try-catch
     *
     * @param str   String to test
     * @return      return true if the string is interger, false otherwise
     */
    public static boolean isInteger(String str) {
        if (str == null) {
            return false;
        }
        int length = str.length();
        if (length == 0) {
            return false;
        }
        int i = 0;
        if (str.charAt(0) == '-') {
            if (length == 1) {
                return false;
            }
            i = 1;
        }
        for (; i < length; i++) {
            char c = str.charAt(i);
            if (c < '0' || c > '9') {
                return false;
            }
        }
        return true;
    }

    /**
     * Generic close method
     *
     * @param resource      Resource you want to close
     * @param <T>           Resource must extends Closeable to call close() on it
     */
    public static <T extends Closeable> void close(T resource) {
        try {
            if (resource != null) {
                resource.close();
            }
        } catch (IOException e) {
            logger.log(Level.WARNING, "Unable to close resource: " + e.getMessage());
        }
    }
}
