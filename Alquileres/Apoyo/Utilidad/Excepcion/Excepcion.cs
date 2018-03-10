using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;

namespace Utilidad
{    
    public class Excepcion
    {
        private string _origenExcepcion;
        private string _nombreTraza = System.Configuration.ConfigurationManager.AppSettings["nombreTrace"].ToString();
        private string _separador = System.Configuration.ConfigurationManager.AppSettings["separador"].ToString();
        private string _rutaTraza = System.Configuration.ConfigurationManager.AppSettings["rutaTrace"].ToString();

        public string Ruta
        {
            get { return _rutaTraza; }
            set { _rutaTraza = value; }
        }

        public Excepcion(string origen)
        {
            try
            {
                CrearDirectorio();
                _origenExcepcion = origen;

            }
            catch (Exception ex)
            {
                EscribirLocalEx(ex, this.ToString() + ".Constructor");
                throw new ApplicationException("Error interno de la Aplicación." + "\n" + "Por favor informar a Sopórte Técnico.");
            }
        }
        public Excepcion(string origen, string nombreTraza)
        {
            try
            {
                _origenExcepcion = origen;
                _nombreTraza = nombreTraza;
                CrearDirectorio();

            }
            catch (Exception ex)
            {
                EscribirLocalEx(ex, this.ToString() + ".Constructor");
                throw new ApplicationException("Error interno de la Aplicación." + "\n" + "Por favor informar a Sopórte Técnico.");
            }
        }

        public void RegistrarExcepcion(Exception excepcion)
        {
            try
            {
                try
                {
                    throw excepcion;

                }
                catch (System.IO.InvalidDataException ex)
                {
                    EscribirInvalidDataException(ex);

                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    EscribirSqlEx(ex);

                }
                catch (System.IO.IOException ex)
                {
                    EscribirIOEx(ex);

                }
                catch (Exception ex)
                {
                    EscribirGenericEx(ex);

                }
            }
            catch (Exception ex)
            {
                EscribirLocalEx(ex, this.ToString() + ".RegistrarExcepcion");
                throw new ApplicationException("Error interno de la Aplicación." + "\n" + "Por favor informar a Sopórte Técnico.");
            }
        }

        private void CrearDirectorio()
        {
            if (!File.Exists(_rutaTraza + _separador + _nombreTraza))
            {
                File.Create(_rutaTraza + _separador + _nombreTraza);
            }
        }

        private void EscribirSqlEx(SqlException ex)
        {
            EscribirLinea("SQLEXCEPTION OCURRIDA EN: " + _origenExcepcion);
            EscribirLinea(" FECHA: " + System.DateTime.Now.ToString());
            EscribirLinea("FUENTE: " + ex.Source);
            EscribirLinea("NÚMERO: " + ex.Number.ToString());
            EscribirLinea(" LÍNEA: " + ex.LineNumber.ToString());
            EscribirLinea("MESAJE: " + ex.Message);
            EscribirLinea("--------------------------");
            EscribirLinea("SERVIDOR     : " + ex.Server);
            EscribirLinea("PROCEDIMIENTO: " + ex.Procedure);
            EscribirLinea("STACK        : " + ex.StackTrace.ToString());
            EscribirLinea("--------------------------");
            EscribirLinea("");
        }

        private void EscribirIOEx(IOException ex)
        {
            EscribirLinea("IOEXCEPTION OCURRIDA EN: " + _origenExcepcion);
            EscribirLinea(" FECHA: " + System.DateTime.Now.ToString());
            EscribirLinea("FUENTE: " + ex.Source);
            EscribirLinea("MESAJE: " + ex.Message);
            EscribirLinea("--------------------------");
            EscribirLinea("STACK        : " + ex.StackTrace.ToString());
            EscribirLinea("--------------------------");
            EscribirLinea("");
        }

        private void EscribirInvalidDataException(InvalidDataException ex)
        {
            EscribirLinea("INVALIDDATAEXCEPTION OCURRIDA EN: " + _origenExcepcion);
            EscribirLinea(" FECHA: " + System.DateTime.Now.ToString());
            EscribirLinea("FUENTE: " + ex.Source);
            EscribirLinea("MESAJE: " + ex.Message);
            EscribirLinea("--------------------------");
            EscribirLinea("STACK        : " + ex.StackTrace.ToString());
            EscribirLinea("--------------------------");
            EscribirLinea("");
        }

        private void EscribirGenericEx(Exception ex)
        {
            EscribirLinea("EXCEPTION OCURRIDA EN: " + _origenExcepcion);
            EscribirLinea(" FECHA        : " + System.DateTime.Now.ToString());
            EscribirLinea("FUENTE        : " + ex.Source);
            EscribirLinea("MESAJE        : " + ex.Message);
            EscribirLinea("TIPO EXCEPCION: " + ex.ToString());
            EscribirLinea("--------------------------");
            EscribirLinea("STACK         : " + ex.StackTrace);
            EscribirLinea("--------------------------");
            EscribirLinea("");
        }

        private void EscribirLocalEx(Exception ex, string origenEx)
        {
            EscribirLinea("EXCEPTION OCURRIDA EN: " + origenEx);
            EscribirLinea(" FECHA: " + System.DateTime.Now.ToString());
            EscribirLinea("FUENTE: " + ex.Source);
            EscribirLinea("MESAJE: " + ex.Message);
            EscribirLinea("--------------------------");
            EscribirLinea("STACK        : " + ex.StackTrace.ToString());
            EscribirLinea("--------------------------");
            EscribirLinea("");
        }

        private void EscribirLinea(string valor)
        {
            StreamWriter objEscritor = null;
            objEscritor = File.AppendText(_rutaTraza + _separador + _nombreTraza);
            objEscritor.WriteLine(valor);
            objEscritor.Close();
        }

        #region "'*** Funcionalidad NO usada ***'"
        private string ObtenerExcepcionSQL(int numeroEx)
        {
            string mensaje = null;
            switch (numeroEx)
            {
                case 2:
                    break; // TODO: might not be correct. Was : Exit Select

                case 53:
                    //NetworkAddressNotFound
                    mensaje = "NetworkAddressNotFound";
                    break; // TODO: might not be correct. Was : Exit Select

                case 4060:
                    //InvalidDatabase
                    mensaje = "InvalidDatabase";
                    break; // TODO: might not be correct. Was : Exit Select

                case 18452:
                    //LoginFailed
                    mensaje = "LoginFailed";
                    break; // TODO: might not be correct. Was : Exit Select

                case 18456:
                    //LoginFailed
                    mensaje = "LoginFailed";
                    break; // TODO: might not be correct. Was : Exit Select

                case 10054:
                    //ConnectionRefused
                    mensaje = "ConnectionRefused";
                    break; // TODO: might not be correct. Was : Exit Select

                case 547:
                    //ForeignKey Violation
                    mensaje = "Registro se encuentra asociado a otra tabla.";
                    break; // TODO: might not be correct. Was : Exit Select

                case 2627:
                    //Unique Index/Constriant Violation
                    mensaje = "Unique Index/Constriant Violation";
                    break; // TODO: might not be correct. Was : Exit Select

                case 2601:
                    //Unique Index/Constriant Violation
                    mensaje = "Unique Index/Constriant Violation";
                    break; // TODO: might not be correct. Was : Exit Select

            }
            return mensaje;
        }
        #endregion
    }
}

// Soli Deo Gloria