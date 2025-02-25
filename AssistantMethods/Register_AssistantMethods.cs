using Bytescout.Spreadsheet;
using Task2.Data;
using Task2.Helpers;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.POM;


namespace Task2.AssistantMethods
{
    public class Register_AssistantMethods
    {
        public static void FillRegisterForm(User user)
        {
            Register_POM register_POM = new Register_POM(ManageDriver.driver);
            register_POM.EnterFirstName(user.FirstName);
            register_POM.EnterLastName(user.LastName);
            register_POM.EnterEmail(user.Email);
            register_POM.EnterPhoneNumber(user.Phone);
            register_POM.EnterPassword(user.Password);
            register_POM.EnterConfirmationPassword(user.ConfirmPassword);
            register_POM.DateOfBirth(user.BirthDate);
            if (user.Gender == Gender.Male)
            {
                register_POM.MaleButton();
            }
            else if (user.Gender == Gender.Female)
            {
                register_POM.FemaleButton();

            }
            register_POM.ClickSubmitButton1();
        }

        public static User ReadRegisterDataFromExcel(int row) //1
        {
            Worksheet registerWorkSheet = CommonMethods.ReadExcelRegister("Register");

            User user = new User();
            user.FirstName = Convert.ToString(registerWorkSheet.Cell(row, 2).Value);
            user.LastName = (string)registerWorkSheet.Cell(row, 3).Value;
            user.Email = (string)registerWorkSheet.Cell(row, 4).Value;
            user.Phone = Convert.ToString(registerWorkSheet.Cell(row, 5).Value);
            user.BirthDate = Convert.ToString(registerWorkSheet.Cell(row, 7).Value);
            user.Password = Convert.ToString(registerWorkSheet.Cell(row, 8).Value);
            user.ConfirmPassword = Convert.ToString(registerWorkSheet.Cell(row, 9).Value);
            user.image = Convert.ToString(registerWorkSheet.Cell(row, 9).Value);
            user.Gender = (Gender)Enum.Parse(typeof(Gender), (string)registerWorkSheet.Cell(row, 6).Value);
            return user;
        }


        public static bool CheckSuccessRegister(string email)
        {
            bool isUserExist = false;

            OracleConnection oracleConnection = new OracleConnection(GlobalConstant.ConnectionString);
            oracleConnection.Open();

            string query = "select count(*) from login_fp where email = :value";
            OracleCommand command = new OracleCommand(query, oracleConnection);
            command.Parameters.Add(new OracleParameter(":value", email));
            int result = Convert.ToInt32(command.ExecuteScalar()); // 0 or 1
            isUserExist = result > 0;
            return isUserExist;
        }


    }
}