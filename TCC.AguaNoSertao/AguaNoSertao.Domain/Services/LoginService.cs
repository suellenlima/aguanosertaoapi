using AguaNoSertao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AguaNoSertao.Domain.Services
{
    public class LoginService
    {


        public void ValidarLogin(Login login)
        {
            if (login == null)
                throw new ArgumentNullException("É necessário informar email e senha.");

            if (string.IsNullOrEmpty(login.Email))
                throw new ArgumentException("É necessário informar o email.");

            if (string.IsNullOrEmpty(login.Senha))
                throw new ArgumentException("É necessário informar a senha.");
        }
    }
}
