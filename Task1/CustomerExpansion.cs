using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class CustomerExpansion : ICustomFormatter, IFormatProvider
    {
        public IFormatProvider Parent { get; private set; }

        public CustomerExpansion() : this(CultureInfo.CurrentCulture)
        {

        }

        public CustomerExpansion(IFormatProvider parent)
        {
            if (parent != null)
                Parent = parent;
            else
                Parent = CultureInfo.CurrentCulture;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null || format != "PN")
                return string.Format(Parent, "{0:" + format + "}", arg);

            var customer = arg as Customer;
            if (customer != null)
                return customer.ContactPhone.ToString(formatProvider) + " , " + customer.Name.ToString(formatProvider);

            string returnedSring = String.Empty;
            if (arg is IFormattable)
                returnedSring = ((IFormattable)arg).ToString(format, formatProvider);
            else
                returnedSring = arg.ToString();

            return returnedSring;
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;

            return null;
        }
    }
}
