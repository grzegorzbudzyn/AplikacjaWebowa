namespace AplikacjaWebowa.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AplikacjaWebowa.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<AplikacjaWebowa.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AplikacjaWebowa.Models.ApplicationDbContext context)
        {
            AddUserAndRole(context);
            context.Contacts.AddOrUpdate(p => p.Nazwa,
               new Kontakty
               {
                   Nazwa = "Grzegorz Budzyn",
                   Adres = "Rynek 9/2",
                   Miasto = "Miko³ów",
                   Stan_Kontenera = "Nowy",
                   Nr_Kontenera = "10999",
                   Email = "grzegorz@abrkontenery.pl",
               }
                
                );
        }
        bool AddUserAndRole(AplikacjaWebowa.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var administrator = new ApplicationUser()
            {
                UserName = "admin@admin.com",
            };
            ir = um.Create(administrator, "Admin123#");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(administrator.Id, "canEdit");
            return ir.Succeeded;
        }
    }
}
