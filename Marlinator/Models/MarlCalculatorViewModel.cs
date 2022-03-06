using CsvHelper.Configuration.Attributes;
using Marlinator.Data.Yarn;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Marlinator.Models
{
    public class MarlCalculatorViewModel
    {
        public List<SelectListItem> YarnWeightOptions { get; set; }
        [Name("Yarn 1")]
        public int? Yarn1 { get; set; }
        [Name("Yarn 2")]
        public int? Yarn2 { get; set; }
        [Name("Yarn 3")]
        public int? Yarn3 { get; set; }

        public List<YarnWeight> YarnWeightResults { get; set; }
    }
}