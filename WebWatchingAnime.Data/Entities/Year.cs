using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebWatchingAnime.Data.Entities
{
    public class Year
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(4)]
        public string Name { get; set; }
        [DefaultValue(true)]
        public bool Status { get; set; }

        //public ICollection<Anime> Animes { get; set; }
    }
}
