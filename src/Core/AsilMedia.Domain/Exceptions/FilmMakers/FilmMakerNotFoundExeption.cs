using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsilMedia.Domain.Exceptions.FilmMakers
{
    public class FilmMakerNotFoundException:Exception
    {
        public FilmMakerNotFoundException() : base("FilmMaker not found.") { }
    }
}
