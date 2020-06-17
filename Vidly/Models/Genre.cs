using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Genre
    {
        [Required]
        public byte id { get; set; }
        [Required]
        public string name { get; set; }
    }
}