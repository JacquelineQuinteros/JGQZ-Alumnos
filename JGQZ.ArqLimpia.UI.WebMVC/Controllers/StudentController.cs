using JGQZ.ArqLimpia.UI.WebMVC.Models;
using JGQZ.ArqLimpia.BL.Interfaces;
using JGQZ.ArqLimpia.EN;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JGQZ.ArqLimpia.BL.DTOs.StudentDTOs;

namespace JGQZ.ArqLimpia.UI.WebMVC.Controllers
{
    public class StudentController : Controller
    {
        readonly IStudentBL _studentBL;

        public StudentController(IStudentBL studentBL)
        {
            _studentBL = studentBL;
        }

        public async Task<IActionResult> Index(StudentInputDTO inputDTO)
        {
            var list = await _studentBL.Search(inputDTO);
            return View(list);
        }

        public async Task<IActionResult> Details(int id)
        {
            StudentGetByIdDTO student = await _studentBL.GetById(id);
            var Result = new StudentUpdateDTO()
            {
                Name = student.Name,
                YearsOld = student.YearsOld,
                Address = student.Address,
                Email = student.Email,
                Number = student.Number,
                SecondNumber = student.SecondNumber
            };
            return View(student);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentAddDTO StudentAddDTO)
        {
            try
            {
                int result = await _studentBL.Create(StudentAddDTO);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ViewBag.ErrorMessage = "ERROR: NO SE REGISTRO";
                    return View(StudentAddDTO);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            StudentGetByIdDTO student = await _studentBL.GetById(id);
            var students = new StudentUpdateDTO()
            {
                Id = student.Id,
                Name = student.Name,
                YearsOld = student.YearsOld,
                Address = student.Address,
                Email = student.Email,
                Number = student.Number,
                SecondNumber = student.SecondNumber
            };
            return View(students);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, StudentUpdateDTO updateDTO)
        {
            try
            {
                int result = await _studentBL.Update(updateDTO);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ViewBag.ErrorMessage = "ERROR: NO SE MODIFICO";
                    return View(updateDTO);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            StudentGetByIdDTO student = await _studentBL.GetById(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, StudentGetByIdDTO student)
        {
            try
            {
                int result = await _studentBL.Delete(id);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ViewBag.ErrorMessage = "ERROR: NO SE ELIMINO";
                    return View(student);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
    }
}
