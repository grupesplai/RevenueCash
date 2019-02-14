using System;
using System.Collections.Generic;

namespace RevenueCash.ServicesLibrary
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DtaNamesAttribute : Attribute
    {
        protected List<string> _attributeList { get; set; }

        public List<string> ValueNames
        {
            get
            {
                return _attributeList;
            }
            set
            {
                _attributeList = value;
            }
        }

        public DtaNamesAttribute()
        {
            _attributeList = new List<string>();
        }

        public DtaNamesAttribute(string value)
        {
            _attributeList.Add(value);
        }
    }
}
