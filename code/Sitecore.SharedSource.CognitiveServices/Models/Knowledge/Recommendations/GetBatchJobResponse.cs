﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Knowledge.Recommendations
{
    public class GetBatchJobResponse
    {
        public List<BatchJobDetails> BatchJobs { get; set; }
    }
}