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
                    element.TipoLoad();
                    _pE.Tipo = new EntidadNegocio.Entidades.Tipo();
                    _pE.Tipo.ID = element.IDTipo;
                    _pE.IDTipo = element.IDTipo;
                    _pE.Tipo.Codigo = element.Tipo.Codigo;
                    _pE.Tipo.Descripcion = element.Tipo.Descripcion;
                    if (element.Tipo.Estatus == 1)
                    {
                        _pE.Tipo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _pE.Tipo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _pE.Tipo.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    _pE.Codigo = element.Codigo;
                    _pE.Descripcion = element.Descripcion;
                    element.MarcaLoad();
                    _pE.Marca = new EntidadNegocio.Entidades.Marca();
                    _pE.Marca.ID = element.IDMarca;
                    _pE.IDMarca = element.IDMarca;
                    _pE.Marca.Codigo = element.Marca.Codigo;
                    _pE.Marca.Descripcion = element.Marca.Descripcion;
                    if (element.Marca.Estatus == 1)
                    {
                        _pE.Marca.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _pE.Marca.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _pE.Marca.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    element.ModeloLoad();
                    _pE.Modelo = new EntidadNegocio.Entidades.Modelo();
                    _pE.Modelo.ID = element.IDModelo;
                    _pE.IDModelo = element.IDModelo;
                    _pE.Modelo.Codigo = element.Modelo.Codigo;
                    _pE.Modelo.Descripcion = element.Modelo.Descripcion;
                    if (element.Modelo.Estatus == 1)
                    {
                        _pE.Modelo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _pE.Modelo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _pE.Modelo.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    element.CategoriaLoad();
                    _pE.Categoria = new EntidadNegocio.Entidades.Categoria();
                    _pE.Categoria.ID = element.IDCategoria;
                    _pE.IDCategoria = element.IDCategoria;
                    _pE.Categoria.Codigo = element.Categoria.Codigo;
                    _pE.Categoria.Descripcion = element.Categoria.Descripcion;
                    if (element.Categoria.Estatus == 1)
                    {
                        _pE.Categoria.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _pE.Categoria.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _pE.Categoria.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    if (element.Estatus == 1)
                    {
                        _pE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _pE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _pE.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
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
                _productoDetail.TipoLoad();
                _productoDetail.MarcaLoad();
                _productoDetail.ModeloLoad();
                _productoDetail.CategoriaLoad();
            }
            EntidadNegocio.Entidades.Producto productoDetail = new EntidadNegocio.Entidades.Producto();

            productoDetail.ID = _productoDetail.ID;

            productoDetail.Tipo = new EntidadNegocio.Entidades.Tipo();
            productoDetail.Tipo.ID = _productoDetail.IDTipo;
            productoDetail.IDTipo = _productoDetail.IDTipo;
            productoDetail.Tipo.Codigo = _productoDetail.Tipo.Codigo;
            productoDetail.Tipo.Descripcion = _productoDetail.Tipo.Descripcion;
            if (_productoDetail.Tipo.Estatus == 1)
            {
                productoDetail.Tipo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
            }
            else
            {
                productoDetail.Tipo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
            }
            productoDetail.Tipo.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;

            productoDetail.Codigo = _productoDetail.Codigo;
            productoDetail.Descripcion = _productoDetail.Descripcion;

            productoDetail.Marca = new EntidadNegocio.Entidades.Marca();
            productoDetail.IDMarca = _productoDetail.IDMarca;
            productoDetail.Marca.ID = _productoDetail.IDMarca;
            productoDetail.Marca.Codigo = _productoDetail.Marca.Codigo;
            productoDetail.Marca.Descripcion = _productoDetail.Marca.Descripcion;
            if (_productoDetail.Marca.Estatus == 1)
            {
                productoDetail.Marca.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
            }
            else
            {
                productoDetail.Marca.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
            }
            productoDetail.Marca.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;

            productoDetail.Modelo = new EntidadNegocio.Entidades.Modelo();
            productoDetail.IDModelo = _productoDetail.IDModelo;
            productoDetail.Modelo.ID = _productoDetail.IDModelo;
            productoDetail.Modelo.Codigo = _productoDetail.Modelo.Codigo;
            productoDetail.Modelo.Descripcion = _productoDetail.Modelo.Descripcion;
            if (_productoDetail.Modelo.Estatus == 1)
            {
                productoDetail.Modelo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
            }
            else
            {
                productoDetail.Modelo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
            }
            productoDetail.Modelo.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;

            productoDetail.Categoria = new EntidadNegocio.Entidades.Categoria();
            productoDetail.IDCategoria = _productoDetail.IDCategoria;
            productoDetail.Categoria.ID = _productoDetail.IDCategoria;
            productoDetail.Categoria.Codigo = _productoDetail.Categoria.Codigo;
            productoDetail.Categoria.Descripcion = _productoDetail.Categoria.Descripcion;
            if (_productoDetail.Categoria.Estatus == 1)
            {
                productoDetail.Categoria.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
            }
            else
            {
                productoDetail.Categoria.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
            }
            productoDetail.Categoria.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;

            if (_productoDetail.Estatus == 1)
            {
                productoDetail.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
            }
            else
            {
                productoDetail.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
            }
            productoDetail.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;

            return productoDetail;
        }

        public Boolean Create(EntidadNegocio.Entidades.Producto _producto)
        {
            Dato.Modelo.Producto productoToAdd = new Dato.Modelo.Producto(); Boolean resul = false;
            String IDTipo = ""; String IDMarca = ""; String IDModelo = ""; String IDCategoria = "";

            productoToAdd.ID = _producto.ID;
            productoToAdd.Codigo = _producto.Codigo;
            productoToAdd.Descripcion = _producto.Descripcion;
            if (_producto.Status == EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo)
            {
                productoToAdd.Estatus = 1;
            }
            else
            {
                productoToAdd.Estatus = 0;
            }

            Int32 iIDTipo = _producto.IDTipo;
            if (iIDTipo == 0)
            {
                TipoController ctrlTipo = new TipoController();
                iIDTipo = ctrlTipo.UltimoID();
            }
            else
            {
                iIDTipo = _producto.IDTipo;
            }
            productoToAdd.IDTipo = iIDTipo;
            IDTipo = iIDTipo.ToString();

            Int32 iIDMarca = _producto.IDMarca;
            productoToAdd.IDMarca = iIDMarca;
            IDMarca = iIDMarca.ToString();

            Int32 iIDModelo = _producto.IDModelo;
            productoToAdd.IDModelo = iIDModelo;
            IDModelo = iIDModelo.ToString();

            Int32 iIDCategoria = _producto.IDCategoria;
            productoToAdd.IDCategoria = iIDCategoria;
            IDCategoria = iIDCategoria.ToString();

            if (!String.IsNullOrEmpty(IDTipo))
            {
                productoToAdd.Tipo = db.TipoSet.FirstOrDefault(c => c.ID == iIDTipo);
            }

            if (productoToAdd.Tipo == null)
            {
                MessageBox.Show(String.Format("El número de IDTipo {0} no está registrado en la base de datos."), EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!String.IsNullOrEmpty(IDMarca))
            {
                productoToAdd.Marca = db.MarcaSet.FirstOrDefault(c => c.ID == iIDMarca);
            }

            if (productoToAdd.Marca == null)
            {
                MessageBox.Show(String.Format("El número de IDMarca {0} no está registrado en la base de datos."), EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!String.IsNullOrEmpty(IDModelo))
            {
                productoToAdd.Modelo = db.ModeloSet.FirstOrDefault(c => c.ID == iIDModelo);
            }

            if (productoToAdd.Modelo == null)
            {
                MessageBox.Show(String.Format("El número de IDModelo {0} no está registrado en la base de datos."), EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!String.IsNullOrEmpty(IDCategoria))
            {
                productoToAdd.Categoria = db.CategoriaSet.FirstOrDefault(c => c.ID == iIDCategoria);
            }

            if (productoToAdd.Categoria == null)
            {
                MessageBox.Show(String.Format("El número de IDCategoria {0} no está registrado en la base de datos."), EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            String IDTipo = ""; String IDMarca = ""; String IDModelo = ""; String IDCategoria = "";

            productoToUpdate.ID = _producto.ID;
            productoToUpdate.Codigo = _producto.Codigo;
            productoToUpdate.Descripcion = _producto.Descripcion;
            if (_producto.Status == EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo)
            {
                productoToUpdate.Estatus = 1;
            }
            else
            {
                productoToUpdate.Estatus = 0;
            }

            Int32 iIDTipo = _producto.IDTipo;
            if (iIDTipo == 0)
            {
                TipoController ctrlTipo = new TipoController();
                iIDTipo = ctrlTipo.UltimoID();
            }
            else
            {
                iIDTipo = _producto.IDTipo;
            }
            productoToUpdate.IDTipo = iIDTipo;
            IDTipo = iIDTipo.ToString();

            Int32 iIDMarca = _producto.IDMarca;
            productoToUpdate.IDMarca = iIDMarca;
            IDMarca = iIDMarca.ToString();

            Int32 iIDModelo = _producto.IDModelo;
            productoToUpdate.IDModelo = iIDModelo;
            IDModelo = iIDModelo.ToString();

            Int32 iIDCategoria = _producto.IDCategoria;
            productoToUpdate.IDCategoria = iIDCategoria;
            IDCategoria = iIDCategoria.ToString();

            if (!String.IsNullOrEmpty(IDTipo))
            {
                productoToUpdate.Tipo = db.TipoSet.FirstOrDefault(c => c.ID == iIDTipo);
            }

            if (productoToUpdate.Tipo == null)
            {
                MessageBox.Show(String.Format("El número de IDTipo {0} no está registrado en la base de datos."), EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!String.IsNullOrEmpty(IDMarca))
            {
                productoToUpdate.Marca = db.MarcaSet.FirstOrDefault(c => c.ID == iIDMarca);
            }

            if (productoToUpdate.Marca == null)
            {
                MessageBox.Show(String.Format("El número de IDMarca {0} no está registrado en la base de datos."), EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!String.IsNullOrEmpty(IDModelo))
            {
                productoToUpdate.Modelo = db.ModeloSet.FirstOrDefault(c => c.ID == iIDModelo);
            }

            if (productoToUpdate.Modelo == null)
            {
                MessageBox.Show(String.Format("El número de IDModelo {0} no está registrado en la base de datos."), EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!String.IsNullOrEmpty(IDCategoria))
            {
                productoToUpdate.Categoria = db.CategoriaSet.FirstOrDefault(c => c.ID == iIDCategoria);
            }

            if (productoToUpdate.Categoria == null)
            {
                MessageBox.Show(String.Format("El número de IDCategoria {0} no está registrado en la base de datos."), EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if (db.Connection.State == System.Data.ConnectionState.Closed)
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

            return resul;
        }

        public Boolean Delete(EntidadNegocio.Entidades.Producto _producto)
        {
            Int32 id = _producto.ID; Boolean resul = false;
            Producto productoToDelete = db.ProductoSet.First(b => b.ID == id);
            String IDTipo = ""; String IDMarca = ""; String IDModelo = ""; String IDCategoria = "";

            productoToDelete.ID = _producto.ID;
            productoToDelete.Codigo = _producto.Codigo;
            productoToDelete.Descripcion = _producto.Descripcion;
            if (_producto.Status == EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo)
            {
                productoToDelete.Estatus = 1;
            }
            else
            {
                productoToDelete.Estatus = 0;
            }

            Int32 iIDTipo = _producto.IDTipo;
            if (iIDTipo == 0)
            {
                TipoController ctrlTipo = new TipoController();
                iIDTipo = ctrlTipo.UltimoID();
            }
            else
            {
                iIDTipo = _producto.IDTipo;
            }
            productoToDelete.IDTipo = iIDTipo;
            IDTipo = iIDTipo.ToString();

            Int32 iIDMarca = _producto.IDMarca;
            productoToDelete.IDMarca = iIDMarca;
            IDMarca = iIDMarca.ToString();

            Int32 iIDModelo = _producto.IDModelo;
            productoToDelete.IDModelo = iIDModelo;
            IDModelo = iIDModelo.ToString();

            Int32 iIDCategoria = _producto.IDCategoria;
            productoToDelete.IDCategoria = iIDCategoria;
            IDCategoria = iIDCategoria.ToString();

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
            var count = (from p in _productos where string.IsNullOrEmpty(p.ID.ToString()) || string.IsNullOrEmpty(p.Codigo.ToString()) || string.IsNullOrEmpty(p.Descripcion)  select p.ID).Count();       
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
