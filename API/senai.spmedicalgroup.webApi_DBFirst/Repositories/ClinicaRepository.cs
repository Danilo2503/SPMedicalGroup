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
    public class ClinicaRepository : IClinica
    {
        // Usuario, TipoDeUsuario, Clinica e Consulta
        SPMed _context = new SPMed();
        public void create(Clinica clinica)
        {
            _context.Clinicas.Add(clinica);
        }

        public void delete(int id)
        {
            Clinica clinicabuscada = _context.Clinicas.Find(id);
            _context.Clinicas.Remove(clinicabuscada);
            _context.SaveChanges();
        }

        public List<Clinica> read()
        {
            return _context.Clinicas.Include(x => x.Medicos).ToList();
        }

        public Clinica readId(int id)
        {
            return _context.Clinicas.FirstOrDefault(x => x.IdClinica == id);
        }

        public void update(int id, Clinica clinica)
        {
            Clinica clinicaBuscada = _context.Clinicas.Find(id);
            if (clinica.Cnpj != null)
            {
                clinicaBuscada.Cnpj = clinica.Cnpj;
                clinicaBuscada.Endereco = clinica.Endereco;
                clinicaBuscada.Nome = clinica.Nome;
                clinicaBuscada.RazaoSocial = clinica.RazaoSocial;

                _context.Clinicas.Update(clinicaBuscada);
                _context.SaveChanges();
            }
        }
    }
}
