﻿// <auto-generated />
using System;
using BeckTech.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeckTech.Data.Migrations
{
    [DbContext(typeof(BeckTechDbContext))]
    [Migration("20240517162531_updateContent2")]
    partial class updateContent2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BechTech.Entity.Entities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("94b70614-d607-4883-8205-442444a54710"),
                            ConcurrencyStamp = "59262c1d-167a-4720-96a2-b416bcd6ad12",
                            Name = "SuperAdmin",
                            NormalizedName = "SUPERADMIN"
                        },
                        new
                        {
                            Id = new Guid("94b70614-d607-4883-8205-442444a54711"),
                            ConcurrencyStamp = "2d6d30dd-8066-420e-9bca-d71ecddb45fc",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("94b70614-d607-4883-8205-442444a54712"),
                            ConcurrencyStamp = "a5b5921b-4ca0-4f08-bf9b-e3fdfb77e058",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("BechTech.Entity.Entities.AppRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("BechTech.Entity.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e400"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e8774630-cb67-4d1d-ac0c-98d548281f73",
                            Email = "superadmin@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Batuhan",
                            ImageId = new Guid("006b8234-53e7-4482-a70d-b36c12304432"),
                            LastName = "Aral",
                            LockoutEnabled = false,
                            NormalizedEmail = "SUPERADMIN@GMAIL.COM",
                            NormalizedUserName = "SUPERADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ+C8uALtGtw2X7EJSCWncpZ997gYLPcLBWUVT7LXAc4sBa+bAUW9t+JywyHLTdPZQ==",
                            PhoneNumber = "+905434579738",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "045f6548-aaf2-4a19-858c-b9f735e8b419",
                            TwoFactorEnabled = false,
                            UserName = "superadmin@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e401"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3c0dfbe9-b988-4a82-8725-a630c03fe597",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Eymen",
                            ImageId = new Guid("e800c003-f241-43d9-8a75-0713987357f6"),
                            LastName = "Dogan",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEOZo3k8h/3Vy7w9WEMdPZmwJ8vvCrkp/6jsPj5FMSpT31zVsyQhL1zp2oS4qSenWvA==",
                            PhoneNumber = "+905434579738",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e12e1d53-5e34-4ce6-9220-25c02d7a11dd",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        });
                });

            modelBuilder.Entity("BechTech.Entity.Entities.AppUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("BechTech.Entity.Entities.AppUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("BechTech.Entity.Entities.AppUserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e400"),
                            RoleId = new Guid("94b70614-d607-4883-8205-442444a54710")
                        },
                        new
                        {
                            UserId = new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e401"),
                            RoleId = new Guid("94b70614-d607-4883-8205-442444a54711")
                        });
                });

            modelBuilder.Entity("BechTech.Entity.Entities.AppUserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BechTech.Entity.Entities.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ImageId");

                    b.HasIndex("UserId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c6810b5c-2468-43f3-9551-2164ad9fd6f8"),
                            CategoryId = new Guid("006b8234-53e7-4482-a70d-b36c12304431"),
                            Content = "DbContext Yapılandırmasını Kontrol Edin: BeckTechDbContext sınıfınızın doğru yapılandırıldığından emin olun. Bağlantı dizesini ve başlatma sırasında gerekli seçenekleri doğru şekilde sağladığınızdan emin olun.\r\n\r\nVeritabanı Sağlayıcısını Kurulumu: Eğer Entity Framework Core kullanıyorsanız, veritabanı sağlayıcısını doğru şekilde yapılandırdığınızdan emin olun. Kullandığınız veritabanına bağlı olarak, ilave NuGet paketlerini yüklemeniz ve sağlayıcıyı Startup.cs veya Program.cs dosyalarında yapılandırmanız gerekebilir.\r\n\r\nBağımlılık Enjeksiyonu Kurulumu: BeckTechDbContext sınıfınızın bağımlılık enjeksiyonu konteynerine doğru şekilde kaydedildiğinden emin olun. Eğer ASP.NET Core kullanıyorsanız, DbContext'i hizmetler koleksiyonuna eklediğinizden emin olun.\r\n\r\nBağlantı Dizesini Kontrol Edin: Veritabanı bağlantı dizesinin doğru olduğundan ve geçerli bir veritabanı örneğine işaret ettiğinden emin olun. Eğer yerel bir veritabanı kullanıyorsanız, veritabanı sunucusunun çalıştığından emin olun.\r\n\r\nVeritabanı Erişim İzinlerini Kontrol Edin: Uygulamanızın veritabanına bağlanmak için kullandığı kullanıcı hesabının, veri okuma ve yazma izinlerine sahip olduğundan emin olun.\r\n\r\nVarlık Yapılandırmasını Kontrol Edin: Eğer ilişkilendirilmiş varlıklarınızı yapılandırdıysanız, yapılandırmaların doğru olduğundan ve döngüsel bağımlılıklar veya diğer sorunlara neden olmadığından emin olun.\r\n\r\nGünlüğe Almayı ve Hata Ayıklamayı Etkinleştirin: Entity Framework Core için günlükleme özelliğini etkinleştirerek daha detaylı hata mesajları alabilirsiniz. Bu, DbContext oluşturma hatasını daha kesin bir şekilde belirlemenize yardımcı olabilir.\r\n\r\nBaşlatma Günlüklerini İnceleyin: Uygulama başlatma günlüklerini, sorunu daha iyi anlamanıza veya gidermenize yardımcı olabilecek ek hata mesajları veya uyarıları için kontrol edin.",
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2024, 5, 17, 19, 25, 30, 529, DateTimeKind.Local).AddTicks(9303),
                            ImageId = new Guid("006b8234-53e7-4482-a70d-b36c12304432"),
                            IsDeleted = false,
                            Title = "C# Makalesi",
                            UserId = new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e400"),
                            ViewCount = 5
                        },
                        new
                        {
                            Id = new Guid("512b6dfb-8431-4378-b614-a9e24630ef0f"),
                            CategoryId = new Guid("e800c003-f241-43d9-8a75-0713987357f5"),
                            Content = "aaaaaaaaa Yapılandırmasını Kontrol Edin: BeckTechDbContext sınıfınızın doğru yapılandırıldığından emin olun. Bağlantı dizesini ve başlatma sırasında gerekli seçenekleri doğru şekilde sağladığınızdan emin olun.\r\n\r\nVeritabanı Sağlayıcısını Kurulumu: Eğer Entity Framework Core kullanıyorsanız, veritabanı sağlayıcısını doğru şekilde yapılandırdığınızdan emin olun. Kullandığınız veritabanına bağlı olarak, ilave NuGet paketlerini yüklemeniz ve sağlayıcıyı Startup.cs veya Program.cs dosyalarında yapılandırmanız gerekebilir.\r\n\r\nBağımlılık Enjeksiyonu Kurulumu: BeckTechDbContext sınıfınızın bağımlılık enjeksiyonu konteynerine doğru şekilde kaydedildiğinden emin olun. Eğer ASP.NET Core kullanıyorsanız, DbContext'i hizmetler koleksiyonuna eklediğinizden emin olun.\r\n\r\nBağlantı Dizesini Kontrol Edin: Veritabanı bağlantı dizesinin doğru olduğundan ve geçerli bir veritabanı örneğine işaret ettiğinden emin olun. Eğer yerel bir veritabanı kullanıyorsanız, veritabanı sunucusunun çalıştığından emin olun.\r\n\r\nVeritabanı Erişim İzinlerini Kontrol Edin: Uygulamanızın veritabanına bağlanmak için kullandığı kullanıcı hesabının, veri okuma ve yazma izinlerine sahip olduğundan emin olun.\r\n\r\nVarlık Yapılandırmasını Kontrol Edin: Eğer ilişkilendirilmiş varlıklarınızı yapılandırdıysanız, yapılandırmaların doğru olduğundan ve döngüsel bağımlılıklar veya diğer sorunlara neden olmadığından emin olun.\r\n\r\nGünlüğe Almayı ve Hata Ayıklamayı Etkinleştirin: Entity Framework Core için günlükleme özelliğini etkinleştirerek daha detaylı hata mesajları alabilirsiniz. Bu, DbContext oluşturma hatasını daha kesin bir şekilde belirlemenize yardımcı olabilir.\r\n\r\nBaşlatma Günlüklerini İnceleyin: Uygulama başlatma günlüklerini, sorunu daha iyi anlamanıza veya gidermenize yardımcı olabilecek ek hata mesajları veya uyarıları için kontrol edin.",
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2024, 5, 17, 19, 25, 30, 529, DateTimeKind.Local).AddTicks(9310),
                            ImageId = new Guid("e800c003-f241-43d9-8a75-0713987357f6"),
                            IsDeleted = false,
                            Title = "Asp.Net Deneme Makalesi",
                            UserId = new Guid("0b66f151-e4ab-4a80-b867-6b868cf2e401"),
                            ViewCount = 5
                        });
                });

            modelBuilder.Entity("BechTech.Entity.Entities.ArticleVisitor", b =>
                {
                    b.Property<Guid>("ArticleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("VisitorId")
                        .HasColumnType("int");

                    b.HasKey("ArticleId", "VisitorId");

                    b.HasIndex("VisitorId");

                    b.ToTable("ArticleVisitors");
                });

            modelBuilder.Entity("BechTech.Entity.Entities.Bulletin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Bulletins");
                });

            modelBuilder.Entity("BechTech.Entity.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("006b8234-53e7-4482-a70d-b36c12304431"),
                            CreatedBy = "AdminTest",
                            CreatedDate = new DateTime(2024, 5, 17, 19, 25, 30, 530, DateTimeKind.Local).AddTicks(678),
                            IsDeleted = false,
                            Name = "C#"
                        },
                        new
                        {
                            Id = new Guid("e800c003-f241-43d9-8a75-0713987357f5"),
                            CreatedBy = "AdminTest",
                            CreatedDate = new DateTime(2024, 5, 17, 19, 25, 30, 530, DateTimeKind.Local).AddTicks(681),
                            IsDeleted = false,
                            Name = "Asp.Net"
                        });
                });

            modelBuilder.Entity("BechTech.Entity.Entities.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameSurname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("BechTech.Entity.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = new Guid("006b8234-53e7-4482-a70d-b36c12304432"),
                            CreatedBy = "Test Admin",
                            CreatedDate = new DateTime(2024, 5, 17, 19, 25, 30, 530, DateTimeKind.Local).AddTicks(811),
                            FileName = "images/testimage",
                            FileType = "jpg",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = new Guid("e800c003-f241-43d9-8a75-0713987357f6"),
                            CreatedBy = "Test Admin",
                            CreatedDate = new DateTime(2024, 5, 17, 19, 25, 30, 530, DateTimeKind.Local).AddTicks(815),
                            FileName = "images/testimage",
                            FileType = "jpg",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("BechTech.Entity.Entities.Visitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserAgent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Visitors");
                });

            modelBuilder.Entity("BechTech.Entity.Entities.AppRoleClaim", b =>
                {
                    b.HasOne("BechTech.Entity.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BechTech.Entity.Entities.AppUser", b =>
                {
                    b.HasOne("BechTech.Entity.Entities.Image", "Image")
                        .WithMany("Users")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");
                });

            modelBuilder.Entity("BechTech.Entity.Entities.AppUserClaim", b =>
                {
                    b.HasOne("BechTech.Entity.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BechTech.Entity.Entities.AppUserLogin", b =>
                {
                    b.HasOne("BechTech.Entity.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BechTech.Entity.Entities.AppUserRole", b =>
                {
                    b.HasOne("BechTech.Entity.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BechTech.Entity.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BechTech.Entity.Entities.AppUserToken", b =>
                {
                    b.HasOne("BechTech.Entity.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BechTech.Entity.Entities.Article", b =>
                {
                    b.HasOne("BechTech.Entity.Entities.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BechTech.Entity.Entities.Image", "Image")
                        .WithMany("Articles")
                        .HasForeignKey("ImageId");

                    b.HasOne("BechTech.Entity.Entities.AppUser", "User")
                        .WithMany("Articles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Image");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BechTech.Entity.Entities.ArticleVisitor", b =>
                {
                    b.HasOne("BechTech.Entity.Entities.Article", "Article")
                        .WithMany("ArticleVisitors")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BechTech.Entity.Entities.Visitor", "Visitor")
                        .WithMany("ArticleVisitors")
                        .HasForeignKey("VisitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("BechTech.Entity.Entities.AppUser", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("BechTech.Entity.Entities.Article", b =>
                {
                    b.Navigation("ArticleVisitors");
                });

            modelBuilder.Entity("BechTech.Entity.Entities.Category", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("BechTech.Entity.Entities.Image", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("BechTech.Entity.Entities.Visitor", b =>
                {
                    b.Navigation("ArticleVisitors");
                });
#pragma warning restore 612, 618
        }
    }
}
