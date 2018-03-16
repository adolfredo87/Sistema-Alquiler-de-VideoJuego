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
        private Dato.Modelo.DemoAlquilerGameDBVW dbVW = new Dato.Modelo.DemoAlquilerGameDBVW();

        public Int32 UltimoID()
        {
            Dato.Modelo.PagoCabecera _entidadToIDAdd = db.PagoCabeceraSet.ToList().LastOrDefault();
            Int32 _id = _entidadToIDAdd.ID;
            return _id;
        }

        public EntidadNegocio.Entidades.PagoCabecera Details(int id)
        {
            Dato.Modelo.PagoCabecera _pagoCabeceraDetail = new Dato.Modelo.PagoCabecera();
            _pagoCabeceraDetail = new Dato.Modelo.PagoCabecera();
            EntidadNegocio.Entidades.PagoCabecera pagoCabeceraDetail = new EntidadNegocio.Entidades.PagoCabecera();
            Dato.Modelo.Cliente cliente = db.ClienteSet.First(c => c.ID == id); Int32 iIDCliente = cliente.ID;
            Dato.Modelo.Cantidad_Alquileres_Por_Pagar_VW clienteAlq = dbVW.Cantidad_Alquileres_Por_Pagar_VW_Set.First(c => c.IDCliente == iIDCliente);
            List<Dato.Modelo.Alquiler> listAlquiler = db.AlquilerSet.Where(a => a.IDCliente == iIDCliente && a.Estatus == 1).ToList();
            Double _dMontoEstimado = 0; _dMontoEstimado = (from e in listAlquiler select e.PrecioEstimado).Sum().Value;
            Dato.Modelo.Descuento descuento = db.DescuentoSet.First(d => d.Codigo == "DEC1");
            Double _dPorcentajeDescuento = 0; _dPorcentajeDescuento = descuento.PorcentajeDescuento ?? 0;
            Double _dDescuento = _dPorcentajeDescuento * _dMontoEstimado;
            Double _dMontoTotal = _dMontoEstimado - _dDescuento;
            Int32 _iIDCliente = iIDCliente;
            Int32 _idCabecera = UltimoID();
            DateTime _dFecha = DateTime.Now;
            pagoCabeceraDetail.Fecha = _dFecha;
            if (clienteAlq.NumAlquiler >= 3 && clienteAlq.NumAlquiler <= 5)
            {
                pagoCabeceraDetail.MontoExento = _dMontoEstimado;
                pagoCabeceraDetail.Descuento = _dDescuento;
                pagoCabeceraDetail.MontoTotal = _dMontoTotal;
            }
            else
            {
                pagoCabeceraDetail.MontoExento = _dMontoEstimado;
                pagoCabeceraDetail.Descuento = 0;
                pagoCabeceraDetail.MontoTotal = _dMontoEstimado;
            }
            pagoCabeceraDetail.IDCliente = _iIDCliente;
            pagoCabeceraDetail.Cliente = new EntidadNegocio.Entidades.Cliente();
            pagoCabeceraDetail.Cliente.ID = _iIDCliente;
            pagoCabeceraDetail.Cliente.Nombre = cliente.Nombre;
            pagoCabeceraDetail.Cliente.Telefono = cliente.Telefono;
            pagoCabeceraDetail.Cliente.Correo = cliente.Correo;
            pagoCabeceraDetail.Cliente.Direccion = cliente.Direccion;
            pagoCabeceraDetail.Cliente.NumAlquileres = clienteAlq.NumAlquiler ?? 0;
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
            _pago.MontoExento = _dMontoEstimado;

            DateTime _dFecha = DateTime.Now;
            _pago.Fecha = _dFecha;
            
            pagoCabeceraToAdd.IDCliente = _iIDCliente;
            pagoCabeceraToAdd.MontoExento = _pago.MontoExento;
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
