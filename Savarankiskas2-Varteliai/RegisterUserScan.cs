using Savarankiskas2_Varteliai.Models;
using Savarankiskas2_Varteliai.Respositories;

namespace Savarankiskas2_Varteliai
{
    /// <summary>
    /// Sukuriam praeinanciu zmoniu duombaze.
    /// 
    /// </summary>
    public class RegisterUserScan
    {
        public void RegisterScan(int UserIdScaned, int gateNumber, string userWorkGroup, string loginDate, Boolean permissionHave)
        {
            RegisterOfEntrance registerOfEntrance = new RegisterOfEntrance()
            {
                userId = UserIdScaned,
                gateId = gateNumber,
                access = permissionHave,
                scanTime = loginDate,
                walkIN = UserWalkInOrOut(permissionHave, UserIdScaned),
            };

            RegisterOfEntranceRespository.allRegisterOfEntrances.Add(registerOfEntrance);
        }

        // Tikrinu ar darbuotojas jau iejas i pastata ar isejas
        private bool UserWalkInOrOut(Boolean permisioIn, int UserIdScanedFromList)
        {
            if (permisioIn == false)
            {
                if (RegisterOfEntranceRespository.allRegisterOfEntrances.FindLast(x => x.userId == UserIdScanedFromList) == null)
                {
                    return false;
                }
                else
                {
                    return RegisterOfEntranceRespository.allRegisterOfEntrances.FindLast(x => x.userId == UserIdScanedFromList).walkIN;
                }
            }
            else if (RegisterOfEntranceRespository.allRegisterOfEntrances.FindLast(x => x.userId == UserIdScanedFromList) != null)
            {
                return !RegisterOfEntranceRespository.allRegisterOfEntrances.FindLast(x => x.userId == UserIdScanedFromList).walkIN;
            }
            else
            {
                return true;
            }
        }
    }
}
