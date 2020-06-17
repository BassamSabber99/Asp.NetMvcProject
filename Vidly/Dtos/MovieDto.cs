using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

     
        [Required]
        public byte genreId { get; set; }

     
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        public GnreDto Genre { get; set; }

        [Range(1, 20)]
        public byte NumberInStock { get; set; }
    }
}