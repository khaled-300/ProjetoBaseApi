using Microsoft.Extensions.Logging;
using ProjetoBase.Data.Interfaces;
using ProjetoBase.Model;
using ProjetoBase.Service.Interfaces;
using System;
using System.Collections.Generic;


namespace ProjetoBase.Service
{
    public class UsuarioService : IUsuarioService
    {
        public IUsuarioRepository UsuarioRepository;

        private readonly ILogger _logger;

        public UsuarioService(ILogger<UsuarioService> logger, IUsuarioRepository usuarioRepository)
        {
            UsuarioRepository = usuarioRepository;
            _logger = logger;
        }

        public List<Usuario> GetUsuarios()
        {
            try
            {
                return UsuarioRepository.GetAllUsuario();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error ao buscar dos usuarios!", ex);
                throw;
            }

        }

        public void AddUsuario(Usuario usuario)
        {
            try
            {
                UsuarioRepository.AddUsuario(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error em add novo usuario!", ex);
                throw;
            }

        }

        public void UpdateUsuario(Usuario usuario)
        {
            try
            {
                UsuarioRepository.UpdateUsuario(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error em atualizar dados do usuario!", ex);
                throw;
            }

        }


        public void DeleteUsuario(Usuario usuario)
        {
            try
            {
                UsuarioRepository.DeleteUsuario(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error em deletar dados do usuario!", ex);
                throw;
            }

        }

    }
}
