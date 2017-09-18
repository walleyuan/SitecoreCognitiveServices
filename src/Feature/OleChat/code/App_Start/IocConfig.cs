using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.SharedSource.CognitiveServices.OleChat.Intents;
using Sitecore.SharedSource.CognitiveServices.OleChat.Factories;
using Sitecore.SharedSource.CognitiveServices.OleChat.Controllers;
using Sitecore.SharedSource.CognitiveServices.OleChat.Dialog;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.App_Start
{
    public class IocConfig : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            //system
            serviceCollection.AddTransient<IOleSettings, OleSettings>();

            //intents
            serviceCollection.AddTransient<IDefaultIntent, DefaultIntent>();
            serviceCollection.AddTransient<IGreetIntent, GreetIntent>();
            serviceCollection.AddTransient<IKickUserIntent, KickUserIntent>();
            serviceCollection.AddTransient<ILoggedInUsersIntent, LoggedInUsersIntent>();
            serviceCollection.AddTransient<IPublishIntent, PublishIntent>();
            serviceCollection.AddTransient<IVersionIntent, VersionIntent>();
            serviceCollection.AddTransient<IAboutIntent, AboutIntent>();
            serviceCollection.AddTransient<IUnlockItemsIntent, UnlockItemsIntent>();
            serviceCollection.AddTransient<ILockedItemCountIntent, LockedItemCountIntent>();
            serviceCollection.AddTransient<IQuitIntent, QuitIntent>();
            serviceCollection.AddTransient<IThanksIntent, ThanksIntent>();
            serviceCollection.AddTransient<ILogoutIntent, LogoutIntent>();

            //intent factories
            serviceCollection.AddTransient<IIntentFactory<IIntent>, DefaultIntentFactory>();
            serviceCollection.AddTransient<IIntentFactory<IIntent>, GreetIntentFactory>();
            serviceCollection.AddTransient<IIntentFactory<IIntent>, KickUserIntentFactory>();
            serviceCollection.AddTransient<IIntentFactory<IIntent>, LoggedInUsersIntentFactory>();
            serviceCollection.AddTransient<IIntentFactory<IIntent>, PublishIntentFactory>();
            serviceCollection.AddTransient<IIntentFactory<IIntent>, VersionIntentFactory>();
            serviceCollection.AddTransient<IIntentFactory<IIntent>, AboutIntentFactory>();
            serviceCollection.AddTransient<IIntentFactory<IIntent>, UnlockItemsIntentFactory>();
            serviceCollection.AddTransient<IIntentFactory<IIntent>, LockedItemCountIntentFactory>();
            serviceCollection.AddTransient<IIntentFactory<IIntent>, QuitIntentFactory>();
            serviceCollection.AddTransient<IIntentFactory<IIntent>, ThanksIntentFactory>();
            serviceCollection.AddTransient<IIntentFactory<IIntent>, LogoutIntentFactory>();

            //intent provider
            serviceCollection.AddSingleton<IIntentProvider, IntentProvider>();

            //conversation
            serviceCollection.AddTransient<IConversation, Conversation>();
            serviceCollection.AddTransient<IConversationFactory, ConversationFactory>();
            serviceCollection.AddTransient<IConversationHistory, ConversationHistory>();
            serviceCollection.AddTransient<IConversationService, ConversationService>();
            
            serviceCollection.AddTransient(typeof(CognitiveBotController));
        }
    }
}