using api.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Teste...");
            try
            {
                var usuariosDatabase = new UsuariosDatabase();

                var lista = usuariosDatabase.GetUsers();
                Console.WriteLine($"Retorno: {lista.Count}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Erro: {ex.Message}");
            }

            Console.ReadLine();
            
        }
    }
}
