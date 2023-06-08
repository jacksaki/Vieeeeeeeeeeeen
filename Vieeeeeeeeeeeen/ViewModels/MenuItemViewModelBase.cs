using Livet;
using Livet.Commands;
using Livet.EventListeners;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.Messaging.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Vieeeeeeeeeeeen.Models;

namespace Vieeeeeeeeeeeen.ViewModels
{
    public class MenuItemViewModelBase : ViewModel
    {
        public delegate void ErrorOccurredEventHandler(object sender, ErrorOccurredEventArgs e);
        public event ErrorOccurredEventHandler ErrorOccurred = delegate { };
        public delegate void MessageEventHandler(object sender, MessageEventArgs e);
        public event MessageEventHandler Message = delegate { };
        protected void OnErrorOccurred(ErrorOccurredEventArgs e)
        {
            ErrorOccurred(this, e);
        }
        protected void OnMessage(MessageEventArgs e)
        {
            Message(this, e);
        }
        public MenuItemViewModelBase(MainWindowViewModel parent) : base()
        {
            this.MainViewModel = parent;
        }
        public MainWindowViewModel MainViewModel
        {
            get;
        }

        #region Icon変更通知プロパティ
        private object _Icon;

        public object Icon
        {
            get
            {
                return _Icon;
            }
            set
            {
                if (_Icon == value)
                {
                    return;
                }
                _Icon = value;
                RaisePropertyChanged(nameof(Icon));
            }
        }
        #endregion

        #region Label変更通知プロパティ
        private object _Label;

        public object Label
        {
            get
            {
                return _Label;
            }
            set
            {
                if (_Label == value)
                {
                    return;
                }
                _Label = value;
                RaisePropertyChanged(nameof(Label));
            }
        }
        #endregion
    }
}
