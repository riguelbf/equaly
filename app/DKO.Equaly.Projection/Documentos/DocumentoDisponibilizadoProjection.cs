using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKO.Equaly.Projection.Documentos
{
    public class DocumentoDisponibilizadoProjection
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Tipo { get; set; }
        public string SetorResponsavel { get; set; }
        public string Armazenamento { get; set; }
        public DateTime Validade{ get; set; }
        public string NomeIcone { get; set; }
    }
}
