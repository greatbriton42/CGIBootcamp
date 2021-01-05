using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABC.Venture.Service;
using ABC.Venture.DTO;
using ABC.Venture.Common.GridEx;
using ABC.Venture.Web.Models;
using ABC.Venture.Common;

namespace ABC.Venture.Web.Controllers
{
   public class ViewTodayController : Controller
   {
      public ActionResult SideBar()
      {
         return PartialView("_SideBar");
      }
      
      public ActionResult ViewToday()
      {
         return View();
      }

      public ActionResult TrackingItems(TrackingItemsCriteria criteria)
      {
         ViewTodayService service = new ViewTodayService();
         var grid = service.GetUpcomingTrackingItems(criteria);
         grid.Criteria = criteria ?? new TrackingItemsCriteria();
         var vm = grid.Select(x => new ProjectTrackingItemsVM(x));
         var paginate = new PaginateVM<ProjectTrackingItemsDTO, ProjectTrackingItemsVM>(grid, criteria, vm);
         return PartialView("_TrackingItems", paginate);
      }

      public ActionResult UpcomingMilestones(MilestoneCriteria criteria)
      {
         ViewTodayService service = new ViewTodayService();
         var grid = service.GetUpcomingMilestones(criteria);
         grid.Criteria = criteria ?? new MilestoneCriteria();
         var vm = grid.Select(x => new UpcomingMilestonesVM(x));
         var paginate = new PaginateVM<UpcomingMilestoneDTO, UpcomingMilestonesVM>(grid, criteria, vm);
         return PartialView("_MilestoneItems", paginate);
      }

      public ActionResult MyProjectsTable(MyProjectsCriteria criteria)
      {
         ViewTodayService service = new ViewTodayService();
         var grid = service.GetMyProjects(criteria);
         grid.Criteria = criteria ?? new MyProjectsCriteria();
         var vm = grid.Select(x => new MyProjectsVM(x));
         var paginate = new PaginateVM<MyProjectDTO, MyProjectsVM>(grid, criteria, vm);
         paginate.Criteria.Filter = criteria.Filter;
         return PartialView("_MyProjectsTable", paginate);
      }

      /// <summary>
      /// My Projects section of View Today page
      /// </summary>
      /// <returns></returns>
      public ActionResult MyProjects()
      {
         return PartialView("_MyProjects");
      }

      /// <summary>
      /// Displays the temporary empty table under my projects
      /// </summary>
      /// <returns></returns>
      public ActionResult EmptyTable()
      {
         return PartialView("_EmptyTable");
      }

   }
}