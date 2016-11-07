using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using NUnit.Framework;
using Task1;


namespace Task1.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        [TestCase("Ivan", "11111111", 0.5, "P", Result = "11111111")]
        [TestCase("Ivan", "11111111", 0.5, "NP", Result = "Ivan , 11111111")]
        [TestCase("Ivan", "11111111", 0.5, "PR", Result = "11111111 , 0,5")]
        [TestCase("Ivan", "11111111", 0.5, "NR", Result = "Ivan , 0,5")]
        public string ToString_ReturnString(string Name, string Phone, decimal Revenue, string format)
        {
            IFormatProvider formatProvider = CultureInfo.CurrentCulture;
            Customer customer = new Customer(Name, Phone, Revenue);
            return String.Format(formatProvider, "{0:" + format + "}", customer);
        }
    }
}
