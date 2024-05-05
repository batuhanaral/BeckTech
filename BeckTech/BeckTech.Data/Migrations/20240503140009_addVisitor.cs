using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeckTech.Data.Migrations
{
    public partial class addVisitor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("0ca22065-233f-4024-9283-76a822149ac6"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("ad86a4a7-303d-4381-939d-595c5cc6785c"));

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Bulletins",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleVisitors",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleVisitors", x => new { x.ArticleId, x.VisitorId });
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("19d50227-6d2c-439c-bde3-f66fff3673b3"), new Guid("e800c003-f241-43d9-8a75-0713987357f5"), "aaaaaaaaa Yapılandırmasını Kontrol Edin: BeckTechDbContext sınıfınızın doğru yapılandırıldığından emin olun. Bağlantı dizesini ve başlatma sırasında gerekli seçenekleri doğru şekilde sağladığınızdan emin olun.\r\n\r\nVeritabanı Sağlayıcısını Kurulumu: Eğer Entity Framework Core kullanıyorsanız, veritabanı sağlayıcısını doğru şekilde yapılandırdığınızdan emin olun. Kullandığınız veritabanına bağlı olarak, ilave NuGet paketlerini yüklemeniz ve sağlayıcıyı Startup.cs veya Program.cs dosyalarında yapılandırmanız gerekebilir.\r\n\r\nBağımlılık Enjeksiyonu Kurulumu: BeckTechDbContext sınıfınızın bağımlılık enjeksiyonu konteynerine doğru şekilde kaydedildiğinden emin olun. Eğer ASP.NET Core kullanıyorsanız, DbContext'i hizmetler koleksiyonuna eklediğinizden emin olun.\r\n\r\nBağlantı Dizesini Kontrol Edin: Veritabanı bağlantı dizesinin doğru olduğundan ve geçerli bir veritabanı örneğine işaret ettiğinden emin olun. Eğer yerel bir veritabanı kullanıyorsanız, veritabanı sunucusunun çalıştığından emin olun.\r\n\r\nVeritabanı Erişim İzinlerini Kontrol Edin: Uygulamanızın veritabanına bağlanmak için kullandığı kullanıcı hesabının, veri okuma ve yazma izinlerine sahip olduğundan emin olun.\r\n\r\nVarlık Yapılandırmasını Kontrol Edin: Eğer ilişkilendirilmiş varlıklarınızı yapılandırdıysanız, yapılandırmaların doğru olduğundan ve döngüsel bağımlılıklar veya diğer sorunlara neden olmadığından emin olun.\r\n\r\nGünlüğe Almayı ve Hata Ayıklamayı Etkinleştirin: Entity Framework Core için günlükleme özelliğini etkinleştirerek daha detaylı hata mesajları alabilirsiniz. Bu, DbContext oluşturma hatasını daha kesin bir şekilde belirlemenize yardımcı olabilir.\r\n\r\nBaşlatma Günlüklerini İnceleyin: Uygulama başlatma günlüklerini, sorunu daha iyi anlamanıza veya gidermenize yardımcı olabilecek ek hata mesajları veya uyarıları için kontrol edin.", "Admin Test", new DateTime(2024, 5, 3, 17, 0, 8, 141, DateTimeKind.Local).AddTicks(4787), null, null, new Guid("e800c003-f241-43d9-8a75-0713987357f6"), false, null, null, "Asp.Net Deneme Makalesi", new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e401"), 5 },
                    { new Guid("9b63faf0-7afb-498b-9656-25d068c3b6a5"), new Guid("006b8234-53e7-4482-a70d-b36c12304431"), "DbContext Yapılandırmasını Kontrol Edin: BeckTechDbContext sınıfınızın doğru yapılandırıldığından emin olun. Bağlantı dizesini ve başlatma sırasında gerekli seçenekleri doğru şekilde sağladığınızdan emin olun.\r\n\r\nVeritabanı Sağlayıcısını Kurulumu: Eğer Entity Framework Core kullanıyorsanız, veritabanı sağlayıcısını doğru şekilde yapılandırdığınızdan emin olun. Kullandığınız veritabanına bağlı olarak, ilave NuGet paketlerini yüklemeniz ve sağlayıcıyı Startup.cs veya Program.cs dosyalarında yapılandırmanız gerekebilir.\r\n\r\nBağımlılık Enjeksiyonu Kurulumu: BeckTechDbContext sınıfınızın bağımlılık enjeksiyonu konteynerine doğru şekilde kaydedildiğinden emin olun. Eğer ASP.NET Core kullanıyorsanız, DbContext'i hizmetler koleksiyonuna eklediğinizden emin olun.\r\n\r\nBağlantı Dizesini Kontrol Edin: Veritabanı bağlantı dizesinin doğru olduğundan ve geçerli bir veritabanı örneğine işaret ettiğinden emin olun. Eğer yerel bir veritabanı kullanıyorsanız, veritabanı sunucusunun çalıştığından emin olun.\r\n\r\nVeritabanı Erişim İzinlerini Kontrol Edin: Uygulamanızın veritabanına bağlanmak için kullandığı kullanıcı hesabının, veri okuma ve yazma izinlerine sahip olduğundan emin olun.\r\n\r\nVarlık Yapılandırmasını Kontrol Edin: Eğer ilişkilendirilmiş varlıklarınızı yapılandırdıysanız, yapılandırmaların doğru olduğundan ve döngüsel bağımlılıklar veya diğer sorunlara neden olmadığından emin olun.\r\n\r\nGünlüğe Almayı ve Hata Ayıklamayı Etkinleştirin: Entity Framework Core için günlükleme özelliğini etkinleştirerek daha detaylı hata mesajları alabilirsiniz. Bu, DbContext oluşturma hatasını daha kesin bir şekilde belirlemenize yardımcı olabilir.\r\n\r\nBaşlatma Günlüklerini İnceleyin: Uygulama başlatma günlüklerini, sorunu daha iyi anlamanıza veya gidermenize yardımcı olabilecek ek hata mesajları veya uyarıları için kontrol edin.", "Admin Test", new DateTime(2024, 5, 3, 17, 0, 8, 141, DateTimeKind.Local).AddTicks(4779), null, null, new Guid("006b8234-53e7-4482-a70d-b36c12304432"), false, null, null, "C# Makalesi", new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e400"), 5 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("94b70614-d607-4883-8205-442444a54710"),
                column: "ConcurrencyStamp",
                value: "1c523d4c-94d7-4526-9991-fc6641314251");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("94b70614-d607-4883-8205-442444a54711"),
                column: "ConcurrencyStamp",
                value: "0332dbde-c6cf-4167-b79e-6a3c58c135d2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("94b70614-d607-4883-8205-442444a54712"),
                column: "ConcurrencyStamp",
                value: "a2e61217-7565-434f-91d4-faa41ba40ffe");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e400"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7229f5b0-adc9-4109-aa19-65ce87a74d95", "AQAAAAEAACcQAAAAEJJd+832zW0NIiO7PNlGHHy0VTYpbd+1YuUAH0wdBSCfZMJ6Cs/9DXv+cC/Xn2Bq0Q==", "6f3df969-6561-413f-b309-9a380481b3f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e401"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c62bfd9-1ea5-410b-a445-a6e69c35eda7", "AQAAAAEAACcQAAAAEGHsanvdRu3kIMdFveWDtASTL245/eJPbT0yZMuIPTRLgxVEkwawLmdLuIXUR/WyhQ==", "1fb03512-8795-44b8-9b87-b6cee20d6b06" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("006b8234-53e7-4482-a70d-b36c12304431"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 3, 17, 0, 8, 141, DateTimeKind.Local).AddTicks(7083));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e800c003-f241-43d9-8a75-0713987357f5"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 3, 17, 0, 8, 141, DateTimeKind.Local).AddTicks(7097));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("006b8234-53e7-4482-a70d-b36c12304432"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 3, 17, 0, 8, 141, DateTimeKind.Local).AddTicks(7527));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e800c003-f241-43d9-8a75-0713987357f6"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 3, 17, 0, 8, 141, DateTimeKind.Local).AddTicks(7533));

            migrationBuilder.CreateIndex(
                name: "IX_ArticleVisitors_VisitorId",
                table: "ArticleVisitors",
                column: "VisitorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleVisitors");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("19d50227-6d2c-439c-bde3-f66fff3673b3"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("9b63faf0-7afb-498b-9656-25d068c3b6a5"));

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Bulletins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("0ca22065-233f-4024-9283-76a822149ac6"), new Guid("006b8234-53e7-4482-a70d-b36c12304431"), "DbContext Yapılandırmasını Kontrol Edin: BeckTechDbContext sınıfınızın doğru yapılandırıldığından emin olun. Bağlantı dizesini ve başlatma sırasında gerekli seçenekleri doğru şekilde sağladığınızdan emin olun.\r\n\r\nVeritabanı Sağlayıcısını Kurulumu: Eğer Entity Framework Core kullanıyorsanız, veritabanı sağlayıcısını doğru şekilde yapılandırdığınızdan emin olun. Kullandığınız veritabanına bağlı olarak, ilave NuGet paketlerini yüklemeniz ve sağlayıcıyı Startup.cs veya Program.cs dosyalarında yapılandırmanız gerekebilir.\r\n\r\nBağımlılık Enjeksiyonu Kurulumu: BeckTechDbContext sınıfınızın bağımlılık enjeksiyonu konteynerine doğru şekilde kaydedildiğinden emin olun. Eğer ASP.NET Core kullanıyorsanız, DbContext'i hizmetler koleksiyonuna eklediğinizden emin olun.\r\n\r\nBağlantı Dizesini Kontrol Edin: Veritabanı bağlantı dizesinin doğru olduğundan ve geçerli bir veritabanı örneğine işaret ettiğinden emin olun. Eğer yerel bir veritabanı kullanıyorsanız, veritabanı sunucusunun çalıştığından emin olun.\r\n\r\nVeritabanı Erişim İzinlerini Kontrol Edin: Uygulamanızın veritabanına bağlanmak için kullandığı kullanıcı hesabının, veri okuma ve yazma izinlerine sahip olduğundan emin olun.\r\n\r\nVarlık Yapılandırmasını Kontrol Edin: Eğer ilişkilendirilmiş varlıklarınızı yapılandırdıysanız, yapılandırmaların doğru olduğundan ve döngüsel bağımlılıklar veya diğer sorunlara neden olmadığından emin olun.\r\n\r\nGünlüğe Almayı ve Hata Ayıklamayı Etkinleştirin: Entity Framework Core için günlükleme özelliğini etkinleştirerek daha detaylı hata mesajları alabilirsiniz. Bu, DbContext oluşturma hatasını daha kesin bir şekilde belirlemenize yardımcı olabilir.\r\n\r\nBaşlatma Günlüklerini İnceleyin: Uygulama başlatma günlüklerini, sorunu daha iyi anlamanıza veya gidermenize yardımcı olabilecek ek hata mesajları veya uyarıları için kontrol edin.", "Admin Test", new DateTime(2024, 4, 23, 21, 18, 44, 63, DateTimeKind.Local).AddTicks(6961), null, null, new Guid("006b8234-53e7-4482-a70d-b36c12304432"), false, null, null, "C# Makalesi", new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e400"), 5 },
                    { new Guid("ad86a4a7-303d-4381-939d-595c5cc6785c"), new Guid("e800c003-f241-43d9-8a75-0713987357f5"), "aaaaaaaaa Yapılandırmasını Kontrol Edin: BeckTechDbContext sınıfınızın doğru yapılandırıldığından emin olun. Bağlantı dizesini ve başlatma sırasında gerekli seçenekleri doğru şekilde sağladığınızdan emin olun.\r\n\r\nVeritabanı Sağlayıcısını Kurulumu: Eğer Entity Framework Core kullanıyorsanız, veritabanı sağlayıcısını doğru şekilde yapılandırdığınızdan emin olun. Kullandığınız veritabanına bağlı olarak, ilave NuGet paketlerini yüklemeniz ve sağlayıcıyı Startup.cs veya Program.cs dosyalarında yapılandırmanız gerekebilir.\r\n\r\nBağımlılık Enjeksiyonu Kurulumu: BeckTechDbContext sınıfınızın bağımlılık enjeksiyonu konteynerine doğru şekilde kaydedildiğinden emin olun. Eğer ASP.NET Core kullanıyorsanız, DbContext'i hizmetler koleksiyonuna eklediğinizden emin olun.\r\n\r\nBağlantı Dizesini Kontrol Edin: Veritabanı bağlantı dizesinin doğru olduğundan ve geçerli bir veritabanı örneğine işaret ettiğinden emin olun. Eğer yerel bir veritabanı kullanıyorsanız, veritabanı sunucusunun çalıştığından emin olun.\r\n\r\nVeritabanı Erişim İzinlerini Kontrol Edin: Uygulamanızın veritabanına bağlanmak için kullandığı kullanıcı hesabının, veri okuma ve yazma izinlerine sahip olduğundan emin olun.\r\n\r\nVarlık Yapılandırmasını Kontrol Edin: Eğer ilişkilendirilmiş varlıklarınızı yapılandırdıysanız, yapılandırmaların doğru olduğundan ve döngüsel bağımlılıklar veya diğer sorunlara neden olmadığından emin olun.\r\n\r\nGünlüğe Almayı ve Hata Ayıklamayı Etkinleştirin: Entity Framework Core için günlükleme özelliğini etkinleştirerek daha detaylı hata mesajları alabilirsiniz. Bu, DbContext oluşturma hatasını daha kesin bir şekilde belirlemenize yardımcı olabilir.\r\n\r\nBaşlatma Günlüklerini İnceleyin: Uygulama başlatma günlüklerini, sorunu daha iyi anlamanıza veya gidermenize yardımcı olabilecek ek hata mesajları veya uyarıları için kontrol edin.", "Admin Test", new DateTime(2024, 4, 23, 21, 18, 44, 63, DateTimeKind.Local).AddTicks(6968), null, null, new Guid("e800c003-f241-43d9-8a75-0713987357f6"), false, null, null, "Asp.Net Deneme Makalesi", new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e401"), 5 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("94b70614-d607-4883-8205-442444a54710"),
                column: "ConcurrencyStamp",
                value: "e2fe3f4a-8987-4d43-9d97-0a82fa189bd8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("94b70614-d607-4883-8205-442444a54711"),
                column: "ConcurrencyStamp",
                value: "7a48f724-986f-4b69-9bb9-a3227cc22632");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("94b70614-d607-4883-8205-442444a54712"),
                column: "ConcurrencyStamp",
                value: "5025b7f8-62c9-460d-ae8a-776ceaa220b8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e400"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba50080d-edd1-486c-9afe-245c4e889ccc", "AQAAAAEAACcQAAAAEBDxhtl0jonmsjHPD+xotD3wh9l9kN4nKRJnpIfTWcgzE/qE/QWeK7CV87GHcM/anw==", "56c4f03f-30f4-47a3-b918-e4b38902c3d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e401"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8d997dd-6006-46a8-9563-bc5ee824aa67", "AQAAAAEAACcQAAAAEC/043X/hPtjPmQnjqddM8Bw1orP6qeP2Fpy9qZlvzvhVXTTgbXok8GUBTQm1u3Spw==", "5b6ca844-69f5-45c1-b2e6-026747d28214" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("006b8234-53e7-4482-a70d-b36c12304431"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 23, 21, 18, 44, 63, DateTimeKind.Local).AddTicks(7162));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e800c003-f241-43d9-8a75-0713987357f5"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 23, 21, 18, 44, 63, DateTimeKind.Local).AddTicks(7165));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("006b8234-53e7-4482-a70d-b36c12304432"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 23, 21, 18, 44, 63, DateTimeKind.Local).AddTicks(7255));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e800c003-f241-43d9-8a75-0713987357f6"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 23, 21, 18, 44, 63, DateTimeKind.Local).AddTicks(7258));
        }
    }
}
