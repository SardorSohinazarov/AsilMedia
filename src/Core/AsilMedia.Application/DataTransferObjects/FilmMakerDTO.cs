using AsilMedia.Domain.Entities;
using AsilMedia.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsilMedia.Application.DataTransferObjects
{
    public class FilmMakerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public Gender Gender { get; set; }
        public string PhotoPath { get; set; }

        public List<Film> Films { get; set; }
    }
}
