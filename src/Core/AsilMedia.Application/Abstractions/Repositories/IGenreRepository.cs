using AsilMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsilMedia.Application.Abstractions.Repositories
{
    public interface IGenreRepository
    {
        public Task<Genre> InsertAsync(Genre gen);
        public Task<Genre> SelectByIdAsync(long id);
        public Task<List<Genre>> SelectAllAsync();
        public Task<Genre> UpdateAsync(Genre gen, long id);
        public Task<Genre> DeleteAsync(long id);
    }
}
