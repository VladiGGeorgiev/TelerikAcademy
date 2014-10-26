using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PracticalExam.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ShouldNotContainHtmlAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            if (valueAsString == null)
            {
                return false;
            }

            if (Regex.IsMatch(valueAsString, @"<([A-Z][A-Z0-9]*)\b[^>]*>(.*?)</\1>"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
