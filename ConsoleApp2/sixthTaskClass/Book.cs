using System;

namespace ConsoleApp2.sixthTaskClass
{
    class Book
    {
        public string Title { get; }
        public string Author { get; }
        public decimal Price { get; }
        public string Isbn { get; }

        public Book(string title, string author, decimal price, string isbn)
        {
            Title = title;
            Author = author;
            Price = price;
            Isbn = isbn;
        }

        public override string ToString()
        {
            return string.Format("{0,-30} {1,-20} {2,8:F2} ₽  ISBN: {3}", Title, Author, Price, Isbn);
        }
    }
}
