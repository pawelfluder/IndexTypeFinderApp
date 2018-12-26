namespace IndexTypeFinderApp
{
   public class Date
   {
      public char[] Year { get; }

      public char[] Month { get; }

      public char[] Day { get; }

      private char _underscore = '_';

      public Date()
      {
         Year = new char[] { '0', '0' };
         Month = new char[] { '0', '0' };
         Day = new char[] { '0', '0' };
      }

      public Date(char[] year, char[] month, char[] day) :base()
      {
         if (year.Length == 2 && AllCharAreDigits(year))
         {
            Year = year;
         }

         if (month.Length == 2 && AllCharAreDigits(year))
         {
            Month = month;
         }

         if (day.Length == 2 && AllCharAreDigits(year))
         {
            Day = day;
         }
      }

      public override string ToString()
      {
         return string.Concat(new string(Year), _underscore,
                              new string(Month), _underscore,
                              new string(Day));
      }

      private bool AllCharAreDigits(char[] array)
      {
         bool areDigits = true;
         foreach (char ch in array)
         {
            if (char.IsDigit(ch) == false)
            {
               areDigits = false;
               break;
            }
         }

         return areDigits;
      }
   }
}