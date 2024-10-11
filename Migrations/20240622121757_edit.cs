using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Group_4_Intake_44.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 43);

            migrationBuilder.AlterColumn<string>(
                name: "SpecialTag",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SpecialTag",
                table: "Product",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "BrandID", "CategoryID", "Description", "Image", "Name", "Price", "Quantity", "SpecialTag" },
                values: new object[,]
                {
                    { 1, 1, 1, "Apple MacBook Air - M1 chip with 8-core CPU and 7-core GPU - 8GB - 256GB - M1 chip -13 inch - MacOs - Space Grey", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/661473ab953cdcdf4c3b607144109b90/z/a/za138.png", "Apple MacBook Air - M1 chip", 47999.0, 5, " " },
                    { 2, 1, 1, "Apple Macbook Air M2 Laptop - M2 chip 8 Cores CPU With 8 Cores GPU - 8GB - 256 GB - 13 inch - Space Gray", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/z/a/za508.png", "Apple Macbook Air - M2 chip", 65999.0, 3, " " },
                    { 3, 1, 1, "Apple Macbook Pro M3 - 8 Cores CPU With 10 Cores GPU - 8GB - 512GB SSD - 14 inch MacOs - Silver", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/z/a/za208.png", "Apple Macbook Pro M3", 107999.0, 2, " " },
                    { 4, 2, 1, "ASUS TUF Gaming F15 FA507VV4-LP105W Laptop - Intel® Core™ i9-13900H - 16GB - 512GB SSD - NVIDIA® GeForce® RTX™ 4060 8GB - 15.6'' FHD - Win11 - Gray", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/z/u/zu617-1.png", "ASUS TUF Gaming F15", 69999.0, 4, " " },
                    { 5, 2, 1, "ASUS Zenbook 14 OLED UX3405MA-PP381WS Laptop - Intel® Core™ Ultra 7-155H - 16GB - 1TB SSD - Intel® Arc™ Graphics - 14.0'' OLED - Win11 - Ponder Blue", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/z/u/zu462-1_1.png", "ASUS Zenbook 14 OLED", 77999.0, 3, " " },
                    { 6, 2, 1, "ASUS Zenbook 13 OLED UX5304MA-NQ007WS Laptop - Intel® Ultra 7-155U - 16GB - 1TB SSD - Intel® Iris Xe Graphics - 13.3 FHD OLED - Win11 - Ponder Blude", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/z/u/zu465.png", "ASUS Zenbook 13 OLED", 60599.0, 4, " " },
                    { 7, 3, 1, "HP EliteBook 840 G8 Laptop - Intel® Core™ i7-1165G7 - 8 GB - 512GB SSD - Intel® Iris® Xᵉ Graphics - 14” FHD - Windows 11 Pro - Silver", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/661473ab953cdcdf4c3b607144109b90/z/i/zi058-1-2b_2_1.jpg", "HP EliteBook 840 G8 Laptop", 59999.0, 3, " " },
                    { 8, 3, 1, "HP ENVY x360 13-bf0001ne Laptop - Intel® Core™ i7-1250U - 16GB - 1TB SSD - Intel® Iris® Xᵉ Graphics - 13.3 WUXGA - Win11 - Natural Silver", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/661473ab953cdcdf4c3b607144109b90/z/h/zh392-1-2bjpg.jpg", "HP ENVY x360 13-bf0001ne Laptop ", 59799.0, 5, " " },
                    { 9, 3, 1, "HP ProBook 450 G9 Laptop - Intel® Core™ i7-1255U - 8GB - 512GB SSD - NVIDIA® GeForce® MX570 - 15.6 HD - Silver Aluminum", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/661473ab953cdcdf4c3b607144109b90/z/h/zh897-1-2b_1.jpg", "HP ProBook 450 G9 Laptop", 45999.0, 3, " " },
                    { 10, 4, 1, "Lenovo Legion 7 Pro 16IRX8H Laptop - Intel® Core™ i9-13900HX -32GB - 1TBSSD - NVIDIA® GeForce RTX™ 4090 16GB - 16 WQXGA - Win11 - Onyx Grey", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/661473ab953cdcdf4c3b607144109b90/z/l/zl880-new.png", "Lenovo Legion 7 Pro", 165999.0, 5, " " },
                    { 11, 4, 1, "Lenovo Legion 5 16IRX9 Laptop - Intel® Core™ i7-14650HX - 16GB - 1TB SSD - NVIDIA® GeForce RTX™ 4060 8GB - 16 WQXGA - Win11 - Luna Grey", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/661473ab953cdcdf4c3b607144109b90/z/l/zl420-new.png", "Lenovo Legion 5 16IRX9", 89999.0, 4, " " },
                    { 12, 4, 1, "Lenovo ThinkPad-E14 Laptop - Intel® Core™ i7-1355U - 8GB - 512GB SSD - NVIDIA® Geforce MX550 2GB - 14.0 FHD - Graphite Black", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/661473ab953cdcdf4c3b607144109b90/z/l/zl415-1_1.png", "Lenovo ThinkPad-E14", 58999.0, 6, " " },
                    { 13, 4, 1, "Lenovo IdeaPad 5 15ITL05 Laptop - Intel® Core™ i7-1165G7 - 8GB - 512 SSD - NVIDIA® GeForce MX450 2GB - 15.6 FHD - Grey", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/d33f1c152d6eb7e8608a208d80f21a14/z/l/zl350-2b-1y.jpg", "Lenovo IdeaPad 5", 31999.0, 6, " " },
                    { 14, 5, 1, "Skip to the beginning of the images gallery Dell Latitude 5430 XCTO Laptop - Intel® Core™ i7-1265U vPro - 16 GB - 512 GB SSD - Intel Iris Xe Graphics -14” FHD - Silver", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/z/d/zd062-edited.jpg", "Dell Latitude 5430 XCTO", 639000.0, 3, " " },
                    { 15, 5, 1, "Dell Gaming 5530 G15 Laptop - Intel® Core™ i7-13650HX - 16GB - 512GB SSD - NVIDIA® GeForce RTX™ 3050 6GB - 15.6 FHD - Win 10 - Dark Shadow Grey", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/z/d/zd190.png", "Dell Gaming 5530 G15", 50999.0, 5, " " },
                    { 16, 1, 2, "The iPhone 15 Pro Max display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle. When measured as a standard rectangular shape, the screen is 6.69 inches diagonally", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/m/a/ma645-1.jpg", "Apple iPhone 15 Pro Max 256GB - Black", 66999.0, 10, " " },
                    { 17, 1, 2, "The iPhone 15 Pro display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle. When measured as a standard rectangular shape, the screen is 6.12 inches diagonally", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/m/a/ma762-1_1.jpg", "Apple iPhone 15 Pro - 128GB - Black", 42999.0, 8, " " },
                    { 18, 1, 2, "The iPhone 14 display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/661473ab953cdcdf4c3b607144109b90/i/p/iphone14-6.jpg", "Apple iPhone 14 - 128GB - Blue", 35999.0, 12, " " },
                    { 19, 1, 3, "", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/w/t/wt705-1-min.jpg", "Apple Watch Ultra 49MM Titanium -", 44999.0, 5, " " },
                    { 20, 1, 3, "", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/w/t/wt305-1.jpg", "Apple Watch Ultra 49MM Titanium Case Black Alpine Loop", 44999.0, 7, " " },
                    { 21, 6, 2, "Samsung Galaxy A15 - 8GB RAM - 256GB - Blue Black", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/b/l/black-min_3.jpg", "Samsung Galaxy A15", 8799.0, 15, " " },
                    { 22, 6, 2, "Samsung Galaxy Tab A9 - 4GB RAM - 64GB - Navy", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/z/g/zg749-1.jpg", "Samsung Galaxy Tab A9", 7899.0, 20, " " },
                    { 23, 6, 2, "Samsung Galaxy A34 - 8GB RAM - 256GB - Black", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/s/a/samsung_galaxy_a34-black_0003_layer_1_1.jpg", "Samsung Galaxy A34", 14899.0, 10, " " },
                    { 24, 6, 2, "Samsung Galaxy A55 5G - 8GB RAM - 128GB - Ice BLUE", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/z/g/zg.png", "Samsung Galaxy A55 5G", 21999.0, 12, " " },
                    { 25, 7, 2, "Xiaomi Redmi 10C - 4GB RAM - 64GB - Green", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/x/i/xiaomi-redmi-note-12-3_1.jpg", "Xiaomi Redmi 10C", 8899.0, 15, " " },
                    { 26, 7, 2, "Xiaomi Redmi Note 12 - 6GB RAM - 128GB - Sunrise Gold", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/x/i/xiaomi-redmi-note--sunrise-gold-1_1.jpg", "Xiaomi Redmi Note 12", 7799.0, 10, " " },
                    { 27, 7, 2, "Xiaomi Redmi Pad 6 - 8GB RAM - 256GB - Grey", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/z/r/zr610-1.jpg", "Xiaomi Redmi Pad 6", 17999.0, 5, " " },
                    { 28, 7, 3, "Xiaomi Redmi Pad 6 - 8GB RAM - 256GB - Grey", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/w/t/wt206-10-min.jpg", "Xiaomi Watch S1 - Black", 7499.0, 15, " " },
                    { 29, 8, 3, "", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/w/t/wt044-1-min_1.jpg", "Huawei Band 7 - Black (PH Warranty)", 1999.0, 6, " " },
                    { 30, 8, 2, "", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/h/u/huawei-nova-10-se-silver-1.jpg", "Huawei Nova 10 SE 8GB RAM - 256GB - Silver", 13999.0, 10, " " },
                    { 31, 8, 3, "", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/g/t/gt4-min_2_1_1.jpg", "Huawei Watch GT 4 46 mm - Brown", 10499.0, 8, " " },
                    { 32, 8, 2, "", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/m/i/mi702--66.jpg", "Huawei nova Y91 - 8GB RAM - 256GB - Midnight Black", 13999.0, 9, " " },
                    { 33, 8, 2, "", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/m/i/mi884-67.jpg", "Huawei nova Y61 - 4GB RAM - 64GB - Sapphire Blue", 6799.0, 6, " " },
                    { 34, 6, 4, "", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/t/v/tv422-00-min.jpg", "Samsung TV 65 LED UHD Smart Built In Receiver - CU8000", 27899.0, 10, " " },
                    { 35, 6, 4, "", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/t/v/tv187-00-min.jpg", "Samsung TV 43 Inch FHD LED Smart - Model", 14099.0, 8, " " },
                    { 36, 6, 4, "", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/t/v/tv220-1-min.jpg", "Samsung TV 65 Inch OLED 4K UHD Smart Built In Receiver", 84999.0, 10, " " },
                    { 37, 6, 4, "", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/t/v/tv422-00-min_1.jpg", "Samsung TV 55 LED UHD Smart Built In Receiver ", 23699.0, 6, " " },
                    { 38, 9, 4, "", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/t/v/tv770-00-min.jpg", "LG TV 43 LED UHD Smart Built In Receiver", 16499.0, 8, " " },
                    { 39, 9, 4, "", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/t/v/tv775-1_1_1_1.jpg", "LG 55 LED UHD Smart Built In Receiver with Magic Remote", 21699.0, 12, " " },
                    { 40, 7, 5, "", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/h/p/hp291-1.jpg", "Xiaomi Redmi Buds 3 Pro - Glacier Gray", 1100.0, 8, " " },
                    { 41, 7, 5, "", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/h/p/hp294-1-min.jpg", "Xiaomi Redmi Buds 3T Pro - Aurora Green", 4200.0, 10, " " },
                    { 42, 7, 5, "", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/h/p/hp760-11-min_1.jpg", "Xiaomi Buds 3 TWS Earphone - White", 2899.0, 5, " " },
                    { 43, 1, 4, "", "https://smhttp-ssl-73217.nexcesscdn.net/pub/media/catalog/product/cache/08a84a1c53d21da95cee3377f8156b2c/h/p/hp252-12.jpg", "Apple AirPods 3rd Generation - White", 10899.0, 10, " " }
                });
        }
    }
}
