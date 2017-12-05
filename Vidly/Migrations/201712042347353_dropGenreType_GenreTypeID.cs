namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropGenreType_GenreTypeID : DbMigration
    {
        public override void Up()
        {
            Sql("  DROP INDEX Movies.[IX_GenreType_GenreTypeId]");
            Sql("ALTER TABLE [dbo].[Movies]    DROP CONSTRAINT[FK_dbo.Movies_dbo.GenreTypes_GenreType_GenreTypeId]");
            Sql("ALTER TABLE MOVIES DROP COLUMN GENRETYPE_GENRETYPEID");
        }
        
        public override void Down()
        {

        }
    }
}
