using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace display_list.Models
{
    public class display_entity
    {
        public int id { get; set; }
        
        [Required(ErrorMessage ="enter the name")]
        public string txtName { get; set; }

        public string sex { get; set; }

        public string txtCourse { get; set; }

        public string TC { get; set; }

        [Required(ErrorMessage = "enter the feed")]
        public string txtFeed { get; set; }
    }
}
