namespace Widly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Fantasy/Adventure')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Fantasy/Sci-fi')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Sci-fi/Thriller')");

            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES ('Shrek', '04/22/2001', '07/22/2001', 10, 1)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES ('Wall-E', '06/21/2008', '09/21/2008', 15, 2)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES ('Spider-Man: Far From Home', '06/26/2019', '09/26/2019', 12, 2)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES ('Inception', '07/16/2010', '10/16/2010', 5, 3)");
        }
        
        public override void Down()
        {
        }
    }
}
