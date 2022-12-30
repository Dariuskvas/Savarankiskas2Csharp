using Savarankiskas2_Varteliai.Respositories;
using Boolean = System.Boolean;

namespace Savarankiskas2_Varteliai.DataSimulation
{
    /// <summary>
    /// Sukuria duomenis simuliuojancius bandyma praeiti pro vartelius
    /// </summary>


    public class CreateRandomDataToProgram
    {
        private DateTime _dayFrom { set; get; }
        private DateTime _dayTo { set; get; }
        private Boolean _access { set; get; }
        private int _randomGate { set; get; }
        private string _loginDate { set; get; }

        RandomNumber randomNumber = new RandomNumber();
        CheckPermitions checkPermitions = new CheckPermitions();

        public CreateRandomDataToProgram()
        {
            _dayFrom = new DateTime(2021, 01, 01);                       //Simuliuojama datos pradzia,nuo kada vartotojai eis pro vartus
            _dayTo = new DateTime(2021, 01, 30);                         //Data iki kada eis.
            _access = false;
        }

        public void CreateRandomData()
        {
            do                                                                              // sukasi kiek dienu ciklas, kiekvienam UserId(CardID) generuojamas iejimo ir isejimo laikas
            {
                foreach (var cardId in UserRespository.allUseers)                           //Kiekvienam User ID
                {
                    CreateDorScan(8, cardId.userId, cardId.userWorkGroupe);                 //Paduodu valandas nuo kurios pradedamas ciklas, iejimui
                    CreateDorScan(17, cardId.userId, cardId.userWorkGroupe);                //Paduodu valandas nuo kurios pradedamas ciklas, isejimui
                }
                _dayFrom = _dayFrom.AddDays(1);
            } while (_dayFrom <= _dayTo);

        }
                                                                                           // Random laikas nuo nurodytos valandos, intervalas 30min
        private string CreateTime(int enterHour)
        {
            DateTime start = DateTime.Today.AddHours(enterHour);
            Random rnd = new Random();
            DateTime value = start.AddMinutes(rnd.Next(30));
            return (value.ToString("HH:mm"));
        }

        private void CreateDorScan(int doorScanTime, int cardIDS, string userWorkGroupe)
        {
                                                                                                //foreach (var cardId in UserRespository.allUseers) //Kiekvienam User
            _loginDate = _dayFrom.ToString("yyyy/MM/dd") + " " + CreateTime(doorScanTime);        //sukuriu iejimo data i stringa pagal paduota valanda "doorScanTime"
            do
            {
                _randomGate = randomNumber.CreateRandomNumb(1, 5);                                   //Sugeneruoju Atsitiktinai vartus
                checkPermitions.ColectDataFromUserCard(cardIDS, _randomGate, _loginDate);         //Paduodu i funkcija userID/kortelesID ir random vartus su data ir tikrinu ar turi leidima ieiti ir registruojama

            } while (PermitsRespository.Retrieve(_randomGate, userWorkGroupe) == null);          //ciklas sukasi, kol vartotojas ieina arba iseina 
        }
    }
}
