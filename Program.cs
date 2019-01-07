using System;
using library.Models;
using System.Collections.Generic;

namespace library
{
  class Program
  {
    static void Main(string[] args)
    {
      bool inLibrary = true;
      Enum activeMenu = Menus.CheckoutBook;

      Console.Clear();

      Console.WriteLine("Welcome to the library");

      Book whereTheSidewalkEnds = new Book("Where The Sidewalk Ends", "Shel Silverstein");
      Book theGivingTree = new Book("The Giving Tree", "Shel Silverstein");
      Book hp = new Book("Harry Potter", "JK Rowling");

      Library lib = new Library("My Library");
      lib.Books.Add(whereTheSidewalkEnds);
      lib.Books.Add(theGivingTree);
      lib.Books.Add(hp);

      lib.AddBook(new Book("Clean Code", "Something Martin"));

      while (inLibrary)
      {
        switch (activeMenu)
        {
          case Menus.CheckoutBook:
            Console.WriteLine("\nAvailable");
            lib.PrintBooks();
            break;
          case Menus.ReturnBook:
            Console.WriteLine("Checked out");
            lib.PrintCheckedOut();
            break;
        }

        string selection = Console.ReadLine();
        // lib.Checkout(selection);

        switch (selection)
        {
          case "return":
            Console.Clear();
            activeMenu = Menus.ReturnBook;
            break;
          case "available":
            Console.Clear();
            activeMenu = Menus.CheckoutBook;
            break;
          default:
            if (activeMenu.Equals(Menus.CheckoutBook))
            {
              lib.Checkout(selection);
            }
            else
            {
              lib.ReturnBook(selection);
            }
            break;
        }

        // lib.PrintBooks();
        // lib.PrintCheckedOut();
        // Console.ReadLine();
      }
    }
    public enum Menus
    {
      CheckoutBook,
      ReturnBook

    }
  }
}
