using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexTypeFinderApp
{
   class Program
   {
      static void Main(string[] args)
      {
         string publicHtmlPath = @"\xampp\htdocs\public_html";

         IndexTypeFinder finder = new IndexTypeFinder();
         FolderItem folderItem = finder.Find(publicHtmlPath);

         ConsoleTreePrinter consoleTreePrinter = new ConsoleTreePrinter();
         consoleTreePrinter.Print(folderItem);

         Console.ReadLine();
      }
   }
}
