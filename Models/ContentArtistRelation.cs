using System;

namespace BiblioApi.Models
{
    public class ContentArtistRelation
    {
        public int Id                   { get; set; }
        public Content Content          { get; set; }
        public Artist Artist            { get; set; }
        public DateTime DateOfCreation    { get; set; }
    }
}
