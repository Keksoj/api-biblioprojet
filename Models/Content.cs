using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioApi.Models
{
    public class Content
    {
        public int Id                       { get; set; }
        public string Name                  { get; set; }
        public TimeSpan Duration            { get; set; }

        [ForeignKey("TypeId")]
        public ContentType Type             { get; set; }
        
        public int TypeId                   { get; set; }
        public string Picture               { get; set; }
        public DateTime DatePublication     { get; set; }
        public DateTime DateCreation        { get; set; }
        public string Description           { get; set; }
    }
}
