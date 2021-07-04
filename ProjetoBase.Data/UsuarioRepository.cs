using ProjetoBase.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PetaPoco;
using ProjetoBase.Data.Interfaces;

namespace ProjetoBase.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ILogger<UsuarioRepository> _logger;
        private string _connectionString;
        public UsuarioRepository(IConfiguration iconfiguration, ILogger<UsuarioRepository> logger)
        {
            _connectionString = iconfiguration.GetConnectionString("ProjetoBaseLocal");
            _logger = logger;
        }
        public IDatabase Connection
        {
            get
            {
                return new Database(_connectionString, SqlClientFactory.Instance);
            }
        }



        public List<Usuario> GetAllUsuario()
        {
            var listUsuariosModel = new List<Usuario>();
            try
            {


                using (IDatabase Db = Connection)
                {

                    listUsuariosModel = Db.Fetch<Usuario>(@"SELECT  Id
                                                                        , Nome
                                                                        , Email
                                                                        , Senha
                                                                        , Perfis
                                                                        , Ativo
                                                                        , DataCadastro
                                                                FROM Usuario");

                }

            }
            catch (SqlException ex)
            {
                _logger.LogError("Error em conectar ao banco do dados!, GetUsuario()", ex);
                throw;
            }

            return listUsuariosModel;
        }

        public void AddUsuario(Usuario usuario)
        {
            try
            {
                using (IDatabase Db = Connection)
                {
                    Db.Insert("Usuario", usuario);
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError("Error ao tentar inserir novo usuario!, AddUsuario()", ex);
                throw;
            }
        }

        public void UpdateUsuario(Usuario usuario)
        {
            try
            {
                using (IDatabase Db = Connection)
                {
                    Db.Update("Usuario","Id", usuario);
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError("Error ao tentar inserir novo usuario!, AddUsuario()", ex);
                throw;
            }
        }

        public void DeleteUsuario(Usuario usuario)
        {
            try
            {
                using (IDatabase Db = Connection)
                {
                    Db.Delete("Usuario", "Id", usuario);
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError("Error ao tentar inserir novo usuario!, AddUsuario()", ex);
                throw;
            }
        }

    }



}

