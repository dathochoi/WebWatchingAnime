using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebWatchingAnime.ViewModel.ViewModel
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<AnimeCategoryViewModel> AnimeCategorys { set; get; }
    }
}
