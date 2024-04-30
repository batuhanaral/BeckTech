using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeckTech.Data.Migrations
{
    public partial class removeEntityBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("523e08cd-a2c8-4690-bd1b-30ec584fdcd5"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("bf3c914e-7c81-49f8-8bc5-bf654f014a6e"));

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NameSurname",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Subject",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameSurname",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Contacts",
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
    }
}
