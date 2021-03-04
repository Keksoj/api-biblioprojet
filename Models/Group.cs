using Microsoft.EntityFrameworkCore;
using System;

namespace BiblioApi.Models
{
    public class Group
    {
        public int Id                   { get; set; }
        public string Name              { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Picture           { get; set; }
        public DateTime DateOfCreation    { get; set; }
    }
}
