using System;

namespace Bitacora.API.Models
{
    public class Actividad
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        public string Activida { get; set; }

        public string Categoria { get; set; }

        public DateTime horaInicial { get; set; }

        public DateTime horaFinal { get; set; }

        public int CategoryId { get; set; }
        public Category category { get; set; }
    }
}