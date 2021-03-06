﻿using System;

namespace BiblioApi.Models
{
    public class GroupArtistRelation
    {
        public int Id                   { get; set; }
        public Group Group              { get; set; }
        public Artist Artist            { get; set; }
        public DateTime DateCreation    { get; set; }
    }
}
