using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Controllers;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;
using SitecoreCognitiveServices.Feature.OleChat.Intents;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Setup;

namespace SitecoreCognitiveServices.Feature.OleChat.App_Start
{
    public class IocConfig : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            //system
            serviceCollection.AddTransient<IOleSettings, OleSettings>();

            //models
            serviceCollection.AddTransient<ISetupInformation, SetupInformation>();

            //intents
            serviceCollection.AddTransient<IOleIntent, DefaultIntent>();
            serviceCollection.AddTransient<IOleIntent, GreetIntent>();
            serviceCollection.AddTransient<IOleIntent, KickUserIntent>();
            serviceCollection.AddTransient<IOleIntent, LoggedInUsersIntent>();
            serviceCollection.AddTransient<IOleIntent, PublishIntent>();
            serviceCollection.AddTransient<IOleIntent, VersionIntent>();
            serviceCollection.AddTransient<IOleIntent, AboutIntent>();
            serviceCollection.AddTransient<IOleIntent, UnlockItemsIntent>();
            serviceCollection.AddTransient<IOleIntent, LockedItemCountIntent>();
            serviceCollection.AddTransient<IOleIntent, QuitIntent>();
            serviceCollection.AddTransient<IOleIntent, ThanksIntent>();
            serviceCollection.AddTransient<IOleIntent, LogoutIntent>();
            serviceCollection.AddTransient<IOleIntent, RebuildIndexIntent>();
            serviceCollection.AddTransient<IOleIntent, FrustratedUserIntent>();

            //factories
            serviceCollection.AddTransient<ISetupInformationFactory, SetupInformationFactory>();

            //intent provider
            serviceCollection.AddScoped<IIntentProvider, IntentProvider>();

            //conversation
            serviceCollection.AddTransient<IConversation, Conversation>();
            serviceCollection.AddTransient<IConversationFactory, ConversationFactory>();
            serviceCollection.AddTransient<IConversationHistory, ConversationHistory>();
            serviceCollection.AddTransient<IConversationService, ConversationService>();
            serviceCollection.AddTransient<IIntentOptionSetFactory, IntentOptionSetFactory>();
            serviceCollection.AddTransient<IConversationResponseFactory, ConversationResponseFactory>();
            
            //setup
            serviceCollection.AddTransient<ISetupService, SetupService>();

            serviceCollection.AddTransient(typeof(CognitiveOleChatController));
        }
    }
}