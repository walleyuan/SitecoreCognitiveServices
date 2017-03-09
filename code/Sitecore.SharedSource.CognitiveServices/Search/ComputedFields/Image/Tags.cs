using System.Collections.Generic;
using System.Linq;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Image
{
    public class Tags : BaseComputedField
    {
        protected override object GetFieldValue(CognitiveIndexableItem cognitiveIndexable)
        {
            var regions = cognitiveIndexable.Text?.Regions;
            var words = (
                from r in regions
                where r.Lines != null
                    from l in r.Lines
                    where l.Words != null
                        from w in l.Words
                        where !string.IsNullOrEmpty(w.Text.Trim())
                        select w.Text.Trim()
            );
            
            var tags = cognitiveIndexable.Visions?.Description?.Tags.Select(t => t.Trim()).ToList();
            if(tags != null && tags.Any())
                words = words.Concat(tags);

            words = words.Concat(new [] { cognitiveIndexable.Item.DisplayName });

            List<string> charList = new List<string>() { ":", ";", "~", "`", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "+", "=", "_", "-", "|", "\\", "{", "}", "[", "]", "\"", "'", "?", "/", ">", ".", "<", ","};
            var results = words.Where(w => !charList.Contains(w)).Distinct().ToArray();

            return (results.Any())
                ? results.Distinct().ToArray()
                : null;
        }
    }
}