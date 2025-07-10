using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoradosBlazor.Shared
{
    public class ST_IUD_ProspectoActividadDTO
    {
        public int iTipoOperacion { get; set; }    // 1 = Insertar, 2 = Actualizar, 3 = Eliminar
        public int iActividadID { get; set; }
        public int iProspectoID { get; set; }
        public int iEjecutivoID { get; set; }      // Usuario responsable, p.ej. reclutador actual
        public string? sTipo { get; set; }         // "Llamada", "Correo", "Visita", "Recordatorio", etc.
        public string? sDescripcion { get; set; }  // Detalles de la tarea (opcional, p.ej. "Llamar para seguimiento de inscripción")
        public DateTime dFechaProgramada { get; set; } // Fecha y hora programada para la actividad
        public bool bRealizado { get; set; }       // Marcar true si ya se realizó (para históricos)
    }
}
