using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaXPTO_Lib;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BibliotecaXPTO_WebApp.Pages
{
    public class AdminModel : PageModel
    {
        private bool isPost;
        private int prm;
        private int? adminId;
        private int readerIdForm;
        private int? readerIdDevolver;
        private int bookId;
        private int libId;
        private string datainicial;
        private string datafinal;
        private string title = "";
        private string exceptionMessage = null;
        private string successMessage = null;
        private List<Book> books;
        private List<Object> emprestimos;
        private List<Object> status;
        private List<Object> historico;
        private int rows;
        private string name;
        private string bookISBN;
        private string bookTitle;
        private string bookAuthor;
        private string bookImg;
        private int bookCat;
        private int libId2;
        private int qtty;

        public bool IsPost { get => isPost; set => isPost = value; }
        public int Prm { get => prm; set => prm = value; }
        public int? AdminId { get => adminId; set => adminId = value; }
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
        public int ReaderIdForm { get => readerIdForm; set => readerIdForm = value; }
        public int Rows { get => rows; set => rows = value; }
        public string Name { get => name; set => name = value; }
        public string BookISBN { get => bookISBN; set => bookISBN = value; }
        public string BookTitle { get => bookTitle; set => bookTitle = value; }
        public string BookAuthor { get => bookAuthor; set => bookAuthor = value; }
        public string BookImg { get => bookImg; set => bookImg = value; }
        public int BookCat { get => bookCat; set => bookCat = value; }
        public int LibId2 { get => libId2; set => libId2 = value; }
        public int Qtty { get => qtty; set => qtty = value; }        
        public int? ReaderIdDevolver { get => readerIdDevolver; set => readerIdDevolver = value; }


        public IActionResult OnGet(int id = 0) /*Pesquisa*/
        {
            IsPost = false;
            HttpContext.Session.SetString("reader_pesquisa", "");
            HttpContext.Session.SetString("reader_devolver", "");
            AdminId = HttpContext.Session.GetInt32("reader.Id"); //getint32 aceita 'int?'
            
            if (HttpContext.Session.GetInt32("reader.Id") == null) //verificar se o user está logado
            {
                return new RedirectToPageResult("Index");
            }
            else if (HttpContext.Session.GetInt32("reader.Id") != null && HttpContext.Session.GetInt32("reader.Admin") == 0) /*verificar se o user tem permissões de admin*/
            {
                return new RedirectToPageResult("Index");
            }

            if (id == 2) /*Empréstimos Ativos e Devoluções*/
            {
                Prm = id;
                Emprestimos = Operations.EmprestimosAtivos(ReaderIdForm);
                return null;
            }
            else if (id == 3) /*Status Empréstimos*/
            {
                Prm = id;
                Status = Operations.StatusLeitor(ReaderIdForm, LibId);
                return null;
            }
            else if (id == 4) /*Histórico Empréstimos*/
            {
                Prm = id;
                Historico = Operations.HistoricoLeitor(ReaderIdForm, LibId, Datainicial, Datafinal);
                return null;
            }
            else if (id == 5) /*Cancelar Inscrição*/
            {
                Prm = id;
                SuccessMessage = "";
                return null;
            }
            else if (id == 6) /*Log Out*/
            {
                Prm = id;
                HttpContext.Session.Clear();
                return new RedirectToPageResult("Index");
            }
            else if (id == 7) /*Inserir Novas Obras*/
            {
                Prm = id;
                SuccessMessage = "";
                Operations.ListaCategorias();
                return null;
            }
            else if (id == 8)
            {
                Prm = id;
                SuccessMessage = "";
                Books = Operations.PesquisaLivros();
                return null;
            }
            else if (id == 9) /*Transferir Exemplares*/
            {
                Prm = id;
                SuccessMessage = "";
                Books = Operations.PesquisaLivros();
                return null;
            }
            else if(id == 11) /*Suspender Acesso*/
            {
                Prm = id;
                return null;
            }
            else if (id == 12) /*Reativar Acesso*/
            {
                Prm = id;
                return null;
            }
            else if (id == 13) /*Eliminar Leitor (Inatividade)*/
            {
                Prm = id;
                return null;
            }
            return null;
        }

        public IActionResult OnPostAdmin()
        {
            AdminId = HttpContext.Session.GetInt32("reader.Id");
            IsPost = true;
            Prm = Convert.ToInt32(Request.Form["prm_post"]);

            if (HttpContext.Session.GetInt32("reader.Id") == null) /*verificar se o user está logado*/
            {
                return new RedirectToPageResult("Index");
            }
            else if(HttpContext.Session.GetInt32("reader.Id") != null && HttpContext.Session.GetInt32("reader.Admin") == 0) /*verificar se o user tem permissões de admin*/
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
                Prm = Convert.ToInt32(Request.Form["prm_post"]);
                IsPost = true;

                Title = HttpContext.Session.GetString("reader_pesquisa");

                ExceptionMessage = "";
                SuccessMessage = "";

                ReaderIdForm = Convert.ToInt32(Request.Form["reader-id"]);
                BookId = Convert.ToInt32(Request.Form["book-id"]);
                LibId = Convert.ToInt32(Request.Form["library"]);

                ExceptionMessage = Operations.RequisitarLivro(ReaderIdForm, BookId, LibId);

                if (String.IsNullOrEmpty(ExceptionMessage))
                {
                    SuccessMessage = "Livro requisitado com sucesso.";
                    books = Operations.PesquisaLivros(Title);
                }
                books = Operations.PesquisaLivros(Title);
                Prm = 1;
                return null;
            }
            else if (Prm == 2) /*Empréstimos Ativos*/
            {
                ReaderIdForm = Convert.ToInt32(Request.Form["reader-id"]);                                
                HttpContext.Session.SetInt32("reader_devolver", ReaderIdForm);
                ReaderIdDevolver = HttpContext.Session.GetInt32("reader_devolver");

                Emprestimos = Operations.EmprestimosAtivos(ReaderIdDevolver);
                return null;
            }
            else if (Prm == 14) /*Devolver Livro*/
            {
                ReaderIdDevolver = HttpContext.Session.GetInt32("reader_devolver");
                BookId = Convert.ToInt32(Request.Form["book-id"]);
                LibId = Convert.ToInt32(Request.Form["library"]);

                Operations.DevolverLivro(ReaderIdDevolver, BookId, LibId);
                Emprestimos = Operations.EmprestimosAtivos(ReaderIdDevolver);
                Prm = 2;
                return null;
            }
            else if (Prm == 3) /*Status Empréstimos*/
            {
                ReaderIdForm = Convert.ToInt32(Request.Form["reader-id"]);
                LibId = Convert.ToInt32(Request.Form["library"]);

                Status = Operations.StatusLeitor(ReaderIdForm, LibId);
                return null;
            }
            else if (Prm == 4) /*Histórico Empréstimos*/
            {
                ReaderIdForm = Convert.ToInt32(Request.Form["reader-id"]);
                LibId = Convert.ToInt32(Request.Form["library"]);
                Datainicial = Request.Form["initial-date"].ToString();
                Datafinal = Request.Form["final-date"].ToString();

                Historico = Operations.HistoricoLeitor(ReaderIdForm, LibId, Datainicial, Datafinal);
                return null;
            }
            else if (Prm == 5) /*Cancelar Inscrição*/
            {
                ReaderIdForm = Convert.ToInt32(Request.Form["reader-id"]);
                Operations.CancelarConta(ReaderIdForm);
                SuccessMessage = "Inscrição cancelada com sucesso.";
                return null;
            }
            else if (Prm == 8) /*Atualizar Número de Exemplares*/
            {
                Qtty = Convert.ToInt32(Request.Form["qtty"]);
                BookId = Convert.ToInt32(Request.Form["title"]);
                LibId = Convert.ToInt32(Request.Form["library"]);

                Operations.AtualizarExemplares(Qtty, BookId, LibId);
                SuccessMessage = "Número de exemplares atualizado com sucesso.";
                Books = Operations.PesquisaLivros();
                return null;
            }
            else if (Prm == 9) /*Transferir Exemplares*/
            {
                Qtty = Convert.ToInt32(Request.Form["qtty"]);
                BookId = Convert.ToInt32(Request.Form["title"]);
                LibId = Convert.ToInt32(Request.Form["library-o"]);
                LibId2 = Convert.ToInt32(Request.Form["library-d"]);

                ExceptionMessage = Operations.TransferirExemplar(Qtty, BookId, LibId, LibId2);

                if(String.IsNullOrEmpty(ExceptionMessage))
                {
                    SuccessMessage = "Transferência de exemplares feita com sucesso.";
                }
                Books = Operations.PesquisaLivros();
            }
            else if (Prm == 11) /*Suspender Acesso*/
            {
                IsPost = true;
                Rows = Operations.SuspenderAcesso();
                return null;
            }
            else if (Prm == 12) /*Reativar Acesso*/
            {
                IsPost = true;
                ReaderIdForm = Convert.ToInt32(Request.Form["reader-id"]);
                Name = Operations.ReativarAcesso(ReaderIdForm);
                return null;
            }
            else if (Prm == 13) /*Eliminar Leitor (Inatividade)*/
            {
                IsPost = true;
                Rows = Operations.EliminarLeitor();
                return null;
            }
            return null;
        }

        public async Task OnPostAsync() /*Inserir Novas Obras*/
        {
            Prm = Convert.ToInt32(Request.Form["prm_post"]);

            var file = Path.Combine(_environment.ContentRootPath, "uploads", Upload.FileName);

            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Upload.CopyToAsync(fileStream);
            }

            BookISBN = (Request.Form["isbn"]).ToString();
            BookTitle = (Request.Form["title"]).ToString();
            BookAuthor = (Request.Form["author"]).ToString();
            BookImg = file;
            BookCat = Convert.ToInt32(Request.Form["category"]);

            Operations.AdicionarObra(BookISBN, BookTitle, BookAuthor, BookImg, BookCat);
            System.IO.File.Delete(file);
            SuccessMessage = "Livro inserido com sucesso.";
            Operations.ListaCategorias();
        }

        /*Image Upload Handling*/
        private IHostingEnvironment _environment; 
        public AdminModel(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        [BindProperty]
        public IFormFile Upload { get; set; }        
    }
}    