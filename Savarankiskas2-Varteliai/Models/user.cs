namespace Savarankiskas2_Varteliai.Models
{
    public class User
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string userWorkGroupe { get; set; }
        public string userWorkTipe { get; set; }
        public int userHourSalary { get; set; }
        public Boolean userEmployed { get; set; }
        public User()
        {
            userId = 0;
            userName = string.Empty;
            userWorkGroupe = string.Empty;
            userWorkTipe = string.Empty;
            userHourSalary = 0;
            userEmployed = false;
        }



    }
}
