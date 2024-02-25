using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsilMedia.Domain.Exceptions.Genres
{
    public class GenreNotFoundException : Exception
    {
        public GenreNotFoundException() : base("Genre not found") { }
    }
}
