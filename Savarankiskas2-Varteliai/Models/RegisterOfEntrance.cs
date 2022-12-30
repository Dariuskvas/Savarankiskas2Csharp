namespace Savarankiskas2_Varteliai.Models
{
    public class RegisterOfEntrance
    {
        public int userId { set; get; }
        public int gateId { set; get; }
        public Boolean access { set; get; }
        public string scanTime { set; get; }
        public Boolean walkIN { set; get; }
    }
}
