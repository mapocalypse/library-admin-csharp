using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaXPTO_Lib
{
    public class Book
    {
        private int id;
        private string isbn;
        private string title;
        private string author;
        private byte[] img;

        public int Id { get => id; set => id = value; }
        public string Isbn { get => isbn; set => isbn = value; }
        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public byte[] Img { get => img; set => img = value; }

    }
}
