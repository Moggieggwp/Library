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
            context.Writers.Add(new Entities.Writer {ImageName="jkRowling.jpg", BirthDate = DateTime.Now, FullName = "J. K. Rowling" });
            context.SaveChanges();
            var writer = context.Writers.FirstOrDefault();
            context.Publishers.Add(new Entities.Publisher { ImageName= "bloomsburyPublishing.jpg", City = "London", Title = "Bloomsbury Publishing" });
            context.SaveChanges();
            var publisher = context.Publishers.FirstOrDefault();
            context.Books.Add(new Entities.Book { ImageName = "harry1.jpg", IssueYear = DateTime.Now, IsOrdered = false, Description = "Harry Potter has no idea how famous he is. That's because he's being raised by his miserable aunt and uncle who are terrified Harry will learn that he's really a wizard, just as his parents were. But everything changes when Harry is summoned to attend an infamous school for wizards, and he begins to discover some clues about his illustrious birthright. From the surprising way he is greeted by a lovable giant, to the unique curriculum and colorful faculty at his unusual school, Harry finds himself drawn deep inside a mystical world he never knew existed and closer to his own noble destiny.", Title = "Harry Potter and the Sorcerer's Stone", Publisher = publisher, Fare = 10, Pages = 432 });
            context.SaveChanges();
            context.Books.Add(new Entities.Book { ImageName = "harry2.jpg", IssueYear = DateTime.Now, IsOrdered = false, Description = "The Dursleys were so mean that hideous that summer that all Harry Potter wanted was to get back to the Hogwarts School for Witchcraft and Wizardry. But just as he's packing his bags, Harry receives a warning from a strange, impish creature named Dobby who says that if Harry Potter returns to Hogwarts, disaster will strike. And strike it does.For in Harry's second year at Hogwarts, fresh torments and horrors arise, including an outrageously stuck-up new professor, Gilderoy Lockheart, a spirit named Moaning Myrtle who haunts the girls' bathroom, and the unwanted attentions of Ron Weasley's younger sister, Ginny.", Title = "Harry Potter And The Chamber Of Secrets", Publisher = publisher, Fare = 10, Pages = 478 });
            context.SaveChanges();
            var book = context.Books.FirstOrDefault();
            context.Participations.Add(new Entities.Participation { Book = book, Writer = writer });
            context.SaveChanges();

            //context.Orders.Add(new Entities.Order { OrderDate = DateTime.Now, ReturnDate = DateTime.Now, User = user, Books = new List<Entities.Book> { book } });
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
