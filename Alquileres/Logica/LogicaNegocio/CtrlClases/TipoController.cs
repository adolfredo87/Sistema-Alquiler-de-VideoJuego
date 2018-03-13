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
    public class TipoController
    {
        private Dato.Modelo.DemoAlquilerGameBD db = new Dato.Modelo.DemoAlquilerGameBD();

        public List<EntidadNegocio.Entidades.Tipo> ObtenerItems()
        {
            try
            {
                List<Dato.Modelo.Tipo> _ListT = null;
                List<EntidadNegocio.Entidades.Tipo> _ListTE = new List<EntidadNegocio.Entidades.Tipo>();
                EntidadNegocio.Entidades.Tipo _tE = null;
                _ListT = (List<Dato.Modelo.Tipo>)db.TipoSet.ToList();
                foreach (Dato.Modelo.Tipo element in _ListT)
                {
                    _tE = new EntidadNegocio.Entidades.Tipo();
                    _tE.ID = element.ID;
                    _tE.Codigo = element.Codigo;
                    _tE.Descripcion = element.Descripcion;
                    if (element.Estatus == 1)
                    {
                        _tE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _tE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _tE.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    _ListTE.Add(_tE);
                }
                return _ListTE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 UltimoID()
        {
            Dato.Modelo.Tipo _entidadToIDAdd = db.TipoSet.ToList().LastOrDefault();
            Int32 _id = _entidadToIDAdd.ID;
            return _id;
        }

        public EntidadNegocio.Entidades.Tipo Details(int id)
        {
            Dato.Modelo.Tipo _tipo = new Dato.Modelo.Tipo();
            if (id == 0)
            {
                _tipo = new Dato.Modelo.Tipo();
            }
            else
            {
                _tipo = db.TipoSet.First(c => c.ID == id);
            }
            EntidadNegocio.Entidades.Tipo tipoDetail = new EntidadNegocio.Entidades.Tipo();
            tipoDetail.ID = _tipo.ID;
            tipoDetail.Codigo = _tipo.Codigo;
            tipoDetail.Descripcion = _tipo.Descripcion;
            if (_tipo.Estatus == 1)
            {
                tipoDetail.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
            }
            else
            {
                tipoDetail.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
            }
            return tipoDetail;
        }

        public Boolean Create(EntidadNegocio.Entidades.Tipo _tipo)
        {
            Dato.Modelo.Tipo tipoToAdd = new Dato.Modelo.Tipo();
            Boolean resul = false;

            tipoToAdd.ID = _tipo.ID;
            tipoToAdd.Codigo = _tipo.Codigo;
            tipoToAdd.Descripcion = _tipo.Descripcion;
            if (_tipo.Status == EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo)
            {
                tipoToAdd.Estatus = 1;
            }
            else
            {
                tipoToAdd.Estatus = 0;
            }

            //valido claves primaria
            if (db.TipoSet.FirstOrDefault(b => b.ID == tipoToAdd.ID) != null)
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
                    db.AddToTipoSet(tipoToAdd);
                    db.SaveChanges();
                    dbTransaction.Commit();
                    /// Si la transaccion es exitosa enviamos true
                    Dato.Modelo.Tipo _entidadToIDAdd = db.TipoSet.ToList().LastOrDefault();
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

        public Boolean Edit(EntidadNegocio.Entidades.Tipo _tipo)
        {
            Int32 id = _tipo.ID; Boolean resul = false;
            Dato.Modelo.Tipo tipoToUpdate = db.TipoSet.First(cb => cb.ID == id);

            tipoToUpdate.ID = _tipo.ID;
            tipoToUpdate.Codigo = _tipo.Codigo;
            tipoToUpdate.Descripcion = _tipo.Descripcion;
            if (_tipo.Status == EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo)
            {
                tipoToUpdate.Estatus = 1;
            }
            else
            {
                tipoToUpdate.Estatus = 0;
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

        public Boolean Delete(EntidadNegocio.Entidades.Tipo _tipo)
        {
            Int32 id = _tipo.ID; Boolean resul = false;
            Dato.Modelo.Tipo tipoToDelete = db.TipoSet.First(cb => cb.ID == id);

            tipoToDelete.ID = _tipo.ID;
            tipoToDelete.Codigo = _tipo.Codigo;
            tipoToDelete.Descripcion = _tipo.Descripcion;
            if (_tipo.Status == EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo)
            {
                tipoToDelete.Estatus = 1;
            }
            else
            {
                tipoToDelete.Estatus = 0;
            }

            //valido la Tipo tiene un producto
            if (db.ProductoSet.FirstOrDefault(b => b.IDTipo == id) != null)
            {
                MessageBox.Show(String.Format("Esta intentando Borrar un Tipo que tiene un Producto"), EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (db.Connection.State != System.Data.ConnectionState.Open)
                    {
                        db.Connection.Open();
                    }

                    DbTransaction dbTransaction = db.Connection.BeginTransaction();

                    // Delete 
                    db.DeleteObject(tipoToDelete);
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

        public Boolean DatosValidos(List<EntidadNegocio.Entidades.Tipo> _tipos)
        {
            bool valido = true;
            var count = (from m in _tipos where string.IsNullOrEmpty(m.ID.ToString()) || string.IsNullOrEmpty(m.Codigo) || string.IsNullOrEmpty(m.Descripcion.ToString()) select m.ID).Count();
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

        public Boolean DatoDuplicado(List<EntidadNegocio.Entidades.Tipo> _tipos, Int32 id)
        {
            if (_tipos.FindAll(m => m.ID.ToString().ToUpper() == id.ToString().ToUpper()).Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean Guardar(List<EntidadNegocio.Entidades.Tipo> _tipos)
        {
            try
            {
                bool resul = false;
                var l = (from c in _tipos where c.Edicion != EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal select c);
                List<EntidadNegocio.Entidades.Tipo> _listT = null;
                _listT = l.ToList();
                if (DatosValidos(_listT))
                {
                    if (_listT.Count == 0)
                    {
                        resul = false;
                    }
                    else if (_listT.Count > 0)
                    {
                        if (MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_Guardar, EntidadNegocio.Entidades.Mensajes.Titulo_Guardar, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            foreach (EntidadNegocio.Entidades.Tipo _tipo in _listT)
                            {
                                if (_tipo.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo)
                                {
                                    resul = this.Create(_tipo);
                                }
                                else if (_tipo.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado)
                                {
                                    resul = this.Edit(_tipo);
                                }
                                else if (_tipo.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Eliminar)
                                {
                                    resul = this.Delete(_tipo);
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
