namespace DesignPatterns.Command
{
    public class MediorSteakWaitress : IWaiter
    {
        private Chef _chef;
        private Cook _cook;
        public MediorSteakWaitress(Chef chef, Cook cook)
        {
            _chef = chef;
            _cook = cook;
        }

        public void MakeOrder()
        {
            _chef.CookSoup();
            _chef.CookSteak();
            _cook.CookSideDishForSteak();
        }
    }
}
