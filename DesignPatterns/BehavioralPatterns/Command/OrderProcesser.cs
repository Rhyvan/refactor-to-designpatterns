using System.Collections.Generic;

namespace DesignPatterns.Command
{
    // Invoker class
    public class OrderProcesser
    {
        private List<IWaiter> _waiters = new List<IWaiter>();

         
        public void SetCommand(IWaiter waiter)
        {
            _waiters.Add(waiter);
        }

        public void Execute()
        {
            _waiters.ForEach(w => w.MakeOrder());
        }


    }
}
