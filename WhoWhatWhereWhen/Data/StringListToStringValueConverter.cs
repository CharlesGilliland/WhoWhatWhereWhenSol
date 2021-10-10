using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWhatWhereWhen.Data
{
    public class StringListToStringValueConverter : ValueConverter<IEnumerable<string>, string>
    {
        public StringListToStringValueConverter() : base(le => ListToString(le), (s => StringToList(s)))
        {

        }
        public static string ListToString(IEnumerable<string> value)
        {
            if (value == null || value.Count() == 0)
            {
                return null;
            }

            string output = "";
            foreach(string user in value)
            {
                output += user;
            }
            return output;
        }

        public static IEnumerable<string> StringToList(string value)
        {
            if (value == null || value == string.Empty)
            {
                return null;
            }

            return value.Split(',');

        }
    }
}
