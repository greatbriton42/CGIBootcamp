using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Venture.Common
{
   /// <summary>
   /// Class containing all Enums used in this project
   /// </summary>
   public static class EnumTypes
   {
      /// <summary>
      /// Project Rating Color options defined by Business Rules (6.3.9 Venture_System Requirements Specification.docx)
      /// White is being used if no value can be determined with the data given
      /// </summary>
      public enum ProjectRatingColor { Gray, Green, Yellow, Red, Blue, White}

      /// <summary>
      /// Project Rating Color options defined by Business Rules (9.2.4 Venture_System Requirements Specification.docx)
      /// White is being used if no value can be determined with the data given
      /// </summary>
      public enum ProjectHealthColor { Green = 1, Yellow = 2, Red = 3, White = 0 }
      public enum ProjectRatingText { Both, Schedule, Budget, Empty }
      /// <summary>
      /// Project Statuses from the Status table
      /// </summary>
      public enum ProjectStatus { Pending = 1, Active = 2, Complete = 3, OnHold = 4, Cancelled = 5}
      public enum StatusUpdateFlag { Green, Yellow, Red, None }
      /// <summary>
      /// Standard Milestones Option from the Standard Milestone Table
      /// </summary>
      public enum StandardMilestonesOptions
      {
         Define = 1, Requirements = 2, Design = 3,
         Approval = 4, Coding = 5, Testing = 6,
         Implementation = 7, Close = 8
      }
   }
}
