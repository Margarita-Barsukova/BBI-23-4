

using System;
using System.Collections.Generic;

abstract class Book
{
    public string Title { get; set; }
    public double Price { get; protected set; }
    public abstract void CalculatePrice();

    protected Book(string title)
    {
        Title = title;
    }
}

class PaperBook : Book
{
    public bool HardCover { get; set; }

    public PaperBook(string title, bool hardCover) : base(title)
    {
        HardCover = hardCover;
        CalculatePrice();
    }

    public override void CalculatePrice()
    {
        Price = HardCover ? 20 : 15;
    }
}

class ElectronicBook : Book
{
    public string Format { get; set; }

    public ElectronicBook(string title, string format) : base(title)
    {
        Format = format;
        CalculatePrice();
    }

    public override void CalculatePrice()
    {
        Price = Format switch
        {
            "pdf" => 10,
            "fb2" => 8,
            "epub" => 12,
            _ => 5
        };
    }
}

class AudioBook : Book
{
    public bool StudioRecording { get; set; }

    public AudioBook(string title, bool studioRecording) : base(title)
    {
        StudioRecording = studioRecording;
        CalculatePrice();
    }

    public override void CalculatePrice()
    {
        Price = StudioRecording ? 25 : 20;
    }
}

class Program
{
    static void Main()
    {
        List<Book> paperBooks = new List<Book>
        {
            new PaperBook("Paper Book 1", true),
            new PaperBook("Paper Book 2", false),
            new PaperBook("Paper Book 3", true),
            new PaperBook("Paper Book 4", false),
            new PaperBook("Paper Book 5", true)
        };

        List<Book> electronicBooks = new List<Book>
        {
            new ElectronicBook("Electronic Book 1", "pdf"),
            new ElectronicBook("Electronic Book 2", "fb2"),
            new ElectronicBook("Electronic Book 3", "epub"),
            new ElectronicBook("Electronic Book 4", "pdf"),
            new ElectronicBook("Electronic Book 5", "fb2")
        };

        List<Book> audioBooks = new List<Book>
        {
            new AudioBook("Audio Book 1", true),
            new AudioBook("Audio Book 2", false),
            new AudioBook("Audio Book 3", true),
            new AudioBook("Audio Book 4", false),
            new AudioBook("Audio Book 5", true)
        };

        Console.WriteLine("Paper Books:");
        PrintBooks(paperBooks);

        Console.WriteLine("Electronic Books:");
        PrintBooks(electronicBooks);

        Console.WriteLine("Audio Books:");
        PrintBooks(audioBooks);

        List<Book> allBooks = new List<Book>();
        allBooks.AddRange(paperBooks);
        allBooks.AddRange(electronicBooks);
        allBooks.AddRange(audioBooks);

        Console.WriteLine("All Books:");
        PrintBooks(allBooks);
    }

    static void PrintBooks(List<Book> books)
    {
        CustomSort(books);

        Console.WriteLine("{0,-20} {1,10}", "Title", "Price");
        foreach (var book in books)
        {
            Console.WriteLine("{0,-20} {1,10:C}", book.Title, book.Price);
        }
        Console.WriteLine();
    }

    static void CustomSort(List<Book> books)
    {
        for (int i = 0; i < books.Count - 1; i++)
        {
            for (int j = i + 1; j < books.Count; j++)
            {
                if (books[i].Price < books[j].Price)
                {
                    var temp = books[i];
                    books[i] = books[j];
                    books[j] = temp;
                }
            }
        }
    }
}




