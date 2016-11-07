using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture]
    class CustomerExpansionTests
    {
        [TestCase("Ivan", "11111111", 0.5, "P", Result = "11111111")]
        [TestCase("Ivan", "11111111", 0.5, "NP", Result = "Ivan , 11111111")]
        [TestCase("Ivan", "11111111", 0.5, "PN", Result = "11111111 , Ivan")]
        public string Format_returnString(string Name, string Phone, decimal Revenue, string format)
        {
            IFormatProvider formatProvider = CultureInfo.CurrentCulture;
            Customer customer = new Customer(Name, Phone, Revenue);
            CustomerExpansion customerEx = new CustomerExpansion();

            return customerEx.Format(format, customer, formatProvider);
        }
    }
}
