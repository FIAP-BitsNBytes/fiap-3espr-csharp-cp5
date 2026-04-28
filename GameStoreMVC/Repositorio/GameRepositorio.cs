using GameStoreMVC.Interfaces;

using GameStoreMVC.Interfaces;
using GameStoreMVC.Models;

namespace GameStoreMVC.Repositorio
{
    public class GameRepositorio : IGameRepositorio
    {
        private readonly string _connectionString;

        public GameRepositorio(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Conexao")!;
        }

        public IEnumerable<Game> ObterTodos()
        {
            var games = new List<Game>();
            using (var conn = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                conn.Open();
                var sql = "SELECT * FROM Games ORDER BY Nome";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        games.Add(new Game
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nome = reader["Nome"].ToString()!,
                            Genero = reader["Genero"].ToString()!,
                            Preco = Convert.ToDecimal(reader["Preco"]),
                            DataLancamento = Convert.ToDateTime(reader["DataLancamento"])
                        });
                    }
                }
            }
            return games;
        }

        public Game? ObterPorId(int id)
        {
            using (var conn = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                conn.Open();
                var sql = "SELECT * FROM Games WHERE Id = @id";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Game
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nome = reader["Nome"].ToString()!,
                                Genero = reader["Genero"].ToString()!,
                                Preco = Convert.ToDecimal(reader["Preco"]),
                                DataLancamento = Convert.ToDateTime(reader["DataLancamento"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void Adicionar(Game game)
        {
            using (var conn = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                conn.Open();
                var sql = "INSERT INTO Games (Nome, Genero, Preco, DataLancamento) VALUES (@nome, @genero, @preco, @dataLancamento)";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", game.Nome);
                    cmd.Parameters.AddWithValue("@genero", game.Genero);
                    cmd.Parameters.AddWithValue("@preco", game.Preco);
                    cmd.Parameters.AddWithValue("@dataLancamento", game.DataLancamento);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(Game game)
        {
            using (var conn = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                conn.Open();
                var sql = "UPDATE Games SET Nome = @nome, Genero = @genero, Preco = @preco, DataLancamento = @dataLancamento WHERE Id = @id";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", game.Id);
                    cmd.Parameters.AddWithValue("@nome", game.Nome);
                    cmd.Parameters.AddWithValue("@genero", game.Genero);
                    cmd.Parameters.AddWithValue("@preco", game.Preco);
                    cmd.Parameters.AddWithValue("@dataLancamento", game.DataLancamento);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Remover(int id)
        {
            using (var conn = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                conn.Open();
                var sql = "DELETE FROM Games WHERE Id = @id";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
