using Savarankiskas2_Varteliai.Models;
using Savarankiskas2_Varteliai.Respositories;

namespace Savarankiskas2_Varteliai
{
    public class CreatePermits
    {
        public void CreatePermit()
        {
            string file = @"C:\Users\Darius\Desktop\Savarankiskas2 C#\Savarankiskas2-Varteliai\Savarankiskas2-Varteliai\DataFiles\Permits.txt";
            List<string> linePermits = File.ReadAllLines(file).ToList();

            foreach (var dataPermit in linePermits)
            {
                string[] valuePermit = dataPermit.Split(",");

                Permit permit = new Permit();
                permit.permitId = Convert.ToInt16(valuePermit[0]);
                permit.gateId = Convert.ToInt16(valuePermit[1]);
                permit.userWorkGroupe = valuePermit[2];
                permit.permissioToOpen = Convert.ToBoolean(valuePermit[3]);

                PermitsRespository.allPermits.Add(permit);
            }
        }
    }
}
