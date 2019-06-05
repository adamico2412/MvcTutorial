using AutoMapper;
using MvcTutorial.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcTutorial.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class GenerateResultListFilterAttribute : FilterAttribute, IResultFilter
    {
        private readonly Type _sourceType;
        private readonly Type _destinationType;

        public GenerateResultListFilterAttribute(Type sourceType, Type destinationType)
        {
            _sourceType = sourceType;
            _destinationType = destinationType;
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var model = filterContext.Controller.ViewData.Model;

            var resultListGenericType = typeof(ResultList<>).MakeGenericType(new Type[] { _destinationType });
            var srcGenericType = typeof(List<>).MakeGenericType(new Type[] { _sourceType });
            var destGenericType = typeof(List<>).MakeGenericType(new Type[] { _destinationType });

            var viewModel = Mapper.Map(model, srcGenericType, destGenericType);

            var queryOptions = filterContext.Controller.ViewData.ContainsKey("QueryOptions")
                ? filterContext.Controller.ViewData["QueryOptions"] : new QueryOptions();

            var resultList = Activator.CreateInstance(resultListGenericType, viewModel, queryOptions);

            filterContext.Controller.ViewData.Model = resultList;
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //no implemenation needed right now
        }
    }
}