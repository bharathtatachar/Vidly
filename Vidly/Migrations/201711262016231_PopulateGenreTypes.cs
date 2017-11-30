namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTypes : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into GenreTypes(GenreName) Values('Comedy')");
            Sql("Insert into GenreTypes(GenreName) Values('Romantic')");
            Sql("Insert into GenreTypes(GenreName) Values('Thriller')");
            Sql("Insert into GenreTypes(GenreName) Values('Sci-Fi')");
            Sql("Insert into GenreTypes(GenreName) Values('Documentary')");
            Sql("Insert into GenreTypes(GenreName) Values('Action')");

        }

        public override void Down()
        {
        }
    }
}
