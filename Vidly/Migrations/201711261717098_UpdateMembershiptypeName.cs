namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershiptypeName : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes set membershiptypename = case when Id =1 then 'Pay as you go'" +
                 "when Id =2 then 'Monthly'" +
                 "when Id = 3 then 'Quarterly'" +
                 "when Id = 4 then 'Annual' End");
        }
        
        public override void Down()
        {
        }
    }
}
