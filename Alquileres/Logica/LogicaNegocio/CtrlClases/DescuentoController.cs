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
    public class DescuentoController
    {
        private Dato.Modelo.DemoAlquilerGameBD db = new Dato.Modelo.DemoAlquilerGameBD();

        public List<EntidadNegocio.Entidades.Descuento> ObtenerItems()
        {
            try
            {
                List<Dato.Modelo.Descuento> _ListD = null;
                List<EntidadNegocio.Entidades.Descuento> _ListDE = new List<EntidadNegocio.Entidades.Descuento>();
                EntidadNegocio.Entidades.Descuento _descE = null;
                _ListD = (List<Dato.Modelo.Descuento>)db.DescuentoSet.ToList();
                foreach (Dato.Modelo.Descuento element in _ListD)
                {
                    _descE = new EntidadNegocio.Entidades.Descuento();
                    _descE.ID = element.ID;
                    _descE.Codigo = element.Codigo;
                    _descE.Descripcion = element.Descripcion;
                    _descE.PorcentajeDescuento = element.PorcentajeDescuento ?? 0;
                    if (element.Estatus == 1)
                    {
                        _descE.Estatus = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _descE.Estatus = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _descE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    _descE.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    _ListDE.Add(_descE);
                }
                return _ListDE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 UltimoID()
        {
            Dato.Modelo.Descuento _entidadToIDAdd = db.DescuentoSet.ToList().LastOrDefault();
            Int32 _id = _entidadToIDAdd.ID;
            return _id;
        }

        public EntidadNegocio.Entidades.Descuento Details(int id)
        {
            Dato.Modelo.Descuento _descuento = new Dato.Modelo.Descuento();
            if (id == 0)
            {
                _descuento = new Dato.Modelo.Descuento();
            }
            else
            {
                _descuento = db.DescuentoSet.First(c => c.ID == id);
            }
            EntidadNegocio.Entidades.Descuento descuentoDetail = new EntidadNegocio.Entidades.Descuento();
            descuentoDetail.ID = _descuento.ID;
            descuentoDetail.Codigo = _descuento.Codigo;
            descuentoDetail.Descripcion = _descuento.Descripcion;
            descuentoDetail.PorcentajeDescuento = _descuento.PorcentajeDescuento ?? 0;
            if (_descuento.Estatus == 1)
            {
                descuentoDetail.Estatus = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
            }
            else
            {
                descuentoDetail.Estatus = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
            }
            return descuentoDetail;
        }

        public Boolean Create(EntidadNegocio.Entidades.Descuento _descuento)
        {
            Dato.Modelo.Descuento descuentoToAdd = new Dato.Modelo.Descuento();
            Boolean resul = false;

            descuentoToAdd.ID = _descuento.ID;
            descuentoToAdd.Codigo = _descuento.Codigo;
            descuentoToAdd.Descripcion = _descuento.Descripcion;
            descuentoToAdd.PorcentajeDescuento = _descuento.PorcentajeDescuento;
            if (_descuento.Estatus == EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo)
            {
                descuentoToAdd.Estatus = 1;
            }
            else
            {
                descuentoToAdd.Estatus = 0;
            }

            //valido claves primaria
            if (db.DescuentoSet.FirstOrDefault(b => b.ID == descuentoToAdd.ID) != null)
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
                    db.AddToDescuentoSet(descuentoToAdd);
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

        public Boolean Edit(EntidadNegocio.Entidades.Descuento _descuento)
        {
            Int32 id = _descuento.ID; Boolean resul = false;
            Dato.Modelo.Descuento descuentoToUpdate = db.DescuentoSet.First(d => d.ID == id);

            descuentoToUpdate.ID = _descuento.ID;
            descuentoToUpdate.Codigo = _descuento.Codigo;
            descuentoToUpdate.Descripcion = _descuento.Descripcion;
            descuentoToUpdate.PorcentajeDescuento = _descuento.PorcentajeDescuento;
            if (_descuento.Estatus == EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo)
            {
                descuentoToUpdate.Estatus = 1;
            }
            else
            {
                descuentoToUpdate.Estatus = 0;
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

        public Boolean Delete(EntidadNegocio.Entidades.Descuento _descuento)
        {
            Int32 id = _descuento.ID; Boolean resul = false;
            Dato.Modelo.Descuento descuentoToDelete = db.DescuentoSet.First(d => d.ID == id);

            descuentoToDelete.ID = _descuento.ID;
            descuentoToDelete.Codigo = _descuento.Codigo;
            String _Descripcion = _descuento.Descripcion;
            descuentoToDelete.Descripcion = _Descripcion;
            descuentoToDelete.PorcentajeDescuento = _descuento.PorcentajeDescuento;
            if (_descuento.Estatus == EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo)
            {
                descuentoToDelete.Estatus = 1;
            }
            else
            {
                descuentoToDelete.Estatus = 0;
            }

            //valido si el descuento que se borra es de cabecera o de linea
            if (_Descripcion.Contains("Cabecera") || _Descripcion.Contains("Linea"))
            {
                MessageBox.Show(String.Format("Ningun descuento de Cabecera o de Linea puede ser eliminado."), EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    db.DeleteObject(descuentoToDelete);
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

        public Boolean DatosValidos(List<EntidadNegocio.Entidades.Descuento> _descuentos)
        {
            bool valido = true;
            var count = (from cp in _descuentos where string.IsNullOrEmpty(cp.ID.ToString()) || string.IsNullOrEmpty(cp.Codigo) select cp.ID).Count();
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

        public Boolean DatoDuplicado(List<EntidadNegocio.Entidades.Descuento> _descuentos, Int32 id)
        {
            if (_descuentos.FindAll(cp => cp.ID.ToString().ToUpper() == id.ToString().ToUpper()).Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean Guardar(List<EntidadNegocio.Entidades.Descuento> _descuentos)
        {
            try
            {
                bool resul = false;
                var l = (from c in _descuentos where c.Edicion != EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal select c);
                List<EntidadNegocio.Entidades.Descuento> _listDesc = null;
                _listDesc = l.ToList();
                if (DatosValidos(_listDesc))
                {
                    if (_listDesc.Count == 0)
                    {
                        resul = false;
                    }
                    else if (_listDesc.Count > 0)
                    {
                        if (MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_Guardar, EntidadNegocio.Entidades.Mensajes.Titulo_Guardar, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            foreach (EntidadNegocio.Entidades.Descuento _desc in _listDesc)
                            {
                                if (_desc.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo)
                                {
                                    resul = this.Create(_desc);
                                }
                                else if (_desc.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado)
                                {
                                    resul = this.Edit(_desc);
                                }
                                else if (_desc.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Eliminar)
                                {
                                    resul = this.Delete(_desc);
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
