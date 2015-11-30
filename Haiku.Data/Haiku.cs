using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Haiku.Data
{
    [Table("Haikus")]
    public class HaikuEntity : TEntity<int>
    {
        [Required]
        [MinLength(10)]
        public string Text { get; set; }

        public int UserId { get; set; }
        
        public virtual User User { get; set; }
    }
}
