using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebWatchingAnime.Data.Entities
{
    [Table("Systems")]
    public class Systems
    {
       [Key]
       public int Id { get; set; }
       [Required]
       public string Name { get; set; }
       public string FullName { get; set; }
       [Required]
       public string PhoneNumber { get; set; }
       public string Address { get; set; }
       [Required]
       [StringLength(255)]
       public string IconLogo { get; set; }
       [Required]
       [StringLength(255)]
       public string ImageCover { get; set; }
       [Required]
       public float Lat { get; set; }
       [Required]
       public float Lng { get; set; }
       [Required]
       public string LinkFaceBook { get; set; }
       public string LinkInstargram { get; set; }
       [Required]
       [StringLength(255)]
       public string Descaription { get; set; }
       [Required]
       [StringLength(255)]
       public string NameWebsite { get; set; }
    
       [StringLength(255)]
       public string Node { get; set; }
       [Required]
       public string Email { get; set; }
    }
}
