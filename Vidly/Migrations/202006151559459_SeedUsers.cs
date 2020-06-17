namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9d284f2f-57eb-43c0-b218-1f97eb63eb03', N'admin@vidly.com', 0, N'AN+5MbmQEM8fzZr0U0Yi7/xBSvKroio6qBpQkC9TZ9KYfZol8ru1NSJXvMpNyVYGYA==', N'cb56a70c-d054-41ca-bc77-dc53d3a75e79', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a5de5bb1-faba-4d18-a694-80317fe794ea', N'guest@vidly.com', 0, N'AKLTu84hyp5a7W39VjWgf0lKMkENow2U73x7FJsrA2JU6qWIDGglH5tAGB0hIDGmWQ==', N'725eaabc-3155-4018-b03f-129fa8ddc1fc', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'85afde25-57e1-4ba6-9205-63a8ef7dbf6e', N'CanManageMovie')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9d284f2f-57eb-43c0-b218-1f97eb63eb03', N'85afde25-57e1-4ba6-9205-63a8ef7dbf6e')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
