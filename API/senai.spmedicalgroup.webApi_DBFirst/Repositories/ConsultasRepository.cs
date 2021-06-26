using Microsoft.EntityFrameworkCore;
using senai.spmedicalgroup.webApi_DBFirst.Contexts;
using senai.spmedicalgroup.webApi_DBFirst.Domains;
using senai.spmedicalgroup.webApi_DBFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webApi_DBFirst.Repositories
{
    public class ConsultasRepository : IConsulta
    {
        // Usuario, TipoDeUsuario, Clinica e Consulta
        SPMed _context = new SPMed();
        public void create(Consulta consultum)
        {
            _context.Consultas.Add(consultum);
        }
        public void delete(int id)
        {
            Consulta consultabuscada = _context.Consultas.Find(id);
            _context.Consultas.Remove(consultabuscada);
            _context.SaveChanges();
        }
        public void update(int id, Consulta consultum)
        {
            Consulta consultaBuscada = _context.Consultas.Find(id);
            consultaBuscada.DataConsulta = consultum.DataConsulta;

            _context.Consultas.Update(consultaBuscada);
            _context.SaveChanges();
        }

        List<Consulta> IConsulta.read()
        {
            return _context.Consultas.Include(x => x.IdMedicoNavigation).Include(y => y.IdPacienteNavigation).Include(z => z.IdSituacaoNavigation).ToList();
        }

        Consulta IConsulta.readId(int id)
        {
            return _context.Consultas.FirstOrDefault(x => x.IdConsulta == id);
        }
    }
}
