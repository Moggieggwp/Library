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
            //var user = context.Users.FirstOrDefault();
            //if (user == null)
            //{
            //    user = new Entities.ApplicationUser
            //    {
            //        Email = "admin@admin.com",
            //        FirstName = "Dima",
            //        LastName = "Grigoryev",
            //        UserName = "Moggie",
            //        PasswordHash = "adminadminqwerty"
            //    };
            //}
            context.Writers.Add(new Entities.Writer { ImageName = "jkRowling.jpg", BirthDate = DateTime.Now, FullName = "J. K. Rowling" });
            context.SaveChanges();
            context.Writers.Add(new Entities.Writer { ImageName = "elJames.jpg", BirthDate = DateTime.Now, FullName = "E. L. James" });
            context.SaveChanges();
            context.Publishers.Add(new Entities.Publisher { ImageName = "bloomsburyPublishing.jpg", City = "London", Title = "Bloomsbury Publishing" });
            context.SaveChanges();
            context.Publishers.Add(new Entities.Publisher { ImageName = "vintageBooks.jpg", City = "New York", Title = "Vintage Books" });
            context.SaveChanges();
            var VintageBooksPublisher = context.Publishers.FirstOrDefault(p => p.Title == "Vintage Books");
            var BloomsBaryPublisher = context.Publishers.FirstOrDefault(p => p.Title == "Bloomsbury Publishing");
            context.Books.Add(new Entities.Book
            {
                ImageName = "harry1.jpg",
                IssueYear = DateTime.Now,
                IsOrdered = false,
                Description = "Harry Potter has no idea how famous he is. That's because he's being raised by his miserable aunt and uncle who are terrified Harry will learn that he's really a wizard, just as his parents were. But everything changes when Harry is summoned to attend an infamous school for wizards, and he begins to discover some clues about his illustrious birthright. From the surprising way he is greeted by a lovable giant, to the unique curriculum and colorful faculty at his unusual school, Harry finds himself drawn deep inside a mystical world he never knew existed and closer to his own noble destiny.",
                Title = "Harry Potter and the Sorcerer's Stone",
                Publisher = BloomsBaryPublisher,
                Fare = 10,
                Pages = 432,
                PathToReadOnline = "http://harrypotter.scholastic.com/excerpts/HP_Book1_Chapter_Excerpt.pdf"
            });
            context.SaveChanges();
            context.Books.Add(new Entities.Book
            {
                ImageName = "harry2.jpg",
                IssueYear = DateTime.Now,
                IsOrdered = false,
                Description = "The Dursleys were so mean that hideous that summer that all Harry Potter wanted was to get back to the Hogwarts School for Witchcraft and Wizardry. But just as he's packing his bags, Harry receives a warning from a strange, impish creature named Dobby who says that if Harry Potter returns to Hogwarts, disaster will strike. And strike it does.For in Harry's second year at Hogwarts, fresh torments and horrors arise, including an outrageously stuck-up new professor, Gilderoy Lockheart, a spirit named Moaning Myrtle who haunts the girls' bathroom, and the unwanted attentions of Ron Weasley's younger sister, Ginny.",
                Title = "Harry Potter And The Chamber Of Secrets",
                Publisher = BloomsBaryPublisher,
                Fare = 10,
                Pages = 478,
                PathToReadOnline = "http://harrypotter.scholastic.com/excerpts/HP_Book2_Chapter_Excerpt.pdf"
            });
            context.SaveChanges();

            context.Books.Add(new Entities.Book
            {
                ImageName = "fiftyShades.jpg",
                IssueYear = DateTime.Now,
                IsOrdered = false,
                Description = "E.L. James' erotica novel is written from the perspective of college student Anastasia Steele. Before graduation, she interviews the mysterious and eligible billionaire bachelor Christian Grey for her school's paper. Naturally, Christian is actually pretty into Ana, too.It's not really clear why. She's a plain Jane, has no plans for her future after college, and she's clumsy. But for some reason he can't control himself any moment she bites down on her lip.Before you know it, Christian's showing up at Ana's place of employment, sending her expensive presents(first - edition copies of books by her favorite author and a new MacBook), getting jealous of other men in her life, and taking her for helicopter rides.",
                Title = "Fifty Shades Of Grey",
                Publisher = VintageBooksPublisher,
                Fare = 15,
                Pages = 600,
                PathToReadOnline = "http://jeankaleb.com/ebooks/50Shades%20-%20of%20Grey.pdf"
            });
            context.SaveChanges();

            var HarryPotterWriter = context.Writers.FirstOrDefault(w => w.FullName == "J. K. Rowling");
            var FiftyShadesWriter = context.Writers.FirstOrDefault(w => w.FullName == "E. L. James");
            var HarryPotterBook1 = context.Books.FirstOrDefault(b=> b.Title == "Harry Potter and the Sorcerer's Stone");
            var HarryPotterBook2 = context.Books.FirstOrDefault(b => b.Title == "Harry Potter And The Chamber Of Secrets");
            var FiftyShadesBook = context.Books.FirstOrDefault(b => b.Title == "Fifty Shades Of Grey");
            context.Participations.Add(new Entities.Participation { Book = HarryPotterBook1, Writer = HarryPotterWriter });
            context.Participations.Add(new Entities.Participation { Book = HarryPotterBook2, Writer = HarryPotterWriter });
            context.Participations.Add(new Entities.Participation { Book = FiftyShadesBook, Writer = FiftyShadesWriter });
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
