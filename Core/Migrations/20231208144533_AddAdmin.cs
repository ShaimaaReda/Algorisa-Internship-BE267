using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class AddAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO AspNetUsers ([Id], [DateOfBirth], [Gender], [Image], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator] , [SpecializeId], [UserType]) VALUES (N'8e6bbc52-45ee-4063-9271-523b57c75680', '1990-01-01', 0, NULL, N'admin', N'ADMIN', N'admin@test.com', N'ADMIN@TEST.COM', 0, N'AQAAAAEAACcQAAAAEAWH/eLXv3ucFRs/Tpb1+bsXh5NHCidhn+QQotrYOmaUUnI72vKLagO4ojuwg5Dkng==', N'ZKHQLKZMOM3JJXOJ2ELXDLOPYBPLXGI5', N'c73573d4-a69d-4304-9d1c-a45944d00ba7', NULL, 0, 0, NULL, 1, 0, 'User',  NULL, 'Admin')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM AspNetUsers WHERE Id = 'c73573d4-a69d-4304-9d1c-a45944d00ba7'");
        }
    }
}
