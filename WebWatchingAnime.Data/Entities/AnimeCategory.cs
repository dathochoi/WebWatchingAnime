using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebWatchingAnime.Data.Entities
{
    [Table("AnimeCategory")]
    public class AnimeCategory
    {
        public int AnimeId{get;set;}
        public int CategoryId { get; set; }

       // [ForeignKey("AnimeId")]
       // public virtual Anime Anime { set; get; }

       // [ForeignKey("CategoryId")]
       // public virtual Catetgory Catetgory { set; get; }
    }
}
