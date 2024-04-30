using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeckTech.Data.Migrations
{
    public partial class AddContactandBulletin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("5a08fd69-cf72-4501-92c8-118d0d28231c"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("e19c8707-d5e0-418e-8e2c-f9d65d6a2f8b"));

            migrationBuilder.CreateTable(
                name: "Bulletins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bulletins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("523e08cd-a2c8-4690-bd1b-30ec584fdcd5"), new Guid("e800c003-f241-43d9-8a75-0713987357f5"), "aaaaaaaaa Yapılandırmasını Kontrol Edin: BeckTechDbContext sınıfınızın doğru yapılandırıldığından emin olun. Bağlantı dizesini ve başlatma sırasında gerekli seçenekleri doğru şekilde sağladığınızdan emin olun.\r\n\r\nVeritabanı Sağlayıcısını Kurulumu: Eğer Entity Framework Core kullanıyorsanız, veritabanı sağlayıcısını doğru şekilde yapılandırdığınızdan emin olun. Kullandığınız veritabanına bağlı olarak, ilave NuGet paketlerini yüklemeniz ve sağlayıcıyı Startup.cs veya Program.cs dosyalarında yapılandırmanız gerekebilir.\r\n\r\nBağımlılık Enjeksiyonu Kurulumu: BeckTechDbContext sınıfınızın bağımlılık enjeksiyonu konteynerine doğru şekilde kaydedildiğinden emin olun. Eğer ASP.NET Core kullanıyorsanız, DbContext'i hizmetler koleksiyonuna eklediğinizden emin olun.\r\n\r\nBağlantı Dizesini Kontrol Edin: Veritabanı bağlantı dizesinin doğru olduğundan ve geçerli bir veritabanı örneğine işaret ettiğinden emin olun. Eğer yerel bir veritabanı kullanıyorsanız, veritabanı sunucusunun çalıştığından emin olun.\r\n\r\nVeritabanı Erişim İzinlerini Kontrol Edin: Uygulamanızın veritabanına bağlanmak için kullandığı kullanıcı hesabının, veri okuma ve yazma izinlerine sahip olduğundan emin olun.\r\n\r\nVarlık Yapılandırmasını Kontrol Edin: Eğer ilişkilendirilmiş varlıklarınızı yapılandırdıysanız, yapılandırmaların doğru olduğundan ve döngüsel bağımlılıklar veya diğer sorunlara neden olmadığından emin olun.\r\n\r\nGünlüğe Almayı ve Hata Ayıklamayı Etkinleştirin: Entity Framework Core için günlükleme özelliğini etkinleştirerek daha detaylı hata mesajları alabilirsiniz. Bu, DbContext oluşturma hatasını daha kesin bir şekilde belirlemenize yardımcı olabilir.\r\n\r\nBaşlatma Günlüklerini İnceleyin: Uygulama başlatma günlüklerini, sorunu daha iyi anlamanıza veya gidermenize yardımcı olabilecek ek hata mesajları veya uyarıları için kontrol edin.", "Admin Test", new DateTime(2024, 4, 7, 4, 53, 59, 599, DateTimeKind.Local).AddTicks(9827), null, null, new Guid("e800c003-f241-43d9-8a75-0713987357f6"), false, null, null, "Asp.Net Deneme Makalesi", new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e401"), 5 },
                    { new Guid("bf3c914e-7c81-49f8-8bc5-bf654f014a6e"), new Guid("006b8234-53e7-4482-a70d-b36c12304431"), "DbContext Yapılandırmasını Kontrol Edin: BeckTechDbContext sınıfınızın doğru yapılandırıldığından emin olun. Bağlantı dizesini ve başlatma sırasında gerekli seçenekleri doğru şekilde sağladığınızdan emin olun.\r\n\r\nVeritabanı Sağlayıcısını Kurulumu: Eğer Entity Framework Core kullanıyorsanız, veritabanı sağlayıcısını doğru şekilde yapılandırdığınızdan emin olun. Kullandığınız veritabanına bağlı olarak, ilave NuGet paketlerini yüklemeniz ve sağlayıcıyı Startup.cs veya Program.cs dosyalarında yapılandırmanız gerekebilir.\r\n\r\nBağımlılık Enjeksiyonu Kurulumu: BeckTechDbContext sınıfınızın bağımlılık enjeksiyonu konteynerine doğru şekilde kaydedildiğinden emin olun. Eğer ASP.NET Core kullanıyorsanız, DbContext'i hizmetler koleksiyonuna eklediğinizden emin olun.\r\n\r\nBağlantı Dizesini Kontrol Edin: Veritabanı bağlantı dizesinin doğru olduğundan ve geçerli bir veritabanı örneğine işaret ettiğinden emin olun. Eğer yerel bir veritabanı kullanıyorsanız, veritabanı sunucusunun çalıştığından emin olun.\r\n\r\nVeritabanı Erişim İzinlerini Kontrol Edin: Uygulamanızın veritabanına bağlanmak için kullandığı kullanıcı hesabının, veri okuma ve yazma izinlerine sahip olduğundan emin olun.\r\n\r\nVarlık Yapılandırmasını Kontrol Edin: Eğer ilişkilendirilmiş varlıklarınızı yapılandırdıysanız, yapılandırmaların doğru olduğundan ve döngüsel bağımlılıklar veya diğer sorunlara neden olmadığından emin olun.\r\n\r\nGünlüğe Almayı ve Hata Ayıklamayı Etkinleştirin: Entity Framework Core için günlükleme özelliğini etkinleştirerek daha detaylı hata mesajları alabilirsiniz. Bu, DbContext oluşturma hatasını daha kesin bir şekilde belirlemenize yardımcı olabilir.\r\n\r\nBaşlatma Günlüklerini İnceleyin: Uygulama başlatma günlüklerini, sorunu daha iyi anlamanıza veya gidermenize yardımcı olabilecek ek hata mesajları veya uyarıları için kontrol edin.", "Admin Test", new DateTime(2024, 4, 7, 4, 53, 59, 599, DateTimeKind.Local).AddTicks(9820), null, null, new Guid("006b8234-53e7-4482-a70d-b36c12304432"), false, null, null, "C# Makalesi", new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e400"), 5 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("94b70614-d607-4883-8205-442444a54710"),
                column: "ConcurrencyStamp",
                value: "d13dfd68-73a6-421e-8ae1-ff78bcd25fa6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("94b70614-d607-4883-8205-442444a54711"),
                column: "ConcurrencyStamp",
                value: "4aebd4c7-5b9e-49dc-a542-b1bdaf03a2ea");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("94b70614-d607-4883-8205-442444a54712"),
                column: "ConcurrencyStamp",
                value: "8a4b6fa6-3932-479f-8116-6813cb48a5c6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e400"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f3e415e-134a-474a-b2af-34f3519f9a3f", "AQAAAAEAACcQAAAAEAmmva3pvY0Wr4Krq8s55HbgAPpnxZZ9rveRWbzj1RcIjTDXgjm/togEofBGfSXerg==", "104c2a64-98ac-48f4-bbe9-adca0a9490d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e401"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b48bb946-4dcd-4eee-bc65-9823d645128a", "AQAAAAEAACcQAAAAEOM81jM4Em8DYSQmJzvvnY1QuK8OZ/FIcUcnPJQH2JaXwRpCUqoWFD9L79dqq9lbkw==", "7dab07bf-e2a5-47c9-9ad8-3c6b61d56d5f" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("006b8234-53e7-4482-a70d-b36c12304431"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 7, 4, 53, 59, 600, DateTimeKind.Local).AddTicks(12));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e800c003-f241-43d9-8a75-0713987357f5"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 7, 4, 53, 59, 600, DateTimeKind.Local).AddTicks(16));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("006b8234-53e7-4482-a70d-b36c12304432"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 7, 4, 53, 59, 600, DateTimeKind.Local).AddTicks(117));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e800c003-f241-43d9-8a75-0713987357f6"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 7, 4, 53, 59, 600, DateTimeKind.Local).AddTicks(120));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bulletins");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("523e08cd-a2c8-4690-bd1b-30ec584fdcd5"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("bf3c914e-7c81-49f8-8bc5-bf654f014a6e"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("5a08fd69-cf72-4501-92c8-118d0d28231c"), new Guid("006b8234-53e7-4482-a70d-b36c12304431"), "DbContext Yapılandırmasını Kontrol Edin: BeckTechDbContext sınıfınızın doğru yapılandırıldığından emin olun. Bağlantı dizesini ve başlatma sırasında gerekli seçenekleri doğru şekilde sağladığınızdan emin olun.\r\n\r\nVeritabanı Sağlayıcısını Kurulumu: Eğer Entity Framework Core kullanıyorsanız, veritabanı sağlayıcısını doğru şekilde yapılandırdığınızdan emin olun. Kullandığınız veritabanına bağlı olarak, ilave NuGet paketlerini yüklemeniz ve sağlayıcıyı Startup.cs veya Program.cs dosyalarında yapılandırmanız gerekebilir.\r\n\r\nBağımlılık Enjeksiyonu Kurulumu: BeckTechDbContext sınıfınızın bağımlılık enjeksiyonu konteynerine doğru şekilde kaydedildiğinden emin olun. Eğer ASP.NET Core kullanıyorsanız, DbContext'i hizmetler koleksiyonuna eklediğinizden emin olun.\r\n\r\nBağlantı Dizesini Kontrol Edin: Veritabanı bağlantı dizesinin doğru olduğundan ve geçerli bir veritabanı örneğine işaret ettiğinden emin olun. Eğer yerel bir veritabanı kullanıyorsanız, veritabanı sunucusunun çalıştığından emin olun.\r\n\r\nVeritabanı Erişim İzinlerini Kontrol Edin: Uygulamanızın veritabanına bağlanmak için kullandığı kullanıcı hesabının, veri okuma ve yazma izinlerine sahip olduğundan emin olun.\r\n\r\nVarlık Yapılandırmasını Kontrol Edin: Eğer ilişkilendirilmiş varlıklarınızı yapılandırdıysanız, yapılandırmaların doğru olduğundan ve döngüsel bağımlılıklar veya diğer sorunlara neden olmadığından emin olun.\r\n\r\nGünlüğe Almayı ve Hata Ayıklamayı Etkinleştirin: Entity Framework Core için günlükleme özelliğini etkinleştirerek daha detaylı hata mesajları alabilirsiniz. Bu, DbContext oluşturma hatasını daha kesin bir şekilde belirlemenize yardımcı olabilir.\r\n\r\nBaşlatma Günlüklerini İnceleyin: Uygulama başlatma günlüklerini, sorunu daha iyi anlamanıza veya gidermenize yardımcı olabilecek ek hata mesajları veya uyarıları için kontrol edin.", "Admin Test", new DateTime(2024, 3, 19, 2, 12, 44, 629, DateTimeKind.Local).AddTicks(6467), null, null, new Guid("006b8234-53e7-4482-a70d-b36c12304432"), false, null, null, "C# Makalesi", new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e400"), 5 },
                    { new Guid("e19c8707-d5e0-418e-8e2c-f9d65d6a2f8b"), new Guid("e800c003-f241-43d9-8a75-0713987357f5"), "aaaaaaaaa Yapılandırmasını Kontrol Edin: BeckTechDbContext sınıfınızın doğru yapılandırıldığından emin olun. Bağlantı dizesini ve başlatma sırasında gerekli seçenekleri doğru şekilde sağladığınızdan emin olun.\r\n\r\nVeritabanı Sağlayıcısını Kurulumu: Eğer Entity Framework Core kullanıyorsanız, veritabanı sağlayıcısını doğru şekilde yapılandırdığınızdan emin olun. Kullandığınız veritabanına bağlı olarak, ilave NuGet paketlerini yüklemeniz ve sağlayıcıyı Startup.cs veya Program.cs dosyalarında yapılandırmanız gerekebilir.\r\n\r\nBağımlılık Enjeksiyonu Kurulumu: BeckTechDbContext sınıfınızın bağımlılık enjeksiyonu konteynerine doğru şekilde kaydedildiğinden emin olun. Eğer ASP.NET Core kullanıyorsanız, DbContext'i hizmetler koleksiyonuna eklediğinizden emin olun.\r\n\r\nBağlantı Dizesini Kontrol Edin: Veritabanı bağlantı dizesinin doğru olduğundan ve geçerli bir veritabanı örneğine işaret ettiğinden emin olun. Eğer yerel bir veritabanı kullanıyorsanız, veritabanı sunucusunun çalıştığından emin olun.\r\n\r\nVeritabanı Erişim İzinlerini Kontrol Edin: Uygulamanızın veritabanına bağlanmak için kullandığı kullanıcı hesabının, veri okuma ve yazma izinlerine sahip olduğundan emin olun.\r\n\r\nVarlık Yapılandırmasını Kontrol Edin: Eğer ilişkilendirilmiş varlıklarınızı yapılandırdıysanız, yapılandırmaların doğru olduğundan ve döngüsel bağımlılıklar veya diğer sorunlara neden olmadığından emin olun.\r\n\r\nGünlüğe Almayı ve Hata Ayıklamayı Etkinleştirin: Entity Framework Core için günlükleme özelliğini etkinleştirerek daha detaylı hata mesajları alabilirsiniz. Bu, DbContext oluşturma hatasını daha kesin bir şekilde belirlemenize yardımcı olabilir.\r\n\r\nBaşlatma Günlüklerini İnceleyin: Uygulama başlatma günlüklerini, sorunu daha iyi anlamanıza veya gidermenize yardımcı olabilecek ek hata mesajları veya uyarıları için kontrol edin.", "Admin Test", new DateTime(2024, 3, 19, 2, 12, 44, 629, DateTimeKind.Local).AddTicks(6478), null, null, new Guid("e800c003-f241-43d9-8a75-0713987357f6"), false, null, null, "Asp.Net Deneme Makalesi", new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e401"), 5 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("94b70614-d607-4883-8205-442444a54710"),
                column: "ConcurrencyStamp",
                value: "159b01ee-2d4d-4ff7-94af-55e7c2803e6d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("94b70614-d607-4883-8205-442444a54711"),
                column: "ConcurrencyStamp",
                value: "de089e5c-8aba-4581-b361-a22ea2018eee");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("94b70614-d607-4883-8205-442444a54712"),
                column: "ConcurrencyStamp",
                value: "d479fddd-a3f4-4f0c-9a9c-7df98d6bdb49");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e400"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3483074b-6df4-4c3b-8a2a-a3894966a972", "AQAAAAEAACcQAAAAENSp85LdbHhV82zFjPnvbCuwGZas3BYCUVxNxVXFeQy1fsyGes1nIqr1sevSC6kKDw==", "65f98355-1cb1-4a74-94f5-5f829dd88041" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e401"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d1258ff-dff3-4244-ad5d-480e548a7d7f", "AQAAAAEAACcQAAAAEEaOo+fpm52qiUO5kOMNubqHLxDyG9X/7B7SdpK5CDQKoTSaB/wVtqgNbeS6HEgo+w==", "2844e1be-e868-464c-993a-708573874dbf" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("006b8234-53e7-4482-a70d-b36c12304431"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 19, 2, 12, 44, 629, DateTimeKind.Local).AddTicks(6822));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e800c003-f241-43d9-8a75-0713987357f5"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 19, 2, 12, 44, 629, DateTimeKind.Local).AddTicks(6827));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("006b8234-53e7-4482-a70d-b36c12304432"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 19, 2, 12, 44, 629, DateTimeKind.Local).AddTicks(6966));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e800c003-f241-43d9-8a75-0713987357f6"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 19, 2, 12, 44, 629, DateTimeKind.Local).AddTicks(6970));
        }
    }
}
