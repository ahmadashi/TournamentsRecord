using Microsoft.EntityFrameworkCore;
using TR.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TR.DAL.DataAccess
{
    public class TRContext: DbContext
    {
        public TRContext(DbContextOptions options) : base(options) { }

        public DbSet<Tournament> Tournaments { get; set; }

        public DbSet<TournamentUser> TournamentUsers { get; set; }

        public DbSet<Logo> Logos { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Staff> Staff { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<RoleType> RoleType { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<SportType> SportType { get; set; }
        public DbSet<TournamentType> TournamentType { get; set; }


        //public DbQuery<TournamentType> TournamentTypeViewModel { get; set; }

        internal void UpdateEntry<T>(T dbEntity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
