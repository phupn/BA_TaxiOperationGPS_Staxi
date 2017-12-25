using System;
using System.IdentityModel.Selectors;
using System.ServiceModel; 

namespace StaxiMan_Services
{
    public class UserNamePassValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName == null || password == null)
            {
                throw new ArgumentNullException();
            }

            if (!(userName == "admin" && password == "staximanadmin"))
            {
                throw new FaultException("Incorrect Username or Password");
            }
        }
    }
}