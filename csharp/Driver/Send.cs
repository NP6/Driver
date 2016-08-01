using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using NP6Api.Models;

namespace NP6Api
{
    public class Send
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connection">class that help to request API</param>
        public Send(Connection connection)
        {
            _connection = connection;
            _route = "actions/";
        }

        /// <summary>
        /// Send a message to a target
        /// </summary>
        /// <param name="actionId">Action's id</param>
        /// <param name="targetId">Target's id</param>
        /// <param name="content">Custom content for message</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse Message(string actionId, string targetId, MessageModel content = null)
        {
            if (actionId == null || actionId == null)
            {
                throw new ArgumentException("Parameter is null");
            }

            return _connection.Request(_route + actionId + "/targets/" + targetId, Method.POST, content);
        }

        private readonly Connection _connection;
        private string _route;
    }
}
