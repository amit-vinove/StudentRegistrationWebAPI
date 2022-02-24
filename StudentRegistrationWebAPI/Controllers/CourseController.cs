using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistrationWebAPI.Data;
using StudentRegistrationWebAPI.Models;

namespace StudentRegistrationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public CourseController(ApplicationDbContext db)
        {
            _db = db;

        }

        [HttpGet("GetAllCourses")]
        public IEnumerable<CourseViewModel> GetAllCourses() {

            var courseData= _db.Course.ToList();
            
/*            Object Creation */
            List<CourseViewModel> courseList=new List<CourseViewModel>();

            foreach (var course in courseData) {
                CourseViewModel obj = new CourseViewModel { 
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                };
                courseList.Add(obj);
            }
            return courseList;
        }

        [HttpGet("GetCourseById")]
        public CourseViewModel GetCourseById(int Id)
        {
            var courseData = _db.Course.Find(Id);
            CourseViewModel obj = new CourseViewModel
            {
                CourseId = courseData.CourseId,
                CourseName = courseData.CourseName,
            };
            return obj;
        }

        [HttpPost("CreateCourse")]
        public IEnumerable<CourseViewModel> AddCourse(string newCourse)
        {
            Course obj = new Course
            {
                CourseId = 0,
                CourseName = newCourse,
            };
            _db.Course.Add(obj);
            _db.SaveChanges();
            return GetAllCourses();
        }


        [HttpPut("EditCourse")]
        public IEnumerable<CourseViewModel> EditCourse(CourseViewModel editCourse)
        {
            Course obj = new Course
            {
                CourseId = editCourse.CourseId,
                CourseName = editCourse.CourseName,
            };
            _db.Course.Update(obj);
            _db.SaveChanges();
            return GetAllCourses();
        }

        [HttpDelete("DeleteCourse")]
        public IEnumerable<CourseViewModel> DeleteCourse(int Id)
        {
            var obj = _db.Course.Find(Id);

            _db.Course.Remove(obj);
            _db.SaveChanges();
            return GetAllCourses();
        }



    }
}
