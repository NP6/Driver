using System;
using System.Linq;
using RestSharp;
using System.IO;

namespace NP6Api
{
    public class Import
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connection">class that help to request API</param>
        public Import(Connection connection)
        {
            _connection = connection;
            _route = "imports/";
        }

        /// <summary>
        /// Create an import
        /// </summary>
        /// <param name="import">Import you want to create</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse Create(dynamic import)
        {
            if (import == null)
            {
                throw new ArgumentException("Parameter is undefined");
            }

            return _connection.Request(_route, Method.POST, import);
        }

        /// <summary>
        /// Execute an import
        /// </summary>
        /// <param name="id">Id of the import you want to execute</param>
        /// <param name="filepath">File path that you'll import</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse Execute(string id, string filepath)
        {
            if (id == null || filepath == null)
            {
                throw new ArgumentException("Parameter are undefined");
            }

            string[] validExt = {
                ".txt",
                ".csv",
                ".zip",
                ".tar.gz",
                ".tgz",
                ".gz"
            };
            string fileExt = Path.GetExtension(filepath);

            if (!validExt.Contains(fileExt))
            {
                throw new ArgumentException("Wrong type of file");
            }

            JsonObject importjson = new JsonObject
            {
                {"fileName", Path.GetFileName(filepath)},
                {"filePath", filepath}
            };

            return _connection.Request(_route + id + "/executions", Method.POST, importjson, true);
        }

        /// <summary>
        /// Get an import
        /// </summary>
        /// <param name="id">Id of the import you want to get</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse Get(string id)
        {
            if (id == null)
            {
                throw new ArgumentException("Parameter is undefined");
            }

            return _connection.Request(_route + id, Method.GET, import: true);
        }

        /// <summary>
        /// List all import
        /// </summary>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse List()
        {
            return _connection.Request(_route, Method.GET, import: true);
        }

        /// <summary>
        /// Delete an import
        /// </summary>
        /// <param name="id">Import's id</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse Delete(string id)
        {
            if (id == null)
            {
                throw new ArgumentException("Parameter is null");
            }

            return _connection.Request(_route + id, Method.DELETE, import: true);
        }

        private readonly Connection _connection;
        private string _route;
    }
}
