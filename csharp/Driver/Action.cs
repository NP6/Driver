using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using NP6Api.Models;

namespace NP6Api
{
    public class Action
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connection">class that help to request API</param>
        public Action(Connection connection)
        {
            _connection = connection;
            _route = "actions/";
        }

        /// <summary>
        /// Create an action
        /// </summary>
        /// <param name="action">Action you want to create</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse Create(IActionModel action)
        {
            if (action == null)
            {
                throw new ArgumentException("Parameter is null");
            }
            
            return _connection.Request(_route, Method.POST, action);
        }

        /// <summary>
        /// Update an action
        /// </summary>
        /// <param name="id">Action's id</param>
        /// <param name="action">Action fields you want to update</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse Update(string id, IActionModel action)
        {
            if (id == null || action == null)
            {
                throw new ArgumentException("Parameter is null");
            }

            return _connection.Request(_route + id, Method.PUT, action);
        }

        /// <summary>
        /// Get an action
        /// </summary>
        /// <param name="id">Action's id</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse Get(string id)
        {
            if (id == null)
            {
                throw new ArgumentException("Parameter is null");
            }

            return _connection.Request(_route + id, Method.GET);
        }

        /// <summary>
        /// List all actions
        /// </summary>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse List()
        {
            return _connection.Request(_route, Method.GET);
        }

        /// <summary>
        /// Delete an action
        /// </summary>
        /// <param name="id">Action's id</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse Delete(string id)
        {
            if (id == null)
            {
                throw new ArgumentException("Parameter is null");
            }

            return _connection.Request(_route + id, Method.DELETE);
        }

        /// <summary>
        /// Validate an action
        /// </summary>
        /// <param name="id">Action's id</param>
        /// <param name="validation">Parameters for validation</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse Validate(string id, ValidationModel validation)
        {
            if (id == null || validation == null)
            {
                throw new ArgumentException("Parameter is null");
            }

            return _connection.Request(_route + id + "/validation", Method.POST, validation);
        }

        /// <summary>
        /// Test an action
        /// </summary>
        /// <param name="id">Action's id</param>
        /// <param name="test">Parameters for test</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse Test(string id, TestModel test)
        {
            if (id == null || test == null)
            {
                throw new ArgumentException("Parameter is null");
            }

            return _connection.Request(_route + id + "/validation", Method.POST, test);
        }

        private readonly Connection _connection;
        private string _route;
    }
}
