using Core.Dominio.Token;
using System.Collections.Generic;

namespace Core.Dominio.Entidade
{
    public static class Autenticacao
    {
        private static string Usuario { get; set; }
        private static string Senha { get; set; }

        public static object geraToken()
        {
            string Token = new JwtTokenBuilder()
                                .AddSecurityKey(JwtSecurityKey.Create("a-password-very-big-to-be-good"))
                                .AddSubject("laudson teodoro")
                                .AddIssuer("laudson.com.br")
                                .AddAudience("laudson.com.br")
                                .AddNameId("laudson.junior@gmail.com")
                                .AddClaim("employeer", "31")
                                .AddExpiry(1)
                                .Build();

            var dict = new Dictionary<string, string>
            {
                {"Token", Token},
            };

            return dict;
        }
    }
}