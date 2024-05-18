using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeckTech.Data.Migrations
{
    public partial class contentUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("0247aa5e-3519-4033-8356-ed2239f2cc77"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("ef764855-74b0-4847-bdf7-422850ca2cd7"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("01a28090-5a9d-4665-82bb-fcf1e10d332c"), new Guid("e800c003-f241-43d9-8a75-0713987357f5"), "aaaaaaaaa Yapılandırmasını Kontrol Edin: BeckTechDbContext sınıfınızın doğru yapılandırıldığından emin olun. Bağlantı dizesini ve başlatma sırasında gerekli seçenekleri doğru şekilde sağladığınızdan emin olun.\r\n\r\nVeritabanı Sağlayıcısını Kurulumu: Eğer Entity Framework Core kullanıyorsanız, veritabanı sağlayıcısını doğru şekilde yapılandırdığınızdan emin olun. Kullandığınız veritabanına bağlı olarak, ilave NuGet paketlerini yüklemeniz ve sağlayıcıyı Startup.cs veya Program.cs dosyalarında yapılandırmanız gerekebilir.\r\n\r\nBağımlılık Enjeksiyonu Kurulumu: BeckTechDbContext sınıfınızın bağımlılık enjeksiyonu konteynerine doğru şekilde kaydedildiğinden emin olun. Eğer ASP.NET Core kullanıyorsanız, DbContext'i hizmetler koleksiyonuna eklediğinizden emin olun.\r\n\r\nBağlantı Dizesini Kontrol Edin: Veritabanı bağlantı dizesinin doğru olduğundan ve geçerli bir veritabanı örneğine işaret ettiğinden emin olun. Eğer yerel bir veritabanı kullanıyorsanız, veritabanı sunucusunun çalıştığından emin olun.\r\n\r\nVeritabanı Erişim İzinlerini Kontrol Edin: Uygulamanızın veritabanına bağlanmak için kullandığı kullanıcı hesabının, veri okuma ve yazma izinlerine sahip olduğundan emin olun.\r\n\r\nVarlık Yapılandırmasını Kontrol Edin: Eğer ilişkilendirilmiş varlıklarınızı yapılandırdıysanız, yapılandırmaların doğru olduğundan ve döngüsel bağımlılıklar veya diğer sorunlara neden olmadığından emin olun.\r\n\r\nGünlüğe Almayı ve Hata Ayıklamayı Etkinleştirin: Entity Framework Core için günlükleme özelliğini etkinleştirerek daha detaylı hata mesajları alabilirsiniz. Bu, DbContext oluşturma hatasını daha kesin bir şekilde belirlemenize yardımcı olabilir.\r\n\r\nBaşlatma Günlüklerini İnceleyin: Uygulama başlatma günlüklerini, sorunu daha iyi anlamanıza veya gidermenize yardımcı olabilecek ek hata mesajları veya uyarıları için kontrol edin.", "Admin Test", new DateTime(2024, 5, 17, 18, 49, 30, 253, DateTimeKind.Local).AddTicks(4830), null, null, new Guid("e800c003-f241-43d9-8a75-0713987357f6"), false, null, null, "Asp.Net Deneme Makalesi", new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e401"), 5 },
                    { new Guid("0b8b1c59-c4d1-4d7e-b673-4f1ec5c6cb76"), new Guid("006b8234-53e7-4482-a70d-b36c12304431"), "DbContext Yapılandırmasını Kontrol Edin: BeckTechDbContext sınıfınızın doğru yapılandırıldığından emin olun. Bağlantı dizesini ve başlatma sırasında gerekli seçenekleri doğru şekilde sağladığınızdan emin olun.\r\n\r\nVeritabanı Sağlayıcısını Kurulumu: Eğer Entity Framework Core kullanıyorsanız, veritabanı sağlayıcısını doğru şekilde yapılandırdığınızdan emin olun. Kullandığınız veritabanına bağlı olarak, ilave NuGet paketlerini yüklemeniz ve sağlayıcıyı Startup.cs veya Program.cs dosyalarında yapılandırmanız gerekebilir.\r\n\r\nBağımlılık Enjeksiyonu Kurulumu: BeckTechDbContext sınıfınızın bağımlılık enjeksiyonu konteynerine doğru şekilde kaydedildiğinden emin olun. Eğer ASP.NET Core kullanıyorsanız, DbContext'i hizmetler koleksiyonuna eklediğinizden emin olun.\r\n\r\nBağlantı Dizesini Kontrol Edin: Veritabanı bağlantı dizesinin doğru olduğundan ve geçerli bir veritabanı örneğine işaret ettiğinden emin olun. Eğer yerel bir veritabanı kullanıyorsanız, veritabanı sunucusunun çalıştığından emin olun.\r\n\r\nVeritabanı Erişim İzinlerini Kontrol Edin: Uygulamanızın veritabanına bağlanmak için kullandığı kullanıcı hesabının, veri okuma ve yazma izinlerine sahip olduğundan emin olun.\r\n\r\nVarlık Yapılandırmasını Kontrol Edin: Eğer ilişkilendirilmiş varlıklarınızı yapılandırdıysanız, yapılandırmaların doğru olduğundan ve döngüsel bağımlılıklar veya diğer sorunlara neden olmadığından emin olun.\r\n\r\nGünlüğe Almayı ve Hata Ayıklamayı Etkinleştirin: Entity Framework Core için günlükleme özelliğini etkinleştirerek daha detaylı hata mesajları alabilirsiniz. Bu, DbContext oluşturma hatasını daha kesin bir şekilde belirlemenize yardımcı olabilir.\r\n\r\nBaşlatma Günlüklerini İnceleyin: Uygulama başlatma günlüklerini, sorunu daha iyi anlamanıza veya gidermenize yardımcı olabilecek ek hata mesajları veya uyarıları için kontrol edin.", "Admin Test", new DateTime(2024, 5, 17, 18, 49, 30, 253, DateTimeKind.Local).AddTicks(4822), null, null, new Guid("006b8234-53e7-4482-a70d-b36c12304432"), false, null, null, "C# Makalesi", new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e400"), 5 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("94b70614-d607-4883-8205-442444a54710"),
                column: "ConcurrencyStamp",
                value: "578c4d03-d55d-4c85-a02c-962c29810e59");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("94b70614-d607-4883-8205-442444a54711"),
                column: "ConcurrencyStamp",
                value: "26a1d69a-c1e0-42c6-9ab7-1b7f45cc7c77");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("94b70614-d607-4883-8205-442444a54712"),
                column: "ConcurrencyStamp",
                value: "9ca7e411-ae59-4ca6-be1a-c183936cd21f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e400"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2979f75-a9b2-4192-9eaf-8de6067fa69b", "AQAAAAEAACcQAAAAEP2/OoQESWDd0EB8cKGmp9WBEqPyRt5X2GjxgGBxhBg9+/A1ah99CS24soYU9F85eg==", "082fe95d-e366-44af-ba04-17ac8e6de633" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e401"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b4e7259-a7e7-4630-85d7-56878ac82708", "AQAAAAEAACcQAAAAEG6dy7NHYMj2zz4usF7gR6UWxPS7zOXCCx8SMzJdp1FpbQSZSjpcWGTZz9lDutzL+Q==", "a4bb02a3-7fc0-4b58-94ed-d151ba1b92ec" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("006b8234-53e7-4482-a70d-b36c12304431"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 18, 49, 30, 253, DateTimeKind.Local).AddTicks(6051));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e800c003-f241-43d9-8a75-0713987357f5"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 18, 49, 30, 253, DateTimeKind.Local).AddTicks(6069));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("006b8234-53e7-4482-a70d-b36c12304432"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 18, 49, 30, 253, DateTimeKind.Local).AddTicks(6178));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e800c003-f241-43d9-8a75-0713987357f6"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 18, 49, 30, 253, DateTimeKind.Local).AddTicks(6219));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("01a28090-5a9d-4665-82bb-fcf1e10d332c"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("0b8b1c59-c4d1-4d7e-b673-4f1ec5c6cb76"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("0247aa5e-3519-4033-8356-ed2239f2cc77"), new Guid("e800c003-f241-43d9-8a75-0713987357f5"), "aaaaaaaaa Yapılandırmasını Kontrol Edin: BeckTechDbContext sınıfınızın doğru yapılandırıldığından emin olun. Bağlantı dizesini ve başlatma sırasında gerekli seçenekleri doğru şekilde sağladığınızdan emin olun.\r\n\r\nVeritabanı Sağlayıcısını Kurulumu: Eğer Entity Framework Core kullanıyorsanız, veritabanı sağlayıcısını doğru şekilde yapılandırdığınızdan emin olun. Kullandığınız veritabanına bağlı olarak, ilave NuGet paketlerini yüklemeniz ve sağlayıcıyı Startup.cs veya Program.cs dosyalarında yapılandırmanız gerekebilir.\r\n\r\nBağımlılık Enjeksiyonu Kurulumu: BeckTechDbContext sınıfınızın bağımlılık enjeksiyonu konteynerine doğru şekilde kaydedildiğinden emin olun. Eğer ASP.NET Core kullanıyorsanız, DbContext'i hizmetler koleksiyonuna eklediğinizden emin olun.\r\n\r\nBağlantı Dizesini Kontrol Edin: Veritabanı bağlantı dizesinin doğru olduğundan ve geçerli bir veritabanı örneğine işaret ettiğinden emin olun. Eğer yerel bir veritabanı kullanıyorsanız, veritabanı sunucusunun çalıştığından emin olun.\r\n\r\nVeritabanı Erişim İzinlerini Kontrol Edin: Uygulamanızın veritabanına bağlanmak için kullandığı kullanıcı hesabının, veri okuma ve yazma izinlerine sahip olduğundan emin olun.\r\n\r\nVarlık Yapılandırmasını Kontrol Edin: Eğer ilişkilendirilmiş varlıklarınızı yapılandırdıysanız, yapılandırmaların doğru olduğundan ve döngüsel bağımlılıklar veya diğer sorunlara neden olmadığından emin olun.\r\n\r\nGünlüğe Almayı ve Hata Ayıklamayı Etkinleştirin: Entity Framework Core için günlükleme özelliğini etkinleştirerek daha detaylı hata mesajları alabilirsiniz. Bu, DbContext oluşturma hatasını daha kesin bir şekilde belirlemenize yardımcı olabilir.\r\n\r\nBaşlatma Günlüklerini İnceleyin: Uygulama başlatma günlüklerini, sorunu daha iyi anlamanıza veya gidermenize yardımcı olabilecek ek hata mesajları veya uyarıları için kontrol edin.", "Admin Test", new DateTime(2024, 5, 3, 18, 13, 29, 466, DateTimeKind.Local).AddTicks(1541), null, null, new Guid("e800c003-f241-43d9-8a75-0713987357f6"), false, null, null, "Asp.Net Deneme Makalesi", new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e401"), 5 },
                    { new Guid("ef764855-74b0-4847-bdf7-422850ca2cd7"), new Guid("006b8234-53e7-4482-a70d-b36c12304431"), "DbContext Yapılandırmasını Kontrol Edin: BeckTechDbContext sınıfınızın doğru yapılandırıldığından emin olun. Bağlantı dizesini ve başlatma sırasında gerekli seçenekleri doğru şekilde sağladığınızdan emin olun.\r\n\r\nVeritabanı Sağlayıcısını Kurulumu: Eğer Entity Framework Core kullanıyorsanız, veritabanı sağlayıcısını doğru şekilde yapılandırdığınızdan emin olun. Kullandığınız veritabanına bağlı olarak, ilave NuGet paketlerini yüklemeniz ve sağlayıcıyı Startup.cs veya Program.cs dosyalarında yapılandırmanız gerekebilir.\r\n\r\nBağımlılık Enjeksiyonu Kurulumu: BeckTechDbContext sınıfınızın bağımlılık enjeksiyonu konteynerine doğru şekilde kaydedildiğinden emin olun. Eğer ASP.NET Core kullanıyorsanız, DbContext'i hizmetler koleksiyonuna eklediğinizden emin olun.\r\n\r\nBağlantı Dizesini Kontrol Edin: Veritabanı bağlantı dizesinin doğru olduğundan ve geçerli bir veritabanı örneğine işaret ettiğinden emin olun. Eğer yerel bir veritabanı kullanıyorsanız, veritabanı sunucusunun çalıştığından emin olun.\r\n\r\nVeritabanı Erişim İzinlerini Kontrol Edin: Uygulamanızın veritabanına bağlanmak için kullandığı kullanıcı hesabının, veri okuma ve yazma izinlerine sahip olduğundan emin olun.\r\n\r\nVarlık Yapılandırmasını Kontrol Edin: Eğer ilişkilendirilmiş varlıklarınızı yapılandırdıysanız, yapılandırmaların doğru olduğundan ve döngüsel bağımlılıklar veya diğer sorunlara neden olmadığından emin olun.\r\n\r\nGünlüğe Almayı ve Hata Ayıklamayı Etkinleştirin: Entity Framework Core için günlükleme özelliğini etkinleştirerek daha detaylı hata mesajları alabilirsiniz. Bu, DbContext oluşturma hatasını daha kesin bir şekilde belirlemenize yardımcı olabilir.\r\n\r\nBaşlatma Günlüklerini İnceleyin: Uygulama başlatma günlüklerini, sorunu daha iyi anlamanıza veya gidermenize yardımcı olabilecek ek hata mesajları veya uyarıları için kontrol edin.", "Admin Test", new DateTime(2024, 5, 3, 18, 13, 29, 466, DateTimeKind.Local).AddTicks(1533), null, null, new Guid("006b8234-53e7-4482-a70d-b36c12304432"), false, null, null, "C# Makalesi", new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e400"), 5 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("94b70614-d607-4883-8205-442444a54710"),
                column: "ConcurrencyStamp",
                value: "c4db8230-782b-4498-a9f8-ec88a93ddcf4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("94b70614-d607-4883-8205-442444a54711"),
                column: "ConcurrencyStamp",
                value: "ea9e47ad-e4d4-49cd-a775-4e45b356b9c0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("94b70614-d607-4883-8205-442444a54712"),
                column: "ConcurrencyStamp",
                value: "3e2443e3-14cb-4d87-937a-85d50e83dc3a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e400"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "236c1f8d-4ff0-4494-96b4-223d790b1fbd", "AQAAAAEAACcQAAAAEDPW/QiZ7yMgUqs7oYdhOp0agFuhH+B7JIwOLOCdJGr3see0HoPJQuBOWOiXoeb8Iw==", "0cd7df2a-39f3-4bb9-8ebe-66d68f0a43cf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e401"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f6b8453-dc0e-4324-b715-9c6a36f0b6c7", "AQAAAAEAACcQAAAAEJHiFvTN/n7rHvAZylYHvZv1ntuC7PanzvVxi/VnU3yD78sUH/oHmW7aFjBEPywuXA==", "69bf5cab-0c8f-4435-9bf4-142c3bb08a7e" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("006b8234-53e7-4482-a70d-b36c12304431"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 3, 18, 13, 29, 466, DateTimeKind.Local).AddTicks(2829));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e800c003-f241-43d9-8a75-0713987357f5"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 3, 18, 13, 29, 466, DateTimeKind.Local).AddTicks(2833));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("006b8234-53e7-4482-a70d-b36c12304432"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 3, 18, 13, 29, 466, DateTimeKind.Local).AddTicks(2996));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e800c003-f241-43d9-8a75-0713987357f6"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 3, 18, 13, 29, 466, DateTimeKind.Local).AddTicks(3012));
        }
    }
}
