using Livet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vieeeeeeeeeeeen.Models
{
    internal class PgTable:NotificationObject
    {
        [DbColumn("table_name")]
        public string Name
        {
            get;
            private set;
        }
        public IEnumerable<string> Keys
        {
            get;
            set;
        }

        private DataTable _DataTable;

        public DataTable DataTable
        {
            get
            {
                return _DataTable;
            }
            set
            { 
                if (_DataTable == value)
                {
                    return;
                }
                _DataTable = value;
                RaisePropertyChanged();
            }
        }
    }
}
