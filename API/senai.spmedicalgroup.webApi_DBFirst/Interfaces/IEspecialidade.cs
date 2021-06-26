using senai.spmedicalgroup.webApi_DBFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webApi_DBFirst.Interfaces
{
    interface IEspecialidade
    {
        void create(Especialidade especialidade);
        List<Especialidade> read();
        Especialidade readId(int id);
        void update(int id, Especialidade especialidade);
        void delete(int id);
    }
}
