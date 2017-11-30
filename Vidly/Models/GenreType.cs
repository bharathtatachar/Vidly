using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class GenreType
    {
        public short GenreTypeId { get; set; }
        [Required]
        [StringLength(25)]
        public string GenreName { get; set; }
    }
}