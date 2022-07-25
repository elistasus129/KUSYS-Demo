using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI_Mvc.Controllers
{   
    public class CourseController : Controller
    {
        CourseManager courseManager = new CourseManager(new EfCourseDal());
        /// <summary>
        ///  Index metodu ile ilgili tüm kurslar listelenir.
        /// </summary>
        public IActionResult Index()
        {
            var values = courseManager.TGetList();
            return View(values);
        }
    }
}
