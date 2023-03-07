﻿namespace Books.Common.Models.Books
{
    public class BookDTO
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public decimal Price { get; set; }
    }
}
