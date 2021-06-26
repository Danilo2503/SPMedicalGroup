using senai.spmedicalgroup.webApi_DBFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webApi_DBFirst.Interfaces
{
    interface ISituacao
    {
        void create(Situacao situacao);
        List<Situacao> read();
        Situacao readId(int id);
        void update(int id, Situacao situacao);
        void delete(int id);
    }
}
