using AsilMedia.Application.DataTransferObjects;
using AsilMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsilMedia.Application.Services.FilmMakers
{
    public interface IFilmMakerService
    {
        public Task<FilmMaker> InsertAsync(FilmMakerDTO filmMakerDTO);
        public Task<FilmMaker> SelectByIdAsync(long id);
        public Task<List<FilmMaker>> SelectAllAsync();
        public Task<FilmMaker> UpdateAsync(FilmMakerDTO filmMakerDTO, long id);
        public Task<FilmMaker> DeleteAsync(long id);
    }
}
