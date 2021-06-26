using senai.spmedicalgroup.webApi_DBFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webApi_DBFirst.Interfaces
{
    interface IPaciente
    {
        void create(Paciente paciente);
        List<Paciente> read();
        Paciente readId(int id);
        void update(int id, Paciente paciente);
        void delete(int id);
    }
}
