using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Repositories.Language {
    public class TranslatorRepository : ITranslatorRepository {
        //https://github.com/MicrosoftTranslator/Csharp-Cmd-Line-Speech-Translate
        //http://docs.microsofttranslator.com/speech-translate.html#!/Speech_translation/SpeechTranslate_Get
        //http://docs.microsofttranslator.com/text-translate.html
        protected static readonly string translateUrl = "wss://dev.microsofttranslator.com/speech/translate";
    }
}