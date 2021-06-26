using senai.spmedicalgroup.webApi_DBFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webApi_DBFirst.Interfaces
{
    interface IConsulta
    {
        void create(Consulta consultum);
        List<Consulta> read();
        Consulta readId(int id);
        void update(int id, Consulta consultum);
        void delete(int id);
    }
}
