namespace EEIMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAdmin : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'56eeb203-9dbb-43c6-8f50-55482957e034', N'Admin')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ca89422f-49b7-4549-b58c-dac29a29b291', N'gk326749@gmail.com', 1, N'AJi8h9TGUVBXA6OOEkpD0wtHnXeeM56GoQv4HzW6Q26snCDmv6j63ZxhLP3Pl/sDxQ==', N'd952323b-28be-43c6-8621-18bde0f76858', NULL, 0, 0, NULL, 1, 0, N'gk326749@gmail.com')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ca89422f-49b7-4549-b58c-dac29a29b291', N'56eeb203-9dbb-43c6-8f50-55482957e034')
            INSERT INTO [dbo].[Employees] ([FirstName], [LastName], [Designation], [Department], [PhoneNumber], [Email]) VALUES (N'Gulshan', N'Kumar', N'Developer', N'IT', N'8210706408', N'gk326749@gmail.com')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
