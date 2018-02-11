﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Feature.OleChat.Setup
{
    public interface ISetupService
    {
        bool PingLuis();
        bool RestoreOle(bool overwrite);
        bool QueryOle();
    }
}