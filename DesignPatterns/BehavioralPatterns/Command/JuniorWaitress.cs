namespace DesignPatterns.Command
{
    public class JuniorWaitress : IWaiter
    {
        private Chef _chef;

        public JuniorWaitress(Chef chef)
        {
            _chef = chef;
        }

        public void MakeOrder()
        {
            _chef.CookSoup();
            _chef.CookPasta();
        }
    }
}
