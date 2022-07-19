using System.ComponentModel.DataAnnotations;

namespace GYM.Models
{
    public class IPLocation
    {
        [Key]
        public int Id { get; set; }
        public string @as { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public string isp { get; set; }
        public double? lat { get; set; }
        public double? lon { get; set; }
        public string org { get; set; }
        public string query { get; set; }
        public string region { get; set; }
        public string regionName { get; set; }
        public string status { get; set; }
        public string timezone { get; set; }
        public string zip { get; set; }
    }
}
