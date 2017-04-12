using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHub.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime datetime;
           var IsValid = DateTime.TryParseExact(Convert.ToString(value),
                "d MMM yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out datetime);
            return (IsValid && datetime > DateTime.Now);
           
        }
    }
    public class ValidTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime datetime;
            var IsValid = DateTime.TryParseExact(Convert.ToString(value),
                 "HH:mm",
                 CultureInfo.CurrentCulture,
                 DateTimeStyles.None,
                 out datetime);
            return (IsValid);

        }
    }
}