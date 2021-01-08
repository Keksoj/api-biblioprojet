using System.Collections.Generic;

namespace BiblioApi.Models
{
    public class ContentType
    {
        public int Id           { get; set; }
        public string NameType  { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}