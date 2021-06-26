using System;
using System.Collections.Generic;

#nullable disable

namespace senai.spmedicalgroup.webApi_DBFirst.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdSituacao { get; set; }
        public string NomeSituacao { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
