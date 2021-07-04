using ProjetoBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBase.Data.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> GetAllUsuario();

        void AddUsuario(Usuario usuario);

        void UpdateUsuario(Usuario usuario);

        void DeleteUsuario(Usuario usuario);

    }
}
