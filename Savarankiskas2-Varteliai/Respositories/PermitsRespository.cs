using Savarankiskas2_Varteliai.Models;

namespace Savarankiskas2_Varteliai.Respositories
{
    public static class PermitsRespository
    {
        public static List<Permit> allPermits = new List<Permit>();

        public static Permit Retrieve(int gateId, string workGroupe)
        {
            foreach (var permitInfo in allPermits)
            {
                if (permitInfo.gateId == gateId && permitInfo.userWorkGroupe == workGroupe)
                {
                    return permitInfo;
                }
            }
            return null;
        }
    }
}