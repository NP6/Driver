using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP6Api.Models
{
    public class SmsCampaignModel : SmsMessageModel
    {
        [JsonProperty("scheduler")]
        public Scheduler Scheduler { get; set; }
    }
}
