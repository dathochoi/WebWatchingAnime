using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebWatchingAnime.Data.Entities
{
    [Table("Episodes")]
    public class Episode
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string Number { get; set; }

        [Required]
        public string Src { get; set; }
        [Required]
        public int AnimeId { get; set; }

        public int STT { get; set; }

        //[ForeignKey("AnimeId")]
        // public virtual Anime Anime { set; get; }

    }
}
