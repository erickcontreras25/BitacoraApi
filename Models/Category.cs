using System.Collections.Generic;

namespace Bitacora.API.Models
{
    public class Category
    {
        public int Id {get; set;}

        public string ActividadName { get; set; }

        public ICollection<Actividad> Actividad { get; set; }
        
    }
}