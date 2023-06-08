using Livet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Vieeeeeeeeeeeen.ViewModels;
using Vieeeeeeeeeeeen.Views;
namespace Vieeeeeeeeeeeen.Models
{
    public class Operation<T1,T2>:IOperation where T1 :OperationViewModelBase, new() 
        where T2: UserControl,new()
    {
        public void Refresh()
        {
            this.ViewModel = new T1();
            this.View = new T2() { DataContext = this.ViewModel };
        }
        public string Name
        {
            get
            {
                return typeof(T1).GetCustomAttribute<OperationViewModelAttribute>().Name; 
            }
        }
        public ViewModel ViewModel
        {
            get;
            private set;
        }
        public UserControl View
        {
            get;
            private set;
        }
    }
}
