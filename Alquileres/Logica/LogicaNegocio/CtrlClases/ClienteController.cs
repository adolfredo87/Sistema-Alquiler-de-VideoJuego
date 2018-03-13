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
    public class ClienteController 
    {
        private Dato.Modelo.DemoAlquilerGameBD db = new Dato.Modelo.DemoAlquilerGameBD();

        public List<EntidadNegocio.Entidades.Cliente> ObtenerItems()
        {
            try
            {
                List<Dato.Modelo.Cliente> _ListC = null;
                List<EntidadNegocio.Entidades.Cliente> _ListCE = new List<EntidadNegocio.Entidades.Cliente>();
                EntidadNegocio.Entidades.Cliente _cE = null;
                _ListC = (List<Dato.Modelo.Cliente>)db.ClienteSet.ToList();
                foreach (Dato.Modelo.Cliente element in _ListC)
                {
                    _cE = new EntidadNegocio.Entidades.Cliente();
                    _cE.ID = element.ID;
                    _cE.Nombre = element.Nombre;
                    _cE.Telefono = element.Telefono;
                    _cE.Correo = element.Correo;
                    _cE.Direccion = element.Direccion;
                    if (element.Estatus == 1)
                    {
                        _cE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _cE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
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
            Cliente _entidadToIDAdd = db.ClienteSet.ToList().LastOrDefault();
            Int32 _id = _entidadToIDAdd.ID;
            return _id;
        }

        public EntidadNegocio.Entidades.Cliente Details(int id)
        {
            Dato.Modelo.Cliente _cliente = new Dato.Modelo.Cliente();
            if (id == 0)
            {
                _cliente = new Dato.Modelo.Cliente();
            }
            else
            {
                _cliente = db.ClienteSet.First(c => c.ID == id);
            }
            EntidadNegocio.Entidades.Cliente clienteDetail = new EntidadNegocio.Entidades.Cliente();
            clienteDetail.ID = _cliente.ID;
            clienteDetail.Nombre = _cliente.Nombre;
            clienteDetail.Telefono = _cliente.Telefono;
            clienteDetail.Correo = _cliente.Correo;
            clienteDetail.Direccion = _cliente.Direccion;
            if (_cliente.Estatus == 1)
            {
                clienteDetail.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
            }
            else
            {
                clienteDetail.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
            }
            return clienteDetail;
        }

        public Boolean Create(EntidadNegocio.Entidades.Cliente _cliente)
        {
            Dato.Modelo.Cliente clienteToAdd = new Dato.Modelo.Cliente();
            Boolean resul = false;

            clienteToAdd.ID = _cliente.ID;
            clienteToAdd.Nombre = _cliente.Nombre;
            clienteToAdd.Telefono = _cliente.Telefono;
            clienteToAdd.Correo = _cliente.Correo;
            clienteToAdd.Direccion = _cliente.Direccion;
            if (_cliente.Status == EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo)
            {
                clienteToAdd.Estatus = 1;
            }
            else
            {
                clienteToAdd.Estatus = 0;
            }

            //valido claves primaria
            if (db.ClienteSet.FirstOrDefault(c => c.ID == clienteToAdd.ID) != null)
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
                    // Guardar y confirmar el cliente.
                    db.AddToClienteSet(clienteToAdd);
                    db.SaveChanges();
                    dbTransaction.Commit();
                    /// Si la transaccion es exitosa enviamos true
                    Dato.Modelo.Cliente _entidadToIDAdd = db.ClienteSet.ToList().LastOrDefault();
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

        public Boolean Edit(EntidadNegocio.Entidades.Cliente _cliente)
        {
            Int32 id = _cliente.ID; Boolean resul = false;
            Dato.Modelo.Cliente clienteToUpdate = db.ClienteSet.First(c => c.ID == id);

            clienteToUpdate.ID = _cliente.ID;
            clienteToUpdate.Nombre = _cliente.Nombre;
            clienteToUpdate.Telefono = _cliente.Telefono;
            clienteToUpdate.Correo = _cliente.Correo;
            clienteToUpdate.Direccion = _cliente.Direccion;
            if (_cliente.Status == EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo)
            {
                clienteToUpdate.Estatus = 1;
            }
            else
            {
                clienteToUpdate.Estatus = 0;
            }

            if (db.Connection.State != System.Data.ConnectionState.Open)
            {
                db.Connection.Open();
            }

            DbTransaction dbTransaction = db.Connection.BeginTransaction();

            try
            {
                // Guardar y confirmar el cliente.
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

        public Boolean Delete(EntidadNegocio.Entidades.Cliente _cliente)
        {
            Int32 id = _cliente.ID; Boolean resul = false;
            Dato.Modelo.Cliente clienteToDelete = db.ClienteSet.First(c => c.ID == id);

            clienteToDelete.ID = _cliente.ID;
            clienteToDelete.Nombre = _cliente.Nombre;
            clienteToDelete.Telefono = _cliente.Telefono;
            clienteToDelete.Correo = _cliente.Correo;
            clienteToDelete.Direccion = _cliente.Direccion;
            if (_cliente.Status == EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo)
            {
                clienteToDelete.Estatus = 1;
            }
            else
            {
                clienteToDelete.Estatus = 0;
            }

            //valido cliente tiene alquiler
            if (db.AlquilerSet.FirstOrDefault(b => b.IDCliente == id) != null)
            {
                MessageBox.Show(String.Format("Esta intentando Borrar un cliente que tiene un Alquiler"), EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    db.DeleteObject(clienteToDelete);
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
            }

            return resul;
        }

        public Boolean DatosValidos(List<EntidadNegocio.Entidades.Cliente> _clientes)
        {
            bool valido = true;
            var count = (from c in _clientes where string.IsNullOrEmpty(c.ID.ToString()) || string.IsNullOrEmpty(c.Nombre) || string.IsNullOrEmpty(c.Correo.ToString()) select c.ID).Count();
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

        public Boolean DatoDuplicado(List<EntidadNegocio.Entidades.Cliente> _clientes, Int32 id)
        {
            if (_clientes.FindAll(c => c.ID.ToString().ToUpper() == id.ToString().ToUpper()).Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean Guardar(List<EntidadNegocio.Entidades.Cliente> _clientes)
        {
            try
            {
                bool resul = false;
                var l = (from c in _clientes where c.Edicion != EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal select c);
                List<EntidadNegocio.Entidades.Cliente> _listC = null;
                _listC = l.ToList();
                if (DatosValidos(_listC))
                {
                    if (_listC.Count == 0)
                    {
                        resul = false;
                    }
                    else if (_listC.Count > 0)
                    {
                        if (MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_Guardar, EntidadNegocio.Entidades.Mensajes.Titulo_Guardar, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            foreach (EntidadNegocio.Entidades.Cliente _cliente in _listC)
                            {
                                if (_cliente.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo)
                                {
                                    resul = this.Create(_cliente);
                                }
                                else if (_cliente.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado)
                                {
                                    resul = this.Edit(_cliente);
                                }
                                else if (_cliente.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Eliminar)
                                {
                                    resul = this.Delete(_cliente);
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
