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
    public class AlquilerController 
    {
        private Dato.Modelo.DemoAlquilerGameBD db = new Dato.Modelo.DemoAlquilerGameBD();

        public List<EntidadNegocio.Entidades.Alquiler> ObtenerItems()
        {
            try
            {
                List<Dato.Modelo.Alquiler> _ListA = null;
                List<EntidadNegocio.Entidades.Alquiler> _ListAE = new List<EntidadNegocio.Entidades.Alquiler>();
                EntidadNegocio.Entidades.Alquiler _aE = null;
                _ListA = (List<Dato.Modelo.Alquiler>)db.AlquilerSet.ToList();
                foreach (Dato.Modelo.Alquiler element in _ListA)
                {
                    _aE = new EntidadNegocio.Entidades.Alquiler();
                    _aE.ID = element.ID;
                    _aE.FechaDesde = element.FechaDesde;
                    _aE.FechaHasta = element.FechaHasta;
                    _aE.TiempoHora = element.TiempoHora;
                    _aE.TiempoDia = element.TiempoDia;
                    _aE.TiempoSemana = element.TiempoSemana;
                    _aE.PrecioEstimado = element.PrecioEstimado ?? 0;
                    if (element.Estatus == 0)
                    {
                        _aE.Estatus = EntidadNegocio.Enumerados.EnumTipos.TipoAccionAlquiler.Generado;
                    }
                    else if (element.Estatus == 1)
                    {
                        _aE.Estatus = EntidadNegocio.Enumerados.EnumTipos.TipoAccionAlquiler.Procesado;
                    }
                    else
                    {
                        _aE.Estatus = EntidadNegocio.Enumerados.EnumTipos.TipoAccionAlquiler.Pagado;
                    }
                    _aE.IDCliente = element.IDCliente;
                    _aE.Cliente = new EntidadNegocio.Entidades.Cliente();
                    _aE.Cliente.ID = element.Cliente.ID;
                    _aE.Cliente.Nombre = element.Cliente.Nombre;
                    _aE.Cliente.Telefono = element.Cliente.Telefono;
                    _aE.Cliente.Correo = element.Cliente.Correo;
                    _aE.Cliente.Direccion = element.Cliente.Direccion;
                    _aE.IDProducto = element.IDProducto;
                    _aE.Producto = new EntidadNegocio.Entidades.Producto();
                    _aE.Producto.ID = element.IDProducto;
                    element.Producto.TipoLoad();
                    _aE.Producto.Tipo = new EntidadNegocio.Entidades.Tipo();
                    _aE.Producto.Tipo.ID = element.Producto.IDTipo;
                    _aE.Producto.IDTipo = element.Producto.IDTipo;
                    _aE.Producto.Tipo.Codigo = element.Producto.Tipo.Codigo;
                    _aE.Producto.Tipo.Descripcion = element.Producto.Tipo.Descripcion;
                    if (element.Producto.Tipo.Estatus == 1)
                    {
                        _aE.Producto.Tipo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _aE.Producto.Tipo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _aE.Producto.Tipo.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    _aE.Producto.ID = element.Producto.ID;
                    _aE.Producto.Codigo = element.Producto.Codigo;
                    _aE.Producto.Descripcion = element.Producto.Descripcion;
                    _aE.Producto.IDMarca = element.Producto.IDMarca;
                    _aE.Producto.IDModelo = element.Producto.IDModelo;
                    _aE.Producto.IDCategoria = element.Producto.IDCategoria;
                    element.Producto.MarcaLoad();
                    _aE.Producto.Marca = new EntidadNegocio.Entidades.Marca();
                    _aE.Producto.Marca.ID = element.Producto.IDMarca;
                    _aE.Producto.Marca.Codigo = element.Producto.Marca.Codigo;
                    _aE.Producto.Marca.Descripcion = element.Producto.Marca.Descripcion;
                    if (element.Producto.Marca.Estatus == 1)
                    {
                        _aE.Producto.Marca.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _aE.Producto.Marca.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _aE.Producto.Marca.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    element.Producto.ModeloLoad();
                    _aE.Producto.Modelo = new EntidadNegocio.Entidades.Modelo();
                    _aE.Producto.Modelo.ID = element.Producto.IDModelo;
                    _aE.Producto.Modelo.Codigo = element.Producto.Modelo.Codigo;
                    _aE.Producto.Modelo.Descripcion = element.Producto.Modelo.Descripcion;
                    if (element.Producto.Modelo.Estatus == 1)
                    {
                        _aE.Producto.Modelo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _aE.Producto.Modelo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _aE.Producto.Modelo.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    element.Producto.CategoriaLoad();
                    _aE.Producto.Categoria = new EntidadNegocio.Entidades.Categoria();
                    _aE.Producto.Categoria.ID = element.Producto.IDCategoria;
                    _aE.Producto.Categoria.Codigo = element.Producto.Categoria.Codigo;
                    _aE.Producto.Categoria.Descripcion = element.Producto.Categoria.Descripcion;
                    if (element.Producto.Categoria.Estatus == 1)
                    {
                        _aE.Producto.Categoria.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _aE.Producto.Categoria.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _aE.Producto.Categoria.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;

                    if (element.Estatus == 1)
                    {
                        _aE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _aE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _aE.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    _ListAE.Add(_aE);
                }
                return _ListAE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EntidadNegocio.Entidades.Alquiler> ObtenerItemsPorPagar()
        {
            try
            {
                List<Dato.Modelo.Alquiler> _ListA = null;
                List<EntidadNegocio.Entidades.Alquiler> _ListAE = new List<EntidadNegocio.Entidades.Alquiler>();
                EntidadNegocio.Entidades.Alquiler _aE = null;
                _ListA = (List<Dato.Modelo.Alquiler>)db.AlquilerSet.Where(a => a.Estatus == 1).ToList();
                foreach (Dato.Modelo.Alquiler element in _ListA)
                {
                    _aE = new EntidadNegocio.Entidades.Alquiler();
                    _aE.ID = element.ID;
                    _aE.FechaDesde = element.FechaDesde;
                    _aE.FechaHasta = element.FechaHasta;
                    _aE.TiempoHora = element.TiempoHora;
                    _aE.TiempoDia = element.TiempoDia;
                    _aE.TiempoSemana = element.TiempoSemana;
                    _aE.PrecioEstimado = element.PrecioEstimado ?? 0;
                    if (element.Estatus == 0)
                    {
                        _aE.Estatus = EntidadNegocio.Enumerados.EnumTipos.TipoAccionAlquiler.Generado;
                    }
                    else if (element.Estatus == 1)
                    {
                        _aE.Estatus = EntidadNegocio.Enumerados.EnumTipos.TipoAccionAlquiler.Procesado;
                    }
                    else
                    {
                        _aE.Estatus = EntidadNegocio.Enumerados.EnumTipos.TipoAccionAlquiler.Pagado;
                    }
                    _aE.IDCliente = element.IDCliente;
                    _aE.Cliente = new EntidadNegocio.Entidades.Cliente();
                    _aE.Cliente.ID = element.Cliente.ID;
                    _aE.Cliente.Nombre = element.Cliente.Nombre;
                    _aE.Cliente.Telefono = element.Cliente.Telefono;
                    _aE.Cliente.Correo = element.Cliente.Correo;
                    _aE.Cliente.Direccion = element.Cliente.Direccion;
                    _aE.IDProducto = element.IDProducto;
                    _aE.Producto = new EntidadNegocio.Entidades.Producto();
                    _aE.Producto.ID = element.IDProducto;
                    element.Producto.TipoLoad();
                    _aE.Producto.Tipo = new EntidadNegocio.Entidades.Tipo();
                    _aE.Producto.Tipo.ID = element.Producto.IDTipo;
                    _aE.Producto.IDTipo = element.Producto.IDTipo;
                    _aE.Producto.Tipo.Codigo = element.Producto.Tipo.Codigo;
                    _aE.Producto.Tipo.Descripcion = element.Producto.Tipo.Descripcion;
                    if (element.Producto.Tipo.Estatus == 1)
                    {
                        _aE.Producto.Tipo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _aE.Producto.Tipo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _aE.Producto.Tipo.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    _aE.Producto.ID = element.Producto.ID;
                    _aE.Producto.Codigo = element.Producto.Codigo;
                    _aE.Producto.Descripcion = element.Producto.Descripcion;
                    _aE.Producto.IDMarca = element.Producto.IDMarca;
                    _aE.Producto.IDModelo = element.Producto.IDModelo;
                    _aE.Producto.IDCategoria = element.Producto.IDCategoria;
                    element.Producto.MarcaLoad();
                    _aE.Producto.Marca = new EntidadNegocio.Entidades.Marca();
                    _aE.Producto.Marca.ID = element.Producto.IDMarca;
                    _aE.Producto.Marca.Codigo = element.Producto.Marca.Codigo;
                    _aE.Producto.Marca.Descripcion = element.Producto.Marca.Descripcion;
                    if (element.Producto.Marca.Estatus == 1)
                    {
                        _aE.Producto.Marca.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _aE.Producto.Marca.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _aE.Producto.Marca.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    element.Producto.ModeloLoad();
                    _aE.Producto.Modelo = new EntidadNegocio.Entidades.Modelo();
                    _aE.Producto.Modelo.ID = element.Producto.IDModelo;
                    _aE.Producto.Modelo.Codigo = element.Producto.Modelo.Codigo;
                    _aE.Producto.Modelo.Descripcion = element.Producto.Modelo.Descripcion;
                    if (element.Producto.Modelo.Estatus == 1)
                    {
                        _aE.Producto.Modelo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _aE.Producto.Modelo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _aE.Producto.Modelo.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    element.Producto.CategoriaLoad();
                    _aE.Producto.Categoria = new EntidadNegocio.Entidades.Categoria();
                    _aE.Producto.Categoria.ID = element.Producto.IDCategoria;
                    _aE.Producto.Categoria.Codigo = element.Producto.Categoria.Codigo;
                    _aE.Producto.Categoria.Descripcion = element.Producto.Categoria.Descripcion;
                    if (element.Producto.Categoria.Estatus == 1)
                    {
                        _aE.Producto.Categoria.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _aE.Producto.Categoria.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _aE.Producto.Categoria.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;

                    if (element.Estatus == 1)
                    {
                        _aE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _aE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _aE.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    _ListAE.Add(_aE);
                }
                return _ListAE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EntidadNegocio.Entidades.Alquiler> ObtenerItemsPorPagar(int idCliente)
        {
            try
            {
                List<Dato.Modelo.Alquiler> _ListA = null;
                List<EntidadNegocio.Entidades.Alquiler> _ListAE = new List<EntidadNegocio.Entidades.Alquiler>();
                EntidadNegocio.Entidades.Alquiler _aE = null;
                _ListA = (List<Dato.Modelo.Alquiler>)db.AlquilerSet.Where(a => a.IDCliente == idCliente && a.Estatus == 1).ToList();
                foreach (Dato.Modelo.Alquiler element in _ListA)
                {
                    _aE = new EntidadNegocio.Entidades.Alquiler();
                    _aE.ID = element.ID;
                    _aE.FechaDesde = element.FechaDesde;
                    _aE.FechaHasta = element.FechaHasta;
                    _aE.TiempoHora = element.TiempoHora;
                    _aE.TiempoDia = element.TiempoDia;
                    _aE.TiempoSemana = element.TiempoSemana;
                    _aE.PrecioEstimado = element.PrecioEstimado ?? 0;
                    if (element.Estatus == 0)
                    {
                        _aE.Estatus = EntidadNegocio.Enumerados.EnumTipos.TipoAccionAlquiler.Generado;
                    }
                    else if (element.Estatus == 1)
                    {
                        _aE.Estatus = EntidadNegocio.Enumerados.EnumTipos.TipoAccionAlquiler.Procesado;
                    }
                    else
                    {
                        _aE.Estatus = EntidadNegocio.Enumerados.EnumTipos.TipoAccionAlquiler.Pagado;
                    }
                    _aE.IDCliente = element.IDCliente;
                    _aE.Cliente = new EntidadNegocio.Entidades.Cliente();
                    _aE.Cliente.ID = element.Cliente.ID;
                    _aE.Cliente.Nombre = element.Cliente.Nombre;
                    _aE.Cliente.Telefono = element.Cliente.Telefono;
                    _aE.Cliente.Correo = element.Cliente.Correo;
                    _aE.Cliente.Direccion = element.Cliente.Direccion;
                    _aE.IDProducto = element.IDProducto;
                    _aE.Producto = new EntidadNegocio.Entidades.Producto();
                    _aE.Producto.ID = element.IDProducto;
                    element.Producto.TipoLoad();
                    _aE.Producto.Tipo = new EntidadNegocio.Entidades.Tipo();
                    _aE.Producto.Tipo.ID = element.Producto.IDTipo;
                    _aE.Producto.IDTipo = element.Producto.IDTipo;
                    _aE.Producto.Tipo.Codigo = element.Producto.Tipo.Codigo;
                    _aE.Producto.Tipo.Descripcion = element.Producto.Tipo.Descripcion;
                    if (element.Producto.Tipo.Estatus == 1)
                    {
                        _aE.Producto.Tipo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _aE.Producto.Tipo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _aE.Producto.Tipo.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    _aE.Producto.ID = element.Producto.ID;
                    _aE.Producto.Codigo = element.Producto.Codigo;
                    _aE.Producto.Descripcion = element.Producto.Descripcion;
                    _aE.Producto.IDMarca = element.Producto.IDMarca;
                    _aE.Producto.IDModelo = element.Producto.IDModelo;
                    _aE.Producto.IDCategoria = element.Producto.IDCategoria;
                    element.Producto.MarcaLoad();
                    _aE.Producto.Marca = new EntidadNegocio.Entidades.Marca();
                    _aE.Producto.Marca.ID = element.Producto.IDMarca;
                    _aE.Producto.Marca.Codigo = element.Producto.Marca.Codigo;
                    _aE.Producto.Marca.Descripcion = element.Producto.Marca.Descripcion;
                    if (element.Producto.Marca.Estatus == 1)
                    {
                        _aE.Producto.Marca.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _aE.Producto.Marca.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _aE.Producto.Marca.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    element.Producto.ModeloLoad();
                    _aE.Producto.Modelo = new EntidadNegocio.Entidades.Modelo();
                    _aE.Producto.Modelo.ID = element.Producto.IDModelo;
                    _aE.Producto.Modelo.Codigo = element.Producto.Modelo.Codigo;
                    _aE.Producto.Modelo.Descripcion = element.Producto.Modelo.Descripcion;
                    if (element.Producto.Modelo.Estatus == 1)
                    {
                        _aE.Producto.Modelo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _aE.Producto.Modelo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _aE.Producto.Modelo.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    element.Producto.CategoriaLoad();
                    _aE.Producto.Categoria = new EntidadNegocio.Entidades.Categoria();
                    _aE.Producto.Categoria.ID = element.Producto.IDCategoria;
                    _aE.Producto.Categoria.Codigo = element.Producto.Categoria.Codigo;
                    _aE.Producto.Categoria.Descripcion = element.Producto.Categoria.Descripcion;
                    if (element.Producto.Categoria.Estatus == 1)
                    {
                        _aE.Producto.Categoria.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _aE.Producto.Categoria.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _aE.Producto.Categoria.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;

                    if (element.Estatus == 1)
                    {
                        _aE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _aE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _aE.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    _ListAE.Add(_aE);
                }
                return _ListAE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EntidadNegocio.Entidades.Alquiler> ObtenerItemsPagado()
        {
            try
            {
                List<Dato.Modelo.Alquiler> _ListA = null;
                List<EntidadNegocio.Entidades.Alquiler> _ListAE = new List<EntidadNegocio.Entidades.Alquiler>();
                EntidadNegocio.Entidades.Alquiler _aE = null;
                _ListA = (List<Dato.Modelo.Alquiler>)db.AlquilerSet.Where(a => a.Estatus == 2).ToList();
                foreach (Dato.Modelo.Alquiler element in _ListA)
                {
                    _aE = new EntidadNegocio.Entidades.Alquiler();
                    _aE.ID = element.ID;
                    _aE.FechaDesde = element.FechaDesde;
                    _aE.FechaHasta = element.FechaHasta;
                    _aE.TiempoHora = element.TiempoHora;
                    _aE.TiempoDia = element.TiempoDia;
                    _aE.TiempoSemana = element.TiempoSemana;
                    _aE.PrecioEstimado = element.PrecioEstimado ?? 0;
                    if (element.Estatus == 0)
                    {
                        _aE.Estatus = EntidadNegocio.Enumerados.EnumTipos.TipoAccionAlquiler.Generado;
                    }
                    else if (element.Estatus == 1)
                    {
                        _aE.Estatus = EntidadNegocio.Enumerados.EnumTipos.TipoAccionAlquiler.Procesado;
                    }
                    else
                    {
                        _aE.Estatus = EntidadNegocio.Enumerados.EnumTipos.TipoAccionAlquiler.Pagado;
                    }
                    _aE.IDCliente = element.IDCliente;
                    _aE.Cliente = new EntidadNegocio.Entidades.Cliente();
                    _aE.Cliente.ID = element.Cliente.ID;
                    _aE.Cliente.Nombre = element.Cliente.Nombre;
                    _aE.Cliente.Telefono = element.Cliente.Telefono;
                    _aE.Cliente.Correo = element.Cliente.Correo;
                    _aE.Cliente.Direccion = element.Cliente.Direccion;
                    _aE.IDProducto = element.IDProducto;
                    _aE.Producto = new EntidadNegocio.Entidades.Producto();
                    _aE.Producto.ID = element.IDProducto;
                    element.Producto.TipoLoad();
                    _aE.Producto.Tipo = new EntidadNegocio.Entidades.Tipo();
                    _aE.Producto.Tipo.ID = element.Producto.IDTipo;
                    _aE.Producto.IDTipo = element.Producto.IDTipo;
                    _aE.Producto.Tipo.Codigo = element.Producto.Tipo.Codigo;
                    _aE.Producto.Tipo.Descripcion = element.Producto.Tipo.Descripcion;
                    if (element.Producto.Tipo.Estatus == 1)
                    {
                        _aE.Producto.Tipo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _aE.Producto.Tipo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _aE.Producto.Tipo.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    _aE.Producto.ID = element.Producto.ID;
                    _aE.Producto.Codigo = element.Producto.Codigo;
                    _aE.Producto.Descripcion = element.Producto.Descripcion;
                    _aE.Producto.IDMarca = element.Producto.IDMarca;
                    _aE.Producto.IDModelo = element.Producto.IDModelo;
                    _aE.Producto.IDCategoria = element.Producto.IDCategoria;
                    element.Producto.MarcaLoad();
                    _aE.Producto.Marca = new EntidadNegocio.Entidades.Marca();
                    _aE.Producto.Marca.ID = element.Producto.IDMarca;
                    _aE.Producto.Marca.Codigo = element.Producto.Marca.Codigo;
                    _aE.Producto.Marca.Descripcion = element.Producto.Marca.Descripcion;
                    if (element.Producto.Marca.Estatus == 1)
                    {
                        _aE.Producto.Marca.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _aE.Producto.Marca.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _aE.Producto.Marca.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    element.Producto.ModeloLoad();
                    _aE.Producto.Modelo = new EntidadNegocio.Entidades.Modelo();
                    _aE.Producto.Modelo.ID = element.Producto.IDModelo;
                    _aE.Producto.Modelo.Codigo = element.Producto.Modelo.Codigo;
                    _aE.Producto.Modelo.Descripcion = element.Producto.Modelo.Descripcion;
                    if (element.Producto.Modelo.Estatus == 1)
                    {
                        _aE.Producto.Modelo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _aE.Producto.Modelo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _aE.Producto.Modelo.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    element.Producto.CategoriaLoad();
                    _aE.Producto.Categoria = new EntidadNegocio.Entidades.Categoria();
                    _aE.Producto.Categoria.ID = element.Producto.IDCategoria;
                    _aE.Producto.Categoria.Codigo = element.Producto.Categoria.Codigo;
                    _aE.Producto.Categoria.Descripcion = element.Producto.Categoria.Descripcion;
                    if (element.Producto.Categoria.Estatus == 1)
                    {
                        _aE.Producto.Categoria.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _aE.Producto.Categoria.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _aE.Producto.Categoria.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;

                    if (element.Estatus == 1)
                    {
                        _aE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _aE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _aE.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    _ListAE.Add(_aE);
                }
                return _ListAE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EntidadNegocio.Entidades.Alquiler> ObtenerItemsPagado(int idCliente)
        {
            try
            {
                List<Dato.Modelo.Alquiler> _ListA = null;
                List<EntidadNegocio.Entidades.Alquiler> _ListAE = new List<EntidadNegocio.Entidades.Alquiler>();
                EntidadNegocio.Entidades.Alquiler _aE = null;
                _ListA = (List<Dato.Modelo.Alquiler>)db.AlquilerSet.Where(a => a.IDCliente == idCliente && a.Estatus == 2).ToList();
                foreach (Dato.Modelo.Alquiler element in _ListA)
                {
                    _aE = new EntidadNegocio.Entidades.Alquiler();
                    _aE.ID = element.ID;
                    _aE.FechaDesde = element.FechaDesde;
                    _aE.FechaHasta = element.FechaHasta;
                    _aE.TiempoHora = element.TiempoHora;
                    _aE.TiempoDia = element.TiempoDia;
                    _aE.TiempoSemana = element.TiempoSemana;
                    _aE.PrecioEstimado = element.PrecioEstimado ?? 0;
                    if (element.Estatus == 0)
                    {
                        _aE.Estatus = EntidadNegocio.Enumerados.EnumTipos.TipoAccionAlquiler.Generado;
                    }
                    else if (element.Estatus == 1)
                    {
                        _aE.Estatus = EntidadNegocio.Enumerados.EnumTipos.TipoAccionAlquiler.Procesado;
                    }
                    else
                    {
                        _aE.Estatus = EntidadNegocio.Enumerados.EnumTipos.TipoAccionAlquiler.Pagado;
                    }
                    _aE.IDCliente = element.IDCliente;
                    _aE.Cliente = new EntidadNegocio.Entidades.Cliente();
                    _aE.Cliente.ID = element.Cliente.ID;
                    _aE.Cliente.Nombre = element.Cliente.Nombre;
                    _aE.Cliente.Telefono = element.Cliente.Telefono;
                    _aE.Cliente.Correo = element.Cliente.Correo;
                    _aE.Cliente.Direccion = element.Cliente.Direccion;
                    _aE.IDProducto = element.IDProducto;
                    _aE.Producto = new EntidadNegocio.Entidades.Producto();
                    _aE.Producto.ID = element.IDProducto;
                    element.Producto.TipoLoad();
                    _aE.Producto.Tipo = new EntidadNegocio.Entidades.Tipo();
                    _aE.Producto.Tipo.ID = element.Producto.IDTipo;
                    _aE.Producto.IDTipo = element.Producto.IDTipo;
                    _aE.Producto.Tipo.Codigo = element.Producto.Tipo.Codigo;
                    _aE.Producto.Tipo.Descripcion = element.Producto.Tipo.Descripcion;
                    if (element.Producto.Tipo.Estatus == 1)
                    {
                        _aE.Producto.Tipo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _aE.Producto.Tipo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _aE.Producto.Tipo.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    _aE.Producto.ID = element.Producto.ID;
                    _aE.Producto.Codigo = element.Producto.Codigo;
                    _aE.Producto.Descripcion = element.Producto.Descripcion;
                    _aE.Producto.IDMarca = element.Producto.IDMarca;
                    _aE.Producto.IDModelo = element.Producto.IDModelo;
                    _aE.Producto.IDCategoria = element.Producto.IDCategoria;
                    element.Producto.MarcaLoad();
                    _aE.Producto.Marca = new EntidadNegocio.Entidades.Marca();
                    _aE.Producto.Marca.ID = element.Producto.IDMarca;
                    _aE.Producto.Marca.Codigo = element.Producto.Marca.Codigo;
                    _aE.Producto.Marca.Descripcion = element.Producto.Marca.Descripcion;
                    if (element.Producto.Marca.Estatus == 1)
                    {
                        _aE.Producto.Marca.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _aE.Producto.Marca.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _aE.Producto.Marca.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    element.Producto.ModeloLoad();
                    _aE.Producto.Modelo = new EntidadNegocio.Entidades.Modelo();
                    _aE.Producto.Modelo.ID = element.Producto.IDModelo;
                    _aE.Producto.Modelo.Codigo = element.Producto.Modelo.Codigo;
                    _aE.Producto.Modelo.Descripcion = element.Producto.Modelo.Descripcion;
                    if (element.Producto.Modelo.Estatus == 1)
                    {
                        _aE.Producto.Modelo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _aE.Producto.Modelo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _aE.Producto.Modelo.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    element.Producto.CategoriaLoad();
                    _aE.Producto.Categoria = new EntidadNegocio.Entidades.Categoria();
                    _aE.Producto.Categoria.ID = element.Producto.IDCategoria;
                    _aE.Producto.Categoria.Codigo = element.Producto.Categoria.Codigo;
                    _aE.Producto.Categoria.Descripcion = element.Producto.Categoria.Descripcion;
                    if (element.Producto.Categoria.Estatus == 1)
                    {
                        _aE.Producto.Categoria.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _aE.Producto.Categoria.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _aE.Producto.Categoria.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;

                    if (element.Estatus == 1)
                    {
                        _aE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                    }
                    else
                    {
                        _aE.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    }
                    _aE.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                    _ListAE.Add(_aE);
                }
                return _ListAE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 UltimoID()
        {
            Dato.Modelo.Alquiler _entidadToIDAdd = db.AlquilerSet.ToList().LastOrDefault();
            Int32 _id = _entidadToIDAdd.ID;
            return _id;
        }

        public EntidadNegocio.Entidades.Alquiler Details(int id)
        {
            try
            {
                Dato.Modelo.Alquiler _alquilerDetail = new Dato.Modelo.Alquiler();
                if (id == 0)
                {
                    _alquilerDetail = new Dato.Modelo.Alquiler();
                }
                else
                {
                    _alquilerDetail = db.AlquilerSet.First(a => a.ID == id);
                    _alquilerDetail.ClienteLoad();
                    _alquilerDetail.ProductoLoad();
                    _alquilerDetail.Producto.TipoLoad();
                    _alquilerDetail.Producto.MarcaLoad();
                    _alquilerDetail.Producto.ModeloLoad();
                    _alquilerDetail.Producto.CategoriaLoad();
                }

                EntidadNegocio.Entidades.Alquiler alquilerDetail = new EntidadNegocio.Entidades.Alquiler();

                alquilerDetail.ID = _alquilerDetail.ID;
                alquilerDetail.FechaDesde = _alquilerDetail.FechaDesde;
                alquilerDetail.FechaHasta = _alquilerDetail.FechaHasta;
                alquilerDetail.TiempoHora = _alquilerDetail.TiempoHora;
                alquilerDetail.TiempoDia = _alquilerDetail.TiempoDia;
                alquilerDetail.TiempoSemana = _alquilerDetail.TiempoSemana;
                alquilerDetail.PrecioEstimado = _alquilerDetail.PrecioEstimado ?? 0;
                if (_alquilerDetail.Estatus == 0)
                {
                    alquilerDetail.Estatus = EntidadNegocio.Enumerados.EnumTipos.TipoAccionAlquiler.Generado;
                }
                else if (_alquilerDetail.Estatus == 1)
                {
                    alquilerDetail.Estatus = EntidadNegocio.Enumerados.EnumTipos.TipoAccionAlquiler.Procesado;
                }
                else
                {
                    alquilerDetail.Estatus = EntidadNegocio.Enumerados.EnumTipos.TipoAccionAlquiler.Pagado;
                }
                alquilerDetail.IDCliente = _alquilerDetail.IDCliente;
                alquilerDetail.Cliente = new EntidadNegocio.Entidades.Cliente();
                alquilerDetail.Cliente.ID = _alquilerDetail.Cliente.ID;
                alquilerDetail.Cliente.Nombre = _alquilerDetail.Cliente.Nombre;
                alquilerDetail.Cliente.Telefono = _alquilerDetail.Cliente.Telefono;
                alquilerDetail.Cliente.Correo = _alquilerDetail.Cliente.Correo;
                alquilerDetail.Cliente.Direccion = _alquilerDetail.Cliente.Direccion;
                alquilerDetail.IDProducto = _alquilerDetail.IDProducto;
                alquilerDetail.Producto = new EntidadNegocio.Entidades.Producto();
                alquilerDetail.Producto.ID = _alquilerDetail.IDProducto;
                alquilerDetail.Producto.Tipo = new EntidadNegocio.Entidades.Tipo();
                alquilerDetail.Producto.Tipo.ID = _alquilerDetail.Producto.IDTipo;
                alquilerDetail.Producto.IDTipo = _alquilerDetail.Producto.IDTipo;
                alquilerDetail.Producto.Tipo.Codigo = _alquilerDetail.Producto.Tipo.Codigo;
                alquilerDetail.Producto.Tipo.Descripcion = _alquilerDetail.Producto.Tipo.Descripcion;
                if (_alquilerDetail.Producto.Tipo.Estatus == 1)
                {
                    alquilerDetail.Producto.Tipo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                }
                else
                {
                    alquilerDetail.Producto.Tipo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                }
                alquilerDetail.Producto.Tipo.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                alquilerDetail.Producto.ID = _alquilerDetail.Producto.ID;
                alquilerDetail.Producto.Codigo = _alquilerDetail.Producto.Codigo;
                alquilerDetail.Producto.Descripcion = _alquilerDetail.Producto.Descripcion;
                alquilerDetail.Producto.IDMarca = _alquilerDetail.Producto.IDMarca;
                alquilerDetail.Producto.IDModelo = _alquilerDetail.Producto.IDModelo;
                alquilerDetail.Producto.IDCategoria = _alquilerDetail.Producto.IDCategoria;
                alquilerDetail.Producto.Marca = new EntidadNegocio.Entidades.Marca();
                alquilerDetail.Producto.Marca.ID = _alquilerDetail.Producto.IDMarca;
                alquilerDetail.Producto.Marca.Codigo = _alquilerDetail.Producto.Marca.Codigo;
                alquilerDetail.Producto.Marca.Descripcion = _alquilerDetail.Producto.Marca.Descripcion;
                if (_alquilerDetail.Producto.Marca.Estatus == 1)
                {
                    alquilerDetail.Producto.Marca.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                }
                else
                {
                    alquilerDetail.Producto.Marca.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                }
                alquilerDetail.Producto.Marca.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                alquilerDetail.Producto.Modelo = new EntidadNegocio.Entidades.Modelo();
                alquilerDetail.Producto.Modelo.ID = _alquilerDetail.Producto.IDModelo;
                alquilerDetail.Producto.Modelo.Codigo = _alquilerDetail.Producto.Modelo.Codigo;
                alquilerDetail.Producto.Modelo.Descripcion = _alquilerDetail.Producto.Modelo.Descripcion;
                if (_alquilerDetail.Producto.Modelo.Estatus == 1)
                {
                    alquilerDetail.Producto.Modelo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                }
                else
                {
                    alquilerDetail.Producto.Modelo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                }
                alquilerDetail.Producto.Modelo.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                alquilerDetail.Producto.Categoria = new EntidadNegocio.Entidades.Categoria();
                alquilerDetail.Producto.Categoria.ID = _alquilerDetail.Producto.IDCategoria;
                alquilerDetail.Producto.Categoria.Codigo = _alquilerDetail.Producto.Categoria.Codigo;
                alquilerDetail.Producto.Categoria.Descripcion = _alquilerDetail.Producto.Categoria.Descripcion;
                if (_alquilerDetail.Producto.Categoria.Estatus == 1)
                {
                    alquilerDetail.Producto.Categoria.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                }
                else
                {
                    alquilerDetail.Producto.Categoria.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                }
                alquilerDetail.Producto.Categoria.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                if (_alquilerDetail.Estatus == 1)
                {
                    alquilerDetail.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                }
                else
                {
                    alquilerDetail.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                }
                alquilerDetail.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal;
                return alquilerDetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean Create(EntidadNegocio.Entidades.Alquiler _alquiler)
        {
            try
            {
                Dato.Modelo.Alquiler alquilerToAdd = new Dato.Modelo.Alquiler();
                Boolean resul = false;

                Int32 iIDCliente = _alquiler.IDCliente;
                String _sIDCliente = iIDCliente.ToString();
                Int32 iIDProducto = _alquiler.IDProducto;
                String _sIDProducto = iIDProducto.ToString();

                String _sFechaDesde = _alquiler.FechaDesde.ToString();
                DateTime dFechaDesde = DateTime.Parse(_sFechaDesde);
                String _sFechaHasta = _alquiler.FechaHasta.ToString();
                DateTime dFechaHasta = DateTime.Parse(_sFechaHasta);

                alquilerToAdd.IDCliente = iIDCliente;
                alquilerToAdd.IDProducto = iIDProducto;
                alquilerToAdd.FechaDesde = dFechaDesde;
                alquilerToAdd.FechaHasta = dFechaHasta;
                alquilerToAdd.TiempoHora = _alquiler.TiempoHora;
                alquilerToAdd.TiempoDia = _alquiler.TiempoDia;
                alquilerToAdd.TiempoSemana = _alquiler.TiempoSemana;
                alquilerToAdd.PrecioEstimado = _alquiler.PrecioEstimado;

                if (_alquiler.Estatus == EntidadNegocio.Enumerados.EnumTipos.TipoAccionAlquiler.Generado)
                {
                    alquilerToAdd.Estatus = 0;
                }
                else if (_alquiler.Estatus == EntidadNegocio.Enumerados.EnumTipos.TipoAccionAlquiler.Procesado)
                {
                    alquilerToAdd.Estatus = 1;
                }
                else
                {
                    alquilerToAdd.Estatus = 2;
                }

                if (!String.IsNullOrEmpty(_sIDCliente))
                {
                    alquilerToAdd.Cliente = db.ClienteSet.FirstOrDefault(c => c.ID == iIDCliente);
                }

                if (!String.IsNullOrEmpty(_sIDProducto))
                {
                    alquilerToAdd.Producto = db.ProductoSet.FirstOrDefault(c => c.ID == iIDProducto);
                }

                if (alquilerToAdd.Cliente == null)
                {
                    MessageBox.Show(String.Format("El número de IDCliente {0} no está registrado en la base de datos."), EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (alquilerToAdd.Producto == null)
                {
                    MessageBox.Show(String.Format("El número de IDProducto {0} no está registrado en la base de datos."), EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //valido claves primaria
                if (db.AlquilerSet.FirstOrDefault(a => a.ID == alquilerToAdd.ID) != null)
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
                        db.AddToAlquilerSet(alquilerToAdd);
                        db.SaveChanges();
                        dbTransaction.Commit();
                        /// Si la transaccion es exitosa enviamos true
                        Alquiler _entidadToIDAdd = db.AlquilerSet.ToList().LastOrDefault();
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean Edit(EntidadNegocio.Entidades.Alquiler _alquiler)
        {
            try
            {
                Int32 id = _alquiler.ID; Boolean resul = false;
                Alquiler alquilerToUpdate = db.AlquilerSet.First(a => a.ID == id);

                Int32 iIDCliente = _alquiler.IDCliente;
                String _sIDCliente = iIDCliente.ToString();
                Int32 iIDProducto = _alquiler.IDProducto;
                String _sIDProducto = iIDProducto.ToString();

                String _sFechaDesde = _alquiler.FechaDesde.ToString();
                DateTime dFechaDesde = DateTime.Parse(_sFechaDesde);
                String _sFechaHasta = _alquiler.FechaHasta.ToString();
                DateTime dFechaHasta = DateTime.Parse(_sFechaHasta);

                alquilerToUpdate.IDCliente = iIDCliente;
                alquilerToUpdate.IDProducto = iIDProducto;
                alquilerToUpdate.FechaDesde = dFechaDesde;
                alquilerToUpdate.FechaHasta = dFechaHasta;
                alquilerToUpdate.TiempoHora = _alquiler.TiempoHora;
                alquilerToUpdate.TiempoDia = _alquiler.TiempoDia;
                alquilerToUpdate.TiempoSemana = _alquiler.TiempoSemana;
                alquilerToUpdate.PrecioEstimado = _alquiler.PrecioEstimado;
                if (_alquiler.Estatus == EntidadNegocio.Enumerados.EnumTipos.TipoAccionAlquiler.Generado)
                {
                    alquilerToUpdate.Estatus = 0;
                }
                else if (_alquiler.Estatus == EntidadNegocio.Enumerados.EnumTipos.TipoAccionAlquiler.Procesado)
                {
                    alquilerToUpdate.Estatus = 1;
                }
                else
                {
                    alquilerToUpdate.Estatus = 2;
                }


                if (!String.IsNullOrEmpty(_sIDCliente))
                {
                    alquilerToUpdate.Cliente = db.ClienteSet.FirstOrDefault(c => c.ID == iIDCliente);
                }

                if (!String.IsNullOrEmpty(_sIDProducto))
                {
                    alquilerToUpdate.Producto = db.ProductoSet.FirstOrDefault(c => c.ID == iIDProducto);
                }

                if (alquilerToUpdate.Cliente == null)
                {
                    MessageBox.Show(String.Format("El número de IDCliente {0} no está registrado en la base de datos."), EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (alquilerToUpdate.Producto == null)
                {
                    MessageBox.Show(String.Format("El número de IDProducto {0} no está registrado en la base de datos."), EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean DatosValidos(List<EntidadNegocio.Entidades.Alquiler> _alquileres)
        {
            bool valido = true;
            var count = (from a in _alquileres where string.IsNullOrEmpty(a.ID.ToString()) || string.IsNullOrEmpty(a.IDCliente.ToString()) || string.IsNullOrEmpty(a.IDProducto.ToString()) select a.ID).Count();
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

        public Boolean DatoDuplicado(List<EntidadNegocio.Entidades.Alquiler> _alquileres, Int32 id)
        {
            if (_alquileres.FindAll(a => a.ID.ToString().ToUpper() == id.ToString().ToUpper()).Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean Guardar(List<EntidadNegocio.Entidades.Alquiler> _alquileres)
        {
            try
            {
                bool resul = false;
                var l = (from c in _alquileres where c.Edicion != EntidadNegocio.Enumerados.EnumEstatus.Edicion.Normal select c);
                List<EntidadNegocio.Entidades.Alquiler> _listA = null;
                _listA = l.ToList();
                if (DatosValidos(_listA))
                {
                    if (_listA.Count == 0)
                    {
                        resul = false;
                    }
                    else if (_listA.Count > 0)
                    {
                        if (MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_Guardar, EntidadNegocio.Entidades.Mensajes.Titulo_Guardar, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            foreach (EntidadNegocio.Entidades.Alquiler _alquiler in _listA)
                            {
                                if (_alquiler.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo)
                                {
                                    this.Create(_alquiler); 
                                    _alquiler.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado;
                                    resul = this.Edit(_alquiler);
                                }
                                else if (_alquiler.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado)
                                {
                                    resul = this.Edit(_alquiler);
                                }
                                else if (_alquiler.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Eliminar)
                                {
                                    resul = false;
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
