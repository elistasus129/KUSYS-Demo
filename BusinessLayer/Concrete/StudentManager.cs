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
    public class StudentManager : IStudentService
    {
            IStudentDal _studentDal;

        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public void TAdd(Student t)
        {
            _studentDal.Insert(t);
        }

        public void TDelete(Student t)
        {
            _studentDal.Delete(t);
        }

        public List<Student> TGetList()
        {
            return _studentDal.GetList();
        }

        public Student TGetByID(int id)
        {
            return _studentDal.GetByID(id);
        }

        public void TUpdate(Student t)
        {
            _studentDal.Update(t);
        }

      

        public List<Student> GetBlogsListWithCourse()
        {
            return _studentDal.GetListCourses();
        }

      
    }
}

