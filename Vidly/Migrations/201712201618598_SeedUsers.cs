namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense], [Phone]) VALUES (N'19902b63-d0b3-446a-b497-f054a483097f', N'guest@vidly.com', 0, N'AEzh6EQ6nHYR2RpZl5Ic1TlmUibC4YZ9WFkeWrP6TNwxqwb6mFBu+1+w90H9Z2vErw==', N'd80a5d11-9866-4d16-b573-54e5eaaa4277', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com', N'ABC', N'2341232451')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense], [Phone]) VALUES (N'fa53ca80-ea89-4314-abe2-a9883f6aeb3e', N'admin@vidly.com', 0, N'AL6qcvxDGFxiB9KRF/TK2h3j94OsFxDKtSIm11TgHvibhIeHo0H3gqwZbDkf7R4LWw==', N'1e241f51-4012-4731-acb3-883a6739ebb9', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com', N'ABC', N'2323141122')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'67c561c8-72d4-441a-91e8-c2fe8333eb61', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fa53ca80-ea89-4314-abe2-a9883f6aeb3e', N'67c561c8-72d4-441a-91e8-c2fe8333eb61')
");
        }
        
        public override void Down()
        {
        }
    }
}
