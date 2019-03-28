using Binit.Infraestructura.Website.Models.Datos;
using Preguntas.Models.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Binit.Infraestructura.Website.Models.Interfaces
{
    public interface IRepositorio<T> where T : class, IEntidad
    {
        T Traer(Guid? Id);
        IQueryable<T> TraerTodos(bool inclusiveEliminados);
        Pagina<T> TraerPagina(int numeroPagina, int elementosPagina, string criterioOrdenamiento, bool ascendente, string criterioBusqueda);
        void Crear(T entidad, bool grabarCambios);
        void Modificar(T entidad, bool grabarCambios);
        void Eliminar(T entidad, bool grabarCambios);
        void GuardarCambios(T entidad);
    }
}