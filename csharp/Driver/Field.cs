using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace NP6Api
{
    public class Field
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connection">class that help to request API</param>
        public Field(Connection connection)
        {
            _connection = connection;
            _route = "fields/";
        }

        /// <summary>
        /// List all fields
        /// </summary>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse List()
        {
            return _connection.Request(_route, Method.GET);
        }

        private readonly Connection _connection;
        private string _route;
    }
}
