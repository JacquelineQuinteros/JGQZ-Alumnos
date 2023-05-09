using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGQZ.ArqLimpia.EN.Interfaces
{
    public interface IStudent
    {
        public void Create(Student student);
        public void Update(Student student);
        public void Delete(Student student);
        public Task<List<Student>> Search(Student student);
        public Task<Student> GetById(int Id);
        public Task<List<Student>> GetAll();
    }
}
