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
    public class CategoriaController
    {
        private Dato.Modelo.DemoAlquilerGameBD db = new Dato.Modelo.DemoAlquilerGameBD();

        public List<EntidadNegocio.Entidades.Categoria> ObtenerItems()
        {
            try
            {
                List<Dato.Modelo.Categoria> _ListC = null;
                List<EntidadNegocio.Entidades.Categoria> _ListCE = new List<EntidadNegocio.Entidades.Categoria>();
                EntidadNegocio.Entidades.Categoria _cE = null;
                _ListC = (List<Dato.Modelo.Categoria>)db.CategoriaSet.ToList();
                foreach (Dato.Modelo.Categoria element in _ListC)
                {
                    _cE = new EntidadNegocio.Entidades.Categoria();
                    _cE.ID = element.ID;
                    _cE.Codigo = element.Codigo;
                    _cE.Descripcion = element.Descripcion;
                    if (element.Estatus == 1)
                    {
                        _cE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _cE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    element.TipoLoad();
                    _cE.Tipo = new EntidadNegocio.Entidades.Tipo();
                    _cE.Tipo.ID = element.IDTipo;
                    _cE.IDTipo = element.IDTipo;
                    _cE.Tipo.Codigo = element.Tipo.Codigo;
                    _cE.Tipo.Descripcion = element.Tipo.Descripcion;
                    if (element.Tipo.Estatus == 1)
                    {
                        _cE.Tipo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _cE.Tipo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _cE.Tipo.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    _cE.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    _ListCE.Add(_cE);
                }
                return _ListCE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 UltimoID()
        {
            Dato.Modelo.Categoria _entidadToIDAdd = db.CategoriaSet.ToList().LastOrDefault();
            Int32 _id = _entidadToIDAdd.ID;
            return _id;
        }

        public EntidadNegocio.Entidades.Categoria Details(int id)
        {
            Dato.Modelo.Categoria _categoria = new Dato.Modelo.Categoria();
            if (id == 0)
            {
                _categoria = new Dato.Modelo.Categoria();
            }
            else
            {
                _categoria = db.CategoriaSet.First(c => c.ID == id);
            }
            EntidadNegocio.Entidades.Categoria categoriaDetail = new EntidadNegocio.Entidades.Categoria();
            categoriaDetail.ID = _categoria.ID;
            categoriaDetail.Codigo = _categoria.Codigo;
            categoriaDetail.Descripcion = _categoria.Descripcion;
            if (_categoria.Estatus == 1)
            {
                categoriaDetail.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
            }
            else
            {
                categoriaDetail.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
            }
            categoriaDetail.Tipo = new EntidadNegocio.Entidades.Tipo();
            categoriaDetail.Tipo.ID = _categoria.IDTipo;
            categoriaDetail.IDTipo = _categoria.IDTipo;
            categoriaDetail.Tipo.Codigo = _categoria.Tipo.Codigo;
            categoriaDetail.Tipo.Descripcion = _categoria.Tipo.Descripcion;
            if (_categoria.Tipo.Estatus == 1)
            {
                categoriaDetail.Tipo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
            }
            else
            {
                categoriaDetail.Tipo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
            }
            categoriaDetail.Tipo.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
            categoriaDetail.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
            return categoriaDetail;
        }

        public Boolean Create(EntidadNegocio.Entidades.Categoria _categoria)
        {
            Dato.Modelo.Categoria categoriaToAdd = new Dato.Modelo.Categoria();
            Boolean resul = false; String IDTipo = "";

            categoriaToAdd.ID = _categoria.ID;

            Int32 iIDTipo = _categoria.IDTipo;
            categoriaToAdd.IDTipo = iIDTipo;
            IDTipo = iIDTipo.ToString();

            categoriaToAdd.Codigo = _categoria.Codigo;
            categoriaToAdd.Descripcion = _categoria.Descripcion;
            if (_categoria.Status == EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo)
            {
                categoriaToAdd.Estatus = 1;
            }
            else
            {
                categoriaToAdd.Estatus = 0;
            }

            if (!String.IsNullOrEmpty(IDTipo))
            {
                categoriaToAdd.Tipo = db.TipoSet.FirstOrDefault(c => c.ID == iIDTipo);
            }

            if (categoriaToAdd.Tipo == null)
            {
                MessageBox.Show(String.Format("El número de IDTipo {0} no está registrado en la base de datos."), EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //valido claves primaria
            if (db.CategoriaSet.FirstOrDefault(b => b.ID == categoriaToAdd.ID) != null)
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
                    db.AddToCategoriaSet(categoriaToAdd);
                    db.SaveChanges();
                    dbTransaction.Commit();
                    /// Si la transaccion es exitosa enviamos true
                    Dato.Modelo.Categoria _entidadToIDAdd = db.CategoriaSet.ToList().LastOrDefault();
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

        public Boolean Edit(EntidadNegocio.Entidades.Categoria _categoria)
        {
            Int32 id = _categoria.ID; Boolean resul = false;
            Dato.Modelo.Categoria categoriaToUpdate = db.CategoriaSet.First(cb => cb.ID == id);

            categoriaToUpdate.ID = _categoria.ID;
            categoriaToUpdate.Codigo = _categoria.Codigo;
            categoriaToUpdate.Descripcion = _categoria.Descripcion;
            if (_categoria.Status == EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo)
            {
                categoriaToUpdate.Estatus = 1;
            }
            else
            {
                categoriaToUpdate.Estatus = 0;
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

        public Boolean Delete(EntidadNegocio.Entidades.Categoria _categoria)
        {
            Int32 id = _categoria.ID; Boolean resul = false;
            Dato.Modelo.Categoria categoriaToDelete = db.CategoriaSet.First(cb => cb.ID == id);

            categoriaToDelete.ID = _categoria.ID;
            categoriaToDelete.Codigo = _categoria.Codigo;
            categoriaToDelete.Descripcion = _categoria.Descripcion;
            if (_categoria.Status == EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo)
            {
                categoriaToDelete.Estatus = 1;
            }
            else
            {
                categoriaToDelete.Estatus = 0;
            }

            //valido la categoria tiene un producto
            if (db.ProductoSet.FirstOrDefault(b => b.IDCategoria == id) != null)
            {
                MessageBox.Show(String.Format("Esta intentando Borrar una categoria que tiene una Producto"), EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    db.DeleteObject(categoriaToDelete);
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

        public Boolean DatosValidos(List<EntidadNegocio.Entidades.Categoria> _categorias)
        {
            bool valido = true;
            var count = (from cp in _categorias where string.IsNullOrEmpty(cp.ID.ToString()) || string.IsNullOrEmpty(cp.Codigo) || string.IsNullOrEmpty(cp.Descripcion.ToString()) select cp.ID).Count();
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

        public Boolean DatoDuplicado(List<EntidadNegocio.Entidades.Categoria> _categorias, Int32 id)
        {
            if (_categorias.FindAll(cp => cp.ID.ToString().ToUpper() == id.ToString().ToUpper()).Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean Guardar(List<EntidadNegocio.Entidades.Categoria> _categorias)
        {
            try
            {
                bool resul = false;
                var l = (from c in _categorias where c.Edicion != EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal select c);
                List<EntidadNegocio.Entidades.Categoria> _listCP = null;
                _listCP = l.ToList();
                if (DatosValidos(_listCP))
                {
                    if (_listCP.Count == 0)
                    {
                        resul = false;
                    }
                    else if (_listCP.Count > 0)
                    {
                        if (MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_Guardar, EntidadNegocio.Entidades.Mensajes.Titulo_Guardar, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            foreach (EntidadNegocio.Entidades.Categoria _categoria in _listCP)
                            {
                                if (_categoria.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo)
                                {
                                    resul = this.Create(_categoria);
                                }
                                else if (_categoria.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado)
                                {
                                    resul = this.Edit(_categoria);
                                }
                                else if (_categoria.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Eliminar)
                                {
                                    resul = this.Delete(_categoria);
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
