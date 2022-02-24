using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistrationWebAPI.Data;
using StudentRegistrationWebAPI.Models;

namespace StudentRegistrationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreamController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public StreamController(ApplicationDbContext db)
        {
            _db = db;

        }

        [HttpGet("GetAllStreams")]
        public IEnumerable<StreamViewModel> GetAllStreams() {

            var streamData= _db.Stream.ToList();
            
            List<StreamViewModel> streamList=new List<StreamViewModel>();

            foreach (var stream in streamData) {
                StreamViewModel obj = new StreamViewModel
                { 
                StreamId = stream.StreamId,
                StreamName = stream.StreamName,
                };
                streamList.Add(obj);
            }
            return streamList;
        }

        [HttpGet("GetStreamById")]
        public StreamViewModel GetStreamById(int Id)
        {
            var streamData = _db.Stream.Find(Id);
            StreamViewModel obj = new StreamViewModel
            {
                StreamId = streamData.StreamId,
                StreamName = streamData.StreamName,
            };
            return obj;
        }

        [HttpPost("CreateStream")]
        public IEnumerable<StreamViewModel> AddStream(string newStream)
        {
            Models.Stream obj = new Models.Stream
            {
                StreamId = 0,
                StreamName = newStream,
            };
            _db.Stream.Add(obj);
            _db.SaveChanges();
            return GetAllStreams();
        }


        [HttpPut("EditStream")]
        public IEnumerable<StreamViewModel> EditCourse(StreamViewModel editStream)
        {
            Models.Stream obj = new Models.Stream
            {
                StreamId = editStream.StreamId,
                StreamName = editStream.StreamName,
            };
            _db.Stream.Update(obj);
            _db.SaveChanges();
            return GetAllStreams();
        }

        [HttpDelete("DeleteStream")]
        public IEnumerable<StreamViewModel> DeleteStream(int Id)
        {
            var obj = _db.Stream.Find(Id);

            _db.Stream.Remove(obj);
            _db.SaveChanges();
            return GetAllStreams();
        }



    }
}
