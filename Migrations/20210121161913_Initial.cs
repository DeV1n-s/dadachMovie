using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dadachMovie.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    DisplayName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Name = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Nationality = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Name_FA = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Nationality_FA = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(40) CHARACTER SET utf8mb4", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(300) CHARACTER SET utf8mb4", maxLength: 300, nullable: false),
                    ShortDescription = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    ImdbRate = table.Column<float>(type: "float", nullable: false),
                    Lenght = table.Column<int>(type: "int", nullable: false),
                    InTheaters = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AverageRating = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ImdbId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    Picture = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(120) CHARACTER SET utf8mb4", maxLength: 120, nullable: false),
                    ShortBio = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Biography = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Picture = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    IsCast = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDirector = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
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
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    FirstName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    LastName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    Picture = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    RegisterDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MoviesCountries",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesCountries", x => new { x.MovieId, x.CountryId });
                    table.ForeignKey(
                        name: "FK_MoviesCountries_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesCountries_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesGenres",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesGenres", x => new { x.GenreId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_MoviesGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesGenres_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesCasts",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Character = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesCasts", x => new { x.MovieId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_MoviesCasts_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesCasts_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesDirectors",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesDirectors", x => new { x.MovieId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_MoviesDirectors_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesDirectors_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeopleCountries",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleCountries", x => new { x.PersonId, x.CountryId });
                    table.ForeignKey(
                        name: "FK_PeopleCountries_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeopleCountries_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false)
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
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false)
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
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Name = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Value = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "MoviesRating",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesRating", x => new { x.MovieId, x.UserId });
                    table.ForeignKey(
                        name: "FK_MoviesRating_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesRating_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieUser",
                columns: table => new
                {
                    FavoriteMoviesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieUser", x => new { x.FavoriteMoviesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_MovieUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieUser_Movies_FavoriteMoviesId",
                        column: x => x.FavoriteMoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Name_FA", "Nationality", "Nationality_FA" },
                values: new object[,]
                {
                    { 1, "Afghanistan", null, "Afghan", null },
                    { 166, "Nigeria", null, "Nigerian", null },
                    { 167, "Niue", null, "Niuean", null },
                    { 168, "Norfolk Island", null, "Norfolk Islander", null },
                    { 169, "North Korea", null, "North Korean", null },
                    { 170, "North Vietnam", null, "?", null },
                    { 171, "Northern Mariana Islands", null, "American", null },
                    { 172, "Norway", null, "Norwegian", null },
                    { 173, "Oman", null, "Omani", null },
                    { 174, "Pacific Islands Trust Territory", null, "?", null },
                    { 175, "Pakistan", null, "Pakistani", null },
                    { 176, "Palau", null, "Palauan", null },
                    { 177, "Palestinian Territories", null, "Palestinian", null },
                    { 178, "Panama Canal Zone", null, "?", null },
                    { 165, "Niger", null, "Nigerian", null },
                    { 179, "Panama", null, "Panamanian", null },
                    { 181, "Paraguay", null, "Paraguayan", null },
                    { 182, "Peru", null, "Peruvian", null },
                    { 183, "Philippines", null, "Filipino", null },
                    { 184, "Pitcairn Islands", null, "Pitcairn Islander", null },
                    { 185, "Poland", null, "Polish", null },
                    { 186, "Portugal", null, "Portuguese", null },
                    { 187, "Puerto Rico", null, "Puerto Rican", null },
                    { 188, "Qatar", null, "Qatari", null },
                    { 189, "Romania", null, "Romanian", null },
                    { 190, "Russia", null, "Russian", null },
                    { 191, "Rwanda", null, "Rwandan", null },
                    { 192, "Réunion", null, "French", null },
                    { 193, "Saint Barthélemy", null, "Saint Barthélemy Islander", null },
                    { 180, "Papua New Guinea", null, "Papua New Guinean", null },
                    { 164, "Nicaragua", null, "Nicaraguan", null },
                    { 163, "New Zealand", null, "New Zealander", null },
                    { 162, "New Caledonia", null, "New Caledonian", null },
                    { 133, "Madagascar", null, "Malagasy", null },
                    { 134, "Malawi", null, "Malawian", null },
                    { 135, "Malaysia", null, "Malaysian", null },
                    { 136, "Maldives", null, "Maldivan", null },
                    { 137, "Mali", null, "Malian", null },
                    { 138, "Malta", null, "Maltese", null },
                    { 139, "Marshall Islands", null, "Marshallese", null },
                    { 140, "Martinique", null, "French", null },
                    { 141, "Mauritania", null, "Mauritanian", null },
                    { 142, "Mauritius", null, "Mauritian", null },
                    { 143, "Mayotte", null, "French", null },
                    { 144, "Metropolitan France", null, "?", null },
                    { 145, "Mexico", null, "Mexican", null },
                    { 146, "Micronesia", null, "Micronesian", null },
                    { 147, "Midway Islands", null, null, null },
                    { 148, "Moldova", null, "Moldovan", null },
                    { 149, "Monaco", null, "Monegasque", null },
                    { 150, "Mongolia", null, "Mongolian", null },
                    { 151, "Montenegro", null, "Montenegrin", null },
                    { 152, "Montserrat", null, "Montserratian", null },
                    { 153, "Morocco", null, "Moroccan", null },
                    { 154, "Mozambique", null, "Mozambican", null },
                    { 155, "Myanmar [Burma]", null, "Myanmar", null },
                    { 156, "Namibia", null, "Namibian", null },
                    { 157, "Nauru", null, "Nauruan", null },
                    { 158, "Nepal", null, "Nepalese", null },
                    { 159, "Netherlands Antilles", null, "Dutch", null },
                    { 160, "Netherlands", null, "Dutch", null },
                    { 161, "Neutral Zone", null, "?", null },
                    { 194, "Saint Helena", null, "Saint Helenian", null },
                    { 195, "Saint Kitts and Nevis", null, "Kittian and Nevisian", null },
                    { 196, "Saint Lucia", null, "Saint Lucian", null },
                    { 197, "Saint Martin", null, "Saint Martin Islander", null },
                    { 231, "Togo", null, "Togolese", null },
                    { 232, "Tokelau", null, "Tokelauan", null },
                    { 233, "Tonga", null, "Tongan", null },
                    { 234, "Trinidad and Tobago", null, "Trinidadian", null },
                    { 235, "Tunisia", null, "Tunisian", null },
                    { 236, "Turkey", null, "Turkish", null },
                    { 237, "Turkmenistan", null, "Turkmen", null },
                    { 238, "Turks and Caicos Islands", null, "Turks and Caicos Islander", null },
                    { 239, "Tuvalu", null, "Tuvaluan", null },
                    { 240, "U.S. Minor Outlying Islands", null, "American", null },
                    { 241, "U.S. Miscellaneous Pacific Islands", null, "?", null },
                    { 242, "U.S. Virgin Islands", null, "Virgin Islander", null },
                    { 243, "Uganda", null, "Ugandan", null },
                    { 244, "Ukraine", null, "Ukrainian", null },
                    { 245, "Union of Soviet Socialist Republics", null, "?", null },
                    { 246, "United Arab Emirates", null, "Emirati", null },
                    { 247, "United Kingdom", null, "British", null },
                    { 248, "United States", null, "American", null },
                    { 249, "Uruguay", null, "Uruguayan", null },
                    { 250, "Uzbekistan", null, "Uzbekistani", null },
                    { 251, "Vanuatu", null, "Ni-Vanuatu", null },
                    { 252, "Vatican City", null, "Italian", null },
                    { 253, "Venezuela", null, "Venezuelan", null },
                    { 254, "Vietnam", null, "Vietnamese", null },
                    { 255, "Wake Island", null, "?", null },
                    { 256, "Wallis and Futuna", null, "Wallis and Futuna Islander", null },
                    { 257, "Western Sahara", null, "Sahrawi", null },
                    { 258, "Yemen", null, "Yemeni", null },
                    { 259, "Zambia", null, "Zambian", null },
                    { 230, "Timor-Leste", null, "East Timorese", null },
                    { 132, "Macedonia", null, "Macedonian", null },
                    { 229, "Thailand", null, "Thai", null },
                    { 227, "Tajikistan", null, "Tadzhik", null },
                    { 198, "Saint Pierre and Miquelon", null, "French", null },
                    { 199, "Saint Vincent and the Grenadines", null, "Saint Vincentian", null },
                    { 200, "Samoa", null, "Samoan", null },
                    { 201, "San Marino", null, "Sammarinese", null },
                    { 202, "Saudi Arabia", null, "Saudi Arabian", null },
                    { 203, "Senegal", null, "Senegalese", null },
                    { 204, "Serbia and Montenegro", null, "Montenegrins, Serbs", null },
                    { 205, "Serbia", null, "Serbian", null },
                    { 206, "Seychelles", null, "Seychellois", null },
                    { 207, "Sierra Leone", null, "Sierra Leonean", null },
                    { 208, "Singapore", null, "Singaporean", null },
                    { 209, "Slovakia", null, "Slovak", null },
                    { 210, "Slovenia", null, "Slovene", null },
                    { 211, "Solomon Islands", null, "Solomon Islander", null },
                    { 212, "Somalia", null, "Somali", null },
                    { 213, "South Africa", null, "South African", null },
                    { 214, "South Georgia and the South Sandwich Islands", null, "South Georgia and the South Sandwich Islander", null },
                    { 215, "South Korea", null, "South Korean", null },
                    { 216, "Spain", null, "Spanish", null },
                    { 217, "Sri Lanka", null, "Sri Lankan", null },
                    { 218, "Sudan", null, "Sudanese", null },
                    { 219, "Suriname", null, "Surinamer", null },
                    { 220, "Svalbard and Jan Mayen", null, "Norwegian", null },
                    { 221, "Swaziland", null, "Swazi", null },
                    { 222, "Sweden", null, "Swedish", null },
                    { 223, "Switzerland", null, "Swiss", null },
                    { 224, "Syria", null, "Syrian", null },
                    { 225, "São Tomé and Príncipe", null, "Sao Tomean", null },
                    { 226, "Taiwan", null, "Taiwanese", null },
                    { 228, "Tanzania", null, "Tanzanian", null },
                    { 260, "Zimbabwe", null, "Zimbabwean", null },
                    { 131, "Macau SAR China", null, "Chinese", null },
                    { 129, "Lithuania", null, "Lithuanian", null },
                    { 35, "Bulgaria", null, "Bulgarian", null },
                    { 36, "Burkina Faso", null, "Burkinabe", null },
                    { 37, "Burundi", null, "Burundian", null },
                    { 38, "Cambodia", null, "Cambodian", null },
                    { 39, "Cameroon", null, "Cameroonian", null },
                    { 40, "Canada", null, "Canadian", null },
                    { 41, "Canton and Enderbury Islands", null, "?", null },
                    { 42, "Cape Verde", null, "Cape Verdian", null },
                    { 43, "Cayman Islands", null, "Caymanian", null },
                    { 44, "Central African Republic", null, "Central African", null },
                    { 45, "Chad", null, "Chadian", null },
                    { 46, "Chile", null, "Chilean", null },
                    { 47, "China", null, "Chinese", null },
                    { 34, "Brunei", null, "Bruneian", null },
                    { 48, "Christmas Island", null, "Christmas Island", null },
                    { 50, "Colombia", null, "Colombian", null },
                    { 51, "Comoros", null, "Comoran", null },
                    { 52, "Congo - Brazzaville", null, "Congolese", null },
                    { 53, "Congo - Kinshasa", null, "Congolese", null },
                    { 54, "Cook Islands", null, "Cook Islander", null },
                    { 55, "Costa Rica", null, "Costa Rican", null },
                    { 56, "Croatia", null, "Croatian", null },
                    { 57, "Cuba", null, "Cuban", null },
                    { 58, "Cyprus", null, "Cypriot", null },
                    { 59, "Czech Republic", null, "Czech", null },
                    { 60, "Côte d’Ivoire", null, "Ivorian", null },
                    { 61, "Denmark", null, "Danish", null },
                    { 62, "Djibouti", null, "Djibouti", null },
                    { 49, "Cocos [Keeling] Islands", null, "Cocos Islander", null },
                    { 33, "British Virgin Islands", null, "Virgin Islander", null },
                    { 32, "British Indian Ocean Territory", null, "Indian", null },
                    { 31, "British Antarctic Territory", null, "Dutch", null },
                    { 2, "Albania", null, "Albanian", null },
                    { 3, "Algeria", null, "Algerian", null },
                    { 4, "American Samoa", null, "American Samoan", null },
                    { 5, "Andorra", null, "Andorran", null },
                    { 6, "Angola", null, "Angolan", null },
                    { 7, "Anguilla", null, "Anguillian", null },
                    { 8, "Antarctica", null, "?", null },
                    { 9, "Antigua and Barbuda", null, "Antiguan, Barbudan", null },
                    { 10, "Argentina", null, "Argentinean", null },
                    { 11, "Armenia", null, "Armenian", null },
                    { 12, "Aruba", null, "Aruban", null },
                    { 13, "Australia", null, "Australian", null },
                    { 14, "Austria", null, "Austrian", null },
                    { 15, "Azerbaijan", null, "Azerbaijani", null },
                    { 16, "Bahamas", null, "Bahamian", null },
                    { 17, "Bahrain", null, "Bahraini", null },
                    { 18, "Bangladesh", null, "Bangladeshi", null },
                    { 19, "Barbados", null, "Barbadian", null },
                    { 20, "Belarus", null, "Belarusian", null },
                    { 21, "Belgium", null, "Belgian", null },
                    { 22, "Belize", null, "Belizean", null },
                    { 23, "Benin", null, "Beninese", null },
                    { 24, "Bermuda", null, "Bermudian", null },
                    { 25, "Bhutan", null, "Bhutanese", null },
                    { 26, "Bolivia", null, "Bolivian", null },
                    { 27, "Bosnia and Herzegovina", null, "Bosnian, Herzegovinian", null },
                    { 28, "Botswana", null, "Motswana", null },
                    { 29, "Bouvet Island", null, "?", null },
                    { 30, "Brazil", null, "Brazilian", null },
                    { 63, "Dominica", null, "Dominican", null },
                    { 64, "Dominican Republic", null, "Dominican", null },
                    { 65, "Dronning Maud Land", null, "?", null },
                    { 66, "Ecuador", null, "Ecuadorean", null },
                    { 100, "Honduras", null, "Honduran", null },
                    { 101, "Hong Kong SAR China", null, "Chinese", null },
                    { 102, "Hungary", null, "Hungarian", null },
                    { 103, "Iceland", null, "Icelander", null },
                    { 104, "India", null, "Indian", null },
                    { 105, "Indonesia", null, "Indonesian", null },
                    { 106, "Iran", null, "Iranian", null },
                    { 107, "Iraq", null, "Iraqi", null },
                    { 108, "Ireland", null, "Irish", null },
                    { 109, "Isle of Man", null, "Manx", null },
                    { 110, "Israel", null, "Israeli", null },
                    { 111, "Italy", null, "Italian", null },
                    { 112, "Jamaica", null, "Jamaican", null },
                    { 113, "Japan", null, "Japanese", null },
                    { 114, "Jersey", null, "Channel Islander", null },
                    { 115, "Johnston Island", null, "?", null },
                    { 116, "Jordan", null, "Jordanian", null },
                    { 117, "Kazakhstan", null, "Kazakhstani", null },
                    { 118, "Kenya", null, "Kenyan", null },
                    { 119, "Kiribati", null, "I-Kiribati", null },
                    { 120, "Kuwait", null, "Kuwaiti", null },
                    { 121, "Kyrgyzstan", null, "Kirghiz", null },
                    { 122, "Laos", null, "Laotian", null },
                    { 123, "Latvia", null, "Latvian", null },
                    { 124, "Lebanon", null, "Lebanese", null },
                    { 125, "Lesotho", null, "Mosotho", null },
                    { 126, "Liberia", null, "Liberian", null },
                    { 127, "Libya", null, "Libyan", null },
                    { 128, "Liechtenstein", null, "Liechtensteiner", null },
                    { 99, "Heard Island and McDonald Islands", null, "Heard and McDonald Islander", null },
                    { 130, "Luxembourg", null, "Luxembourger", null },
                    { 98, "Haiti", null, "Haitian", null },
                    { 96, "Guinea-Bissau", null, "Guinea-Bissauan", null },
                    { 67, "Egypt", null, "Egyptian", null },
                    { 68, "El Salvador", null, "Salvadoran", null },
                    { 69, "Equatorial Guinea", null, "Equatorial Guinean", null },
                    { 70, "Eritrea", null, "Eritrean", null },
                    { 71, "Estonia", null, "Estonian", null },
                    { 72, "Ethiopia", null, "Ethiopian", null },
                    { 73, "Falkland Islands", null, "Falkland Islander", null },
                    { 74, "Faroe Islands", null, "Faroese", null },
                    { 75, "Fiji", null, "Fijian", null },
                    { 76, "Finland", null, "Finnish", null },
                    { 77, "France", null, "French", null },
                    { 78, "French Guiana", null, "?", null },
                    { 79, "French Polynesia", null, "French Polynesian", null },
                    { 80, "French Southern Territories", null, "French", null },
                    { 81, "French Southern and Antarctic Territories", null, "?", null },
                    { 82, "Gabon", null, "Gabonese", null },
                    { 83, "Gambia", null, "Gambian", null },
                    { 84, "Georgia", null, "Georgian", null },
                    { 85, "Germany", null, "German", null },
                    { 86, "Ghana", null, "Ghanaian", null },
                    { 87, "Gibraltar", null, "Gibraltar", null },
                    { 88, "Greece", null, "Greek", null },
                    { 89, "Greenland", null, "Greenlandic", null },
                    { 90, "Grenada", null, "Grenadian", null },
                    { 91, "Guadeloupe", null, "Guadeloupian", null },
                    { 92, "Guam", null, "Guamanian", null },
                    { 93, "Guatemala", null, "Guatemalan", null },
                    { 94, "Guernsey", null, "Channel Islander", null },
                    { 95, "Guinea", null, "Guinean", null },
                    { 97, "Guyana", null, "Guyanese", null },
                    { 261, "Åland Islands", null, "Swedish", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                name: "IX_AspNetUsers_CountryId",
                table: "AspNetUsers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ImdbId",
                table: "Movies",
                column: "ImdbId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoviesCasts_PersonId",
                table: "MoviesCasts",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesCountries_CountryId",
                table: "MoviesCountries",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesDirectors_PersonId",
                table: "MoviesDirectors",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesGenres_MovieId",
                table: "MoviesGenres",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesRating_UserId",
                table: "MoviesRating",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieUser_UsersId",
                table: "MovieUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleCountries_CountryId",
                table: "PeopleCountries",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleCountries_PersonId",
                table: "PeopleCountries",
                column: "PersonId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "MoviesCasts");

            migrationBuilder.DropTable(
                name: "MoviesCountries");

            migrationBuilder.DropTable(
                name: "MoviesDirectors");

            migrationBuilder.DropTable(
                name: "MoviesGenres");

            migrationBuilder.DropTable(
                name: "MoviesRating");

            migrationBuilder.DropTable(
                name: "MovieUser");

            migrationBuilder.DropTable(
                name: "PeopleCountries");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
