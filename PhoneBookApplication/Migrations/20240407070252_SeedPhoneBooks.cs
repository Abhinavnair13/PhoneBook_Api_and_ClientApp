using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneBookApplication.Migrations
{
    public partial class SeedPhoneBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
  table: "PhoneBooks",
  columns: new[]
  {
             "FirstName", "LastName", "Email","ContactNumber","CompanyName"
  },
  values: new object[,]
  {
             {"Abhinav","Nair","abc@gmail.com","9999999999","Civica"},
             {"Bheem","Patel","bca@gmail.com","9999977999","Civica"},
             {"Emma","Brown","emma.brown@outlook.com","9997430281","Civica"},
             {"David","Johnson","david.johnson@yahoo.com","9996624857","Civica"},
{"John","Martinez","john.martinez@hotmail.com","9992097145","Civica"},
{"Alice","Doe","alice.doe@hotmail.com","9995958184","Civica"},
{"Sarah","Smith","sarah.smith@gmail.com","9994826229","Civica"},
{"Michael","Nair","michael.nair@outlook.com","9993666191","Civica"},
{"Jane","Patel","jane.patel@yahoo.com","9993091316","Civica"},
{"Abhinav","Lee","abhinav.lee@gmail.com","9996571599","Civica"},
{"Bheem","Wilson","bheem.wilson@yahoo.com","9995879759","Civica"},
{"Bob","Garcia","bob.garcia@outlook.com","9996506364","Civica"},
{"Emma","Smith","emma.smith@hotmail.com","9995813653","Civica"},
{"David","Johnson","david.johnson@yahoo.com","9999264563","Civica"},
{"John","Martinez","john.martinez@hotmail.com","9994570028","Civica"},
{"Alice","Doe","alice.doe@hotmail.com","9999691449","Civica"},
{"Sarah","Brown","sarah.brown@gmail.com","9995869783","Civica"},
{"Michael","Nair","michael.nair@outlook.com","9999161131","Civica"},
{"Jane","Patel","jane.patel@yahoo.com","9998394257","Civica"},
{"Abhinav","Wilson","abhinav.wilson@gmail.com","9998546829","Civica"},
{"Bheem","Lee","bheem.lee@hotmail.com","9993768354","Civica"},
{"Bob","Garcia","bob.garcia@outlook.com","9999967412","Civica"},
{"Emma","Smith","emma.smith@hotmail.com","9995368120","Civica"},
{"David","Johnson","david.johnson@yahoo.com","9994142777","Civica"},
{"John","Martinez","john.martinez@hotmail.com","9996460202","Civica"},
{"Alice","Doe","alice.doe@hotmail.com","9999550132","Civica"}


  }



  );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
             table: "PhoneBooks",
             keyColumn: "PhoneId",
             keyValues: new object[] { 1, 2, 3, 4 ,5}

             );


        }
    }
}
