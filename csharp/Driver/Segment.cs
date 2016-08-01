using System;
using RestSharp;

namespace NP6Api
{
    public class Segment
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connection">class that help to request API</param>
        public Segment(Connection connection)
        {
            _connection = connection;
            _route = "segments/";
        }

        /// <summary>
        /// Create a segment
        /// </summary>
        /// <param name="segment">Segment you want to create</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse Create(Models.SegmentModel segment)
        {
            if (segment == null)
            {
                throw new ArgumentException("Parameter is undefined");
            }
            return _connection.Request(_route, Method.POST, segment);
        }

        /// <summary>
        /// Update a segment
        /// </summary>
        /// <param name="id">Segment's id</param>
        /// <param name="segment">Segment filds you want to update</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse Update(string id, Models.SegmentModel segment)
        {
            if (id == null || segment == null)
            {
                throw new ArgumentException("Parameter is undefined");
            }
            return _connection.Request(_route + id, Method.PUT, segment);
        }

        /// <summary>
        /// Get a segment
        /// </summary>
        /// <param name="id">Segment's id</param>
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
        /// List all segment
        /// </summary>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse List()
        {
            return _connection.Request(_route, Method.GET);
        }

        /// <summary>
        /// Delete a segment
        /// </summary>
        /// <param name="id">Segment's id</param>
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
        /// Add a target to a segment
        /// </summary>
        /// <param name="segmentId">Segment's id</param>
        /// <param name="targetId">Target's id</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse AddToSegment(string segmentId, string targetId)
        {
            if (segmentId == null || targetId == null)
            {
                throw new ArgumentException("Parameter are undefined");
            }
            var routeUrl = "targets/" + targetId + "/segments/" + segmentId;
            return _connection.Request(routeUrl, Method.POST);
        }

        /// <summary>
        /// Remove a target from a segment
        /// </summary>
        /// <param name="segmentId">Segment's id</param>
        /// <param name="targetId">Target's id</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse Remove(string segmentId, string targetId)
        {
            if (segmentId == null || targetId == null)
            {
                throw new ArgumentException("Parameter are undefined");
            }
            var routeUrl = "targets/" + targetId + "/segments/" + segmentId;
            return _connection.Request(routeUrl, Method.DELETE);
        }

        private readonly Connection _connection;

        private string _route;
    }
}