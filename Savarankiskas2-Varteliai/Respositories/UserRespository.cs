using Savarankiskas2_Varteliai.Models;

namespace Savarankiskas2_Varteliai.Respositories
{
    public static class UserRespository
    {
        public static List<User> allUseers = new List<User>();

        public static User Retrieve(int id)
        {
            foreach (var worker in allUseers)
            {
                if (worker.userId == id)
                {
                    return worker;
                }
            }
            return null;
        }
    }
}