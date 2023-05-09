using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JGQZ.ArqLimpia.BL.Interfaces;
using JGQZ.ArqLimpia.EN;
using JGQZ.ArqLimpia.EN.Interfaces;
using JGQZ.ArqLimpia.BL.DTOs.StudentDTOs;
using System.Net;
using System.Xml.Linq;

namespace JGQZ.ArqLimpia.BL
{
    public class StudentBL : IStudentBL
    {
        readonly IStudent _studentDAL;
        readonly IUnitOfWork _unitWork;
        public StudentBL(IStudent studentDAL, IUnitOfWork unitWork)
        {
            _studentDAL = studentDAL;
            _unitWork = unitWork;
        }

        public async Task<int> Create(StudentAddDTO pUser)
        {
            Student student = new Student
            {
                Name = pUser.Name,
                YearsOld = pUser.YearsOld,
                Address = pUser.Address,
                Email = pUser.Email,
                Number = pUser.Number,
                SecondNumber = pUser.SecondNumber
            };
            _studentDAL.Create(student);
            return await _unitWork.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            Student student = await _studentDAL.GetById(id);
            if (student.Id == id)
            {
                _studentDAL.Delete(student);
                return await _unitWork.SaveChangesAsync();
            }
            else
                return 0;
        }

        public async Task<List<StudentGetAllDTO>> GetAll()
        {
            List<Student> student = await _studentDAL.GetAll();
            List<StudentGetAllDTO> list = new List<StudentGetAllDTO>();
            student.ForEach(s => list.Add(new StudentGetAllDTO
            {
                Id = s.Id,
                Name = s.Name,
                YearsOld = s.YearsOld,
                Address = s.Address,
                Email = s.Email,
                Number = s.Number,
                SecondNumber = s.SecondNumber
            }));
            return list;
        }

        public async Task<StudentGetByIdDTO> GetById(int id)
        {
            Student student = await _studentDAL.GetById(id);
            return new StudentGetByIdDTO()
            {
                Id = student.Id,
                Name = student.Name,
                YearsOld = student.YearsOld,
                Address = student.Address,
                Email = student.Email,
                Number = student.Number,
                SecondNumber = student.SecondNumber
            };
        }

        public async Task<List<StudentOutputDTO>> Search(StudentInputDTO pUser)
        {
            List<Student> student = await _studentDAL.Search(new Student { Name = pUser.Name });
            List<StudentOutputDTO> list = new List<StudentOutputDTO>();
            student.ForEach(s => list.Add(new StudentOutputDTO
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
            }));
            return list;
        }

        public async Task<int> Update(StudentUpdateDTO pUser)
        {
            Student student = await _studentDAL.GetById(pUser.Id);
            if (student.Id == pUser.Id)
            {
                student.Name = pUser.Name;
                student.YearsOld = pUser.YearsOld;
                student.Address = pUser.Address;
                student.Email = pUser.Email;
                student.Number = pUser.Number;
                student.SecondNumber = pUser.SecondNumber;
                _studentDAL.Update(student);
                return await _unitWork.SaveChangesAsync();
            }
            else
                return 0;
        }
    }
}
