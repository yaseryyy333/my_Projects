using System;
using System.Collections.Generic;
using System.Text;
using chatApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace chatApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext<myUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<myUser>().HasIndex(u => u.UserName).IsUnique(unique: false).IsClustered(false);
            builder.Entity<IdentityUser>().HasIndex(u => u.UserName).IsUnique(false);

        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<myRoles> myRoles { get; set; }
        public DbSet<myUser> myUsers { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<IndividualChat> IndividualChats { set; get; }
        public DbSet<IndividualRoom> IndividualRooms { set; get; }




    }
}