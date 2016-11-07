using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Customer : IFormattable
    {
        public string Name { get; private set; }
        public string ContactPhone { get; private set; }
        public decimal Revenue { get; private set; }

        public Customer(string name, string contactPhone, decimal revenue)
        {
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        }

        public override string ToString()
        {
            return this.ToString("G", CultureInfo.CurrentCulture);
        }

        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (ReferenceEquals(format, null))
                format = "G";
            if (ReferenceEquals(formatProvider, null))
                formatProvider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "G":
                case "NPR":
                    return Name.ToString(formatProvider) + " , " + ContactPhone.ToString(formatProvider) + " , " + Revenue.ToString("G", formatProvider);
                case "N":
                    return Name.ToString(formatProvider);
                case "P":
                    return ContactPhone.ToString(formatProvider);
                case "R":
                    return Revenue.ToString("G", formatProvider);
                case "NP":
                    return Name.ToString(formatProvider) + " , " + ContactPhone.ToString(formatProvider);
                case "PR":
                    return ContactPhone.ToString(formatProvider) + " , " + Revenue.ToString("G", formatProvider);
                case "NR":
                    return Name.ToString(formatProvider) + " , " + Revenue.ToString("G", formatProvider);
                default:
                    throw new FormatException(String.Format("The {0} format string isn't supported", format));
            }
        }
    }
}
