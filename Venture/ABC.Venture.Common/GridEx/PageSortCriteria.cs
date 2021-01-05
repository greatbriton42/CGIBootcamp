using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Venture.Common.GridEx
{
   /// <summary>
   /// Stores paging and sorting information.
   /// </summary>
   public abstract class PageSortCriteria
   {

      /// <summary>
      /// Current page number.
      /// </summary>
      public int? Page { get; set; }

      /// <summary>
      /// Column to sort with. 
      /// <remarks>
      /// This value must match entity's property name to generate orderby clause.
      /// </remarks>
      /// </summary>
      public string Sort { get; set; }

      /// <summary>
      /// Sort direction.
      /// </summary>
      public string  Order { get; set; }

      /// <summary>
      /// Search string to generate where clause.
      /// </summary>
      public virtual string Filter { get; set; }

      /// <summary>
      /// Total number of subsets within the superset.
      /// </summary>
      /// <value>
      /// Total number of subsets within the superset.
      /// </value>
      public int PageCount { get; private set; }

      /// <summary>
      /// Total number of objects contained within the superset.
      /// </summary>
      /// <value>
      /// Total number of objects contained within the superset.
      /// </value>
      public int TotalItemCount { get; private set; }

      /// <summary>
      /// Zero-based index of this subset within the superset.
      /// </summary>
      /// <value>
      /// Zero-based index of this subset within the superset.
      /// </value>
      public int PageIndex { get; private set; }


      /// <summary>
      /// Maximum size any individual subset.
      /// </summary>
      /// <value>
      /// Maximum size any individual subset.
      /// </value>
      public int PageSize { get; private set; }

      /// <summary>
      /// Returns true if this is NOT the first subset within the superset.
      /// </summary>
      /// <value>
      /// Returns true if this is NOT the first subset within the superset.
      /// </value>
      public bool HasPreviousPage { get; private set; }

      /// <summary>
      /// Returns true if this is NOT the last subset within the superset.
      /// </summary>
      /// <value>
      /// Returns true if this is NOT the last subset within the superset.
      /// </value>
      public bool HasNextPage { get; private set; }

      /// <summary>
      /// Returns true if this is the first subset within the superset.
      /// </summary>
      /// <value>
      /// Returns true if this is the first subset within the superset.
      /// </value>
      public bool IsFirstPage { get; private set; }

      /// <summary>
      /// Returns true if this is the last subset within the superset.
      /// </summary>
      /// <value>
      /// Returns true if this is the last subset within the superset.
      /// </value>
      public bool IsLastPage { get; private set; }
      public void UpdateFromGrid<T>(IGrid<T> grid)
      {
         IsFirstPage = grid.IsFirstPage;
         IsLastPage = grid.IsLastPage;
         PageCount = grid.PageCount;
         HasNextPage = grid.HasNextPage;
         HasPreviousPage = grid.HasPreviousPage;
         PageSize = grid.PageSize;
         PageIndex = grid.PageIndex;
         TotalItemCount = grid.TotalItemCount;
      }
   }
}
