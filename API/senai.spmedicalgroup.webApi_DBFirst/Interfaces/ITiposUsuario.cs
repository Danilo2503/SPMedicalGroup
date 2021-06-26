using senai.spmedicalgroup.webApi_DBFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webApi_DBFirst.Interfaces
{
    interface ITiposUsuario
    {
        void create(TiposUsuario tipoDeUsuario);
        List<TiposUsuario> read();
        TiposUsuario readId(int id);
        void update(int id, TiposUsuario tipoDeUsuario);
        void delete(int id)
    }
}
