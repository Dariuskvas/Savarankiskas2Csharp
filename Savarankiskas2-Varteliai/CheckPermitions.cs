using Savarankiskas2_Varteliai.Respositories;

namespace Savarankiskas2_Varteliai
{
    /// <summary>
    /// Nuskanavus kortele surenkami duomenys:
    ///     * UserIdScaned - darbuotojo ID;
    ///     * gateNumber - vartu ID;
    ///     * userWorkGroup - kokiai grupei priskirtas darbuotojas;
    ///     * acces - ar turi leidima praeiti pro duris;
    /// Surinkti duomenys perduodami i registra.
    /// 
    /// </summary>
    public class CheckPermitions
    {
        Boolean access { get; set; }

        public void ColectDataFromUserCard(int UserIdScaned, int gateNumber, string logindate)
        {
            var userWorkGroup = UserRespository.Retrieve(UserIdScaned).userWorkGroupe;

            if (PermitsRespository.Retrieve(gateNumber, userWorkGroup) == null)
                access = false;
            else
                access = PermitsRespository.Retrieve(gateNumber, userWorkGroup).permissioToOpen;

            RegisterUserScan registerUserScan = new RegisterUserScan();
            registerUserScan.RegisterScan(UserIdScaned, gateNumber, userWorkGroup, logindate, access);
        }

    }
}
