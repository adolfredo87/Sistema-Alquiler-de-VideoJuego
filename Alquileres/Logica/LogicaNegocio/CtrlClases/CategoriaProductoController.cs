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
    public class CategoriaProductoController
    {
        private Dato.Modelo.DemoAlquilerGameBD db = new Dato.Modelo.DemoAlquilerGameBD();

        public List<EntidadNegocio.Entidades.CategoriaProducto> ObtenerItems()
        {
            try
            {
                List<Dato.Modelo.CategoriaProducto> _ListCP = null;
                List<EntidadNegocio.Entidades.CategoriaProducto> _ListCPE = new List<EntidadNegocio.Entidades.CategoriaProducto>();
                EntidadNegocio.Entidades.CategoriaProducto _cpE = null;
                _ListCP = (List<Dato.Modelo.CategoriaProducto>)db.CategoriaProductoSet.ToList();
                foreach (Dato.Modelo.CategoriaProducto element in _ListCP)
                {
                    _cpE = new EntidadNegocio.Entidades.CategoriaProducto();
                    _cpE.ID = element.ID;
                    _cpE.Codigo = element.Codigo;
                    _cpE.Categoria = element.Categoria;
                    _cpE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    _cpE.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    _ListCPE.Add(_cpE);
                }
                return _ListCPE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 UltimoID()
        {
            Dato.Modelo.CategoriaProducto _entidadToIDAdd = db.CategoriaProductoSet.ToList().LastOrDefault();
            Int32 _id = _entidadToIDAdd.ID;
            return _id;
        }

        public EntidadNegocio.Entidades.CategoriaProducto Details(int id)
        {
            Dato.Modelo.CategoriaProducto _categoriaProducto = new Dato.Modelo.CategoriaProducto();
            if (id == 0)
            {
                _categoriaProducto = new Dato.Modelo.CategoriaProducto();
            }
            else
            {
                _categoriaProducto = db.CategoriaProductoSet.First(c => c.ID == id);
            }
            EntidadNegocio.Entidades.CategoriaProducto categoriaProductoDetail = new EntidadNegocio.Entidades.CategoriaProducto();
            categoriaProductoDetail.ID = _categoriaProducto.ID;
            categoriaProductoDetail.Codigo = _categoriaProducto.Codigo;
            categoriaProductoDetail.Categoria = _categoriaProducto.Categoria;
            return categoriaProductoDetail;
        }

        public Boolean Create(EntidadNegocio.Entidades.CategoriaProducto _categoriaProducto)
        {
            Dato.Modelo.CategoriaProducto categoriaProductoToAdd = new Dato.Modelo.CategoriaProducto();
            Boolean resul = false;

            categoriaProductoToAdd.ID = _categoriaProducto.ID;
            categoriaProductoToAdd.Codigo = _categoriaProducto.Codigo;
            categoriaProductoToAdd.Categoria = _categoriaProducto.Categoria;

            //valido claves primaria
            if (db.CategoriaProductoSet.FirstOrDefault(b => b.ID == categoriaProductoToAdd.ID) != null)
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
                    db.AddToCategoriaProductoSet(categoriaProductoToAdd);
                    db.SaveChanges();
                    dbTransaction.Commit();
                    /// Si la transaccion es exitosa enviamos true
                    Dato.Modelo.CategoriaProducto _entidadToIDAdd = db.CategoriaProductoSet.ToList().LastOrDefault();
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

        public Boolean Edit(EntidadNegocio.Entidades.CategoriaProducto _categoriaProducto)
        {
            Int32 id = _categoriaProducto.ID; Boolean resul = false;
            Dato.Modelo.CategoriaProducto categoriaProductoToUpdate = db.CategoriaProductoSet.First(cb => cb.ID == id);

            categoriaProductoToUpdate.ID = _categoriaProducto.ID;
            categoriaProductoToUpdate.Codigo = _categoriaProducto.Codigo;
            categoriaProductoToUpdate.Categoria = _categoriaProducto.Categoria;

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

        public Boolean Delete(EntidadNegocio.Entidades.CategoriaProducto _categoriaProducto)
        {
            Int32 id = _categoriaProducto.ID; Boolean resul = false;
            Dato.Modelo.CategoriaProducto categoriaProductoToDelete = db.CategoriaProductoSet.First(cb => cb.ID == id);

            categoriaProductoToDelete.ID = _categoriaProducto.ID;
            categoriaProductoToDelete.Codigo = _categoriaProducto.Codigo;
            categoriaProductoToDelete.Categoria = _categoriaProducto.Categoria;

            //valido la categoria tiene un producto
            if (db.ProductoSet.FirstOrDefault(b => b.IDcategoriaProducto == id) != null)
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
                    db.DeleteObject(categoriaProductoToDelete);
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

        public Boolean DatosValidos(List<EntidadNegocio.Entidades.CategoriaProducto> _categoriaProductos)
        {
            bool valido = true;
            var count = (from cp in _categoriaProductos where string.IsNullOrEmpty(cp.ID.ToString()) || string.IsNullOrEmpty(cp.Codigo) || string.IsNullOrEmpty(cp.Categoria.ToString()) select cp.ID).Count();
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

        public Boolean DatoDuplicado(List<EntidadNegocio.Entidades.CategoriaProducto> _categoriaProductos, Int32 id)
        {
            if (_categoriaProductos.FindAll(cp => cp.ID.ToString().ToUpper() == id.ToString().ToUpper()).Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean Guardar(List<EntidadNegocio.Entidades.CategoriaProducto> _categoriaProductos)
        {
            try
            {
                bool resul = false;
                var l = (from c in _categoriaProductos where c.Edicion != EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal select c);
                List<EntidadNegocio.Entidades.CategoriaProducto> _listCP = null;
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
                            foreach (EntidadNegocio.Entidades.CategoriaProducto _categoriaProd in _listCP)
                            {
                                if (_categoriaProd.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo)
                                {
                                    resul = this.Create(_categoriaProd);
                                }
                                else if (_categoriaProd.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado)
                                {
                                    resul = this.Edit(_categoriaProd);
                                }
                                else if (_categoriaProd.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Eliminar)
                                {
                                    resul = this.Delete(_categoriaProd);
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
