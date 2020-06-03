using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebWatchingAnime.Data.Entities
{
    [Table("Categories")]
    public class Catetgory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [DefaultValue(true)]
        public bool Status { get; set; }
        //public virtual ICollection<AnimeCategory> AnimeCategorys { set; get; }
    }
}
