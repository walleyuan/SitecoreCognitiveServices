using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Items;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Search.ComputedFields.Image
{
    public class Tags : BaseComputedField
    {
        protected override object GetFieldValue(Item cognitiveIndexable)
        {
            var regions = Text?.Regions;
            if (regions == null)
                return null;

            var words = (
                from r in regions
                where r.Lines != null
                    from l in r.Lines
                    where l.Words != null
                        from w in l.Words
                        where !string.IsNullOrEmpty(w.Text.Trim())
                        select w.Text.Trim()
            );
            
            var tags = Visions?.Description?.Tags.Select(t => t.Trim()).ToList();
            if(tags != null && tags.Any())
                words = words.Concat(tags);

            words = words.Concat(new [] { cognitiveIndexable.DisplayName });

            List<string> charList = new List<string>() { ":", ";", "~", "`", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "+", "=", "_", "-", "|", "\\", "{", "}", "[", "]", "\"", "'", "?", "/", ">", ".", "<", ","};
            var results = words.Where(w => !charList.Contains(w)).Distinct().ToArray();

            return (results.Any())
                ? results.Distinct()
                : null;
        }
    }
}