using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class JobFieldTypeDisplay
    {
        /**
         * A wrapper class that allows ToString() to access the 
         * Display attribute of JobFieldTypes.
         */

        public JobFieldType Type { get; set; }

        // If the enum has a display name attribute, use that. Otherwise,
        // use the default ToString() result from the enum.
        public override string ToString()
        {
            var displayAttribute = Type.GetAttribute<DisplayAttribute>();
            return displayAttribute == null ? Type.ToString() : displayAttribute.Name;
        }
    }

    public static class Extensions
    {
        /**
         *  An extension method that allows us to get attributes of enums.
         *  
         *  For example, in an enum we can add [Display(Name = "Custom Name")]
         *  and then access this attribute via:
         *  
         *      Type.GetAttribute<DisplayAttribute>().Name
         */
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
                where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }
    }
}
