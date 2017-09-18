using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Enums
{
    public enum SafeSearchOptions { Off, Moderate, Strict }
    public enum AspectOptions { Square, Wide, Tall, All }
    public enum ColorOptions { ColorOnly, Monochrome, Black, Blue, Brown, Gray, Green, Orange, Pink, Purple, Red, Teal, White, Yellow, All }
    public enum FreshnessOptions { Day, Week, Month, All }
    public enum ImageContentOptions { Face, Portrait, All }
    public enum ImageTypeOptions { AnimatedGif, Clipart, Line, Photo, Shopping, All }
    public enum LicenseOptions { Public, Share, ShareCommercially, Modify, ModifyCommercially, All }
    public enum SizeOptions { Small, Medium, Large, Wallpaper, All }
    public enum ModulesRequestedOptions { All, Annotations, BRQ, Caption, Collections, Recipes, PagesIncluding, RecognizedEntities, RelatedSearches, ShoppingSources, SimilarImages, SimilarProducts }
    public enum SpellCheckModeOptions { Proof, Spell, None }
    public enum NewsCategoryOptions { Business, Entertainment, Health, Politics, ScienceAndTechnology, Sports, USUK, World }
    public enum VideoDetailsModulesOptions { All, RelatedVideos, VideoResult }
    public enum GenderOptions { Female, Male }
    public enum AudioOutputFormatOptions {
        
        /// <summary>
        /// raw-8khz-8bit-mono-mulaw request output audio format type.
        /// </summary>
        [EnumMember(Value = "raw-8khz-8bit-mono-mulaw")]
        Raw8Khz8BitMonoMULaw,

        /// <summary>
        /// raw-16khz-16bit-mono-pcm request output audio format type.
        /// </summary>
        [EnumMember(Value = "raw-16khz-16bit-mono-pcm")]
        Raw16Khz16BitMonoPcm,

        /// <summary>
        /// riff-8khz-8bit-mono-mulaw request output audio format type.
        /// </summary>
        [EnumMember(Value = "riff-8khz-8bit-mono-mulaw")]
        Riff8Khz8BitMonoMULaw,

        /// <summary>
        /// riff-16khz-16bit-mono-pcm request output audio format type.
        /// </summary>
        [EnumMember(Value = "riff-16khz-16bit-mono-pcm")]
        Riff16Khz16BitMonoPcm,

        /// <summary>
        /// ssml-16khz-16bit-mono-silk request output audio format type.
        /// It is a SSML with audio segment, with audio compressed by SILK codec
        /// </summary>
        [EnumMember(Value = "ssml-16khz-16bit-mono-silk")]
        Ssml16Khz16BitMonoSilk,

        /// <summary>
        /// raw-16khz-16bit-mono-truesilk request output audio format type.
        /// Audio compressed by SILK codec
        /// </summary>
        [EnumMember(Value = "raw-16khz-16bit-mono-truesilk")]
        Raw16Khz16BitMonoTrueSilk,

        /// <summary>
        /// ssml-16khz-16bit-mono-tts request output audio format type.
        /// It is a SSML with audio segment, and it needs tts engine to play out
        /// </summary>
        [EnumMember(Value = "ssml-16khz-16bit-mono-tts")]
        Ssml16Khz16BitMonoTts,

        /// <summary>
        /// audio-16khz-128kbitrate-mono-mp3 request output audio format type.
        /// </summary>
        [EnumMember(Value = "audio-16khz-128kbitrate-mono-mp3")]
        Audio16Khz128KBitRateMonoMp3,

        /// <summary>
        /// audio-16khz-64kbitrate-mono-mp3 request output audio format type.
        /// </summary>
        [EnumMember(Value = "audio-16khz-64kbitrate-mono-mp3")]
        Audio16Khz64KBitRateMonoMp3,

        /// <summary>
        /// audio-16khz-32kbitrate-mono-mp3 request output audio format type.
        /// </summary>
        [EnumMember(Value = "audio-16khz-32kbitrate-mono-mp3")]
        Audio16Khz32KBitRateMonoMp3,

        /// <summary>
        /// audio-16khz-16kbps-mono-siren request output audio format type.
        /// </summary>
        [EnumMember(Value = "audio-16khz-16kbps-mono-siren")]
        Audio16Khz16KbpsMonoSiren,

        /// <summary>
        /// riff-16khz-16kbps-mono-siren request output audio format type.
        /// </summary>
        [EnumMember(Value = "riff-16khz-16kbps-mono-siren")]
        Riff16Khz16KbpsMonoSiren,
    }
    public enum ScenarioOptions { ulm, websearch }
    public enum BingSpeechLocaleOptions {
        [EnumMember(Value = "ar-EG")]
        arEG,
        [EnumMember(Value = "ca-ES")]
        caES,
        [EnumMember(Value = "de-DE")]
        deDE,
        [EnumMember(Value = "da-DK")]
        daDK,
        [EnumMember(Value = "es-ES")]
        esES,
        [EnumMember(Value = "es-MX")]
        esMX,
        [EnumMember(Value = "en-AU")]
        enAU,
        [EnumMember(Value = "en-CA")]
        enCA,
        [EnumMember(Value = "en-GB")]
        enGB,
        [EnumMember(Value = "en-IN")]
        enIN,
        [EnumMember(Value = "en-NZ")]
        enNZ,
        [EnumMember(Value = "en-US")]
        enUS,
        [EnumMember(Value = "fr-CA")]
        frCA,
        [EnumMember(Value = "fi-FI")]
        fiFI,
        [EnumMember(Value = "fr-FR")]
        frFR,
        [EnumMember(Value = "hi-IN")]
        hiIN,
        [EnumMember(Value = "it-IT")]
        itIT,
        [EnumMember(Value = "ja-JP")]
        jaJP,
        [EnumMember(Value = "ko-KR")]
        koKR,
        [EnumMember(Value = "nb-NO")]
        nbNO,
        [EnumMember(Value = "nl-NL")]
        nlNL,
        [EnumMember(Value = "pl-PL")]
        plPL,
        [EnumMember(Value = "pt-BR")]
        ptBR,
        [EnumMember(Value = "pt-PT")]
        ptPT,
        [EnumMember(Value = "ru-RU")]
        ruRU,
        [EnumMember(Value = "sv-SE")]
        svSE,
        [EnumMember(Value = "zh-CN")]
        zhCN,
        [EnumMember(Value = "zh-HK")]
        zhHK,
        [EnumMember(Value = "zh-TW")]
        zhTW
    };
    public enum SpeechOsOptions {
        [EnumMember(Value = "Windows OS")]
        WindowsOS,
        [EnumMember(Value = "Windows Phone OS")]
        WindowsPhoneOS,
        [EnumMember(Value = "XBOX")]
        XBOX,
        [EnumMember(Value = "Android")]
        Android,
        [EnumMember(Value = "iPhone OS")]
        iPhoneOS
    }
}