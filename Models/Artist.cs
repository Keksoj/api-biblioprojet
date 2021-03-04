using System;

namespace BiblioApi.Models
{
    public class Artist
    {
        public int Id                   { get; set; }
        public string CivilName         { get; set; }
        public string ArtistName        { get; set; }
        public DateTime Birthday        { get; set; }
        public string Gender            { get; set; }
        public string Nationality       { get; set; }
        public string Picture           { get; set; }
        public DateTime BeginCareerDate { get; set; }
        public DateTime EndCareerDate   { get; set; }
        public DateTime DateOfCreation    { get; set; }
    }
}
