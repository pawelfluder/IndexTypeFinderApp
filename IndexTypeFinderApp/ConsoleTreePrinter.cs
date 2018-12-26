using System;

namespace IndexTypeFinderApp
{
   public class ConsoleTreePrinter
   {
      private char _space = ' ';
      private int _numOfSpaces = 2;
      private string _separator = " - ";

      public void Print(FolderItem folderItem)
      {
         Console.WriteLine(folderItem.Name);
         PrintAllSubFolders(folderItem, 0);
      }

      private void PrintAllSubFolders(FolderItem folderItem, int level)
      {
         int nextLevel = level + 1;
         foreach (var subFolderItem in folderItem.SubFolderItems)
         {
            string indentation = new string(_space, _numOfSpaces * nextLevel);
            string line = string.Concat(indentation, subFolderItem.Name, _separator, subFolderItem.Type);
            Console.WriteLine(line);
            PrintAllSubFolders(subFolderItem, nextLevel);
         }
      }
   }
}
