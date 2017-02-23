using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Enums
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
}