using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistrationWebAPI.Data;
using StudentRegistrationWebAPI.Models;

namespace StudentRegistrationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db) { 
            _db = db; 
        }

        [HttpGet("GetAllEmployee")]
        public IEnumerable<Employee> GetAllEmployee()
        {
            var empData = _db.Employee.ToList();
            List<Employee> empList = new List<Employee>();

            foreach(var emp in empData)
            {
                Employee obj = new Employee
                {
                    EmployeeId = emp.EmployeeId,
                    EmployeeName = emp.EmployeeName,
                    Designation = emp.Designation,
                    EmployeeTeam = emp.EmployeeTeam,
                    Location  = emp.Location,
                    Email = emp.Email,
                };
                empList.Add(obj);
            }
            return empList;
        }

        [HttpGet("GetStudentById")]
        public Employee GetEmployeeById(int Id)
        {
            var empData = _db.Employee.Find(Id);
            Employee employee = new Employee
            {
                EmployeeId = empData.EmployeeId,
                EmployeeName = empData.EmployeeName,
                Designation = empData.Designation,
                EmployeeTeam = empData.EmployeeTeam,
                Location = empData.Location,
                Email = empData.Email
            };

            return employee;
        }

        [HttpPost("AddEmployee")]
        public Employee Addemployee(Employee newEmployee)
        {
            Employee obj = new Employee
            {
                EmployeeId=0,
                EmployeeName = newEmployee.EmployeeName,
                Designation =newEmployee.Designation,
                EmployeeTeam = newEmployee.EmployeeTeam,
                Location=newEmployee.Location,
                Email=newEmployee.Email,

            };
            _db.Employee.Add(obj);
            _db.SaveChanges();
            var data = _db.Employee.Max(x => x.EmployeeId);
            obj.EmployeeId = data;
            return obj ;
        }
/*
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

        }*/

    }
}
