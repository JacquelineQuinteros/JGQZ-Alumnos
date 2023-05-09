using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JGQZ.ArqLimpia.BL.DTOs.StudentDTOs;

namespace JGQZ.ArqLimpia.BL.Interfaces
{
    public interface IStudentBL
    {
        Task<int> Create(StudentAddDTO pUser);
        Task<int> Update(StudentUpdateDTO pUser);
        Task<int> Delete(int id);
        Task<StudentGetByIdDTO> GetById(int id);
        Task<List<StudentGetAllDTO>> GetAll();
        Task<List<StudentOutputDTO>> Search(StudentInputDTO pUser);
    }
}
