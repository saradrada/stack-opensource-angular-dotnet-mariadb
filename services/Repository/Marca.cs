using System;
using System.Collections.Generic;

namespace services.Repository
{
    public partial class Marca
    {
        public Marca()
        {
            Modelo = new HashSet<Modelo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Modelo> Modelo { get; set; }
    }
}
