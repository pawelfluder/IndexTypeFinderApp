using System.Collections.Generic;
using System.IO;

namespace IndexTypeFinderApp
{
   public class FolderItem
   {
      public string Name { get; }
      public List<FolderItem> SubFolderItems { get; }
      public TypeProvider.IndexType Type { get; private set; }
      public Date SourceDate { get; private set; }

      public FolderItem(string name)
      {
         Name = name;
         SubFolderItems = new List<FolderItem>();
         Type = TypeProvider.IndexType.unknown;
         SourceDate = new Date();
      }

      public void AddSubFolders(string[] subFoldersNames)
      {
         foreach (var subFolderName in subFoldersNames)
         {
            SubFolderItems.Add(new FolderItem(subFolderName));
         }
      }

      public void ChangeType(TypeProvider.IndexType type)
      {
         Type = type;
      }

      public void ChangeSourceDate(Date sourceDate)
      {
         SourceDate = sourceDate;
      }

      private string[] GetSubFoldersNames(string path)
      {
         string[] subFoldersPaths = Directory.GetDirectories(path);
         List<string> subFoldersNames = new List<string>();
         foreach (var subFoldersPath in subFoldersPaths)
         {
            string subFoldersName = Path.GetFileName(subFoldersPath);
            subFoldersNames.Add(subFoldersName);
         }

         return subFoldersNames.ToArray();
      }
   }
}
