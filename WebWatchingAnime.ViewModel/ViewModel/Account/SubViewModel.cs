using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebWatchingAnime.ViewModel.ViewModel.Account
{
    public class SubViewModel
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [DefaultValue(true)]
        public bool Status { get; set; }
    }
}
