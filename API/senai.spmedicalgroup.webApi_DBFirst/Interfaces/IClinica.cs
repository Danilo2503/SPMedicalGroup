using senai.spmedicalgroup.webApi_DBFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webApi_DBFirst.Interfaces
{
    interface IClinica
    {
        void create(Clinica clinica);
        List<Clinica> read();
        Clinica readId(int id);
        void update(int id, Clinica clinica);
        void delete(int id);
    }
}
