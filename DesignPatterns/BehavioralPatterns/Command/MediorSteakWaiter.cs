﻿namespace DesignPatterns.Command
{
    public class MediorSteakWaiter : IWaiter
    {
        private Chef _chef;
        private Cook _cook;
        public MediorSteakWaiter(Chef chef, Cook cook)
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
