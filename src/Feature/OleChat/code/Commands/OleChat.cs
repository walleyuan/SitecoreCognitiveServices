﻿using System;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Foundation.SCSDK.Commands;

namespace SitecoreCognitiveServices.Feature.OleChat.Commands
{
    [Serializable]
    public class OleChat : BaseCommand
    {
        public override void Execute(CommandContext context)
        {
            Item ctxItem = DataWrapper.ExtractItem(context);
            if (ctxItem == null)
                return;

            context.Parameters.Add(idParam, ctxItem.ID.ToString());
            context.Parameters.Add(heightParam, DataWrapper.GetFieldDimension(ctxItem, "height", 500, 56));
            context.Parameters.Add(widthParam, DataWrapper.GetFieldDimension(ctxItem, "width", 810, 20));
           
            Sitecore.Context.ClientPage.Start(this, "Run", context.Parameters);
        }

        public virtual void Run(ClientPipelineArgs args)
        {
            if (args.IsPostBack)
                return;

            string id = args.Parameters[idParam];
            string db = Sitecore.Context.ContentDatabase.Name;
            Item i = DataWrapper.GetItemByIdValue(id, db);
            string langCode = i.Language.Name;
            string height = args.Parameters[heightParam];
            string width = args.Parameters[widthParam];
            
            ModalDialogOptions mdo = new ModalDialogOptions($"/SitecoreCognitiveServices/CognitiveOleChat/OleChat?id={id}&language={langCode}&db={db}")
            {
                Header = "Chat with Ole",
                Height = height,
                Width = width,
                Message = "Chat with Ole, Sitecore's internal AI",
                Response = true
            };
            SheerResponse.ShowModalDialog(mdo);
            args.WaitForPostBack();
        }

        public override CommandState QueryState(CommandContext context)
        {
            return CommandState.Enabled;
        }
    }
}