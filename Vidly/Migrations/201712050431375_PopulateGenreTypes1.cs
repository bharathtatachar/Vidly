namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTypes1 : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres(Id,Name) Values(1,'Comedy')");
            Sql("Insert into Genres(Id,Name) Values(2,'Romantic')");
            Sql("Insert into Genres(Id,Name) Values(3,'Thriller')");
            Sql("Insert into Genres(Id,Name) Values(4,'Sci-Fi')");
            Sql("Insert into Genres(Id,Name) Values(5,'Documentary')");
            Sql("Insert into Genres(Id,Name) Values(6, 'Action')");
        }
        
        public override void Down()
        {
        }
    }
}
