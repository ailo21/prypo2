using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;

namespace prypo2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public DateTime DateRegister { get; set; }//дата регистрации
        [MaxLength(1024)]
        public string ShortInfo { get; set; }
        public bool Adult { get; set; }//отображать маетриалы для взрослых
        public bool Horor { get; set; }//отображать маетриалы "жесть"

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }
    public class Fant
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(256)]
        [Required]
        [DisplayName("Название вызова")]
        public string Title { get; set; }
        [MaxLength(128)]
        public string Author { get; set; }
        [DisplayName("Описание вызова")]
        public string Text { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
    public class LingFantTag
    {
        [Key]
        public int Id { get; set; }
        public int TagId { get; set; }
        public int FantId { get; set; }

    }
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Fant> Fants { get; set; }
        public DbSet<LingFantTag> LingFantTags { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}