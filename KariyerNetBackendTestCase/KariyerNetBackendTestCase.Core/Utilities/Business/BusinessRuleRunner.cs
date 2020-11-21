using System;
using System.Collections.Generic;

namespace KariyerNetBackendTestCase.Core.Utilities.Business
{
    public class BusinessRuleRunner
    {
        public static bool Run(out List<string> errorMessages, params Action[] logics)
        {
            errorMessages=new List<string>();

            try
            {
                foreach (var result in logics) result();

                return false;
            }
            catch (System.Exception e)
            {
                errorMessages.Add(e.Message);
                return true;
            }



        }
    }
}
