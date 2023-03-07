using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Books.Common.Models.Orders
{
    public class OrderFilter
    {
        [DefaultValue(0)]
        [Range(0, 2024)]
        public int Year { get; set; }

        [DefaultValue(0)]
        [Range(0, 12)]
        public int Month { get; set; }

        [DefaultValue(0)]
        [Range(0, 31)]
        public int Day { get; set; }

        [DefaultValue(-1)]
        [Range(-1, 23)]
        public int Hour { get; set; }

        [DefaultValue(-1)]
        [Range(-1, 59)]
        public int Minute { get; set; }
    }
}
