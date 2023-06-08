using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vieeeeeeeeeeeen.ViewModels;
using Vieeeeeeeeeeeen.Views;

namespace Vieeeeeeeeeeeen.Models
{
    public class OperationProvider
    {
        public static IEnumerable<IOperation> GetAll()
        {
            return new IOperation[]
            {
                new Operation<WelcomeBoxViewModel,WelcomeBox>(),
                new Operation<ThankYouBoxViewModel,ThankYouBox>(),
            };
        }
    }
}
