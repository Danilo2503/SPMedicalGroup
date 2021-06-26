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
    public class TipoUsuarioRepository : ITiposUsuario
    {
        SPMed _context = new SPMed();
        public void create(TiposUsuario tipoDeUsuario)
        {
            _context.TiposUsuarios.Add(tipoDeUsuario);
        }

        public void delete(int id)
        {
            TiposUsuario tipoDeUsuariobuscado = _context.TiposUsuarios.Find(id);
            _context.TiposUsuarios.Remove(tipoDeUsuariobuscado);
            _context.SaveChanges();
        }

        public List<TiposUsuario> read()
        {
            return _context.TiposUsuarios.Include(x => x.Usuarios).ToList();
        }

        public TiposUsuario readId(int id)
        {
            return _context.TiposUsuarios.FirstOrDefault(x => x.IdTipoUsuario == id);
        }

        public void update(int id, TiposUsuario tipoDeUsuario)
        {
            TiposUsuario tipoDeUsuariobuscado = _context.TiposUsuarios.Find(id);
            if (tipoDeUsuario.NomeTipoUsuario != null)
            {
                tipoDeUsuario.NomeTipoUsuario = tipoDeUsuariobuscado.NomeTipoUsuario;

                _context.TiposUsuarios.Update(tipoDeUsuariobuscado);
                _context.SaveChanges();
            }
        }
    }
}
