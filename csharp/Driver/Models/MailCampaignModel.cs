using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NP6Api.Models
{
    public class MailCampaignModel : MailMessageModel
    {
        [JsonProperty("scheduler")]
        public Scheduler Scheduler { get; set; }
    }
}
