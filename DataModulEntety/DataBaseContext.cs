﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModulEntety.Model;
using Interfaces.Models.Notice;

namespace DataModulEntety
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext(string ConStr) : base(ConStr)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<NoticeEntety> Notices { get; set; }

        public DbSet<Histories> Histories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Notices)
                .WithMany(n => n.Users)
                .Map(m =>
                {
                    m.ToTable("UserNotices");
                    m.MapLeftKey("idUser");
                    m.MapRightKey("idNotice");
                });
        }
    }

}
