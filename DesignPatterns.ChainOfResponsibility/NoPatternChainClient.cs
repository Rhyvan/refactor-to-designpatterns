using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DesignPatterns.ChainOfResponsibility
{
    public class NoPatternChainClient : IChainCLient
    {
        public bool ValidateUser(User user)
        {
            if (!string.IsNullOrEmpty(user.Name))
            {
                if (user.Age >= 18)
                {
                    if (!String.IsNullOrEmpty(user.Email)
                        && IsValidEmailAddress(user.Email))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool IsValidEmailAddress(string email)
        {
            var regex = new Regex(@"^.+@.+\..+$");
            return regex.IsMatch(email);
        }
    }
}
