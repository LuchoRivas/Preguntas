using Binit.Infraestructura.Website.Models;
using Binit.Infraestructura.Website.Models.Dominio.Archivo;
using Binit.Infraestructura.Website.Models.Dominio.General;
using Preguntas.Controllers;
using Preguntas.Models;
using Preguntas.Models.Dominio.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Binit.Infraestructura.Website.Controllers
{
    public class ArchivoController : BaseController
    {
        public ActionResult ObtenerImagenPorId(Guid id)
        {
            var db = new ApplicationDbContext();
            var path = ConfigurationManager.AppSettings["PathArchivos"];
            var file = new Repositorio<Archivo>(db).Traer(id);
            var extension = Path.GetExtension(file.Nombre);
            path += id.ToString().Substring(0, 2) + @"\";
            path += id.ToString().Substring(2, 1) + @"\";
            path += id.ToString() + extension;

            var bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "image/" + extension);
        }

        public ActionResult SubirArchivo()
        {
            string convert = this.Contenido.Replace("data:image/png;base64,", String.Empty);
            var data = Convert.FromBase64String(convert);
            //var model = Newtonsoft.Json.JsonConvert.DeserializeObject<ArchivoViewModel>(this.Contenido);
            var db = new ApplicationDbContext();

            //Obtengo el path del web.config
            var path = ConfigurationManager.AppSettings["PathArchivos"];

            //Obtengo Extension
            //var extension = Path.GetExtension(file.FileName);

            ////Guarda en bd

            //var imagen = new Archivo();
            //imagen.Nombre = file.FileName;
            //imagen.IdFileManager = imagen.Id.ToString();
            //imagen.Extension = extension;

            ////Genero Id
            //var guid = imagen.IdFileManager;

            ////Genero el path donde guardare el archivo y si no existe lo genero
            //path += guid.Substring(0, 2) + @"\";
            //if (!Directory.Exists(path))
            //    Directory.CreateDirectory(path);
            //path += guid.Substring(2, 1) + @"\";
            //if (!Directory.Exists(path))
            //    Directory.CreateDirectory(path);
            //path += guid + extension;

            ////Obtengo el byte[] de la File enviada
            //MemoryStream target = new MemoryStream();
            //file.InputStream.CopyTo(target);
            //byte[] bytes = target.ToArray();

            //Guardo en Disco
            //System.IO.File.WriteAllBytes(path, bytes);

            //new Repositorio<Archivo>(db).Crear(imagen);

            //Link para obtener imagen
            //var link = ConfigurationManager.AppSettings["Core"] + "/Archivo/ObtenerImagenPorId/" + guid;

            //Retorno link del archivo
            //return Json(new { link = link }, JsonRequestBehavior.AllowGet);
            return Json(new { Result = "OK" }, JsonRequestBehavior.AllowGet);
        }
    }
}