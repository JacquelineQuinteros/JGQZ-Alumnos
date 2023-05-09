using JGQZ.ArqLimpia.EN;
using JGQZ.ArqLimpia.EN.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGQZ.ArqLimpia.DAL
{
    public class StudentsDAL : IStudent
    {
        readonly JGQZDBContext dbContext;

        public StudentsDAL(JGQZDBContext context)
        {
            dbContext = context;
        }

        public void Create(Student student)
        {
            dbContext.Add(student);
        }

        public void Delete(Student student)
        {
            dbContext.Remove(student);
        }

        public async Task<List<Student>> GetAll()
        {
            return await dbContext.Students.ToListAsync();
        }

        public async Task<Student> GetById(int Id)
        {
            Student? student = await dbContext.Students.FirstOrDefaultAsync(s => s.Id == Id);
            if (student != null)
                return student;
            else
                return new Student();
        }

        public Task<List<Student>> Search(Student student)
        {
            var query = dbContext.Students.AsQueryable();
            if (!string.IsNullOrWhiteSpace(student.Name))
                query = query.Where(s => s.Name.Contains(student.Name));
            return query.ToListAsync();
        }

        public void Update(Student student)
        {
            dbContext.Update(student);
        }
    }
}
