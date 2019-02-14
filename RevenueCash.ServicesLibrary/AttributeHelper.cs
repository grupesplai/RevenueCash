﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueCash.ServicesLibrary
{
    public class AttributeHelper
    {
        public static List<string> GetDataNames(Type type, string propertyName)
        {
            var property = type.GetProperty(propertyName).GetCustomAttributes(false).Where(x => x.GetType().Name == "DataNamesAttribute").FirstOrDefault();
            if (property != null)
            {
                return ((DtaNamesAttribute)property).ValueNames;
            }
            return new List<string>();
        }
    }
}
