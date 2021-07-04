using ProjetoBase.Model;
using System.Collections.Generic;


namespace ProjetoBase.Service.Interfaces
{
    public interface IUsuarioService 
    {
        List<Usuario> GetUsuarios();

        void AddUsuario(Usuario usuario);

        void UpdateUsuario(Usuario usuario);

        void DeleteUsuario(Usuario usuario);

    }
}
