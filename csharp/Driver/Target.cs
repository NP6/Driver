using System;
using RestSharp;

namespace NP6Api
{
    public class Target
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connection">class that help to request API</param>
        public Target(Connection connection)
        {
            _connection = connection;
            _route = "targets/";
        }

        /// <summary>
        /// Create a target
        /// </summary>
        /// <param name="target">Target you want to create</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse Create(JsonObject target)
        {
            if (target == null)
            {
                throw new ArgumentException("Parameter is undefined");
            }
            return _connection.Request(_route, Method.POST, target);
        }

        /// <summary>
        /// Creates a target or update it if it already exists using its unicity
        /// </summary>
        /// <param name="target">Target you want to create or update</param>
        /// <param name="unicity">Target unicity (if it already exists, update it)</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse Create(JsonObject target, string unicity)
        {
            if (target == null || unicity == null)
            {
                throw new ArgumentException("Parameter is undefined");
            }
            return _connection.Request("targets?unicity=" + unicity, Method.PUT, target);
        }

        /// <summary>
        /// Update a target
        /// </summary>
        /// <param name="id">Target's id</param>
        /// <param name="target">Target you want to update</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse Update(string id, dynamic target)
        {
            if (id == null || target == null)
            {
                throw new ArgumentException("Parameter is undefined");
            }
            return _connection.Request(_route + id, Method.PUT, target);
        }

        /// <summary>
        /// Get a target
        /// </summary>
        /// <param name="id">Target's id</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse Get(string id)
        {
            if (id == null)
            {
                throw new ArgumentException("Parameter is undefined");
            }
            return _connection.Request(_route + id, Method.GET);
        }

        /// <summary>
        /// List all targets
        /// </summary>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse List()
        {
            return _connection.Request(_route, Method.GET);
        }

        /// <summary>
        /// Delete a target
        /// </summary>
        /// <param name="id">Target's id</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse Delete(string id)
        {
            if (id == null)
            {
                throw new ArgumentException("Parameter is undefined");
            }
            return _connection.Request(_route + id, Method.DELETE);
        }

        /// <summary>
        /// Find a target thanks to its unicity
        /// </summary>
        /// <param name="unicity">Target's unicity</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse Find(string unicity)
        {
            if (unicity == null)
            {
                throw new ArgumentException("Parameter is undefined");
            }
            var routeUrl = "targets?unicity=" + unicity;
            return _connection.Request(routeUrl, Method.GET);
        }

        private readonly Connection _connection;

        private string _route;
    }
}