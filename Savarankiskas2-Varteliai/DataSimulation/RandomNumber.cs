namespace Savarankiskas2_Varteliai.DataSimulation
{
    public class RandomNumber
    {
        public int CreateRandomNumb(int numberfrom, int numberTo)
        {
            Random r = new Random();
            int rInt = r.Next(numberfrom, numberTo);
            return rInt;
        }
    }
}
