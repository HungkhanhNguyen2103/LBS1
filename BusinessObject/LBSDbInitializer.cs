using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public static class LBSDbInitializer
    {
        public static void Seed(this ModelBuilder builder)
        {
            #region Role

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = Guid.Parse("46118fe1-2d15-4c5b-82f9-bc2f19b4a7c3").ToString(),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole()
                {
                    Id = Guid.Parse("627ec4a3-646f-455f-b65f-2903f87c19b6").ToString(),
                    Name = "User",
                    NormalizedName = "USER"
                },
                //new IdentityRole()
                //{
                //    Id = Guid.Parse("627ec4a3-646f-455f-b65f-2903cf7819b2").ToString(),
                //    Name = "Staff",
                //    NormalizedName = "STAFF"
                //},
                new IdentityRole()
                {
                    Id = Guid.Parse("627ec4a3-646f-455f-b65f-2903cf7820f2").ToString(),
                    Name = "Author",
                    NormalizedName = "AUTHOR"
                },
                new IdentityRole()
                {
                    Id = Guid.Parse("627ec4a3-646f-455f-b65f-2903cf78220f").ToString(),
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                }
                );

            #endregion Role

            #region User

            var hasher = new PasswordHasher<Account>();
            builder.Entity<Account>().HasData(
                new Account()
                {
                    Id = Guid.Parse("7d5002bd-f22f-4c7c-bce1-3d22eed213ff").ToString(),
                    UserName = "admin",
                    FullName = "Admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@gmail.com",
                    AccountActive = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    PasswordHash = hasher.HashPassword(null, "Admin@123")
                },
                new Account()
                {
                    Id = Guid.Parse("7d5002bd-f22f-4c7c-bce1-3d22eed213dd").ToString(),
                    UserName = "manager",
                    FullName = "Manager",
                    NormalizedUserName = "MANAGER",
                    Email = "manager@gmail.com",
                    AccountActive = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    PasswordHash = hasher.HashPassword(null, "Manager@123")
                },
                new Account()
                {
                    Id = Guid.Parse("7d5002bd-f22f-4c7c-bce1-3d22eff012ef").ToString(),
                    UserName = "author",
                    FullName = "Author",
                    NormalizedUserName = "AUTHOR",
                    Email = "author@gmail.com",
                    AccountActive = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    PasswordHash = hasher.HashPassword(null, "Author@123")
                }
                );

            #endregion User

            builder.Entity<IdentityUserRole<string>>().HasData(
                    new IdentityUserRole<string>
                    {
                        RoleId = Guid.Parse("46118fe1-2d15-4c5b-82f9-bc2f19b4a7c3").ToString(),
                        UserId = Guid.Parse("7d5002bd-f22f-4c7c-bce1-3d22eed213ff").ToString()
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = Guid.Parse("627ec4a3-646f-455f-b65f-2903f87c19b6").ToString(),
                        UserId = Guid.Parse("7d5002bd-f22f-4c7c-bce1-3d22eff012ef").ToString()
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = Guid.Parse("627ec4a3-646f-455f-b65f-2903cf78220f").ToString(),
                        UserId = Guid.Parse("7d5002bd-f22f-4c7c-bce1-3d22eed213dd").ToString()
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = Guid.Parse("627ec4a3-646f-455f-b65f-2903cf7819b2").ToString(),
                        UserId = Guid.Parse("7d5002bd-f22f-4c7c-bce1-3d22eff321ef").ToString()
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = Guid.Parse("627ec4a3-646f-455f-b65f-2903cf7820f2").ToString(),
                        UserId = Guid.Parse("7d5002bd-f22f-4c7c-bce1-3d22eff012ef").ToString()
                    });

        }
    }
}
