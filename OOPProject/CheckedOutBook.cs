using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject
{
    internal class CheckedOutBook : Book
    {
        public DateTime DueDate { get; set; }

        public CheckedOutBook(string _title, string _author, bool _status, DateTime _dueDate)
            : base(_title, _author, _status)
        {
            DueDate = _dueDate;
        }

    }
}
