using System.Collections.Generic;
using System.Linq;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Image
{
    public class Tags : BaseComputedField
    {
        protected override object GetFieldValue(CognitiveIndexableItem cognitiveIndexable)
        {
            var regions = cognitiveIndexable.Text?.Regions;
            List<string> words = (
                from r in regions
                where r.Lines != null
                    from l in r.Lines
                    where l.Words != null
                        from w in l.Words
                        where !string.IsNullOrEmpty(w.Text)
                        select w.Text
            ).ToList();
            
            var tags = cognitiveIndexable.Visions?.Description?.Tags;
            if(tags != null && tags.Any())
                words.AddRange(tags);

            words.Add(cognitiveIndexable.Item.DisplayName);

            return (words.Any())
                ? (object)words.ToArray()
                : null;
        }
    }
}