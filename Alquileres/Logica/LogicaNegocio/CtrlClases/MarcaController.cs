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
    public class MarcaController
    {
        private Dato.Modelo.DemoAlquilerGameBD db = new Dato.Modelo.DemoAlquilerGameBD();

        public List<EntidadNegocio.Entidades.Marca> ObtenerItems()
        {
            try
            {
                List<Dato.Modelo.Marca> _ListM = null;
                List<EntidadNegocio.Entidades.Marca> _ListME = new List<EntidadNegocio.Entidades.Marca>();
                EntidadNegocio.Entidades.Marca _mE = null;
                _ListM = (List<Dato.Modelo.Marca>)db.MarcaSet.ToList();
                foreach (Dato.Modelo.Marca element in _ListM)
                {
                    _mE = new EntidadNegocio.Entidades.Marca();
                    _mE.ID = element.ID;
                    _mE.Codigo = element.Codigo;
                    _mE.Descripcion = element.Descripcion;
                    if (element.Estatus == 1)
                    {
                        _mE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _mE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    element.TipoLoad();
                    _mE.Tipo = new EntidadNegocio.Entidades.Tipo();
                    _mE.Tipo.ID = element.IDTipo;
                    _mE.IDTipo = element.IDTipo;
                    _mE.Tipo.Codigo = element.Tipo.Codigo;
                    _mE.Tipo.Descripcion = element.Tipo.Descripcion;
                    if (element.Tipo.Estatus == 1)
                    {
                        _mE.Tipo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _mE.Tipo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _mE.Tipo.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    _mE.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    _ListME.Add(_mE);
                }
                return _ListME;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 UltimoID()
        {
            Dato.Modelo.Marca _entidadToIDAdd = db.MarcaSet.ToList().LastOrDefault();
            Int32 _id = _entidadToIDAdd.ID;
            return _id;
        }

        public EntidadNegocio.Entidades.Marca Details(int id)
        {
            Dato.Modelo.Marca _marca = new Dato.Modelo.Marca();
            if (id == 0)
            {
                _marca = new Dato.Modelo.Marca();
            }
            else
            {
                _marca = db.MarcaSet.First(c => c.ID == id);
                _marca.TipoLoad();
            }
            EntidadNegocio.Entidades.Marca marcaDetail = new EntidadNegocio.Entidades.Marca();
            marcaDetail.ID = _marca.ID;
            marcaDetail.Codigo = _marca.Codigo;
            marcaDetail.Descripcion = _marca.Descripcion;
            if (_marca.Estatus == 1)
            {
                marcaDetail.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
            }
            else
            {
                marcaDetail.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
            }
            marcaDetail.Tipo = new EntidadNegocio.Entidades.Tipo();
            marcaDetail.Tipo.ID = _marca.IDTipo;
            marcaDetail.IDTipo = _marca.IDTipo;
            marcaDetail.Tipo.Codigo = _marca.Tipo.Codigo;
            marcaDetail.Tipo.Descripcion = _marca.Tipo.Descripcion;
            if (_marca.Tipo.Estatus == 1)
            {
                marcaDetail.Tipo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
            }
            else
            {
                marcaDetail.Tipo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
            }
            marcaDetail.Tipo.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
            marcaDetail.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
            return marcaDetail;
        }

        public Boolean Create(EntidadNegocio.Entidades.Marca _marca)
        {
            Dato.Modelo.Marca marcaToAdd = new Dato.Modelo.Marca();
            Boolean resul = false;

            marcaToAdd.ID = _marca.ID;
            marcaToAdd.Codigo = _marca.Codigo;
            marcaToAdd.Descripcion = _marca.Descripcion;
            if (_marca.Status == EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo)
            {
                marcaToAdd.Estatus = 1;
            }
            else
            {
                marcaToAdd.Estatus = 0;
            }

            //valido claves primaria
            if (db.MarcaSet.FirstOrDefault(b => b.ID == marcaToAdd.ID) != null)
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
                    db.AddToMarcaSet(marcaToAdd);
                    db.SaveChanges();
                    dbTransaction.Commit();
                    /// Si la transaccion es exitosa enviamos true
                    Dato.Modelo.Marca _entidadToIDAdd = db.MarcaSet.ToList().LastOrDefault();
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

        public Boolean Edit(EntidadNegocio.Entidades.Marca _marca)
        {
            Int32 id = _marca.ID; Boolean resul = false;
            Dato.Modelo.Marca marcaToUpdate = db.MarcaSet.First(cb => cb.ID == id);

            marcaToUpdate.ID = _marca.ID;
            marcaToUpdate.Codigo = _marca.Codigo;
            marcaToUpdate.Descripcion = _marca.Descripcion;
            if (_marca.Status == EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo)
            {
                marcaToUpdate.Estatus = 1;
            }
            else
            {
                marcaToUpdate.Estatus = 0;
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

        public Boolean Delete(EntidadNegocio.Entidades.Marca _marca)
        {
            Int32 id = _marca.ID; Boolean resul = false;
            Dato.Modelo.Marca marcaToDelete = db.MarcaSet.First(cb => cb.ID == id);

            marcaToDelete.ID = _marca.ID;
            marcaToDelete.Codigo = _marca.Codigo;
            marcaToDelete.Descripcion = _marca.Descripcion;
            if (_marca.Status == EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo)
            {
                marcaToDelete.Estatus = 1;
            }
            else
            {
                marcaToDelete.Estatus = 0;
            }

            //valido la Marca tiene un producto
            if (db.ProductoSet.FirstOrDefault(b => b.IDMarca == id) != null)
            {
                MessageBox.Show(String.Format("Esta intentando Borrar una Marca que tiene una Producto"), EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    db.DeleteObject(marcaToDelete);
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

        public Boolean DatosValidos(List<EntidadNegocio.Entidades.Marca> _marcas)
        {
            bool valido = true;
            var count = (from m in _marcas where string.IsNullOrEmpty(m.ID.ToString()) || string.IsNullOrEmpty(m.Codigo) || string.IsNullOrEmpty(m.Descripcion.ToString()) select m.ID).Count();
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

        public Boolean DatoDuplicado(List<EntidadNegocio.Entidades.Marca> _marcas, Int32 id)
        {
            if (_marcas.FindAll(m => m.ID.ToString().ToUpper() == id.ToString().ToUpper()).Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean Guardar(List<EntidadNegocio.Entidades.Marca> _marcas)
        {
            try
            {
                bool resul = false;
                var l = (from c in _marcas where c.Edicion != EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal select c);
                List<EntidadNegocio.Entidades.Marca> _listM = null;
                _listM = l.ToList();
                if (DatosValidos(_listM))
                {
                    if (_listM.Count == 0)
                    {
                        resul = false;
                    }
                    else if (_listM.Count > 0)
                    {
                        if (MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_Guardar, EntidadNegocio.Entidades.Mensajes.Titulo_Guardar, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            foreach (EntidadNegocio.Entidades.Marca _marca in _listM)
                            {
                                if (_marca.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo)
                                {
                                    resul = this.Create(_marca);
                                }
                                else if (_marca.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado)
                                {
                                    resul = this.Edit(_marca);
                                }
                                else if (_marca.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Eliminar)
                                {
                                    resul = this.Delete(_marca);
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