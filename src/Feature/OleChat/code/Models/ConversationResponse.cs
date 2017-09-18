﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Models
{
    public class ConversationResponse
    {
        public string Message { get; set; }
        public Dictionary<string, string> Options { get; set; }
        public KeyValuePair<string, string> Action { get; set; }
    }
}