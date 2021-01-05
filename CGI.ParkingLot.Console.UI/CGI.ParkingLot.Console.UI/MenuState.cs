using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGI.ParkingLot.ConsoleApp.UI
{
   /// <summary>
   /// Base class used for all screens or states of the menu
   /// </summary>
   abstract class MenuState
   {
      protected const int WIDTHOFTITLE = 70;

      /// <summary>
      /// Takes in a string and centers within a box of '*'
      /// Issues: Cannot take in a string larger then WIDTHOFTITLE
      /// Only supports one title line in the box
      /// </summary>
      /// <param name="headingTitle"></param>
      protected void PrintHeading(string headingTitle)
      {
         //Print the top row of '*'
         for(int i = 0;i < WIDTHOFTITLE;i++)
         {
            Console.Write('*');
         }
         Console.Write("\n");

         //Print the title
         StringBuilder title = new StringBuilder();

         title.Append(headingTitle.PadLeft((int)(((WIDTHOFTITLE - 2) / 2) + ((int)headingTitle.Length / 2))));
         title.Append(new string(' ', (WIDTHOFTITLE - 2) - (headingTitle.Length / 2) - (int)((WIDTHOFTITLE - 2) / 2)));
         Console.WriteLine("*" + title + "*");

         //Print the bottom row of '*'
         for(int i = 0;i < WIDTHOFTITLE;i++)
         {
            Console.Write('*');
         }
         Console.WriteLine();
      }

      /// <summary>
      /// Print out a menu for the user to select from
      /// </summary>
      /// <param name="menuItems">A string for each individual item you want listed</param>
      protected void PrintMenu(params string[] menuItems)
      {
         StringBuilder menu = new StringBuilder();
         int count = 0;
         foreach(string item in menuItems)
         {
            if(count % 2 == 0)
            {
               menu.Append("\n ");
            }
            menu.Append(item.PadRight(WIDTHOFTITLE / 2));
            count++;
         }
         Console.WriteLine(menu);
      }

      /// <summary>
      /// Asks user for a time. Verifies time is valid
      /// </summary>
      /// <returns></returns>
      protected DateTime? GetDateTime()
      {
         DateTime time;
         Console.Write("Enter new time (mm/dd/yyyy hh:mm:ss am/pm): ");
         var input = Console.ReadLine();

         if(string.IsNullOrEmpty(input))
         {
            return null;
         }
         else
         {
            while(!DateTime.TryParse(input, out time))
            {
               Console.WriteLine("Invalid Time");
               Console.Write("Enter new time (mm/dd/yyyy hh:mm:ss am/pm): ");
               input = Console.ReadLine();
            }
         }
         return (DateTime?)time;
      }

      /// <summary>
      /// Entry point for all child classes. Should be overridden
      /// </summary>
      /// <returns></returns>
      public abstract MenuState Start();
   }
}
