//using Microsoft.EntityFrameworkCore;
//using Supermarket.Core.Entities;
//using System.Collections.Generic;

//namespace SupermarketAPI.DAL
//{
//    public class ApplicationDbContext : DbContext
//    {
//        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
//        {
//            this.ChangeTracker.LazyLoadingEnabled = false;

//        }

//        //// Set DBset in here

//        public DbSet<User> Users { get; set; }
//        public DbSet<Role> Roles { get; set; }
//        public DbSet<UserRole> UserRoles { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);
//            //modelBuilder.Entity<UserRole>().HasOne(ur => ur.User)
//            //    .WithMany(ur => ur.UserRoles)
//            //    .HasForeignKey(ur => ur.UserId)
//            //   ;
//            modelBuilder.Entity<User>().HasMany(u => u.UserRoles).WithOne(u => u.User);
//            modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });
//            modelBuilder.Entity<UserRole>().HasOne(ur => ur.Role).WithMany(u => u.UserRoles);
//            //modelBuilder.Entity<UserRole>().HasOne(ur => ur.User).WithMany(u => u.UserRoles);

//            modelBuilder.Entity<Role>().Property(a => a.RoleId).UseIdentityColumn(seed: 1, increment: 1);
//            //modelBuilder.Entity<Role>().Property(a => a.RoleId).ValueGeneratedOnAdd();
//            //modelBuilder.Entity<Role>().Property(a => a.RoleId).UseSqlServerIdentityColumn(seed: 1, increment: 1);
//            //seed data
//            var listUser = new List<User>()
//            {
//                new User()
//            {
//                UserId = 1,
//                Username = "Admin",
//                Password = "12345"
//            },
//            new User()
//            {
//                UserId = 2,
//                Username = "User",
//                Password = "12345"
//            }
//            };
//            modelBuilder.Entity<User>().HasData(listUser);

//            var listRole = new List<Role>()
//            {
//                new Role()
//                {
//                    RoleName = ERole.Admin.ToString(),
//                    RoleId = (int)ERole.Admin
//                },
//                new Role()
//                {
//                    RoleName = ERole.User.ToString(),
//                    RoleId = (int)ERole.User
//                }
//            };
//            modelBuilder.Entity<Role>().HasData(listRole);

//            var listUserRole = new List<UserRole>()
//            {
//                new UserRole()
//                {
//                    UserId = listUser[0].UserId,
//                    RoleId = listRole[0].RoleId
//                },
//                new UserRole()
//                {
//                    UserId = listUser[1].UserId,
//                    RoleId = listRole[1].RoleId
//                }
//            };
//            modelBuilder.Entity<UserRole>().HasData(listUserRole);
//        }
//    }
//}
