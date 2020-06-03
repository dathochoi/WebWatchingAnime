using System;
using System.Collections.Generic;
using System.Text;

namespace WebWatchingAnime.ViewModel.ViewModel.Account
{
    public class ResetPasswordViewModel
    {
        public string Username { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
