using senai.spmedicalgroup.webApi_DBFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webApi_DBFirst.Interfaces
{
    interface IUsuario
    {
        void create(Usuario usuario);
        List<Usuario> read();
        Usuario readId(int id);
        void update(int id, Usuario usuario);
        void delete(int id);
    }
}
