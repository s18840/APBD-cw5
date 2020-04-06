using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw3.DAL;
using cw3.DTOs.Requests;
using cw3.DTOs.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cw3.Controllers
{
    [Route("api/enrollments")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private IStudentDbService _service;
        
        public EnrollmentsController(IStudentDbService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            _service.EnrollStudent(request);
            var response = new EnrollStudentResponse();

            return CreatedAtAction("EnrollStudent", response);
            //i tak dalej

        }
        [HttpPost]
        public IActionResult PromoteStudents(PromoteStudentRequest request)
        {
            _service.PromoteStudents(request);
            var response = new PromoteStudentResponse();

            return Ok(response);

        }

    }
}