using System.Collections.Generic;

namespace NP6Api
{
    /// <summary>
    /// Driver class that contain everything
    /// </summary>
    public class Driver
    {
        private string _url;
        private string _xKey;
        private Connection _connection;

        public Target Target;
        public Action Action;
        public Field Field;
        public Send Send;
        public Import Import;
        public Segment Segment;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config">Configuration for the driver</param>
        public Driver(Dictionary<string, string> config)
        {
            _url = config["url"] != null ? config["url"] : "https://backoffice.mailperformance.com/";
            _xKey = config["xKey"];
            _connection = new Connection(_xKey, _url);
            Target = new Target(_connection);
            Action = new Action(_connection);
            Field = new Field(_connection);
            Send = new Send(_connection);
            Import = new Import(_connection);
            Segment = new Segment(_connection);
        }

    }
}