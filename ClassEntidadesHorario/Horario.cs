using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassEntidadesHorario
{
    public class Horario
    {
        public int idHorario { get; set; } 
        public int AsignacionID { get; set; }
        public int DiaID { get; set; }
        public TimeSpan HrInicio { get; set; }
        public TimeSpan HrFinal {  get; set; }
        public int AulaID { get; set; }
    }
}
