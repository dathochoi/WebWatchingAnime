using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebWatchingAnime.ViewModel.ViewModel.Account;

namespace WebWatchingAnime.Service.Interfaces
{
    public interface ISubService
    {
        int Add(SubViewModel year);

        void Update(SubViewModel year);

        void Delete(int id);

        Task<List<SubViewModel>> GetAll();
        SubViewModel GetById(int id);
    }
}
