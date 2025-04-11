using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpeechToTextProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechToTextProject.DataAccessLayer.Context
{
    public class ApiContext:IdentityDbContext<AudioUser ,AudioRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-AFU114N\\SQLEXPRESS;initial Catalog=SpeechToTextDb;integrated Security=true");
        }
        public DbSet<Audio> Audios { get; set; }
        public DbSet<Transcription> Transcriptions { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        
    }
}
