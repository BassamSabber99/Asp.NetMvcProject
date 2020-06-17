using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        
        [Required]
        [Display(Name = "Genre")]
        public byte genreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }
    }
}