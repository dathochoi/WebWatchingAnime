using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebWatchingAnime.Data.Entities;
using WebWatchingAnime.Utilities.DTOs;
using WebWatchingAnime.ViewModel.ViewModel;
using WebWatchingAnime.ViewModel.ViewModel.Client;

namespace WebWatchingAnime.Service.Interfaces
{
    public interface IAnimeService
    {
        Task<List<AnimeViewModel>> GetAll();
        PagedResult<AnimeViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize);

        PagedResult<AnimeClientViewModel> GetAllPagingClient(int? categoryId, string keyword, int page, int pageSize);
        AnimeViewModel GetDetails(int id);
        int Add(AnimeViewModel anime);
        void Update(AnimeViewModel anime);
        void Delete(int id);
        AnimeViewModel GetById(int id);     
    }
}
