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
    public class UsuarioRepository : IUsuario
    {
        SPMed _context = new SPMed();
        public void create(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }

        public void delete(int id)
        {
            Usuario usuarioBuscado = _context.Usuarios.Find(id);
            _context.Usuarios.Remove(usuarioBuscado);
            _context.SaveChanges();
        }

        public List<Usuario> read()
        {
            return _context.Usuarios.Include(x => x.IdTipoUsuarioNavigation).ToList();
        }

        public Usuario readId(int id)
        {
            throw new NotImplementedException();
        }

        public void update(int id, Usuario usuario)
        {
            Usuario usuarioBuscado = _context.Usuarios.Find(id);
            if (usuario.EmailUsuario != null)
            {
                usuarioBuscado.EmailUsuario = usuario.EmailUsuario;
                usuarioBuscado.Medicos = usuario.Medicos;
                usuarioBuscado.Pacientes = usuario.Pacientes;

                _context.Usuarios.Update(usuarioBuscado);
                _context.SaveChanges();
            }
        }
    }
}
