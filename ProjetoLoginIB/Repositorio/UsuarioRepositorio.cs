using MySql.Data.MySqlClient;
using ProjetoLoginIB.interfaces;
using ProjetoLoginIB.Models;
using Org.BouncyCastle.Crypto.Generators;
using System.Security.Cryptography;
using BCrypt.Net;


namespace ProjetoLoginIB.Repositorio
{
    public class UsuarioRepositorio:IUsuarioRepositorio
    {
        private readonly string _connectionString;

        public UsuarioRepositorio(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Conexao");
        }
        public LoginViewModel Validar(string email, string senha)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            var sql = "SELECT * FROM tb_Usuario WHERE Email =@email";
            var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@email", email);

            using var reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                string senhaBanco = reader["Senha"].ToString()!;
                if(BCrypt.Net.BCrypt.Verify(senha,senhaBanco))
                {
                    return new LoginViewModel
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nome = reader["Nome"].ToString()!,
                        Email = reader["Email"].ToString()!,
                        Nivel = reader["Nivel"].ToString()!
                    };
                }
            }
        }
    }
}
