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
    public class PrecioController
    {
        private Dato.Modelo.DemoAlquilerGameBD db = new Dato.Modelo.DemoAlquilerGameBD();

        public List<EntidadNegocio.Entidades.Precio> ObtenerItems()
        {
            try
            {
                List<Dato.Modelo.Precio> _ListP = null;
                List<EntidadNegocio.Entidades.Precio> _ListPE = new List<EntidadNegocio.Entidades.Precio>();
                EntidadNegocio.Entidades.Precio _precioE = null;
                _ListP = (List<Dato.Modelo.Precio>)db.PrecioSet.ToList();
                foreach (Dato.Modelo.Precio element in _ListP)
                {
                    _precioE = new EntidadNegocio.Entidades.Precio();
                    _precioE.ID = element.ID;
                    _precioE.Codigo = element.Codigo;
                    _precioE.Descripcion = element.Descripcion;
                    _precioE.PrecioUnitario = element.PrecioUnitario ?? 0;
                    if (element.Estatus == 1)
                    {
                        _precioE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _precioE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _precioE.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    _ListPE.Add(_precioE);
                }
                return _ListPE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 UltimoID()
        {
            Dato.Modelo.Precio _entidadToIDAdd = db.PrecioSet.ToList().LastOrDefault();
            Int32 _id = _entidadToIDAdd.ID;
            return _id;
        }

        public EntidadNegocio.Entidades.Precio Details(int id)
        {
            Dato.Modelo.Precio _precio = new Dato.Modelo.Precio();
            if (id == 0)
            {
                _precio = new Dato.Modelo.Precio();
            }
            else
            {
                _precio = db.PrecioSet.First(c => c.ID == id);
            }
            EntidadNegocio.Entidades.Precio precioDetail = new EntidadNegocio.Entidades.Precio();
            precioDetail.ID = _precio.ID;
            precioDetail.Codigo = _precio.Codigo;
            precioDetail.Descripcion = _precio.Descripcion;
            precioDetail.PrecioUnitario = _precio.PrecioUnitario ?? 0;
            if (_precio.Estatus == 1)
            {
                precioDetail.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
            }
            else
            {
                precioDetail.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
            }
            return precioDetail;
        }

        public Boolean Create(EntidadNegocio.Entidades.Precio _precio)
        {
            Dato.Modelo.Precio precioToAdd = new Dato.Modelo.Precio();
            Boolean resul = false;

            precioToAdd.ID = _precio.ID;
            precioToAdd.Codigo = _precio.Codigo;
            precioToAdd.Descripcion = _precio.Descripcion;
            precioToAdd.PrecioUnitario = _precio.PrecioUnitario;
            if (_precio.Status == EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo)
            {
                precioToAdd.Estatus = 1;
            }
            else
            {
                precioToAdd.Estatus = 0;
            }

            //valido claves primaria
            if (db.DescuentoSet.FirstOrDefault(b => b.ID == precioToAdd.ID) != null)
            {
                MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_ErrorAlGuardarViolacionPK, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (db.Connection.State != System.Data.ConnectionState.Open)
                {
                    db.Connection.Open();
                }

                DbTransaction dbTransaction = db.Connection.BeginTransaction();

                try
                {
                    // Guardar y confirmar.
                    db.AddToPrecioSet(precioToAdd);
                    db.SaveChanges();
                    dbTransaction.Commit();
                    /// Si la transaccion es exitosa enviamos true
                    Dato.Modelo.Descuento _entidadToIDAdd = db.DescuentoSet.ToList().LastOrDefault();
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
                    resul = false;
                }
            }

            return resul;

        }

        public Boolean Edit(EntidadNegocio.Entidades.Precio _precio)
        {
            Int32 id = _precio.ID; Boolean resul = false;
            Dato.Modelo.Precio precioToUpdate = db.PrecioSet.First(d => d.ID == id);

            precioToUpdate.ID = _precio.ID;
            precioToUpdate.Codigo = _precio.Codigo;
            precioToUpdate.Descripcion = _precio.Descripcion;
            precioToUpdate.PrecioUnitario = _precio.PrecioUnitario;
            if (_precio.Status == EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo)
            {
                precioToUpdate.Estatus = 1;
            }
            else
            {
                precioToUpdate.Estatus = 0;
            }

            if (db.Connection.State != System.Data.ConnectionState.Open)
            {
                db.Connection.Open();
            }

            DbTransaction dbTransaction = db.Connection.BeginTransaction();

            try
            {
                // Guardar y confirmar.
                db.SaveChanges();
                dbTransaction.Commit();
                /// Si la transaccion es exitosa enviamos true
                resul = true;
            }
            catch (Exception ex)
            {
                dbTransaction.Rollback();
                HandleException excepcion = new HandleException();
                String msjLog = "Error en " + ObtenerMetodoEnEjecucion(false).ToString() + ".\n" + excepcion.RegistrarExcepcion(ex, ObtenerMetodoEnEjecucion(false).ToString());
                excepcion.EscribirLogExcepcion(msjLog); String clientMessage = excepcion.HandleExceptionEx(ex); excepcion = null;
                resul = false;
            }

            return resul;
        }

        public Boolean Delete(EntidadNegocio.Entidades.Precio _precio)
        {
            Int32 id = _precio.ID; Boolean resul = false;
            Dato.Modelo.Precio precioToDelete = db.PrecioSet.First(d => d.ID == id);

            precioToDelete.ID = _precio.ID;
            precioToDelete.Codigo = _precio.Codigo;
            String _Descripcion = _precio.Descripcion;
            precioToDelete.Descripcion = _Descripcion;
            precioToDelete.PrecioUnitario = _precio.PrecioUnitario;
            if (_precio.Status == EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo)
            {
                precioToDelete.Estatus = 1;
            }
            else
            {
                precioToDelete.Estatus = 0;
            }

            //valido si el descuento que se borra es de cabecera o de linea
            if (_Descripcion.Contains("Hora") || _Descripcion.Contains("Dia") || _Descripcion.Contains("Semana"))
            {
                MessageBox.Show(String.Format("Ningun precio por hora, dia o semana puede ser eliminado."), EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (db.Connection.State != System.Data.ConnectionState.Open)
                {
                    db.Connection.Open();
                }

                DbTransaction dbTransaction = db.Connection.BeginTransaction();

                try
                {
                    // Delete 
                    db.DeleteObject(precioToDelete);
                    db.SaveChanges();
                    dbTransaction.Commit();
                    /// Si la transaccion es exitosa enviamos true
                    resul = true;
                }
                catch (Exception ex)
                {
                    HandleException excepcion = new HandleException();
                    String msjLog = "Error en " + ObtenerMetodoEnEjecucion(false).ToString() + ".\n" + excepcion.RegistrarExcepcion(ex, ObtenerMetodoEnEjecucion(false).ToString());
                    excepcion.EscribirLogExcepcion(msjLog); String clientMessage = excepcion.HandleExceptionEx(ex); excepcion = null;
                    resul = false;
                }
            }

            return resul;
        }

        public Boolean DatosValidos(List<EntidadNegocio.Entidades.Precio> _precios)
        {
            bool valido = true;
            var count = (from cp in _precios where string.IsNullOrEmpty(cp.ID.ToString()) || string.IsNullOrEmpty(cp.Codigo) select cp.ID).Count();
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

        public Boolean DatoDuplicado(List<EntidadNegocio.Entidades.Precio> _precios, Int32 id)
        {
            if (_precios.FindAll(cp => cp.ID.ToString().ToUpper() == id.ToString().ToUpper()).Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean Guardar(List<EntidadNegocio.Entidades.Precio> _precios)
        {
            try
            {
                bool resul = false;
                var l = (from c in _precios where c.Edicion != EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal select c);
                List<EntidadNegocio.Entidades.Precio> _listPrecio = null;
                _listPrecio = l.ToList();
                if (DatosValidos(_listPrecio))
                {
                    if (_listPrecio.Count == 0)
                    {
                        resul = false;
                    }
                    else if (_listPrecio.Count > 0)
                    {
                        if (MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_Guardar, EntidadNegocio.Entidades.Mensajes.Titulo_Guardar, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            foreach (EntidadNegocio.Entidades.Precio _precio in _listPrecio)
                            {
                                if (_precio.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo)
                                {
                                    resul = this.Create(_precio);
                                }
                                else if (_precio.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado)
                                {
                                    resul = this.Edit(_precio);
                                }
                                else if (_precio.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Eliminar)
                                {
                                    resul = this.Delete(_precio);
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
