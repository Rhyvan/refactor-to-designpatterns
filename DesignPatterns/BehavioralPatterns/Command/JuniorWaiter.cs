namespace DesignPatterns.Command
{
    public class JuniorWaiter : IWaiter
    {
        private Chef _chef;

        public JuniorWaiter(Chef chef)
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
