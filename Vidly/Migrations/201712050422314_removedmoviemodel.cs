namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedmoviemodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "GenreType_GenreTypeId", "dbo.GenreTypes");
            DropIndex("dbo.Movies", new[] { "GenreType_GenreTypeId" });
            DropTable("dbo.Movies");
            DropTable("dbo.GenreTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GenreTypes",
                c => new
                    {
                        GenreTypeId = c.Short(nullable: false, identity: true),
                        GenreName = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.GenreTypeId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GenreTypeId = c.Byte(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        NumberInStock = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        GenreType_GenreTypeId = c.Short(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Movies", "GenreType_GenreTypeId");
            AddForeignKey("dbo.Movies", "GenreType_GenreTypeId", "dbo.GenreTypes", "GenreTypeId");
        }
    }
}
