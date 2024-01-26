using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Comun.ViewModels;
using Logica.BLL;
using Modelo.Modelos;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] // se instala y configura Cors para poder trabajar con Angular (ver también ' App_Start -> WebApiConfig ')
    public class MedicoController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Crear(Medico item) {
            var respuesta = new RespuestaVMR<long?>();

            try
            {
                respuesta.datos = MedicoBLL.Crear(item);
            }
            catch (Exception e)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = null;
                respuesta.mensajes.Add(e.Message);
                respuesta.mensajes.Add(e.ToString());
            }

            return Content(respuesta.codigo, respuesta);
        }
        [HttpGet]
        public IHttpActionResult LeerUno(long id){
            var respuesta = new RespuestaVMR<MedicoVMR>();

            try
            {
                respuesta.datos = MedicoBLL.LeerUno(id);
            }
            catch (Exception e)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = null;
                respuesta.mensajes.Add(e.Message);
                respuesta.mensajes.Add(e.ToString());
            }

            if (respuesta.datos == null && respuesta.mensajes.Count() == 0) {
                respuesta.codigo = HttpStatusCode.NotFound;
                respuesta.mensajes.Add("Elemento no encontrado");
            }

            return Content(respuesta.codigo, respuesta);
        }
        [HttpGet]
        public IHttpActionResult LeerTodo(int cantItems = 10, int pagina = 0, string textoBusqueda = null) { // se le agregan valores por defecto a cada parámetro ya que serán opcionales
            var respuesta = new RespuestaVMR<ListadoPaginadoVMR<MedicoVMR>>();

            try
            {
                respuesta.datos = MedicoBLL.LeerTodo(cantItems, pagina, textoBusqueda);
            }
            catch (Exception e)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = null;
                respuesta.mensajes.Add(e.Message);
                respuesta.mensajes.Add(e.ToString());
            }

            return Content(respuesta.codigo, respuesta);
        }
        [HttpPut]
        public IHttpActionResult Actualizar(long id, MedicoVMR item){
            var respuesta = new RespuestaVMR<bool>();

            try
            {
                item.id = id;
                MedicoBLL.Actualizar(item);
                respuesta.datos = true;
            }
            catch (Exception e)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = false;
                respuesta.mensajes.Add(e.Message);
                respuesta.mensajes.Add(e.ToString());
            }

            return Content(respuesta.codigo, respuesta);
        }
        [HttpDelete]
        public IHttpActionResult Eliminar(List<long> ids){
            var respuesta = new RespuestaVMR<bool>();

            try
            {
                MedicoBLL.Eliminar(ids);
                respuesta.datos = true;
            }
            catch (Exception e)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = false;
                respuesta.mensajes.Add(e.Message);
                respuesta.mensajes.Add(e.ToString());
            }

            return Content(respuesta.codigo, respuesta);
        }
    }
}
