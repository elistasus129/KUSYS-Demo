using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace UI_Mvc.Controllers
{
    public class StudentController : Controller
    {
        StudentManager studentManager = new StudentManager(new EfStudentDal());
        CourseManager courseManager = new CourseManager(new EfCourseDal());

        /// <summary>
        ///  Index metodu öğrencileri listeler
        /// </summary>
       
        public IActionResult Index()
        {
            var values = studentManager.TGetList();
            return View(values);
        }

        [HttpGet]
        /// <summary>
        ///  AddStudent 
        /// </summary>
        public IActionResult AddStudent()
        {
            return View();
        }

        /// <summary>
        ///  AddStudent metodu post işlemi öğrenci kaydedilir.Koşullar sağlanmaz ise validation ile hata verir.
        /// </summary>
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            StudentValidator validations = new StudentValidator();
            ValidationResult results = validations.Validate(student);
            if (results.IsValid)
            {
                studentManager.TAdd(student);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }
        /// <summary>
        ///  DeleteStudent metodu ile öğrenci silme işlemi yapılır
        /// </summary>

        public IActionResult DeleteStudent(int id)
        {
            var values = studentManager.TGetByID(id);
            studentManager.TDelete(values);
            return RedirectToAction("Index");
        }

        /// <summary>
        ///  EditStudent metodu get ile öğrenci verilerini alır.
        /// </summary>
        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            var getcourse = courseManager.TGetList();
            List<SelectListItem> degerler = (from i in getcourse
                                             select new SelectListItem
                                             {
                                                 Text = i.CourseName,
                                                 Value = i.CourseId.ToString()
                                             }).ToList();

            ViewBag.courses = degerler;
            var values = studentManager.TGetByID(id);          
            return View(values);
        }

        /// <summary>
        ///  EditStudent metodu ile get işlemi sonra ilgili değişiklikler yapılırsa güncelleme yapışır
        /// </summary>
        [HttpPost]
        public IActionResult EditStudent(Student student)
        {
            StudentValidator validations = new StudentValidator();
            ValidationResult results = validations.Validate(student);
            if (results.IsValid)
            {
                studentManager.TUpdate(new Student { 
                StudentId = student.StudentId,  
                FirstName=student.FirstName,    
                LastName=student.LastName,
                BirthDate=student.BirthDate,
                CourseId= student.CourseId 
                
                });
                
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
       
        }

        /// <summary>
        ///  CourseAssignStudent metodu ile ilgili sayfada ders atama için dropdownlistte kursları çeker.
        /// </summary>

        [HttpGet]
        public IActionResult CourseAssignStudent(int id)
        {
            var values = studentManager.TGetByID(id);
            var getcourse = courseManager.TGetList();
            List<SelectListItem> degerler = (from i in getcourse
                                             select new SelectListItem
                                                {
                                            Text = i.CourseName,
                                            Value = i.CourseId.ToString()
                                            }). ToList();

            ViewBag.courses=degerler;

            return View(values);
        }

        /// <summary>
        ///  CourseAssignStudent metodu ile ilgili kursun ataması yapılır.
        /// </summary>
        [HttpPost]
        public IActionResult CourseAssignStudent(Student student)
        {         
                studentManager.TUpdate(new Student {
                    StudentId = student.StudentId,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    BirthDate = student.BirthDate,
                    CourseId = student.CourseId 
                });
                return RedirectToAction("Index");
    
        }


        /// <summary>
        ///  GetListWithCourses metodu ile ilgili öğrenci ve kursların eşleşmesi getirilir.
        /// </summary>
        public IActionResult GetListWithCourses()
        {
            var values = studentManager.GetBlogsListWithCourse();
            return View(values);
        }

        /// <summary>
        ///  StudentDetails metodu ile ilgili öğrenci ve kursların eşleşmesi getirilir.
        /// </summary>
        [HttpPost]
        public IActionResult StudentDetails(int id){

           
            var values = studentManager.TGetList().FirstOrDefault(x => x.StudentId == id);
            return Json(values);
        }
    }
}

