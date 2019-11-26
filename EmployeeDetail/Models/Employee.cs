using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc.Html;
using Microsoft.AspNetCore.Mvc;

namespace EmpDetail.Models
{
    public class Employee
    {
        public int ID
        { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string City { get; set; }
    }
}

