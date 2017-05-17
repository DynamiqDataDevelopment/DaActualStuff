using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Archdiocese.Helpers
{
    public class clsValidation_Item
    {
        bool _returnStatus;
        string _returnMessage;

        public clsValidation_Item(bool returnStatus, string returnMessage)
        {
            _returnStatus = returnStatus;
            _returnMessage = returnMessage;
        }
        public clsValidation_Item()
        {
            //default constructor
        }

        public bool returnStatus
        {
            get { return _returnStatus; }
            set { _returnStatus = value; }
        }

        public string returnMessage
        {
            get { return _returnMessage; }
            set { _returnMessage = value; }
        }
    }
}
