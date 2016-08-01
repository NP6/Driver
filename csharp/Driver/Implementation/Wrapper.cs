using RestSharp;
using System;
using System.Collections.Generic;
using NP6Api.Models;
using System.Net;
using Newtonsoft.Json.Linq;

namespace NP6Api.Implementation
{
    public class Wrapper
    {
        private Driver _driver;
        private string _unicity;
        private Dictionary<string, string> _fields;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config">Configuration for the driver</param>
        public Wrapper(Dictionary<string, string> config)
        {
            _driver = new Driver(config);
            _unicity = null;
            _fields = new Dictionary<string, string>();
        }

        /// <summary>
        /// Create a segment
        /// </summary>
        /// <param name="segment">Segment you want to create</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse CreateSegment(SegmentModel segment)
        {
            return _driver.Segment.Create(segment);
        }

        /// <summary>
        /// Create a campaign
        /// </summary>
        /// <param name="campaign">Action you want to create</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse CreateCampaign(IActionModel campaign)
        {
            return _driver.Action.Create(campaign);
        }

        /// <summary>
        /// Create a campaign, then test it with giving test options
        /// </summary>
        /// <param name="campaign">Campaign you want to create</param>
        /// <param name="testOption">Tests parameters</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse CreateAndTestCampaign(IActionModel campaign, TestModel testOptions)
        {
            NResponse response = _driver.Action.Create(campaign);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return response;
            }
            JObject body = (JObject)response.Body;
            string campaignId = (string)body.GetValue("id");
            return _driver.Action.Test(campaignId, testOptions);
        }

        /// <summary>
        /// Create a target or update its value if it already exist
        /// </summary>
        /// <param name="target">Target you want to create (or update)</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse CreateOrModifyTarget(JsonObject target)
        {
            string unicityId = GetUnicityId();
            JsonObject normalizeTarget = NormalizeTarget(target);

            return _driver.Target.Create(normalizeTarget, (string)normalizeTarget[unicityId]);
        }

        /// <summary>
        /// Create a target (or update it) and send it a message
        /// </summary>
        /// <param name="target">Target you want to create (or update)</param>
        /// <param name="actionId">Message's id</param>
        /// <param name="message">Custom message content</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse AddTargetAndSendMessage(JsonObject target, string actionId, MessageModel message = null)
        {
            var response = CreateOrModifyTarget(target);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return response;
            }
            JObject body = (JObject)response.Body;
            string targetId = (string)body.GetValue("id");
            return _driver.Send.Message(actionId, targetId, message);
        }

        /// <summary>
        /// Create a target and add it to a segment
        /// </summary>
        /// <param name="target">Target you want to create</param>
        /// <param name="segmentId">Segment's id in which you want to add the target</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse CreateTargetAndAddToSegment(JsonObject target, string segmentId)
        {
            var response = CreateOrModifyTarget(target);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return response;
            }
            JObject body = (JObject)response.Body;
            string targetId = (string)body.GetValue("id");
            return _driver.Segment.AddToSegment(segmentId, targetId);
        }

        // Private methods

        /// <summary>
        /// Retrieve the unicity ID
        /// </summary>
        /// <returns>Unicity ID</returns>
        private string GetUnicityId()
        {
            if (_unicity == null)
            {
                var response = _driver.Field.List();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new InvalidOperationException("Unable to retrieve all fields");
                }
                JArray fields = (JArray)response.Body;
                foreach (JObject field in fields.Children<JObject>())
                {
                    _fields[(string)field.GetValue("name")] = (string)field.GetValue("id");
                    if ((bool)field.GetValue("isUnicity"))
                    {
                        _unicity = (string)field.GetValue("id");
                    }
                }
                if (_unicity == null)
                {
                    throw new InvalidOperationException("You haven't set any unicity type");
                }
                return _unicity;
            }
            return _unicity;
        }

        /// <summary>
        /// Convert field name to its ID value
        /// </summary>
        /// <param name="target">Target to normalize</param>
        /// <returns>Normalized target</returns>
        private JsonObject NormalizeTarget(JsonObject target)
        {
            JsonObject newTarget = new JsonObject();
            int n;

            foreach (var field in target)
            {
                if (!int.TryParse(field.Key, out n))
                {
                    if (!_fields.ContainsKey(field.Key))
                    {
                        throw new ArgumentException("The field named " + field.Key + " doesn't exist");
                    }
                    newTarget.Add(_fields[field.Key], field.Value);
                }
                else
                {
                    newTarget.Add(field.Key, field.Value);
                }
            }
            return newTarget;
        }

        /// <summary>
        /// Validate a campaign
        /// </summary>
        /// <param name="id">Id of the campaign to validate</param>
        /// <param name="validate">Validation object</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse ValidateCampaign(string id, ValidationModel validate)
        {
            return _driver.Action.Validate(id, validate);
        }

        /// <summary>
        /// Create an Import and Execute it
        /// </summary>
        /// <param name="import">Import Object</param>
        /// <param name="filePath">File path</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse Import(ImportModel import, string filePath)
        {
            var response = _driver.Import.Create(import);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return response;
            }
            var body = (JObject)response.Body;
            var importId = (string)body.GetValue("id");
            return _driver.Import.Execute(importId, filePath);
        }
    }
}
