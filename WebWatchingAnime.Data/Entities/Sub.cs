using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebWatchingAnime.Data.Entities
{
    [Table("Subs")]
    public class Sub
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [DefaultValue(true)]
        public bool Status { get; set; }
    }
}
