using System;
using System.Collections.Generic;

namespace library.Models
{
  public class Library
  {
    public string Name { get; set; }
    public List<Book> Books { get; set; }
    public List<Book> CheckedOut { get; set; }


    public Library(string name)
    {
      Name = name;
      Books = new List<Book>();
      CheckedOut = new List<Book>();
    }
    public void PrintBooks()
    {
      for (int i = 0; i < Books.Count; i++)
      {
        Console.WriteLine($"{i + 1} {Books[i].Title} - {Books[i].Author}");
        Console.WriteLine();
      };
    }

    public void PrintCheckedOut()
    {
      for (int i = 0; i < CheckedOut.Count; i++)
      {
        Console.WriteLine($"{i + 1} {CheckedOut[i].Title} - {CheckedOut[i].Author} is checked out");
        Console.WriteLine();
      }
    }

    public void AddBook(Book book)
    {
      Books.Add(book);
    }
    private Book ValidateUserSelection(string selection, List<Book> books)
    {
      int bookIndex;
      bool valid = Int32.TryParse(selection, out bookIndex);
      if (!valid || bookIndex < 0 || bookIndex > books.Count)
      {
        Console.Clear();
        Console.WriteLine("Please make a valid selection");
        return null;
      }
      return books[bookIndex - 1];
    }

    public void Checkout(string selection)
    {
      Book selectedBook = ValidateUserSelection(selection, Books);
      if (selectedBook == null)
      {
        Console.Clear();
        System.Console.WriteLine(@"Invalid Selection");
        return;
      }
      else
      {
        selectedBook.IsAvailable = false;
        Books.Remove(selectedBook);
        CheckedOut.Add(selectedBook);
        Console.WriteLine("Book successfully checked out!");
      }
    }
    public void ReturnBook(string selection)
    {
      Book selectedBook = ValidateUserSelection(selection, CheckedOut);
      if (selectedBook == null)
      {
        System.Console.WriteLine(@"Invalid Selection, please make a valid selection");
        return;
      }
      selectedBook.IsAvailable = true;
      Books.Add(selectedBook);
      CheckedOut.Remove(selectedBook);
      Console.Clear();
      System.Console.WriteLine("Sucessfully returned book!");
    }
  }
}
