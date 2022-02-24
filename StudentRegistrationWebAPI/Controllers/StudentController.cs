using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistrationWebAPI.Data;
using StudentRegistrationWebAPI.Models;

namespace StudentRegistrationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public StudentController(ApplicationDbContext db) { 
            _db = db; 
        }

        [HttpGet("GetAllStudents")]
        public IEnumerable<StudentViewModel> GetAllStudents()
        {
            var studentData = _db.FormData.ToList();
            List<StudentViewModel> studentsList = new List<StudentViewModel>();

            foreach(var student in studentData)
            {
                StudentViewModel obj = new StudentViewModel
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Gender = student.Gender,
                    DOB = student.DOB,
                    Email = student.Email,
                    Phone = student.Phone,
                    PermanentAddress = student.PermanentAddress,
                    CurrentAddress = student.CurrentAddress,
                    ProfileImagePath = student.ProfileImagePath,
                    CourseId = student.CourseId,
                    StreamId = student.StreamId,
                    TwelfthMarks = student.TwelfthMarks,
                    TenthMarks = student.TenthMarks,
                    StudentBio = student.StudentBio,
                };
                studentsList.Add(obj);
            }
            return studentsList;
        }

        [HttpGet("GetStudentById")]
        public StudentViewModel GetStudentById(int Id)
        {
            var student = _db.FormData.Find(Id);
            StudentViewModel studentView = new StudentViewModel
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Gender = student.Gender,
                DOB = student.DOB,
                Email = student.Email,
                Phone = student.Phone,
                PermanentAddress = student.PermanentAddress,
                CurrentAddress = student.CurrentAddress,
                ProfileImagePath = student.ProfileImagePath,
                CourseId = student.CourseId,
                StreamId = student.StreamId,
                TwelfthMarks = student.TwelfthMarks,
                TenthMarks = student.TenthMarks,
                StudentBio = student.StudentBio,
            };

            return studentView;
        }

        [HttpPost("AddStudent")]
        public IEnumerable<StudentViewModel> AddStudent(StudentViewModel newStudent)
        {
            Student obj = new Student
            {
                Id = 0,
                FirstName = newStudent.FirstName,
                LastName = newStudent.LastName,
                Gender = newStudent.Gender,
                DOB = newStudent.DOB,
                Email = newStudent.Email,
                Phone = newStudent.Phone,
                PermanentAddress = newStudent.PermanentAddress,
                CurrentAddress = newStudent.CurrentAddress,
                ProfileImagePath = newStudent.ProfileImagePath,
                CourseId = newStudent.CourseId,
                StreamId = newStudent.StreamId,
                TwelfthMarks = newStudent.TwelfthMarks,
                TenthMarks = newStudent.TenthMarks,
                StudentBio = newStudent.StudentBio,

            };
            _db.FormData.Add(obj);
            _db.SaveChanges();
            return GetAllStudents();

        }

        [HttpPut("EditStudent")]
        public IEnumerable<StudentViewModel> EditStudent(StudentViewModel editStudent)
        {
            Student obj = new Student
            {
                Id = editStudent.Id,
                FirstName = editStudent.FirstName,
                LastName = editStudent.LastName,
                Gender = editStudent.Gender,
                DOB = editStudent.DOB,
                Email = editStudent.Email,
                Phone = editStudent.Phone,
                PermanentAddress = editStudent.PermanentAddress,
                CurrentAddress = editStudent.CurrentAddress,
                ProfileImagePath = editStudent.ProfileImagePath,
                CourseId = editStudent.CourseId,
                StreamId = editStudent.StreamId,
                TwelfthMarks = editStudent.TwelfthMarks,
                TenthMarks = editStudent.TenthMarks,
                StudentBio = editStudent.StudentBio,

            };
            _db.FormData.Update(obj);
            _db.SaveChanges();
            return GetAllStudents();

        }

        [HttpDelete("DeleteStudent")]
        public IEnumerable<StudentViewModel> DeleteStudent(int Id)
        {
            var obj = _db.FormData.Find(Id);
            _db.FormData.Remove(obj);
            _db.SaveChanges();
            return GetAllStudents();

        }

    }
}
