using Livet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Vieeeeeeeeeeeen.Models
{
    public interface IOperation
    {
        public ViewModel ViewModel
        {
            get;
        }
        public UserControl View
        {
            get;
        }
        public void Refresh();
    }
}
