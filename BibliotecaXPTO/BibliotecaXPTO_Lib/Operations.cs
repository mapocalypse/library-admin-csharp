using LibBD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace BibliotecaXPTO_Lib
{
    public class Operations
    {
        private static string exceptionMessageRegister;
        public static string ExceptionMessageRegister { get => exceptionMessageRegister; set => exceptionMessageRegister = value; }

        public static List<Nucleo> ListaNucleos()
        {
            SqlConnection cn = BD.OpenBD(LibUtils.Core.GetAppKey("ConnectionStrings", "ConnectionBibliotecaXPTO").ToString());
            DataTable _dtNucleos = BD.GetDTForSQL(ref cn, "SELECT * FROM libraries ORDER BY lib_city");

            List<Nucleo> nucleos = new List<Nucleo>();

            foreach (DataRow dr in _dtNucleos.Rows)
            {
                Nucleo nucleo = new Nucleo();

                nucleo.Id = Convert.ToInt32(dr["lib_id"]);
                nucleo.City = dr["lib_city"].ToString();

                nucleos.Add(nucleo);
            }

            cn.Dispose();
            cn.Close();

            return nucleos;
        }

        public static string VerificarEmail(string email)
        {
            SqlConnection cn = BD.OpenBD(LibUtils.Core.GetAppKey("ConnectionStrings", "ConnectionBibliotecaXPTO").ToString());

            SqlDataReader dr = BD.LerQuery(cn, "SELECT reader_email FROM readers WHERE reader_email = '" + email + "'");

            if (dr.HasRows)
            {
                ExceptionMessageRegister = "E-mail já registado. Use um e-mail diferente para se registar ou inicie sessão na conta existente.";
                ListaNucleos();

                dr.Close();
            }

            cn.Dispose();
            cn.Close();

            return ExceptionMessageRegister;
        }

        public static void Register(string fname, string lname, string email, string psw, int lib)
        {
            SqlConnection cn = BD.OpenBD(LibUtils.Core.GetAppKey("ConnectionStrings", "ConnectionBibliotecaXPTO").ToString());

            List<String> lstP = new List<String>() { "@Nome", "@Apelido", "@Email", "@Senha", "@Nucleo" };
            List<Object> lstV = new List<Object>() { fname, lname, email, psw, lib };
            SqlCommand command = null;

            BD.SPExecute(cn, "08_Registar_Leitor", lstP, lstV, ref command);

            command.ExecuteNonQuery();

            cn.Dispose();
            cn.Close();
        }

        public static Dictionary<string, Object> Login(string email, string psw)
        {
            Dictionary<string, Object> user = new Dictionary<string, Object>();

            SqlConnection cn = BD.OpenBD(LibUtils.Core.GetAppKey("ConnectionStrings", "ConnectionBibliotecaXPTO").ToString());
            SqlDataReader dr = BD.LerQuery(cn, "SELECT * FROM readers WHERE reader_email = '" + email + "' AND reader_pass = '" + psw + "'");

            dr.Read();

            if (dr.HasRows)
            {
                //guardar dados do user na variável de sessão

                user.Add("reader.Id", Convert.ToInt32(dr.GetValue(dr.GetOrdinal("reader_id"))));
                user.Add("reader.FirstName", (dr.GetValue(dr.GetOrdinal("reader_fname"))).ToString());
                user.Add("reader.LastName", (dr.GetValue(dr.GetOrdinal("reader_lname"))).ToString());
                user.Add("reader.Email", (dr.GetValue(dr.GetOrdinal("reader_email"))).ToString());
                user.Add("reader.Status", Convert.ToInt32(dr.GetValue(dr.GetOrdinal("reader_status"))));
                user.Add("reader.Admin", Convert.ToInt32(dr.GetValue(dr.GetOrdinal("admin"))));

                dr.Close();
            }

            cn.Dispose();
            cn.Close();

            return user;
        }

        public static List<Book> PesquisaLivros(string title="")
        {
            SqlConnection cn = BD.OpenBD(LibUtils.Core.GetAppKey("ConnectionStrings", "ConnectionBibliotecaXPTO").ToString());

            List<String> lstP = new List<String>() { "@Titulo" };
            List<Object> lstV = new List<Object>() { title };

            DataTable _dtLivros = BD.GetDTForSP(ref cn, "21_Pesquisar_Obras_Titulo", lstP, lstV);

            List<Book> books = new List<Book>();

            foreach (DataRow dr in _dtLivros.Rows)
            {
                Book book = new Book();

                book.Id = Convert.ToInt32(dr["book_id"]);
                book.Isbn = dr["book_ISBN"].ToString();
                book.Title = dr["book_title"].ToString();
                book.Author = dr["book_author"].ToString();
                book.Img = dr["book_img"] as byte[];

                books.Add(book);
            }

            cn.Dispose();
            cn.Close();

            return books;
        }

        public static List<Nucleo> ListaNucleosLivro(int bookId)
        {
            SqlConnection cn = BD.OpenBD(LibUtils.Core.GetAppKey("ConnectionStrings", "ConnectionBibliotecaXPTO").ToString());
            DataTable _dtNucleos = BD.GetDTForSQL(ref cn, "SELECT libraries.lib_id, libraries.lib_city FROM libraries INNER JOIN book_lib ON libraries.lib_id = book_lib.lib_id AND book_lib.book_id =" + bookId + "ORDER BY lib_city");

            List<Nucleo> nucleos = new List<Nucleo>();

            foreach (DataRow dr in _dtNucleos.Rows)
            {
                Nucleo nucleo = new Nucleo();

                nucleo.Id = Convert.ToInt32(dr["lib_id"]);
                nucleo.City = dr["lib_city"].ToString();

                nucleos.Add(nucleo);
            }

            cn.Dispose();
            cn.Close();

            return nucleos;
        }

        public static List<Nucleo> ListaNucleosLeitor(int? readerId)
        {
            SqlConnection cn = BD.OpenBD(LibUtils.Core.GetAppKey("ConnectionStrings", "ConnectionBibliotecaXPTO").ToString());
            DataTable _dtNucleos = BD.GetDTForSQL(ref cn, "SELECT libraries.lib_id, libraries.lib_city FROM libraries INNER JOIN reader_lib ON libraries.lib_id = reader_lib.lib_id AND reader_id =" + readerId + "ORDER BY lib_city");

            List<Nucleo> nucleos = new List<Nucleo>();

            foreach (DataRow dr in _dtNucleos.Rows)
            {
                Nucleo nucleo = new Nucleo();

                nucleo.Id = Convert.ToInt32(dr["lib_id"]);
                nucleo.City = dr["lib_city"].ToString();

                nucleos.Add(nucleo);
            }

            cn.Dispose();
            cn.Close();

            return nucleos;
        }

        public static List<Object> StatusLeitor(int? readerId, int libId)
        {
            SqlConnection cn = BD.OpenBD(LibUtils.Core.GetAppKey("ConnectionStrings", "ConnectionBibliotecaXPTO").ToString());

            List<String> lstP = new List<String>() { "@IDLeitor", "@IDNucleo" };
            List<Object> lstV = new List<Object>() { readerId, libId };

            List<Object> status = BD.SPExecute(cn, "14_Verificar_Situacao_Devolucao", lstP, lstV);

            cn.Dispose();
            cn.Close();

            return status;
        }

        public static List<Object> HistoricoLeitor(int? readerId, int libId = -1, string dataInicial = null, string dataFinal = null)
        {
            Object paramDataInicial;
            Object paramDataFinal;

            if (String.IsNullOrEmpty(dataInicial))
                paramDataInicial = DBNull.Value;
            else
                paramDataInicial = dataInicial;

            if (String.IsNullOrEmpty(dataFinal))
                paramDataFinal = DBNull.Value;
            else
                paramDataFinal = dataInicial;

            SqlConnection cn = BD.OpenBD(LibUtils.Core.GetAppKey("ConnectionStrings", "ConnectionBibliotecaXPTO").ToString());

            List<String> lstP = new List<String>() { "@IDLeitor", "@IDNucleo", "@DataInicial", "@DataFinal" };
            List<Object> lstV;

            if (libId == -1)
                lstV = new List<Object>() { readerId, DBNull.Value, paramDataInicial, paramDataFinal };
            else
                lstV = new List<Object>() { readerId, libId, paramDataInicial, paramDataFinal };

            List<Object> status = BD.SPExecute(cn, "15_Pesquisar_Histórico", lstP, lstV);

            cn.Dispose();
            cn.Close();

            return status;
        }      

        public static string RequisitarLivro(int? readerId, int bookId, int libId)
        {
            string returnException = String.Empty;
            SqlConnection cn = BD.OpenBD(LibUtils.Core.GetAppKey("ConnectionStrings", "ConnectionBibliotecaXPTO").ToString());

            List<String> lstP = new List<String>() { "@IDLeitor", "@IDLivro", "@IDNucleo" };
            List<Object> lstV = new List<Object>() { readerId, bookId, libId };
            SqlCommand command = null;

            BD.SPExecute(cn, "16_Requisitar_Livro", lstP, lstV, ref command);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                returnException = ex.Message;               
            }

            cn.Dispose();
            cn.Close();

            return returnException;
        }

        public static List<Object> EmprestimosAtivos(int? readerId)
        {
            SqlConnection cn = BD.OpenBD(LibUtils.Core.GetAppKey("ConnectionStrings", "ConnectionBibliotecaXPTO").ToString());

            List<Object> emprestimos = BD.ToList(cn, "SELECT * FROM Emprestimos_Ativos WHERE reader_id =" + readerId);

            cn.Dispose();
            cn.Close();

            return emprestimos;
        }

        public static void DevolverLivro(int? readerId, int bookId, int libId)
        {
            SqlConnection cn = BD.OpenBD(LibUtils.Core.GetAppKey("ConnectionStrings", "ConnectionBibliotecaXPTO").ToString());

            List<String> lstP = new List<String>() { "@IDLeitor", "@IDLivro", "@IDNucleo" };
            List<Object> lstV = new List<Object>() { readerId, bookId, libId };
            SqlCommand command = null;

            BD.SPExecute(cn, "17_Devolver_Livro", lstP, lstV, ref command);

            command.ExecuteNonQuery();
        }

        public static void CancelarConta(int? readerId)
        {
            SqlConnection cn = BD.OpenBD(LibUtils.Core.GetAppKey("ConnectionStrings", "ConnectionBibliotecaXPTO").ToString());

            List<Object> ListaDevolucoes = BD.ToList(cn, "SELECT * FROM Emprestimos_Ativos WHERE reader_id =" + readerId);

            foreach (Object emprestimo in ListaDevolucoes)
            {
                int bookId = Convert.ToInt32((emprestimo as List<Object>)[2]);
                int libId = Convert.ToInt32((emprestimo as List<Object>)[3]);

                DevolverLivro(readerId, bookId, libId);
            }

            BD.LerQuery(cn, "DELETE FROM readers WHERE reader_id =" + readerId);

            cn.Dispose();
            cn.Close();
        }

        public static List<Object> ListaCategorias()
        {
            SqlConnection cn = BD.OpenBD(LibUtils.Core.GetAppKey("ConnectionStrings", "ConnectionBibliotecaXPTO").ToString());
            List<Object> Categorias = BD.ToList(cn, "SELECT * FROM categories ORDER BY cat_name"); //obtido no momento em que é preciso (dinamicamente)

            cn.Dispose();
            cn.Close();

            return Categorias;
        }

        public static void AdicionarObra(string bookISBN, string bookTitle, string bookAuthor, string bookImg, int bookCat) 
        {
            SqlConnection cn = BD.OpenBD(LibUtils.Core.GetAppKey("ConnectionStrings", "ConnectionBibliotecaXPTO").ToString());

            List<String> lstP = new List<String>() { "@book_ISBN", "@book_title", "@book_author", "@book_img", "@book_cat" };
            List<Object> lstV = new List<Object>() { bookISBN, bookTitle, bookAuthor, bookImg, bookCat };
            SqlCommand command = null;

            BD.SPExecute(cn, "05_Adicionar_Obra", lstP, lstV, ref command);

            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
            }
            cn.Dispose();
            cn.Close();
        }

        public static void AtualizarExemplares(int qtty, int bookId, int libId)
        {
            SqlConnection cn = BD.OpenBD(LibUtils.Core.GetAppKey("ConnectionStrings", "ConnectionBibliotecaXPTO").ToString());

            List<String> lstP = new List<String>() { "@Qtdade", "@Obra", "@NucleoDestino" };
            List<Object> lstV = new List<Object>() { qtty, bookId, libId };
            SqlCommand command = null;

            BD.SPExecute(cn, "18_Distribuir_Livro_Nucleo", lstP, lstV, ref command);

            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
            }
            cn.Dispose();
            cn.Close();
        }

        public static string TransferirExemplar(int qtty, int bookId, int libId, int libId2)
        {
            string returnException = String.Empty;

            SqlConnection cn = BD.OpenBD(LibUtils.Core.GetAppKey("ConnectionStrings", "ConnectionBibliotecaXPTO").ToString());

            List<String> lstP = new List<String>() { "@QtdadeTransferencia", "@Obra", "@NucleoOrigem", "@NucleoDestino" };
            List<Object> lstV = new List<Object>() { qtty, bookId, libId, libId2 };
            SqlCommand command = null;

            BD.SPExecute(cn, "07_Transferir_Exemplar", lstP, lstV, ref command);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                returnException = ex.Message;
            }
            cn.Dispose();
            cn.Close();

            return returnException;
        }
        
        public static int SuspenderAcesso()
        {
            SqlConnection cn = BD.OpenBD(LibUtils.Core.GetAppKey("ConnectionStrings", "ConnectionBibliotecaXPTO").ToString());

            List<String> lstP = new List<String>() { };
            List<Object> lstV = new List<Object>() { };
            List<String> lstO = new List<String>() { "@cnt" };
            SqlCommand command = null;

            BD.SPExecuteOut(cn, "09_Suspender_Acesso_Devolucoes_Atrasadas", lstP, lstV, lstO, ref command);

            command.ExecuteNonQuery();

            int rows = Convert.ToInt32(command.Parameters["@cnt"].Value);

            cn.Dispose();
            cn.Close();

            return rows;
        }

        public static string ReativarAcesso(int? readerId)
        {
            SqlConnection cn = BD.OpenBD(LibUtils.Core.GetAppKey("ConnectionStrings", "ConnectionBibliotecaXPTO").ToString());

            List<String> lstP = new List<String>() { "@IDLeitor" };
            List<Object> lstV = new List<Object>() { readerId };
            List<String> lstO = new List<String>() { "@NomeLeitor" };
            SqlCommand command = null;

            BD.SPExecuteOut(cn, "10_Reativar_Acesso", lstP, lstV, lstO, ref command);

            command.ExecuteNonQuery();

            string name = command.Parameters["@NomeLeitor"].Value.ToString();

            cn.Dispose();
            cn.Close();

            return name;
        }

        public static int EliminarLeitor()
        {
            SqlConnection cn = BD.OpenBD(LibUtils.Core.GetAppKey("ConnectionStrings", "ConnectionBibliotecaXPTO").ToString());

            List<String> lstP = new List<String>() { };
            List<Object> lstV = new List<Object>() { };
            List<String> lstO = new List<String>() { "@cnt" };
            SqlCommand command = null;

            BD.SPExecuteOut(cn, "11_Eliminar_Leitor_Um_Ano", lstP, lstV, lstO, ref command);

            command.ExecuteNonQuery();

            int rows = Convert.ToInt32(command.Parameters["@cnt"].Value);

            cn.Dispose();
            cn.Close();

            return rows;
        }
    }    
}


