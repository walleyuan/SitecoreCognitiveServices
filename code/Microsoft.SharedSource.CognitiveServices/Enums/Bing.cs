using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Enums
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
}