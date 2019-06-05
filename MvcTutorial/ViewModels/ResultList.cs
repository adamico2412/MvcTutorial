﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTutorial.ViewModels
{
    public class ResultList<T>
    {
        public ResultList(List<T> results, QueryOptions queryOptions)
        {
            Results = results;
            QueryOptions = queryOptions;
        }

        [JsonProperty(PropertyName ="queryOptions")]
        public QueryOptions QueryOptions { get; set; }

        [JsonProperty(PropertyName ="results")]
        public List<T> Results { get; set; }
    }
}