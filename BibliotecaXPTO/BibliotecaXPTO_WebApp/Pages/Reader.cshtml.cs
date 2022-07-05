using BibliotecaXPTO_Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BibliotecaXPTO_WebApp.Pages
{
    public class ReaderModel : PageModel
    {
        private bool isPost;
        private int prm;
        private int? readerId;
        private int bookId;
        private int libId;
        private string datainicial;
        private string datafinal;
        private string title = "";
        private string exceptionMessage = null;
        private string successMessage = null;
        private List<BibliotecaXPTO_Lib.Book> books;
        private List<Object> emprestimos;
        private List<Object> status;
        private List<Object> historico;

        public bool IsPost { get => isPost; set => isPost = value; }
        public int Prm { get => prm; set => prm = value; }
        public int? ReaderId { get => readerId; set => readerId = value; }
        public int BookId { get => bookId; set => bookId = value; }
        public int LibId { get => libId; set => libId = value; }
        public string Datainicial { get => datainicial; set => datainicial = value; }
        public string Datafinal { get => datafinal; set => datafinal = value; }
        public string Title { get => title; set => title = value; }
        public string SuccessMessage { get => successMessage; set => successMessage = value; }
        public string ExceptionMessage { get => exceptionMessage; set => exceptionMessage = value; }
        public List<Book> Books { get => books; set => books = value; }
        public List<object> Emprestimos { get => emprestimos; set => emprestimos = value; }
        public List<object> Status { get => status; set => status = value; }
        public List<object> Historico { get => historico; set => historico = value; }

        public IActionResult OnGet(int id = 0) /*Pesquisa*/
        {
            IsPost = false;
            HttpContext.Session.SetString("reader_pesquisa", "");
            ReaderId = HttpContext.Session.GetInt32("reader.Id"); //getint32 aceita 'int?'

            if (HttpContext.Session.GetInt32("reader.Id") == null) //verificar se o user está logado
            {
                return new RedirectToPageResult("Index");
            }

            if (id == 2) /*Empréstimos Ativos e Devoluções*/
            {
                Prm = id;
                Emprestimos = Operations.EmprestimosAtivos(ReaderId);
                return null;
            }
            else if (id == 3) /*Status Empréstimos*/
            {
                Prm = id;
                Status = Operations.StatusLeitor(ReaderId, LibId);
                return null;
            }
            else if (id == 4) /*Histórico Empréstimos*/
            {
                Prm = id;
                Historico = Operations.HistoricoLeitor(ReaderId, LibId, Datainicial, Datafinal);
                return null;
            }
            else if (id == 5) /*Cancelar Inscrição*/
            {
                Prm = id;
                return null;
            }
            else if (id == 6) /*Log Out*/
            {
                Prm = id;
                HttpContext.Session.Clear();
                return new RedirectToPageResult("Index");
            }
            return null;
        }

        public IActionResult OnPost()
        {
            IsPost = true;
            ReaderId = HttpContext.Session.GetInt32("reader.Id"); 
            Prm = Convert.ToInt32(Request.Form["prm_post"]);

            if (HttpContext.Session.GetInt32("reader.Id") == null) /*verificar se o user está logado*/
            {
                return new RedirectToPageResult("Index");
            }

            if (Prm == 1) /*Resultado da Pesquisa*/
            {         
                ExceptionMessage = "";
                SuccessMessage = "";

                Title = Request.Form["book-search"].ToString();
                HttpContext.Session.SetString("reader_pesquisa", Title);

                Books = Operations.PesquisaLivros(Title);

                return null;
            }
            else if (Prm == 10) /*Requisitar Livro*/
            {
                if (HttpContext.Session.GetInt32("reader.Id") == null)
                {
                    return new RedirectToPageResult("Index");
                }

                Prm = Convert.ToInt32(Request.Form["prm_post"]);
                IsPost = true;

                Title = HttpContext.Session.GetString("reader_pesquisa");

                ExceptionMessage = "";
                SuccessMessage = "";

                ReaderId = HttpContext.Session.GetInt32("reader.Id");
                BookId = Convert.ToInt32(Request.Form["book-id"]);
                LibId = Convert.ToInt32(Request.Form["library"]);

                ExceptionMessage = Operations.RequisitarLivro(ReaderId, BookId, LibId);

                if (String.IsNullOrEmpty(ExceptionMessage))
                {
                    SuccessMessage = "Livro requisitado com sucesso.";
                    books = Operations.PesquisaLivros(Title);
                }
                books = Operations.PesquisaLivros(Title);
                Prm = 1;
                return null;
            }
            else if (Prm == 2) /*Empréstimos Ativos e Devoluções*/
            {
                BookId = Convert.ToInt32(Request.Form["book-id"]);
                LibId = Convert.ToInt32(Request.Form["library"]);

                Operations.DevolverLivro(ReaderId, BookId, LibId);

                Emprestimos = Operations.EmprestimosAtivos(ReaderId);

                return null;
            }
            else if (Prm == 3) /*Status Empréstimos*/
            {
                LibId = Convert.ToInt32(Request.Form["library"]);

                Status = Operations.StatusLeitor(ReaderId, LibId);
                return null;
            }
            else if (Prm == 4) /*Histórico Empréstimos*/
            {
                LibId = Convert.ToInt32(Request.Form["library"]);
                Datainicial = Request.Form["initial-date"].ToString();
                Datafinal = Request.Form["final-date"].ToString();

                Historico = Operations.HistoricoLeitor(ReaderId, LibId, Datainicial, Datafinal);
                return null;
            }
            else if (Prm == 5) /*Cancelar Inscrição*/
            {
                Operations.CancelarConta(ReaderId);
                HttpContext.Session.Clear();
                return null;
            }
            return null;
        }
    }
}