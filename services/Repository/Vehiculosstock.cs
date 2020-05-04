using System;
using System.Collections.Generic;

namespace services.Repository
{
    public partial class Vehiculosstock
    {
        public int Id { get; set; }
        public int IdVersion { get; set; }
        public string Comentarios { get; set; }
        public int Cantidad { get; set; }

        public virtual Version IdVersionNavigation { get; set; }
    }
}
