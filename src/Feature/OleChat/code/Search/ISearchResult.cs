using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Collections;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Search
{
    public interface ISearchResult
    {
        DateTime CreatedDate { get; set; }
        string Url { get; set; }
        string Datasource { get; set; }
        string CreatedBy { get; set; }
        ID ItemId { get; set; }
        string Language { get; set; }
        string Name { get; set; }
        string Path { get; set; }
        IEnumerable<ID> Paths { get; set; }
        ID Parent { get; set; }
        ID TemplateId { get; set; }
        string TemplateName { get; set; }
        string DatabaseName { get; set; }
        DateTime Updated { get; set; }
        string UpdatedBy { get; set; }
        string Content { get; set; }
        IEnumerable<ID> Semantics { get; set; }
        IEnumerable<string> Sites { get; set; }
        string LockOwner { get; set; }
        ItemUri Uri { get; set; }
        string Version { get; set; }
        Dictionary<string, object> Fields { get; }
        string this[string key] { get; set; }
        object this[ObjectIndexerKey key] { get; set; }
        Item GetItem();
        Field GetField(ID fieldId);
        FieldCollection GetFields(ID[] fieldId);
        Field GetField(string fieldName);
        string ToString();

        IQueryable<TResult> GetDescendants<TResult>(IProviderSearchContext context)
            where TResult : SearchResultItem, new();

        IQueryable<TResult> GetChildren<TResult>(IProviderSearchContext context)
            where TResult : SearchResultItem, new();

        IQueryable<TResult> GetAncestors<TResult>(IProviderSearchContext context)
            where TResult : SearchResultItem, new();
    }
}