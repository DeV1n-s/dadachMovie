using Microsoft.EntityFrameworkCore.Migrations;

namespace dadachMovie.Migrations
{
    public partial class AddedDataToCountriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name_FA",
                table: "Countries",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality_FA",
                table: "Countries",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DropColumn(
                name: "Name_FA",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Nationality_FA",
                table: "Countries");
        }
    }
}
