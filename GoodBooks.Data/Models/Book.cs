﻿using System;

namespace GoodBooks.Data
{
    public class Book
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime Updated { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
