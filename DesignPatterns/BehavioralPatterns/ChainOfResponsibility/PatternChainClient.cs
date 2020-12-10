using System.Text.RegularExpressions;

namespace DesignPatterns.ChainOfResponsibility
{
    public class PatternChainClient : IChainCLient
    {
        public bool ValidateUser(User user)
        {
            var nameValidator = new HandleName();
            var ageValidator = new HandleAge();
            var mailValidator = new HandleEmail();

            // set the chain of validations
            nameValidator.Next(ageValidator).Next(mailValidator);

            var result = nameValidator.Validate(user);
            return result;
        }
    }

    public interface IValidator
    {
        IValidator Next(IValidator validator);
        bool Validate(User request);

    }

    public abstract class Validator : IValidator
    {

        private IValidator _nextValidator;

        public IValidator Next(IValidator validator)
        {
            _nextValidator = validator;
            return validator;
        }

        public virtual bool Validate(User request)
        {
            return _nextValidator != null
                && _nextValidator.Validate(request);
        }
    }

    public class HandleName : Validator
    {
        public override bool Validate(User user)
        {
            return !string.IsNullOrEmpty(user.Name)
                 && base.Validate(user);
        }
    }
    public class HandleAge : Validator
    {
        public override bool Validate(User user)
        {
            return user.Age >= 18 
                && base.Validate(user);
        }
    }

    public class HandleEmail : Validator
    {
        public override bool Validate(User user)
        {
            var regex = new Regex(@"^.+@.+\..+$");
            return regex.IsMatch(user.Email);
        }
    }
}
