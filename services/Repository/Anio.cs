using System;
using System.Collections.Generic;

namespace services.Repository
{
    public partial class Anio
    {
        public Anio()
        {
            Modelo = new HashSet<Modelo>();
        }

        public int Id { get; set; }
        public short Nombre { get; set; }

        public virtual ICollection<Modelo> Modelo { get; set; }
    }
}
