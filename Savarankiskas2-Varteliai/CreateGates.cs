using Savarankiskas2_Varteliai.Models;
using Savarankiskas2_Varteliai.Respositories;

namespace Savarankiskas2_Varteliai
{
    public class CreateGates
    {
        GateRespository gateRespository = new GateRespository();

        public void CreateGate()
        {
            string file = @"C:\Users\Darius\Desktop\Savarankiskas2 C#\Savarankiskas2-Varteliai\Savarankiskas2-Varteliai\DataFiles\Gates.txt";
            List<string> lineGate = File.ReadAllLines(file).ToList();

            foreach (var gateData in lineGate)
            {
                string[] valueGate = gateData.Split(",");

                Gate gate = new Gate();
                gate.gateId = Convert.ToInt16(valueGate[0]);
                gate.gateName = valueGate[1];
                gate.gateStatus = Convert.ToBoolean(valueGate[2]);

                gateRespository.allGates.Add(gate);
            }
        }
    }
}
