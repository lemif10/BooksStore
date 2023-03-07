using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Books.Common.Models.Books
{
    public class BookFilter
    {
        [DefaultValue("")]
        public string Name { get; set; }

        [DefaultValue("")]
        public string Author { get; set; }

        [DefaultValue(0)]
        [Range(0, 2024)]
        public int Year { get; set; }

        [DefaultValue(0)]
        [Range(0, 12)]
        public int Month { get; set; }

        [DefaultValue(0)]
        [Range(0, 31)]
        public int Day { get; set; }
    }
}
