﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP6Api.Models
{
    public class MailMessageModel : IActionModel
    {
        [JsonProperty("type")]
        public Content Content { get; set; }
    }
}
