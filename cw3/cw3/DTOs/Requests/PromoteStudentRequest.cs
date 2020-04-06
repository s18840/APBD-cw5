using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cw3.DTOs.Requests
{
    public class PromoteStudentRequest
    {
        [Required] [MaxLength(255)] public string StudiesName { get; set; }
        [Required] public int Semester { get; set; }
    }
}
