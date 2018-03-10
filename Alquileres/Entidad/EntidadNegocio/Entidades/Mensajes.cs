using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace EntidadNegocio.Entidades
{
    public class Mensajes
    {
        public const string Info_Bienvenido = "Bienvenido al Sistema de Alquiler de VideoGame.";
	    public const string Info_Guardar = "Esta seguro de guardar la información";
        public const string Info_Eliminar = "Esta seguro de eliminar la informacion";
	    public const string Info_Guardado = "Información guardada con exito";
	    public const string Info_Eliminado = "Información eliminada con exito";
        public const string Info_NoCoincidencia = "No se encontraron coincidencias";
	    public const string Info_Incompleta = "Existen datos o registros con información incompleta";
	    public const string Info_ErrorAlGuardar = "Se produjo un error al guardar la información";
        public const string Info_ErrorAlGuardarViolacionPK = "Se produjo un error al guardar la información - se produjo una violacion de Clave primaria.";
	    public const string Info_ErrorAlEliminar = "Se produjo un error al eliminar la información";
	    public const string Info_FormatoInvalido = "Existen datos con formato invalido";
	    public const string Info_DatosRepetidos = "Existen registros con datos repetidos";
	    public const string Info_ErrorAlCargar = "Se produjo un error al cargar la información";
	    public const string Info_ErrorAlMostrar = "Se produjo un error al mostrar la información";
	    public const string Info_ErrorSinGuardar = "Existe información sin guardar";
	    public const string Info_OperacionInvalida = "Operación invalida";
	    public const string Info_ErrorFecha = "El rango de fecha no se puede procesar";
        public const string Info_ErrorEntSinSeleccionar = "No hay ninguna entrada selecionada";
        public const string Info_ErrorVehSinSeleccionar = "No hay ningun vehiculo selecionado";
        public const string Info_ErrorVehiculoSinSalir = "La Entrada especificada No tiene ninguna Salida, por lo que es imposible generar la Nota de Salida";
	    public const string Info_Error_ConexionServidor = "Se produjo un error en la conexion con el servidor";
	    public const string Info_DatoInvalido = "Dato invalido";
	    public const string Info_Producto = "El rango de productos es invalido";
	    public const string Info_ErrorID = "El rango de ID es invalido";
        public const string Info_ErrorUser = "Asegurese de que el usuario y/o la contraseña es correcta";
        public const string Info_Denegado = "Usuario No Autorizado a Esta Aplicacion";

        public const string Titulo_Bienvenido = "Bienvenido a Sistema.";
	    public const string Titulo_Guardar = "Guardar información";
	    public const string Titulo_Eliminar = "Eliminar información";
	    public const string Titulo_Cargar = "Cargar información";
	    public const string Titulo_Mostrar = "Mostrar información";
        public const string Titulo_Buscar = "Buscar";
	    public const string Titulo_Error = "Error";
        public const string Titulo_Advertencia = "Advertencia";
        public const string Titulo_AccesoDenegado = "Acceso Denegado";

	    public const string Titulo_Salir = "Salir";
	    public const string Info_OK = "OK";
	    public const string Info_ConfiguracionIndefinida = "Configuración no establecida para esta operación";

	    public const string Info_OperacionInvalidaPorEstatus = "Operación invalida. Estatus del Documento no Valido para la operación";
	    public const string Espera_Titulo = "Por favor espere...";
	    public const string Espera_Guardando = "Guardando información...";
	    public const string Espera_Eliminando = "Eliminando información...";
	    public const string Espera_Cargando = "Cargando información...";

	    public const string Espera_Mostrando = "Mostrando información...";
	    public const string Salir = "Esta Seguro de Cerrar la Ventana";

	    public const string Info_SinDatos = "No existe informacion para mostrar";
    }
}

// Soli Deo Gloria