using Preguntas.Models;
using Preguntas.Models.OneSignal;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Preguntas.Controllers;

namespace cuidarlos.web.Controllers
{
    public class OneSignalController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private const string OneSignalApiUri = "https://onesignal.com/api/v1/notifications";
        private const string OneSignalAppId = "1da6dc35-9443-4d70-a309-c8e9cec129df";
        private const string RestApiKey = "";
        #region OneSignalPlayers
        private const string CuidarlosSignalId = "5a02174f-34c7-492a-d8c2-2520db91811a";
        //private const string EnzoOneSignalId = "ffc27e4a-ab89-48b4-9415-2ebb578b0dc1";
        //private const string AleOneSignalId = "6d3e6347-7f40-4cb6-9975-f5569e3a046f";
        #endregion

        private static bool SendToAll(PushNotification push)
        {
            var request = BuildRequest();
            var segments = new string[] { "Test" };
            var notification = new ToSegmentsNotificationDTO(push, OneSignalAppId, segments);
            try
            {
                WriteContent(request, notification);
                return true;
            }
            catch (Exception ex)
            {
                //Elmah.ErrorLog.GetDefault(System.Web.HttpContext.Current).Log(new Elmah.Error(ex));
                return false;
            }
        }

        private static bool SendToDevice(PushNotification push)
        {
            var request = BuildRequest();
            var notification = new ToPlayersNotificationDTO(push, OneSignalAppId);
            try
            {
                WriteContent(request, notification);
                return true;
            }
            catch (Exception ex)
            {
                //Elmah.ErrorLog.GetDefault(System.Web.HttpContext.Current).Log(new Elmah.Error(ex));
                return false;
            }
        }

        private static void WriteContent(HttpWebRequest request, object notification)
        {
            var param = new JavaScriptSerializer().Serialize(notification);
            var bytes = Encoding.UTF8.GetBytes(param);
            string responseContent = null;
            try
            {
                using (var writer = request.GetRequestStream())
                {
                    writer.Write(bytes, 0, bytes.Length);
                }

                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
                //Elmah.ErrorLog.GetDefault(System.Web.HttpContext.Current).Log(new Elmah.Error(ex));
            }

            System.Diagnostics.Debug.WriteLine(responseContent);
        }

        private static HttpWebRequest BuildRequest()
        {
            var request = WebRequest.Create(OneSignalApiUri) as HttpWebRequest;
            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            request.Headers.Add("authorization", RestApiKey);

            return request;
        }

        #region Test
        public ActionResult SendNotificationToCuidarlos()
        {
            var push = new PushNotification
            {
                Titulo = "Testeando one signal",
                Mensaje = "hola",
                ImagenPrincipal = "https://preview-back.danzfloor.com/Archivo/ObtenerImagenPorId/dc759d1f-0e39-ba36-1447-39e6e2e7d56d",
                ImagenPequeña = "https://is2-ssl.mzstatic.com/image/thumb/Purple128/v4/6b/fb/cf/6bfbcf70-37ab-52c1-eee9-504c7d6bc8ba/source/512x512bb.jpg",
                Deeplink = "https://m.danzfloor.com/Artista/Detalle/453d64e3-11e9-c553-f331-39e6e2e7d59b",
                OneSignalId = CuidarlosSignalId
            };
            var result = SendToDevice(push);

            return Json(result ? "OK" : "ERROR", JsonRequestBehavior.AllowGet);
        }

        public ActionResult SendNotificationToAle()
        {
            var push = new PushNotification
            {
                Titulo = "No te olvides! SASHA en Buenos Aires",
                Mensaje = "Próximamente entradas en www.emtworld.com.ar",
                ImagenPrincipal = "https://preview-back.danzfloor.com/Archivo/ObtenerImagenPorId/dc759d1f-0e39-ba36-1447-39e6e2e7d56d",
                ImagenPequeña = "https://is2-ssl.mzstatic.com/image/thumb/Purple128/v4/6b/fb/cf/6bfbcf70-37ab-52c1-eee9-504c7d6bc8ba/source/512x512bb.jpg",
                Deeplink = "https://m.danzfloor.com/Artista/Detalle/453d64e3-11e9-c553-f331-39e6e2e7d59b",
                OneSignalId = CuidarlosSignalId
            };
            var result = SendToDevice(push);

            return Json(result ? "OK" : "ERROR", JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}