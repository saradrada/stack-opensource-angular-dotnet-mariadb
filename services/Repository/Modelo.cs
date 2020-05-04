using System;
using System.Collections.Generic;

namespace services.Repository
{
    public partial class Modelo
    {
        public Modelo()
        {
            Version = new HashSet<Version>();
        }

        public int Id { get; set; }
        public int IdMarca { get; set; }
        public int IdAnio { get; set; }
        public string Nombre { get; set; }

        public virtual Anio IdAnioNavigation { get; set; }
        public virtual Marca IdMarcaNavigation { get; set; }
        public virtual ICollection<Version> Version { get; set; }
    }
}
