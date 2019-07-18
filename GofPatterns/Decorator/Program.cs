using System;
using System.Collections.Generic;

namespace Decorator
{
    // The Component
    abstract class LibraryItem
    {
        private int numCopies;

        // Property
        public int NumCopies
        {
            get { return numCopies; }
            set { numCopies = value; }
        }

        public abstract void Display();
    }

    // The ConcreteComponent1
    class Book : LibraryItem
    {
        private string author;
        private string title;

        public Book(string author, string title, int numCopies)
        {
            this.author = author;
            this.title = title;
            this.NumCopies = numCopies;
        }

        public override void Display()
        {
            Console.WriteLine("Book ------ ");
            Console.WriteLine("Author: {0}", author);
            Console.WriteLine("Title: {0}", title);
            Console.WriteLine("Copies: {0}", NumCopies);
        }
    }

    // The ConcreteComponent2
    class Video : LibraryItem
    {
        private string director;
        private string title;
        private int playTime;

        public Video(string director, string title,
          int numCopies, int playTime)
        {
            this.director = director;
            this.title = title;
            this.NumCopies = numCopies;
            this.playTime = playTime;
        }

        public override void Display()
        {
            Console.WriteLine("Video ----- ");
            Console.WriteLine("Director: {0}", director);
            Console.WriteLine("Title: {0}", title);
            Console.WriteLine("Copies: {0}", NumCopies);
            Console.WriteLine("Playtime: {0}", playTime);
        }
    }

    // The Decorator
    abstract class Decorator : LibraryItem
    {
        protected LibraryItem libraryItem;

        public Decorator(LibraryItem libraryItem)
        {
            this.libraryItem = libraryItem;
        }

        public override void Display()
        {
            libraryItem.Display();
        }
    }

    // The ConcreteDecorator
    class Borrowable : Decorator
    {
        protected List<string> borrowers = new List<string>();

        public Borrowable(LibraryItem libraryItem)
            : base(libraryItem)
        {
        }

        public void BorrowItem(string name)
        {
            borrowers.Add(name);
            libraryItem.NumCopies--;
        }

        public void ReturnItem(string name)
        {
            borrowers.Remove(name);
            libraryItem.NumCopies++;
        }

        public override void Display()
        {
            base.Display();

            foreach (string borrower in borrowers)
            {
                Console.WriteLine("Borrower: " + borrower);
            }
        }
    }

    // The Application
    public class Program
    {
        public static void Main()
        {
            // Create book
            Book book = new Book("Worley", "Inside ASP.NET", 10);
            book.Display();

            // Create video
            Video video = new Video("Spielberg", "Jaws", 23, 92);
            video.Display();

            // Make video borrowable, then borrow and display
            Console.WriteLine("Making video borrowable:");

            Borrowable borrowVideo = new Borrowable(video);
            borrowVideo.BorrowItem("Customer #1");
            borrowVideo.BorrowItem("Customer #2");

            borrowVideo.Display();
        }
    }
}
