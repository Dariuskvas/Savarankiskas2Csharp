using Savarankiskas2_Varteliai.Respositories;

namespace Savarankiskas2_Varteliai
{
    public class ReportService
    {
        private string _fulldateIn;
        private string _fulldateOut;
        private string _dataIn;
        private string _timeIN;
        private int _gateIn;
        private static string _content;
        private string _style;

        public ReportService()
        {
            _style = @"_style border='1px solid #000'";
        }

        public void PrintList()
        {
            foreach (var i in RegisterOfEntranceRespository.allRegisterOfEntrances)
            {
                Console.WriteLine($"UserId: {i.userId}  |   GateID: {i.gateId}  |  Leidimas: {i.access}   |   Vartotojas viduje: {i.walkIN} |   Laikas: {i.scanTime}");
            }
        }

        public void GetDataFromLogs()
        {
            foreach (var card in UserRespository.allUseers)
            {
                CreateHTMLHead(card.userId, card.userName, card.userWorkGroupe);
                foreach (var i in RegisterOfEntranceRespository.allRegisterOfEntrances)
                {
                    if (i.userId == card.userId)
                    {
                        if (i.access == true && i.walkIN == true)                           //Surenku iejimo 
                        {
                            _fulldateIn = i.scanTime;
                            _dataIn = DateTime.Parse(_fulldateIn).ToString("yyyy-MM-dd");
                            _timeIN = DateTime.Parse(_fulldateIn).ToString("hh:mm");
                            _gateIn = i.gateId;
                        }
                        if (i.access == true && i.walkIN == false)
                        {
                            _fulldateOut = i.scanTime;
                            var timeOut = DateTime.Parse(_fulldateOut).ToString("hh:mm"); ;
                            var gateOut = i.gateId;
                            var workTime = Convert.ToString(DateTime.Parse(_fulldateOut) - DateTime.Parse(_fulldateIn));
                            CreateHTMLBody(_dataIn, _timeIN, _gateIn, timeOut, gateOut, workTime);
                        }
                    }
                }
                CreateHTMLFile();
            }

        }

        private void CreateHTMLHead(int userId, string userName, string userWorkGroupe)
        {
            _content += $"<h2>{userId} | {userName} | {userWorkGroupe}</h2>";
            _content += $"<table {_style}><tr{_style}><th {_style}>Data</th><th {_style}>In Time</th>" +
                $"<th {_style}>In Gate</th><th {_style}>Out Time</th><th {_style}>Out Gate</th><th {_style}>Dirbtas laikas</th></tr>";
        }

        private void CreateHTMLBody(string dataIn, string timeIN, int gateIn, string timeOut, int gateOut, string workTime)
        {
            _content += $"<tr><td>{dataIn}</td><td>{timeIN}</td><td>{gateIn}</td><td>{timeOut}</td><td>{gateOut}</td><td>{workTime}</td></tr>";
        }

        private void CreateHTMLFile()
        {
            _content += $"</table><br>";
            File.WriteAllText(@"C:\Users\Darius\Desktop\Savarankiskas2 C#\Savarankiskas2-Varteliai\Report1.html", _content);
        }
    }
}
