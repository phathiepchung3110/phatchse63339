
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
   public  interface IStudentService:IBaseService<Student,int>
    {
        Student InsertApply(Student _entity);
    }
    public class StudentService : BaseService<Student, int>, IStudentService
    {
        public StudentService(SWDContext context) : base(context){

        }
        public Student InsertApply(Student _entity)
        {
            return Insert(_entity);
        }
    }
}
