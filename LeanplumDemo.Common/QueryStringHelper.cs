﻿using System;
using System.Collections.Generic;

namespace LeanplumDemo.Common
{
    public class QueryStringHelper
    {
        public static Dictionary<string, string> ParseQueryString(string query)
		{
            var parameters = new Dictionary<string, string>();
            if(string.IsNullOrWhiteSpace(query))
            {
                return parameters;
            }

            var items = query.Split(new[] { "&" }, StringSplitOptions.None);
            if(items == null || items.Length == 0)
            {
                return parameters;
            }

            foreach (var item in items)
            {
                var entry = item.Split(new[] { "=" }, StringSplitOptions.None);
                if(entry.Length != 2)
                {
                    continue;
                }
                parameters.Add(entry[0], entry[1]);
            }
            return parameters;
		}

		public static Dictionary<string, string> ParseQueryStringForAndroid(String query)
		{
			var parameters = new Dictionary<string, string>();
			if (string.IsNullOrWhiteSpace(query))
			{
				return parameters;
			}

			var items = query.Split(new[] { "===" }, StringSplitOptions.None);
			if (items == null || items.Length == 0)
			{
				return parameters;
			}

			foreach (var item in items)
			{
				var entry = item.Split(new[] { "=" }, StringSplitOptions.None);
				if (entry.Length != 2)
				{
					continue;
				}
				parameters.Add(entry[0], entry[1]);
			}
			return parameters;
		}
    }
}
