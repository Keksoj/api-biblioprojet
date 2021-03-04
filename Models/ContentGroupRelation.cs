using System;

namespace BiblioApi.Models
{
    public class ContentGroupRelation
    {
        public int Id                   { get; set; }
        public Content Content          { get; set; }
        public Group Group              { get; set; }
        public DateTime DateOfCreation    { get; set; }
    }
}
