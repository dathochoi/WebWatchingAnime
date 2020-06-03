using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebWatchingAnime.Data.Entities
{
    [Table("Animes")]
    public class Anime
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
        public string OrderName { get; set; }

        [StringLength(250)]
        [Required]
        public string ImgSrc { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Description { get; set; }
        //public string Node { get; set; }
        //[Required]
        //public string Src { get; set; }
        public string SrcTrailer { get; set; }
        [DefaultValue(true)]
        public bool Status { get; set; }
        public string EpisodesMax { get; set; }
        public bool IsAnime { get; set; }
        [DefaultValue(true)]
        public bool IsEpisodes { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public int? SeasonId { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string SeasonName { get; set; }
        public string CategoryIds { get; set; }

       // [ForeignKey("SeasonId")]
       // public Season Season { get; set; }

        public int SubId { get; set; }
        public int YearId { get; set; }

        //[ForeignKey("YearId")]
       //public Year Year { get; set; }

       // public virtual ICollection<AnimeCategory> AnimeCategorys { set; get; }

        //public virtual ICollection<Episode> Episodes { set; get; }

    }
}
