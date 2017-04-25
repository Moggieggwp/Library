namespace Library.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Library.Data.Context.LibraryDatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Library.Data.Context.LibraryDatabaseContext context)
        {
            var user = context.Users.FirstOrDefault();
            context.Writers.Add(new Entities.Writer { BirthDate = DateTime.Now, FirstName = "Dima", LastName = "Ivanov" });
            context.SaveChanges();
            var writer = context.Writers.FirstOrDefault();
            context.Publishers.Add(new Entities.Publisher { City = "Kharkiv", Title = "ABABAGALAMAGA" });
            context.SaveChanges();
            var publicsher = context.Publishers.FirstOrDefault();
            context.Books.Add(new Entities.Book { IssueYear = DateTime.Now, IsOrdered = false, Description = "about your mom", Title = "Mom", Publisher=publicsher, Fare = 100, Pages = 1000 });
            context.SaveChanges();
            var book = context.Books.FirstOrDefault();
            context.Participations.Add(new Entities.Participation { Book = book, Writer = writer });
            context.SaveChanges();

            //context.Orders.Add(new Entities.Order { OrderDate= DateTime.Now, ReturnDate= DateTime.Now, User = user, Books = new List<Entities.Book> { book } });
            //context.SaveChanges();

            //  This method will be called after migrating to the latest version.

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
    }
}
