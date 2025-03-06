using Microsoft.EntityFrameworkCore.Migrations;

namespace EbtakrAlmanalntro.Data.Migrations
{
    public partial class tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advantages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advantages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppImgs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppImgs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOpinions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOpinions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntroContactUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntroContactUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntroSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntroAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntroEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GooglePlayUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppleStoreUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntroImg1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroImg2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutAppAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutAppEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutDescrioptionAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutDescrioptionEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutAppImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterDescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FooterDescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommercialRegistrationNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    licenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    licenseExpiryDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    licenseside = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrivacyPolicyAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrivacyPolicyEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TermsOfUsersAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TermsOfUsersEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsHiddenIntroVideo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntroSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advantages");

            migrationBuilder.DropTable(
                name: "AppImgs");

            migrationBuilder.DropTable(
                name: "CustomerOpinions");

            migrationBuilder.DropTable(
                name: "IntroContactUs");

            migrationBuilder.DropTable(
                name: "IntroSettings");

            migrationBuilder.DropTable(
                name: "SocialMedias");
        }
    }
}
