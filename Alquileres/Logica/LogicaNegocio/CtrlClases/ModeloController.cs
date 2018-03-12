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
    public class ModeloController
    {
        private Dato.Modelo.DemoAlquilerGameBD db = new Dato.Modelo.DemoAlquilerGameBD();

        public List<EntidadNegocio.Entidades.Modelo> ObtenerItems()
        {
            try
            {
                List<Dato.Modelo.Modelo> _ListM = null;
                List<EntidadNegocio.Entidades.Modelo> _ListME = new List<EntidadNegocio.Entidades.Modelo>();
                EntidadNegocio.Entidades.Modelo _mE = null;
                _ListM = (List<Dato.Modelo.Modelo>)db.ModeloSet.ToList();
                foreach (Dato.Modelo.Modelo element in _ListM)
                {
                    _mE = new EntidadNegocio.Entidades.Modelo();
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
            Dato.Modelo.Modelo _entidadToIDAdd = db.ModeloSet.ToList().LastOrDefault();
            Int32 _id = _entidadToIDAdd.ID;
            return _id;
        }

        public EntidadNegocio.Entidades.Modelo Details(int id)
        {
            Dato.Modelo.Modelo _Modelo = new Dato.Modelo.Modelo();
            if (id == 0)
            {
                _Modelo = new Dato.Modelo.Modelo();
            }
            else
            {
                _Modelo = db.ModeloSet.First(c => c.ID == id);
            }
            EntidadNegocio.Entidades.Modelo ModeloDetail = new EntidadNegocio.Entidades.Modelo();
            ModeloDetail.ID = _Modelo.ID;
            ModeloDetail.Codigo = _Modelo.Codigo;
            ModeloDetail.Descripcion = _Modelo.Descripcion;
            return ModeloDetail;
        }

        public Boolean Create(EntidadNegocio.Entidades.Modelo _modelo)
        {
            Dato.Modelo.Modelo modeloToAdd = new Dato.Modelo.Modelo();
            Boolean resul = false;

            modeloToAdd.ID = _modelo.ID;
            modeloToAdd.Codigo = _modelo.Codigo;
            modeloToAdd.Descripcion = _modelo.Descripcion;

            //valido claves primaria
            if (db.ModeloSet.FirstOrDefault(b => b.ID == modeloToAdd.ID) != null)
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
                    db.AddToModeloSet(modeloToAdd);
                    db.SaveChanges();
                    dbTransaction.Commit();
                    /// Si la transaccion es exitosa enviamos true
                    Dato.Modelo.Modelo _entidadToIDAdd = db.ModeloSet.ToList().LastOrDefault();
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

        public Boolean Edit(EntidadNegocio.Entidades.Modelo _modelo)
        {
            Int32 id = _modelo.ID; Boolean resul = false;
            Dato.Modelo.Modelo modeloToUpdate = db.ModeloSet.First(cb => cb.ID == id);

            modeloToUpdate.ID = _modelo.ID;
            modeloToUpdate.Codigo = _modelo.Codigo;
            modeloToUpdate.Descripcion = _modelo.Descripcion;

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

        public Boolean Delete(EntidadNegocio.Entidades.Modelo _modelo)
        {
            Int32 id = _modelo.ID; Boolean resul = false;
            Dato.Modelo.Modelo modeloToDelete = db.ModeloSet.First(cb => cb.ID == id);

            modeloToDelete.ID = _modelo.ID;
            modeloToDelete.Codigo = _modelo.Codigo;
            modeloToDelete.Descripcion = _modelo.Descripcion;

            //valido la Modelo tiene un producto
            if (db.ProductoSet.FirstOrDefault(b => b.IDModelo == id) != null)
            {
                MessageBox.Show(String.Format("Esta intentando Borrar un Modelo que tiene un Producto"), EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    db.DeleteObject(modeloToDelete);
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

        public Boolean DatosValidos(List<EntidadNegocio.Entidades.Modelo> _modelos)
        {
            bool valido = true;
            var count = (from m in _modelos where string.IsNullOrEmpty(m.ID.ToString()) || string.IsNullOrEmpty(m.Codigo) || string.IsNullOrEmpty(m.Descripcion.ToString()) select m.ID).Count();
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

        public Boolean DatoDuplicado(List<EntidadNegocio.Entidades.Modelo> _modelos, Int32 id)
        {
            if (_modelos.FindAll(m => m.ID.ToString().ToUpper() == id.ToString().ToUpper()).Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean Guardar(List<EntidadNegocio.Entidades.Modelo> _Modelos)
        {
            try
            {
                bool resul = false;
                var l = (from c in _Modelos where c.Edicion != EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal select c);
                List<EntidadNegocio.Entidades.Modelo> _listM = null;
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
                            foreach (EntidadNegocio.Entidades.Modelo _modelo in _listM)
                            {
                                if (_modelo.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo)
                                {
                                    resul = this.Create(_modelo);
                                }
                                else if (_modelo.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado)
                                {
                                    resul = this.Edit(_modelo);
                                }
                                else if (_modelo.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Eliminar)
                                {
                                    resul = this.Delete(_modelo);
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