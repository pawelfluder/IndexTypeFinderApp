using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IndexTypeFinderApp
{
   public class IndexTypeFinder
   {
      public void Find(FolderItem folderItem, string path)
      {
         FindRecursively(folderItem, path);
      }

      private void FindRecursively(FolderItem folderItem, string path)
      {
         if (CheckIfFolderExists(folderItem, path))
         {
            TypeProvider.IndexType type = GetType(path);
            folderItem.ChangeType(type);
            foreach (var subFolderItem in folderItem.SubFolderItems)
            {
               string subFolderPath = string.Concat(path, @"\", subFolderItem.Name);
               FindRecursively(subFolderItem, subFolderPath);
            }
         }
      }

      private bool CheckIfFolderExists(FolderItem folderItem, string path)
      {
         bool fileExists = Directory.Exists(path);
         bool correctName = Path.GetFileName(path) == folderItem.Name;
         if (fileExists && correctName)
         {
            return true;
         }

         return false;
      }

      private TypeProvider.IndexType GetType(string folderPath)
      {
         string indexPath = string.Concat(folderPath, @"\", "index.php");
         string[] lines = System.IO.File.ReadAllLines(indexPath);
         List<string> foundLines = new List<string>();

         foreach (string line in lines)
         {
            if (line.Contains("$typeName = ") ||
                line.Contains("$typeOfIndex = "))
            {
               foundLines.Add(line);
            }
         }

         if (foundLines.Count == 1)
         {
            MatchCollection matches = Regex.Matches(foundLines[0], "\"([^\"]*)\"");
            string type = matches[0].Value.TrimStart('"').TrimEnd('"').TrimEnd('\\').TrimEnd('/');
            Enum.TryParse(type, out TypeProvider.IndexType indexTypeEnum);

            return indexTypeEnum;
         }

         return TypeProvider.IndexType.unknown;
      }
   }
}
