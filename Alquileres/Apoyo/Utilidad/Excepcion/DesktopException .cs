using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Collections;
using System.Collections.Generic;

namespace Utilidad
{
    public class DesktopException : Exception
    {
        private string strMessage;
        private string strClase;
        private string strMetodo;
        private string strStackTrace;

        public DesktopException(string message)
        {
            strMessage = message;
        }

        public DesktopException(string clase, string metodo, string message, Exception inner)
            : base(inner.Message, inner)
        {
            strStackTrace = inner.StackTrace;
            strMessage = message;
            strClase = clase;
            strMetodo = metodo;
        }

        public string Clase
        {
            get { return strClase; }
            set { strClase = value; }
        }

        public string Metodo
        {
            get { return strMetodo; }
            set { strMetodo = value; }
        }

        public override string Message
        {
            get { return strMessage; }
        }

        public override string StackTrace
        {
            get { return strStackTrace; }
        }
    }
}

// Soli Deo Gloria