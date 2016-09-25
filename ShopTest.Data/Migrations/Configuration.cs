namespace ShopTest.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopTest.Data.ShopTestDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShopTest.Data.ShopTestDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            CreateSlide(context);
            CreatePage(context);
            CreateContactDetail(context);

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ShopTestDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ShopTestDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "tedu",
                Email = "tedu.international@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Technology Education"

            };

            manager.Create(user, "123654$");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("tedu.international@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }
        private void CreateUser(ShopTestDbContext context)
        {
            

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
        private void CreateSlide(ShopTestDbContext context)
        {
            if(context.Slides.Count()==0)
            {
                List<Slide> listSlide = new List<Slide>()
                {
                    new Slide() {
                        Name ="Slide 1",
                        DisplayOrder =1,
                        Status =true,
                        Url ="#",
                        Image ="/Assets/Clients/images/bag.jpg",
                        Description =@"<h2>FLAT 50% 0FF</h2>
								<label>FOR ALL PURCHASE <b>VALUE</b></label>
								<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>					
								<span class=""on-get"">GET NOW</span>" },
                    new Slide() {
                        Name ="Slide 2",
                        DisplayOrder =2,
                        Status =true,
                        Url ="#",
                        Image ="/Assets/Clients/images/bag1.jpg",
                        Description=@"<h2>FLAT 50% 0FF</h2>
								<label>FOR ALL PURCHASE <b>VALUE</b></label>
								<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>					
								<span class=""on-get"">GET NOW</span>"}
                };
                context.Slides.AddRange(listSlide);
                context.SaveChanges();
            }
           
        }
        private void CreatePage(ShopTestDbContext context)
        {
            if(context.Pages.Count()==0)
            {
                var page = new Page()
                {
                    Name= "Giới thiệu",
                    Alias="gioi-thieu",
                    Content = @"Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?",
                    Status =true
                };
                context.Pages.Add(page);
                context.SaveChanges();
            }
        }
        private void CreateContactDetail(ShopTestDbContext context)
        {
            if (context.ContactDetails.Count() == 0)
            {
                var contactDetail = new ShopTest.Model.Models.ContactDetail()
                {
                    Name = "Harley Quinn",
                    Address = "Harley Quinn",
                    Email = "leluc276@gmail.com",
                    Lat = 21.0050024,
                    Lng = 105.8210348,
                    Phone = "0921373777",
                    Website = "http://tedu.com.vn",
                    Other = "",
                    Status = true
                };
                context.ContactDetails.Add(contactDetail);
                context.SaveChanges();
            }
        }
    }
}
