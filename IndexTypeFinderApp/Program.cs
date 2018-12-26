using System;

namespace IndexTypeFinderApp
{
   class Program
   {

      static void Main(string[] args)
      {
         string publicHtmlPath = @"\xampp\htdocs\public_html";

         ConsoleHelper _consoleHelper = new ConsoleHelper();
         FolderStructure finder = new FolderStructure();
         ConsoleTreePrinter consoleTreePrinter = new ConsoleTreePrinter();
         IndexTypeFinder indexTypeFinder = new IndexTypeFinder();
         IndexUpadater indexUpadater = new IndexUpadater();
         IndexDateFinder indexDateFinder = new IndexDateFinder();

         FolderItem folderItem = finder.Find(publicHtmlPath);
         indexTypeFinder.Find(folderItem, publicHtmlPath);
         indexDateFinder.Find(folderItem, publicHtmlPath);
         consoleTreePrinter.Print(folderItem);

         bool doYouWantToUpdate = _consoleHelper.DoYouWantToUpdate();

         if (doYouWantToUpdate)
         {
            indexUpadater.Update(folderItem, publicHtmlPath);
            indexTypeFinder.Find(folderItem, publicHtmlPath);
            indexDateFinder.Find(folderItem, publicHtmlPath);
            consoleTreePrinter.Print(folderItem);
         }

         Console.ReadLine();
      }
   }
}
