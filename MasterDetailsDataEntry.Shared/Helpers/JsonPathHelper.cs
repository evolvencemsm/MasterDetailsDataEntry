﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MasterDetailsDataEntry.Shared
{
    public static class JsonPathHelper
    {
        public static string ReplaceLambdaVar(this string selectorString)
        {
            var result = selectorString.Trim();
            var values = result.Split('.');

            if (values.Length > 0)
            {
                result = result.Substring(values[0].Length + 1);
            }

            return result;
        }

        public static void SetPropertyValue(this object target, string bindingProperty, object value)
        {
            var property = target.GetType().GetProperty(bindingProperty);
            object convertedValue = value;

            try
            {
                switch (property.PropertyType.Name)
                {
                    case "Int32":
                        convertedValue = Convert.ToInt32(value);
                        break;

                    case "Decimal":
                        convertedValue = Convert.ToDecimal(value);
                        break;
                }

                property.SetValue(target, convertedValue);
            }
            catch (FormatException fexc)
            { }
        }

        public static object GetPropertyValue(this object target, string bindingProperty)
        {
            var property = target.GetType().GetProperty(bindingProperty);
            var result = property.GetValue(target);
            return result;
        }
    }
}
