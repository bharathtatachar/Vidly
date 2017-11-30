namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedMovieProperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenreTypes",
                c => new
                    {
                        GenreTypeId = c.Short(nullable: false, identity: true),
                        GenreName = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.GenreTypeId);
            
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "GenreType_GenreTypeId", c => c.Short());
            CreateIndex("dbo.Movies", "GenreType_GenreTypeId");
            AddForeignKey("dbo.Movies", "GenreType_GenreTypeId", "dbo.GenreTypes", "GenreTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreType_GenreTypeId", "dbo.GenreTypes");
            DropIndex("dbo.Movies", new[] { "GenreType_GenreTypeId" });
            DropColumn("dbo.Movies", "GenreType_GenreTypeId");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropTable("dbo.GenreTypes");
        }
    }
}
