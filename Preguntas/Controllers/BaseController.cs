using Preguntas.Models;
using System;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Preguntas.Controllers
{
    public class BaseController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        public string Contenido
        { get =>
            System.Web.HttpContext.Current.Request.HttpMethod == "POST" ?
            System.Web.HttpContext.Current.Request.Form["contenido"] : System.Web.HttpContext.Current.Request.QueryString["contenido"];
        }

        public string usuarioId
        {
            get
            {
                var usuarioRecibido = System.Web.HttpContext.Current.Request.HttpMethod == "POST" ?
                System.Web.HttpContext.Current.Request.Form["UsuarioId"] : System.Web.HttpContext.Current.Request.QueryString["UsuarioId"];
                if (String.IsNullOrWhiteSpace(usuarioRecibido))
                {
                    return null;
                }
                else
                {
                    return usuarioRecibido;
                }
            }
            set
            {

            }
        }
        public string tokenId
        {
            get
            {
                var tokenRecibido = System.Web.HttpContext.Current.Request.HttpMethod == "POST" ?
                System.Web.HttpContext.Current.Request.Form["Token"] : System.Web.HttpContext.Current.Request.QueryString["Token"];
                if (String.IsNullOrWhiteSpace(tokenRecibido))
                {
                    return null;
                }
                else
                {
                    return tokenRecibido;
                }
            }
        }
        public string version
        {
            get
            {
                var versionRecibida = System.Web.HttpContext.Current.Request.Form["version"];
                if (String.IsNullOrWhiteSpace(versionRecibida))
                {
                    return null;
                }
                else
                {
                    return versionRecibida;
                }
            }
        }

        public BaseController()
       {
            var logueado = !String.IsNullOrWhiteSpace(usuarioId);

            if (logueado)
            {
                var usuarioData = db.Usuarios.Where(x => x.UsuarioApp.Id.ToString().ToLower() == usuarioId.ToLower()).FirstOrDefault();
                if (usuarioId != null)
                {
                    if (usuarioData.Token == tokenId)
                    {
                        string[] roles = { "Suscriptor" };

                        FormsAuthentication.SetAuthCookie(usuarioData.UsuarioApp.UserName, true);
                        HttpCookie decryptedCookie = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

                        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(decryptedCookie.Value);

                        var identity = new GenericIdentity(ticket.Name);
                        var principal = new GenericPrincipal(identity, roles);

                        System.Web.HttpContext.Current.User = principal;
                        Thread.CurrentPrincipal = System.Web.HttpContext.Current.User;
                    }
                    else
                    {
                        System.Web.HttpContext.Current.Response.StatusCode = (int)HttpStatusCode.Unauthorized; //Token invalido
                    }
                }
                else
                {
                    System.Web.HttpContext.Current.Response.StatusCode = (int)HttpStatusCode.Forbidden; //Usuario invalido
                }
            }
        }
    }
}