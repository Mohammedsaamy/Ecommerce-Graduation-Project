using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Group_4_Intake_44.Migrations
{
    /// <inheritdoc />
    public partial class after2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Stores",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "ID", "Address", "CarNumbers", "FacebookLink", "Lat", "Long", "MobileNumber", "Name", "Store_ProductID", "whatsappNumber" },
                values: new object[,]
                {
                    { 1, "علام حسين، النصر، باب الشعرية، محافظة القاهرة‬ 11311", 10, "//ourStore.com", 31.264639797811899, 30.066393856441799, "+201157760283", "bab elshaaria", null, "+201019879660" },
                    { 2, "طوسون،روضالفرج،محافظةالقاهرة‬ 11311", 15, "//ourStore.com", 31.243697112607599, 30.0842198767313, "+201157760283", "Rod elfarag", null, "+201019879660" },
                    { 3, "شارع مكرم عبيد، المنطقة السادسة، مدينة نصر، محافظة القاهرة‬ 4450345", 15, "//ourStore.com", 31.343650827501101, 30.0686854249143, "+201157760283", "Nasr city", null, "+201019879660" },
                    { 4, "4J5H+M95، مدينتى، ثانى القاهرة الجديدة،، ثانى القاهرة الجديدة، محافظة القاهرة‬", 5, "//ourStore.com", 31.453170786065701, 30.0839302318766, "+201157760283", "new cairo", null, "+201019879660" },
                    { 5, "1st settlement. Mustafa Kamel Axis close to English School Suiz Road، محافظة الق, محافظة القاهرة‬", 14, "//ourStore.com", 31.627449998971699, 30.1137260222809, "+201157760283", "el shrouq", null, "+201019879660" },
                    { 6, "جولف سيتي مول, العبور، محافظة القليوبية 13612", 5, "//ourStore.com", 31.475701339782599, 30.177260340098499, "+201157760283", "Golf City mall obour", null, "+201019879660" },
                    { 7, "نادي العبور الرياضي, مدينة العبور، العبور، محافظة القاهرة‬ 11828", 5, "//ourStore.com", 31.457161908219199, 30.2383808709682, "+201157760283", "Obour City", null, "+201019879660" },
                    { 8, "5C29+6W6، السلام الشرقية، قسم أول السلام، محافظة القاهرة‬ 4645101", 8, "//ourStore.com", 31.419332037042501, 30.1519554277053, "+201157760283", "el salam", null, "+201019879660" },
                    { 9, "بركة النصر، قسم أول السلام، محافظة القاهرة‬ 4642286", 10, "//ourStore.com", 31.397702703295401, 30.145127183122199, "+201157760283", "el salam 2", null, "+201019879660" },
                    { 10, "حديقة بدر، جسر السويس، الخصوص، قسم أول السلام، محافظة القاهرة‬ 11772", 12, "//ourStore.com", 31.367833622769901, 30.136962357496099, "+201157760283", "Badr bark", null, "+201019879660" },
                    { 11, "مصطفى حافظ،, جسر السويس، محافظة القاهرة‬ 11311", 8, "//ourStore.com", 31.351010806550601, 30.129242264750999, "+201157760283", "Gesr Elsuez", null, "+201019879660" },
                    { 12, "العشرين، عين شمس الشرقية، عين شمس،، محافظة القاهرة‬", 10, "//ourStore.com", 31.339166172328099, 30.138595376425499, "+201157760283", "Ein shams", null, "+201019879660" },
                    { 13, "المطرية، العزب، قسم المطرية، محافظة القاهرة‬ 11753", 15, "//ourStore.com", 31.303117285564099, 30.1212246065414, "+201157760283", "mataria", null, "+201019879660" },
                    { 14, "جسر السويس، المطار، قسم عين شمس، محافظة القاهرة‬ 4542362", 10, "//ourStore.com", 31.339509495618302, 30.121224606469301, "+201157760283", "Gesr Elsuez", null, "+201019879660" },
                    { 15, "204 El Nozha Street, Heliopolis, the first of the Hijaz Bridge MASR ELGEDIDA, محافظة القاهرة‬ 11757", 15, "//ourStore.com", 31.3450026593157, 30.111424362401198, "+201157760283", "Heliopolis", null, "+201019879660" },
                    { 16, "النزهة، قسم مصر الجديدة، محافظة القاهرة‬ 11311", 5, "//ourStore.com", 31.341741093370398, 30.102217186858301, "+201157760283", "Nozha", null, "+201019879660" },
                    { 17, "1 شارع عمر إبن الخطاب - بجوار مدرسه نوتردام - من ميدان الإسماعيلية، قسم مصر الجديدة، محافظة القاهرة‬ 11511", 10, "//ourStore.com", 31.333501347824299, 30.101920166912699, "+201157760283", "qesm masr elgedida", null, "+201019879660" },
                    { 18, "آخر سور مستشفى العاصمه، 2 شارع شبين، صلاح الدين، قسم مصر الجديدة، محافظة القاهرة‬ 11511", 10, "//ourStore.com", 31.3298964591479, 30.0965736552556, "+201157760283", "qesm masr elgedida2", null, "+201019879660" },
                    { 19, "ميدان الكوربة شارع الاهرام MASR ELGEDIDA, محافظة القاهرة‬ 11757", 12, "//ourStore.com", 31.322343358972699, 30.095831060968202, "+201157760283", "elcorba", null, "+201019879660" },
                    { 20, "شارع الملك فيصل، عطاطي، الهرم، محافظة الجيزة 3553021", 18, "//ourStore.com", 31.1529135789958, 29.9986517202504, "+201157760283", "elgiza ", null, "+201019879660" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Stores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);
        }
    }
}
