using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaXPTO_Lib
{
    public class Reader
    {
        private int id;
        private string firstName;
        private string lastName;
        private string email;
        private int status;
        private int admin;

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public int Status { get => status; set => status = value; }
        public int Admin { get => admin; set => admin = value; }
    }
}
