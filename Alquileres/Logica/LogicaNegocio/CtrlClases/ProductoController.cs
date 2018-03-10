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
    public class ProductoController 
    {
        private Dato.Modelo.DemoAlquilerGameBD db = new Dato.Modelo.DemoAlquilerGameBD();

        public List<EntidadNegocio.Entidades.Producto> ObtenerItems()
        {
            try
            {
                List<Dato.Modelo.Producto> _ListP = null;
                List<EntidadNegocio.Entidades.Producto> _ListPE = new List<EntidadNegocio.Entidades.Producto>();
                EntidadNegocio.Entidades.Producto _pE = null;
                _ListP = (List<Dato.Modelo.Producto>)db.ProductoSet.ToList();
                foreach (Dato.Modelo.Producto element in _ListP)
                {
                    _pE = new EntidadNegocio.Entidades.Producto();
                    _pE.ID = element.ID;
                    _pE.Nombre = element.Nombre;
                    _pE.Marca = element.Marca;
                    _pE.IDcategoriaProducto = element.IDcategoriaProducto;
                    _pE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    _pE.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    element.CategoriaProductoLoad();
                    _pE.CategoriaProducto = new EntidadNegocio.Entidades.CategoriaProducto();
                    _pE.CategoriaProducto.ID = element.IDcategoriaProducto;
                    _pE.CategoriaProducto.Codigo = element.CategoriaProducto.Codigo;
                    _pE.CategoriaProducto.Categoria = element.CategoriaProducto.Categoria;
                    _pE.CategoriaProducto.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    _pE.CategoriaProducto.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    _ListPE.Add(_pE);
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
            Dato.Modelo.Producto _entidadToIDAdd = db.ProductoSet.ToList().LastOrDefault();
            Int32 _id = _entidadToIDAdd.ID;
            return _id;
        }

        public EntidadNegocio.Entidades.Producto Details(int id)
        {
            Dato.Modelo.Producto _productoDetail = new Dato.Modelo.Producto();
            if (id == 0)
            {
                _productoDetail = new Dato.Modelo.Producto();
            }
            else
            {
                _productoDetail = db.ProductoSet.First(p => p.ID == id);
                _productoDetail.CategoriaProductoLoad();
            }
            EntidadNegocio.Entidades.Producto productoDetail = new EntidadNegocio.Entidades.Producto();

            productoDetail.ID = _productoDetail.ID;
            productoDetail.Nombre = _productoDetail.Nombre;
            productoDetail.Marca = _productoDetail.Marca;
            productoDetail.IDcategoriaProducto = _productoDetail.IDcategoriaProducto;
            productoDetail.CategoriaProducto = new EntidadNegocio.Entidades.CategoriaProducto();
            productoDetail.CategoriaProducto.ID = _productoDetail.IDcategoriaProducto;
            productoDetail.CategoriaProducto.Codigo = _productoDetail.CategoriaProducto.Codigo;
            productoDetail.CategoriaProducto.Categoria = _productoDetail.CategoriaProducto.Categoria;

            return productoDetail;
        }

        public Boolean Create(EntidadNegocio.Entidades.Producto _producto)
        {
            Dato.Modelo.Producto productoToAdd = new Dato.Modelo.Producto();
            Boolean resul = false; String IDCategoriaProducto = "";

            productoToAdd.ID = _producto.ID;
            productoToAdd.Nombre = _producto.Nombre;
            productoToAdd.Marca = _producto.Marca;
            Int32 iIDCategoriaProducto = _producto.IDcategoriaProducto;
            productoToAdd.IDcategoriaProducto = iIDCategoriaProducto;
            IDCategoriaProducto = iIDCategoriaProducto.ToString();

            if (!String.IsNullOrEmpty(IDCategoriaProducto))
            {
                productoToAdd.CategoriaProducto = db.CategoriaProductoSet.FirstOrDefault(c => c.ID == iIDCategoriaProducto);
            }

            if (productoToAdd.CategoriaProducto == null)
            {
                MessageBox.Show(String.Format("El número de IDCategoriaProducto {0} no está registrado en la base de datos."), EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
            //valido claves primaria
            if (db.ProductoSet.FirstOrDefault(b => b.ID == productoToAdd.ID) != null)
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
                    // Guardar y confirmo.
                    db.AddToProductoSet(productoToAdd);
                    db.SaveChanges();
                    dbTransaction.Commit();
                    /// Si la transaccion es exitosa enviamos true
                    Dato.Modelo.Producto _entidadToIDAdd = db.ProductoSet.ToList().LastOrDefault();
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

        public Boolean Edit(EntidadNegocio.Entidades.Producto _producto)
        {
            Int32 id = _producto.ID; Boolean resul = false;
            Producto productoToUpdate = db.ProductoSet.First(b => b.ID == id);
            String IDCategoriaProducto = "";

            productoToUpdate.ID = id;
            productoToUpdate.Nombre = _producto.Nombre;
            productoToUpdate.Marca = _producto.Marca;
            Int32 iIDCategoriaProducto = _producto.IDcategoriaProducto;
            productoToUpdate.IDcategoriaProducto = iIDCategoriaProducto;
            IDCategoriaProducto = iIDCategoriaProducto.ToString();
            
            if (!String.IsNullOrEmpty(IDCategoriaProducto))
            {
                productoToUpdate.CategoriaProducto = db.CategoriaProductoSet.FirstOrDefault(c => c.ID == iIDCategoriaProducto);
            }

            if (productoToUpdate.CategoriaProducto == null)
            {
                MessageBox.Show(String.Format("El número de IDCategoriaProducto {0} no está registrado en la base de datos."), EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    db.SaveChanges();
                    dbTransaction.Commit();
                    // Si la transaccion es exitosa enviamos true
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

        public Boolean Delete(EntidadNegocio.Entidades.Producto _producto)
        {
            Int32 id = _producto.ID; Boolean resul = false;
            Producto productoToDelete = db.ProductoSet.First(b => b.ID == id);
            String IDCategoriaProducto = "";

            productoToDelete.ID = id;
            productoToDelete.Nombre = _producto.Nombre;
            productoToDelete.Marca = _producto.Marca;
            Int32 iIDCategoriaProducto = _producto.IDcategoriaProducto;
            productoToDelete.IDcategoriaProducto = iIDCategoriaProducto;
            IDCategoriaProducto = iIDCategoriaProducto.ToString();

            //valido si la Producto tiene alquiler
            if (db.AlquilerSet.FirstOrDefault(a => a.IDProducto == id) != null)
            {
                MessageBox.Show(String.Format("Esta intentando Borrar una Producto que tiene alquiler."), EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    db.DeleteObject(productoToDelete);
                    db.SaveChanges();
                    dbTransaction.Commit();
                    // Si la transaccion es exitosa enviamos true
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

        public Boolean DatosValidos(List<EntidadNegocio.Entidades.Producto> _productos)
        {
            bool valido = true;
            var count = (from p in _productos where string.IsNullOrEmpty(p.ID.ToString()) || string.IsNullOrEmpty(p.Nombre) || string.IsNullOrEmpty(p.Marca.ToString()) select p.ID).Count();
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

        public Boolean DatoDuplicado(List<EntidadNegocio.Entidades.Producto> _productos, Int32 id)
        {
            if (_productos.FindAll(p => p.ID.ToString().ToUpper() == id.ToString().ToUpper()).Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean Guardar(List<EntidadNegocio.Entidades.Producto> _productos)
        {
            try
            {
                bool resul = false;
                var l = (from c in _productos where c.Edicion != EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal select c);
                List<EntidadNegocio.Entidades.Producto> _listP = null;
                _listP = l.ToList();
                if (DatosValidos(_listP))
                {
                    if (_listP.Count == 0)
                    {
                        resul = false;
                    }
                    else if (_listP.Count > 0)
                    {
                        if (MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_Guardar, EntidadNegocio.Entidades.Mensajes.Titulo_Guardar, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            foreach (EntidadNegocio.Entidades.Producto _prod in _listP)
                            {
                                if (_prod.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo)
                                {
                                    resul = this.Create(_prod);
                                }
                                else if (_prod.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado)
                                {
                                    resul = this.Edit(_prod);
                                }
                                else if (_prod.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Eliminar)
                                {
                                    resul = this.Delete(_prod);
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
