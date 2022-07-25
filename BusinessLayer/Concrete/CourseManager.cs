using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CourseManager : ICourseService
    {
        ICourseDal _courseDal;

        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public void TAdd(Course t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Course t)
        {
            throw new NotImplementedException();
        }

        public Course TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Course> TGetList()
        {
            return _courseDal.GetList();
        }

     

        public void TUpdate(Course t)
        {
            throw new NotImplementedException();
        }
    }
}
