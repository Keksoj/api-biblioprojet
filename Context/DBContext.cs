using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BiblioApi.Models;

namespace BiblioApi
{
    public class DBContext : DbContext
    {
        public DbSet<Artist> Artists                                { get; set; }
        public DbSet<Content> Contents                              { get; set; }
        public DbSet<ContentType> ContentTypes                      { get; set; }
        public DbSet<Group> Groups                                  { get; set; }

        public DbSet<GroupArtistRelation> GroupArtistRelations      { get; set; }
        public DbSet<ContentArtistRelation> ContentArtistRelations  { get; set; }
        public DbSet<ContentGroupRelation> ContentGroupRelations    { get; set; }

        public DBContext(DbContextOptions<DBContext> opts) : base(opts) { }
    }
}
