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
                    EmployeeFirstName = emp.EmployeeFirstName,
                    EmployeeLastName = emp.EmployeeLastName,
                    EmployeeDOB = emp.EmployeeDOB,
                    EmployeeGender = emp.EmployeeGender,
                    EmployeeManager = emp.EmployeeManager,
                    About = emp.About,
                    CurrentAddress = emp.CurrentAddress,
                    PermanentAddress = emp.PermanentAddress,
                    Phone = emp.Phone,
                    EmployeeNumber = emp.EmployeeNumber,
                    Designation = emp.Designation,
                    EmployeeTeam = emp.EmployeeTeam,
                    Location  = emp.Location,
                    Email = emp.Email,
                    UserId = emp.UserId,
                };
                empList.Add(obj);
            }
            return empList;
        }

        [HttpGet("GetEmployeeById")]
        public Employee GetEmployeeById(int Id)
        {
            var empData = _db.Employee.Find(Id);
            Employee employee = new Employee
            {
                EmployeeId = empData.EmployeeId,
                EmployeeFirstName = empData.EmployeeFirstName,
                EmployeeLastName = empData.EmployeeLastName,
                EmployeeGender= empData.EmployeeGender,
                EmployeeDOB = empData.EmployeeDOB,
                EmployeeNumber= empData.EmployeeNumber,
                EmployeeManager= empData.EmployeeManager,
                CurrentAddress = empData.CurrentAddress,
                PermanentAddress =  empData.PermanentAddress,
                About = empData.About,
                UserId = empData.UserId,
                Designation = empData.Designation,
                EmployeeTeam = empData.EmployeeTeam,
                Location = empData.Location,
                Email = empData.Email,
                Phone = empData.Phone,
            };

            return employee;
        }

        [HttpGet("GetEmployeeByTeam")]
        public IEnumerable<EmployeeViewModel> GetEmployeeByTeam(int teamId)
        {
            
            var empData =
                (from empDB in _db.Employee
                          join teamDB in _db.Teams
                          on empDB.EmployeeTeam equals teamDB.TeamId
                where empDB.EmployeeTeam == teamId
                select new EmployeeViewModel()
                          {   EmployeeId = empDB.EmployeeId,
                              EmployeeFirstName = empDB.EmployeeFirstName,
                              EmployeeLastName = empDB.EmployeeLastName,
                              EmployeeTeam = teamDB.TeamName,
                              Designation = empDB.Designation,
                              Location = empDB.Location,
                              Email = empDB.Email
                          }).ToList();

            return empData;
        }

        [HttpPost("AddEmployee")]
        public Employee Addemployee(Employee newEmployee)
        {
            Employee obj = new Employee
            {
                EmployeeId=0,
                EmployeeFirstName = newEmployee.EmployeeFirstName,
                EmployeeLastName = newEmployee.EmployeeLastName,
                Designation = newEmployee.Designation,
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

        [HttpPut("EditEmployee")]
        public Employee EditEmployee(Employee editEmployee)
        {
            Employee obj = new Employee
            {
                EmployeeId = editEmployee.EmployeeId,
                EmployeeFirstName =editEmployee.EmployeeFirstName,
                EmployeeLastName = editEmployee.EmployeeLastName,
                EmployeeGender = editEmployee.EmployeeGender,
                EmployeeDOB = editEmployee.EmployeeDOB,
                EmployeeManager = editEmployee.EmployeeManager,
                EmployeeNumber = editEmployee.EmployeeNumber,
                About = editEmployee.About,
                EmployeeTeam =editEmployee.EmployeeTeam,
                Designation =editEmployee.Designation,
                Email =editEmployee.Email,
                Phone =editEmployee.Phone,
                PermanentAddress =editEmployee.PermanentAddress,
                CurrentAddress =editEmployee.CurrentAddress,
                UserId =editEmployee.UserId,
                Location =editEmployee.Location,

            };
            _db.Employee.Update(obj);
            _db.SaveChanges();
            return obj;

        }

        [HttpDelete("DeleteEmployee")]
        public IEnumerable<Employee> DeleteStudent(int Id)
        {
            var obj = _db.Employee.Find(Id);
            _db.Employee.Remove(obj);
            _db.SaveChanges();
            return GetAllEmployee();

        }

    }
}
