using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var conexao = 
                new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Alunos\Documents\BancoTeste.mdf;Integrated Security=True;Connect Timeout=30");

            conexao.Open();

            if (conexao.State == ConnectionState.Open)
            {
                Console.WriteLine("Conexão OK");

                var sql = "insert into Aluno(Nome,Email) values (@nome, @email)";
                var comando = new SqlCommand(sql, conexao);
                comando.Parameters.AddWithValue("@nome", "Asdrubal");
                comando.Parameters.AddWithValue("@email", "asdru@teste.com");
                var retorno = comando.ExecuteNonQuery();
                if (retorno > 0)
                {
                    Console.WriteLine("Inserção OK");
                }
            }
            else
            {
                Console.WriteLine("Sem conexão com o BD");
            }

            Console.ReadKey();
        }
    }
}
