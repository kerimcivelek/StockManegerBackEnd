using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "{0} boş geçilemez")]
        public string Name { get; set; }
        public int CategoryType  { get; set; }
    }
}
