using System.ComponentModel.DataAnnotations.Schema;
using P03.Models;

namespace P03
{
    public class Town
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        [ForeignKey(nameof(Country))]
        public int? CountryCode { get; set; }

        public Country? Country { get; set; }
    }
}

