using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matjary.Models
{
    public static class ModelBuilderExtension
    {
        public static void seed(this ModelBuilder modelBuilder) {
            modelBuilder.Entity<Owner>().HasNoKey();
            modelBuilder.Entity<Owner>().HasData(
                new Owner
                {
                    Id = 1,
                    Name = "مؤسسة العطور",
                    Email = "owner@gmail.com",
                    Telephone = "01554488",
                    Mobile = "7744556611",
                    Title = "العطر الفخم",
                    Commercial = "0002225599",
                    NumberVat = 123456798,
                    Logo = "Logo.svg",
                }
                ); 
        }
    }
}
