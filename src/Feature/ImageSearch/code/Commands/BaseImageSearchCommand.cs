﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Shell.Framework.Commands;
using SitecoreCognitiveServices.Feature.ImageSearch.Search;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.SCSDK.Commands;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Commands
{
    public class BaseImageSearchCommand : BaseCommand
    {
        protected readonly IImageSearchSettings _settings;
        protected readonly IImageSearchService _searchService;
        
        public BaseImageSearchCommand()
        {
            _settings = DependencyResolver.Current.GetService<IImageSearchSettings>();
            _searchService = DependencyResolver.Current.GetService<IImageSearchService>();
        }

        public override void Execute(CommandContext context)
        {
            Item ctxItem = DataWrapper.ExtractItem(context);
            if (ctxItem == null)
                return;

            context.Parameters.Add(idParam, ctxItem.ID.ToString());
            
            Sitecore.Context.ClientPage.Start(this, "Run", context.Parameters);
        }
    }
}