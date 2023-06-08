using Livet;
using Livet.Commands;
using Livet.EventListeners;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.Messaging.Windows;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Vieeeeeeeeeeeen.Models;

namespace Vieeeeeeeeeeeen.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel() : base()
        {
            this.DialogCoordinator = MahApps.Metro.Controls.Dialogs.DialogCoordinator.Instance;

            var fv = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
            this.AppTitle = $"{fv.ProductName} Ver {fv.ProductVersion}";
            this.Operations = new DispatcherCollection<IOperation>(DispatcherHelper.UIDispatcher);
            this.Operations.CollectionChanged += (sender, e) =>
            {
                RaisePropertyChanged(nameof(Operations));
            };
            foreach(var o in OperationProvider.GetAll())
            {
                this.Operations.Add(o);
            }
        }

        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged();
        }

        public MahApps.Metro.Controls.Dialogs.IDialogCoordinator DialogCoordinator
        {
            get;
            set;
        }
        public string AppTitle
        {
            get;
        }


        private IOperation _SelectedOperation;

        public IOperation SelectedOperation
        {
            get
            {
                return _SelectedOperation;
            }
            set
            { 
                if (_SelectedOperation == value)
                {
                    return;
                }
                value.Refresh();
                _SelectedOperation = value;
                RaisePropertyChanged();
            }
        }

        public void Initialize()
        {

        }

        public DispatcherCollection<IOperation> Operations
        {
            get;
        }
        private void Menu_Message(object sender, MessageEventArgs e)
        {
            DialogCoordinator.ShowMessageAsync(this, e.Title, e.Message, MahApps.Metro.Controls.Dialogs.MessageDialogStyle.Affirmative);
        }

        private void Menu_ErrorOccurred(object sender, ErrorOccurredEventArgs e)
        {
            DialogCoordinator.ShowMessageAsync(this, "エラー", e.Message, MahApps.Metro.Controls.Dialogs.MessageDialogStyle.Affirmative);
        }
    }
}