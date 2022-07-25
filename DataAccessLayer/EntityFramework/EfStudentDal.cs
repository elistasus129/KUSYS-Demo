using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfStudentDal : GenericRepository<Student>, IStudentDal
    {
        public List<Student> GetListCourses()
        {
            using (var c = new Context())
            {
                return c.Students.Include(x => x.Course).ToList();
            }
        }

     
    }
}
