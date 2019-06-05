using System.Web.Mvc;
using System.Web;
using Newtonsoft.Json;
using MvcTutorial.Models;
using System;
using MvcTutorial.ViewModels;
using Newtonsoft.Json.Serialization;

namespace MvcTutorial.Extensions
{
    public static class HtmlHelperExtension
    {
        public static MvcHtmlString BuildKnockoutNextPreviousLinks(this HtmlHelper htmlHelper, string actionName)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);

            return new MvcHtmlString(string.Format(
                "<nav>" +
                "   <ul class=\"pager\">" +
                "       <li data-bind=\"css: pagingService.buildPreviousClass()\"><a href=\"{0}\" data-bind=\"click: pagingService.previousPage\">Previous</a></li>" +
                "       <li data-bind=\"css: pagingService.buildNextClass()\"><a href=\"{0}\" data-bind=\"click: pagingService.NextPage\">Next</a></li>" +
                "   </ul>" +
                "</nav>",
                urlHelper.Action(actionName)
            ));
        }

        public static MvcHtmlString BuildKnockoutSortableLink(this HtmlHelper htmlHelper, string fieldName, 
            string actionName, string sortField)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);

            return new MvcHtmlString(string.Format(
                "<a href=\"{0}\" data-bind=\"click: pagingService.sortEntitiesBy\"" +
                "   data-sort-field=\"{1}\"> {2} " +
                "   <span data-bind=\"css: pagingService.buildSortIcon('{1}')\"></span></a>",
                urlHelper.Action(actionName),
                sortField,
                fieldName
            ));
        }

        public static HtmlString HtmlConvertToJson(this HtmlHelper htmlHelper, object model)
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return new HtmlString(JsonConvert.SerializeObject(model, settings));
        }
    }
}