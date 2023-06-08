using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vieeeeeeeeeeeen.Models
{
    public class OperationViewModelAttribute:Attribute
    {
        public OperationViewModelAttribute(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get;
        }
    }
}
