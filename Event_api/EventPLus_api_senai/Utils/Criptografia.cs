using System.Globalization;

namespace api_filmes_senai.Utils
{
    //Classe istatica = não precisa ser instanciada para usar seus recursos, basta chamar a classe e o metodo
    public static class Criptografia
    {
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public static bool CompararHash(string senhaInformada, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaInformada, senhaBanco);
        } //retorna true ou false por causa do bool(Buuu👻)
    }
}
