using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeckTech.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("94b70614-d607-4883-8205-442444a54710"), "159b01ee-2d4d-4ff7-94af-55e7c2803e6d", "SuperAdmin", "SUPERADMIN" },
                    { new Guid("94b70614-d607-4883-8205-442444a54711"), "de089e5c-8aba-4581-b361-a22ea2018eee", "Admin", "ADMIN" },
                    { new Guid("94b70614-d607-4883-8205-442444a54712"), "d479fddd-a3f4-4f0c-9a9c-7df98d6bdb49", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("006b8234-53e7-4482-a70d-b36c12304431"), "AdminTest", new DateTime(2024, 3, 19, 2, 12, 44, 629, DateTimeKind.Local).AddTicks(6822), null, null, false, null, null, "C#" },
                    { new Guid("e800c003-f241-43d9-8a75-0713987357f5"), "AdminTest", new DateTime(2024, 3, 19, 2, 12, 44, 629, DateTimeKind.Local).AddTicks(6827), null, null, false, null, null, "Asp.Net" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("006b8234-53e7-4482-a70d-b36c12304432"), "Test Admin", new DateTime(2024, 3, 19, 2, 12, 44, 629, DateTimeKind.Local).AddTicks(6966), null, null, "images/testimage", "jpg", false, null, null },
                    { new Guid("e800c003-f241-43d9-8a75-0713987357f6"), "Test Admin", new DateTime(2024, 3, 19, 2, 12, 44, 629, DateTimeKind.Local).AddTicks(6970), null, null, "images/testimage", "jpg", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e400"), 0, "3483074b-6df4-4c3b-8a2a-a3894966a972", "superadmin@gmail.com", true, "Batuhan", new Guid("006b8234-53e7-4482-a70d-b36c12304432"), "Aral", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAENSp85LdbHhV82zFjPnvbCuwGZas3BYCUVxNxVXFeQy1fsyGes1nIqr1sevSC6kKDw==", "+905434579738", true, "65f98355-1cb1-4a74-94f5-5f829dd88041", false, "superadmin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e401"), 0, "8d1258ff-dff3-4244-ad5d-480e548a7d7f", "admin@gmail.com", false, "Eymen", new Guid("e800c003-f241-43d9-8a75-0713987357f6"), "Dogan", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEEaOo+fpm52qiUO5kOMNubqHLxDyG9X/7B7SdpK5CDQKoTSaB/wVtqgNbeS6HEgo+w==", "+905434579738", false, "2844e1be-e868-464c-993a-708573874dbf", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("5a08fd69-cf72-4501-92c8-118d0d28231c"), new Guid("006b8234-53e7-4482-a70d-b36c12304431"), "DbContext Yapılandırmasını Kontrol Edin: BeckTechDbContext sınıfınızın doğru yapılandırıldığından emin olun. Bağlantı dizesini ve başlatma sırasında gerekli seçenekleri doğru şekilde sağladığınızdan emin olun.\r\n\r\nVeritabanı Sağlayıcısını Kurulumu: Eğer Entity Framework Core kullanıyorsanız, veritabanı sağlayıcısını doğru şekilde yapılandırdığınızdan emin olun. Kullandığınız veritabanına bağlı olarak, ilave NuGet paketlerini yüklemeniz ve sağlayıcıyı Startup.cs veya Program.cs dosyalarında yapılandırmanız gerekebilir.\r\n\r\nBağımlılık Enjeksiyonu Kurulumu: BeckTechDbContext sınıfınızın bağımlılık enjeksiyonu konteynerine doğru şekilde kaydedildiğinden emin olun. Eğer ASP.NET Core kullanıyorsanız, DbContext'i hizmetler koleksiyonuna eklediğinizden emin olun.\r\n\r\nBağlantı Dizesini Kontrol Edin: Veritabanı bağlantı dizesinin doğru olduğundan ve geçerli bir veritabanı örneğine işaret ettiğinden emin olun. Eğer yerel bir veritabanı kullanıyorsanız, veritabanı sunucusunun çalıştığından emin olun.\r\n\r\nVeritabanı Erişim İzinlerini Kontrol Edin: Uygulamanızın veritabanına bağlanmak için kullandığı kullanıcı hesabının, veri okuma ve yazma izinlerine sahip olduğundan emin olun.\r\n\r\nVarlık Yapılandırmasını Kontrol Edin: Eğer ilişkilendirilmiş varlıklarınızı yapılandırdıysanız, yapılandırmaların doğru olduğundan ve döngüsel bağımlılıklar veya diğer sorunlara neden olmadığından emin olun.\r\n\r\nGünlüğe Almayı ve Hata Ayıklamayı Etkinleştirin: Entity Framework Core için günlükleme özelliğini etkinleştirerek daha detaylı hata mesajları alabilirsiniz. Bu, DbContext oluşturma hatasını daha kesin bir şekilde belirlemenize yardımcı olabilir.\r\n\r\nBaşlatma Günlüklerini İnceleyin: Uygulama başlatma günlüklerini, sorunu daha iyi anlamanıza veya gidermenize yardımcı olabilecek ek hata mesajları veya uyarıları için kontrol edin.", "Admin Test", new DateTime(2024, 3, 19, 2, 12, 44, 629, DateTimeKind.Local).AddTicks(6467), null, null, new Guid("006b8234-53e7-4482-a70d-b36c12304432"), false, null, null, "C# Makalesi", new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e400"), 5 },
                    { new Guid("e19c8707-d5e0-418e-8e2c-f9d65d6a2f8b"), new Guid("e800c003-f241-43d9-8a75-0713987357f5"), "aaaaaaaaa Yapılandırmasını Kontrol Edin: BeckTechDbContext sınıfınızın doğru yapılandırıldığından emin olun. Bağlantı dizesini ve başlatma sırasında gerekli seçenekleri doğru şekilde sağladığınızdan emin olun.\r\n\r\nVeritabanı Sağlayıcısını Kurulumu: Eğer Entity Framework Core kullanıyorsanız, veritabanı sağlayıcısını doğru şekilde yapılandırdığınızdan emin olun. Kullandığınız veritabanına bağlı olarak, ilave NuGet paketlerini yüklemeniz ve sağlayıcıyı Startup.cs veya Program.cs dosyalarında yapılandırmanız gerekebilir.\r\n\r\nBağımlılık Enjeksiyonu Kurulumu: BeckTechDbContext sınıfınızın bağımlılık enjeksiyonu konteynerine doğru şekilde kaydedildiğinden emin olun. Eğer ASP.NET Core kullanıyorsanız, DbContext'i hizmetler koleksiyonuna eklediğinizden emin olun.\r\n\r\nBağlantı Dizesini Kontrol Edin: Veritabanı bağlantı dizesinin doğru olduğundan ve geçerli bir veritabanı örneğine işaret ettiğinden emin olun. Eğer yerel bir veritabanı kullanıyorsanız, veritabanı sunucusunun çalıştığından emin olun.\r\n\r\nVeritabanı Erişim İzinlerini Kontrol Edin: Uygulamanızın veritabanına bağlanmak için kullandığı kullanıcı hesabının, veri okuma ve yazma izinlerine sahip olduğundan emin olun.\r\n\r\nVarlık Yapılandırmasını Kontrol Edin: Eğer ilişkilendirilmiş varlıklarınızı yapılandırdıysanız, yapılandırmaların doğru olduğundan ve döngüsel bağımlılıklar veya diğer sorunlara neden olmadığından emin olun.\r\n\r\nGünlüğe Almayı ve Hata Ayıklamayı Etkinleştirin: Entity Framework Core için günlükleme özelliğini etkinleştirerek daha detaylı hata mesajları alabilirsiniz. Bu, DbContext oluşturma hatasını daha kesin bir şekilde belirlemenize yardımcı olabilir.\r\n\r\nBaşlatma Günlüklerini İnceleyin: Uygulama başlatma günlüklerini, sorunu daha iyi anlamanıza veya gidermenize yardımcı olabilecek ek hata mesajları veya uyarıları için kontrol edin.", "Admin Test", new DateTime(2024, 3, 19, 2, 12, 44, 629, DateTimeKind.Local).AddTicks(6478), null, null, new Guid("e800c003-f241-43d9-8a75-0713987357f6"), false, null, null, "Asp.Net Deneme Makalesi", new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e401"), 5 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("94b70614-d607-4883-8205-442444a54710"), new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e400") },
                    { new Guid("94b70614-d607-4883-8205-442444a54711"), new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e401") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ImageId",
                table: "Articles",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
