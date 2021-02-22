using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
   public class CategoryCreate
    {
        [Required]
        [MinLength(2,ErrorMessage ="need at leat 2 characters")]
        [MaxLength(40,ErrorMessage ="There are too many characters.")]

        public string Name { get; set; }
    }
}
