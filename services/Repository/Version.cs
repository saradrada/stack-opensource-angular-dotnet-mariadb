using System;
using System.Collections.Generic;

namespace services.Repository
{
    public partial class Version
    {
        public Version()
        {
            Vehiculosstock = new HashSet<Vehiculosstock>();
        }

        public int Id { get; set; }
        public int IdModelo { get; set; }
        public string Nombre { get; set; }

        public virtual Modelo IdModeloNavigation { get; set; }
        public virtual ICollection<Vehiculosstock> Vehiculosstock { get; set; }
    }
}
