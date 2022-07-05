using BibliotecaXPTO_Lib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaXPTO_WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private bool isPost;
        private int prm;
        private string fname;
        private string lname;
        private string email;
        private string psw;
        private string pswRepeat;
        private int lib;
        private string exceptionMessage = null;
        private string successMessage = null;

        private Dictionary<string, Object> _prmBag = new Dictionary<string, Object>();
            
        public bool IsPost { get => isPost; set => isPost = value; }
        public int Prm { get => prm; set => prm = value; }
        public string Fname { get => fname; set => fname = value; }
        public string Lname { get => lname; set => lname = value; }
        public string Email { get => email; set => email = value; }
        public string Psw { get => psw; set => psw = value; }
        public string PswRepeat { get => pswRepeat; set => pswRepeat = value; }
        public int Lib { get => lib; set => lib = value; }
        public string ExceptionMessage { get => exceptionMessage; set => exceptionMessage = value; }
        public string SuccessMessage { get => successMessage; set => successMessage = value; }

        public void OnGet(int prm = 0)
        {
            IsPost = false;
            Prm = prm;
            ExceptionMessage = "";
            SuccessMessage = "";
        }

        public void OnPostRegister()
        {
            Prm = Convert.ToInt32(Request.Form["prm_post"]);
            Fname = Request.Form["fname"].ToString();
            Lname = Request.Form["lname"].ToString();
            Email = Request.Form["email-register"].ToString();
            Psw = Request.Form["psw-register"].ToString();
            PswRepeat = Request.Form["psw-repeat"].ToString();
            Lib = Convert.ToInt32(Request.Form["library"]);
            
            if (Psw != PswRepeat)
            {
                ExceptionMessage = "As palavras-passe não coincidem.";
            }
            else
            {
                ExceptionMessage = Operations.VerificarEmail(Email);

                if (String.IsNullOrEmpty(ExceptionMessage))
                {
                    Operations.Register(Fname, Lname, Email, Psw, Lib);
                    SuccessMessage = "Registo feito com sucesso. ";
                }
            }
        }

        public IActionResult OnPostLogin()
        {
            Prm = Convert.ToInt32(Request.Form["prm_post"]);
            Email = Request.Form["email-login"].ToString();
            Psw = Request.Form["psw-login"].ToString();

            Dictionary<string, Object> utilizador = Operations.Login(Email, Psw);

            if (utilizador.Count == 0) {
                ExceptionMessage = "Palavra-passe ou email incorretos. Por favor, verifique as suas credenciais de acesso.";
                return null;
            }

            foreach (KeyValuePair<string, Object> entry in utilizador)
            {
                if(entry.Value is String)
                    HttpContext.Session.SetString(entry.Key, entry.Value.ToString());
                else
                    HttpContext.Session.SetInt32(entry.Key, Convert.ToInt32(entry.Value));

                setPrmBag(entry.Key, entry.Value);
            }

            if (Convert.ToInt32(getPrmBag("reader.Admin")) == 1)
            {
                return new RedirectToPageResult("Admin");
            }
            else
            {
                return new RedirectToPageResult("Reader");
            }
        }

        public Object getPrmBag(string k)
        {
            if (_prmBag.ContainsKey(k))
            {
                return _prmBag[k];
            }
            else
            {
                return "";
            }
        }

        public void setPrmBag(string k, Object v)
        {
            if (_prmBag.ContainsKey(k))
            {
                _prmBag[k] = v;
            }
            else
            {
                _prmBag.Add(k, v);
            }
        }
    }
}