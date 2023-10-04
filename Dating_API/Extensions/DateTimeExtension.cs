using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Dating_API.Extensions
{
    public static class DateTimeExtension
    {
        public static int CalculateAge(this DateOnly dob)
        { 
           var Today=DateOnly.FromDateTime(DateTime.UtcNow);
           var age=Today.Year-dob.Year;
           if(dob>Today.AddYears(-age)) age--;
           return age;
        }
    }
}