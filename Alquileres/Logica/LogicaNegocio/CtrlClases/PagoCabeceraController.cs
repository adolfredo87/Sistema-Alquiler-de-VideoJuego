using System;
using Utilidad;
using Dato.Modelo;
using EntidadNegocio;
using System.Linq;
using System.Threading;
using System.Data.OleDb;
using System.Data.Common;
using System.Windows.Forms;
using System.Collections.Generic;

namespace LogicaNegocio
{
    public class PagoCabeceraController
    {
        private Dato.Modelo.DemoAlquilerGameBD db = new Dato.Modelo.DemoAlquilerGameBD();

        public List<EntidadNegocio.Entidades.PagoCabecera> ObtenerItems()
        {
            try
            {
                List<Dato.Modelo.PagoCabecera> _ListPag = null;
                List<EntidadNegocio.Entidades.PagoCabecera> _ListPagE = new List<EntidadNegocio.Entidades.PagoCabecera>();
                EntidadNegocio.Entidades.PagoCabecera _pagE = null;
                _ListPag = (List<Dato.Modelo.PagoCabecera>)db.PagoCabeceraSet.ToList();
                foreach (Dato.Modelo.PagoCabecera element in _ListPag)
                {
                    _pagE = new EntidadNegocio.Entidades.PagoCabecera();
                    _pagE.ID = element.ID;
                    _pagE.Fecha = element.Fecha;
                    _pagE.MontoExento = element.MontoExento ?? 0;
                    _pagE.Descuento = element.Descuento ?? 0;
                    _pagE.MontoTotal = element.MontoTotal ?? 0;
                    _pagE.Estatus = element.Estatus;
                    _pagE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    _pagE.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    element.ClienteLoad(); _pagE.IDCliente = element.IDCliente;
                    _pagE.Cliente = new EntidadNegocio.Entidades.Cliente();
                    _pagE.Cliente.ID = element.IDCliente;
                    _pagE.Cliente.Nombre = element.Cliente.Nombre;
                    _pagE.Cliente.Telefono = element.Cliente.Telefono;
                    _pagE.Cliente.Correo = element.Cliente.Correo;
                    _pagE.Cliente.Direccion = element.Cliente.Direccion;
                    _pagE.Cliente.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    _pagE.Cliente.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    _ListPagE.Add(_pagE);
                }
                return _ListPagE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 UltimoID()
        {
            Dato.Modelo.PagoCabecera _entidadToIDAdd = db.PagoCabeceraSet.ToList().LastOrDefault();
            Int32 _id = _entidadToIDAdd.ID;
            return _id;
        }

        public EntidadNegocio.Entidades.PagoCabecera Details(int id)
        {
            Dato.Modelo.PagoCabecera _pagoCabeceraDetail = new Dato.Modelo.PagoCabecera();
            if (id == 0)
            {
                _pagoCabeceraDetail = new Dato.Modelo.PagoCabecera();
            }
            else
            {
                _pagoCabeceraDetail = db.PagoCabeceraSet.First(p => p.ID == id);
                _pagoCabeceraDetail.ClienteLoad();
            }
            EntidadNegocio.Entidades.PagoCabecera pagoCabeceraDetail = new EntidadNegocio.Entidades.PagoCabecera();
            Dato.Modelo.Cliente cliente = db.ClienteSet.First(c => c.ID == id); Int32 iIDCliente = cliente.ID;
            List<Dato.Modelo.Alquiler> listAlquiler = db.AlquilerSet.Where(a => a.IDCliente == iIDCliente && a.Estatus == 1).ToList();
            Double _dMontoEstimado = 0; _dMontoEstimado = (from e in listAlquiler select e.PrecioEstimado).Sum().Value;
            Int32 _iIDCliente = iIDCliente;
            DateTime _dFecha = DateTime.Now;
            pagoCabeceraDetail.Fecha = _dFecha;
            pagoCabeceraDetail.MontoTotal = _dMontoEstimado;
            pagoCabeceraDetail.IDCliente = _iIDCliente;
            pagoCabeceraDetail.Cliente = new EntidadNegocio.Entidades.Cliente();
            pagoCabeceraDetail.Cliente.ID = _iIDCliente;
            pagoCabeceraDetail.Cliente.Nombre = _pagoCabeceraDetail.Cliente.Nombre;
            pagoCabeceraDetail.Cliente.Telefono = _pagoCabeceraDetail.Cliente.Telefono;
            pagoCabeceraDetail.Cliente.Correo = _pagoCabeceraDetail.Cliente.Correo;
            pagoCabeceraDetail.Cliente.Direccion = _pagoCabeceraDetail.Cliente.Direccion;
            return pagoCabeceraDetail;
        }

        public Boolean Create(EntidadNegocio.Entidades.PagoCabecera _pago)
        {
            Int32 iIDCliente = _pago.IDCliente; Boolean resul = false;
            Dato.Modelo.Cliente cliente = db.ClienteSet.First(c => c.ID == iIDCliente);
            Int32 _iIDCliente = cliente.ID;
            
            Dato.Modelo.PagoCabecera pagoCabeceraToAdd = new PagoCabecera();
            List<Dato.Modelo.Alquiler> listAlquiler = db.AlquilerSet.Where(a => a.IDCliente == iIDCliente && a.Estatus == 1).ToList();

            Double _dMontoEstimado = 0; _dMontoEstimado = (from monto in listAlquiler select monto.PrecioEstimado).Sum().Value;
            _pago.MontoTotal = _dMontoEstimado;
            DateTime _dFecha = DateTime.Now;
            _pago.Fecha = _dFecha;
            
            pagoCabeceraToAdd.IDCliente = _iIDCliente;
            pagoCabeceraToAdd.MontoTotal = _pago.MontoTotal;
            pagoCabeceraToAdd.Fecha = _pago.Fecha;
            Int32 iEstatus = 1;
            pagoCabeceraToAdd.Estatus = iEstatus;

            if (db.Connection.State != System.Data.ConnectionState.Open)
            {
                db.Connection.Open();
            }

            DbTransaction dbTransaction = db.Connection.BeginTransaction();

            try
            {
                // Guardar y confirmar.
                db.AddToPagoCabeceraSet(pagoCabeceraToAdd);
                db.SaveChanges();
                dbTransaction.Commit();
                /// Si la transaccion es exitosa enviamos true
                PagoCabecera _entidadToIDAdd = db.PagoCabeceraSet.ToList().LastOrDefault();
                Int32 _id = _entidadToIDAdd.ID;
                _entidadToIDAdd.ID = _id;
                resul = true;
            }
            catch (Exception ex)
            {
                dbTransaction.Rollback();
                HandleException excepcion = new HandleException();
                String msjLog = "Error en " + ObtenerMetodoEnEjecucion(false).ToString() + ".\n" + excepcion.RegistrarExcepcion(ex, ObtenerMetodoEnEjecucion(false).ToString());
                excepcion.EscribirLogExcepcion(msjLog); String clientMessage = excepcion.HandleExceptionEx(ex); excepcion = null;
                resul = true;
            }

            return resul;
        }

        public Boolean DatosValidos(List<EntidadNegocio.Entidades.PagoCabecera> _pagos)
        {
            bool valido = true;
            var count = (from pag in _pagos where string.IsNullOrEmpty(pag.ID.ToString()) || string.IsNullOrEmpty(pag.IDCliente.ToString()) select pag.ID).Count();
            if (count > 0)
            {
                valido = false; throw new Exception(EntidadNegocio.Entidades.Mensajes.Info_Incompleta);
            }
            else
            {
                valido = true;
            }
            return valido;
        }

        public Boolean DatoDuplicado(List<EntidadNegocio.Entidades.PagoCabecera> _pagos, Int32 id)
        {
            if (_pagos.FindAll(pag => pag.ID.ToString().ToUpper() == id.ToString().ToUpper()).Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean Guardar(List<EntidadNegocio.Entidades.PagoCabecera> _pagos)
        {
            try
            {
                bool resul = false;
                var l = (from c in _pagos where c.Edicion != EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal select c);
                List<EntidadNegocio.Entidades.PagoCabecera> _listPag = null;
                _listPag = l.ToList();
                if (DatosValidos(_listPag))
                {
                    if (_listPag.Count == 0)
                    {
                        resul = false;
                    }
                    else if (_listPag.Count > 0)
                    {
                        if (MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_Guardar, EntidadNegocio.Entidades.Mensajes.Titulo_Guardar, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            foreach (EntidadNegocio.Entidades.PagoCabecera _pago in _listPag)
                            {
                                if (_pago.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo)
                                {
                                    resul = this.Create(_pago);
                                }
                                else if (_pago.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado)
                                {
                                    resul = false;
                                }
                                else if (_pago.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Eliminar)
                                {
                                    resul = false;
                                }
                                else
                                {
                                    resul = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        resul = false;
                        MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_ErrorAlGuardar, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    resul = false;
                }
                return resul;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private System.String ObtenerMetodoEnEjecucion(bool nombreCorto)
        {
            if (nombreCorto)
            {
                return new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name;
            }
            else
            {
                return this.ToString() + "." + new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name;
            }
        }

    }
}
