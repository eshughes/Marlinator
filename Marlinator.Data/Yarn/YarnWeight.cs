using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marlinator.Data.Yarn
{
    public class YarnWeight
    {
        public int Id { get; set; }
        [Name("Name")]
        public string FriendlyName { get; set; }
        [Name("Minimum Meters Per 100g")]
        public int MinimumMetersPer100g { get; set; }
        [Name("Maximum Meters Per 100g")]
        public int MaximumMetersPer100g { get; set; }
    }
}
