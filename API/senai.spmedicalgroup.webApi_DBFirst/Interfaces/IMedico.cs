using senai.spmedicalgroup.webApi_DBFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webApi_DBFirst.Interfaces
{
    interface IMedico
    {
        void create(Medico medico);
        List<Medico> read();
        Medico readId(int id);
        void update(int id, Medico medico);
        void delete(int id);
    }
}
