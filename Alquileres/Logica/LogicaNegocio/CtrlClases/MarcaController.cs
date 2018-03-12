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
                    _mE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
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
            Dato.Modelo.Marca _Marca = new Dato.Modelo.Marca();
            if (id == 0)
            {
                _Marca = new Dato.Modelo.Marca();
            }
            else
            {
                _Marca = db.MarcaSet.First(c => c.ID == id);
            }
            EntidadNegocio.Entidades.Marca MarcaDetail = new EntidadNegocio.Entidades.Marca();
            MarcaDetail.ID = _Marca.ID;
            MarcaDetail.Codigo = _Marca.Codigo;
            MarcaDetail.Descripcion = _Marca.Descripcion;
            return MarcaDetail;
        }

        public Boolean Create(EntidadNegocio.Entidades.Marca _marca)
        {
            Dato.Modelo.Marca MarcaToAdd = new Dato.Modelo.Marca();
            Boolean resul = false;

            MarcaToAdd.ID = _marca.ID;
            MarcaToAdd.Codigo = _marca.Codigo;
            MarcaToAdd.Descripcion = _marca.Descripcion;

            //valido claves primaria
            if (db.MarcaSet.FirstOrDefault(b => b.ID == MarcaToAdd.ID) != null)
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
                    db.AddToMarcaSet(MarcaToAdd);
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
            Dato.Modelo.Marca MarcaToUpdate = db.MarcaSet.First(cb => cb.ID == id);

            MarcaToUpdate.ID = _marca.ID;
            MarcaToUpdate.Codigo = _marca.Codigo;
            MarcaToUpdate.Descripcion = _marca.Descripcion;

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
            Dato.Modelo.Marca MarcaToDelete = db.MarcaSet.First(cb => cb.ID == id);

            MarcaToDelete.ID = _marca.ID;
            MarcaToDelete.Codigo = _marca.Codigo;
            MarcaToDelete.Descripcion = _marca.Descripcion;

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
                    db.DeleteObject(MarcaToDelete);
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