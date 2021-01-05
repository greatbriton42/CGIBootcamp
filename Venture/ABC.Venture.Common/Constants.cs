using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Venture.Common
{
   /// <summary>
   /// All section are from Venture_System Requirements Specification
   /// </summary>
   public class Constants
   {
      /// <summary>
      /// 6.1.3 All dates in the solution will be in MM/DD/YYYY format
      /// </summary>
      public const string DATE_FORMAT = "{0:MM/dd/yyyy}";
      /// <summary>
      /// RFC from client 7/16/19
      /// </summary>
      public const int MAX_RECORDS_PER_TABLE = 15;
      /// <summary>
      /// 6.2.9 Status Update Flags rule
      /// </summary>
      public const int WITHIN_GREEN_STATUS_FLAG_DAYS = 7;
      /// <summary>
      /// 6.2.9 Status Update Flags rule
      /// </summary>
      public const int WITHIN_YELLOW_STATUS_FLAG_DAYS = 14;
      /// <summary>
      /// 6.3.9 Calculate Project Rating Color
      /// </summary>
      public const int MONTHS_AFTER_BASELINE_FINISH = 6;
      /// <summary>
      /// 6.3.9 Calculate Project Rating Color
      /// </summary>
      public const decimal APPROVED_CAPITAL_MULTIPLIER = 1.1M;
      /// <summary>
      /// 6.2.7 Maximum Results
      /// </summary>
      public const int MAX_SEARCH_RESULTS = 25;
      /// <summary>
      /// 6.2.9 Project Tracking Items
      /// </summary>
      public const int DAYS_TILL_TRACKINGITEMS_DUE = 7;
      /// <summary>
      /// 6.2.9 Upcoming Milestone
      /// </summary>
      public const int DAYS_TILL_MILESTONES_DUE = 14;
   }
}
