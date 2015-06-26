using System.Collections.Generic;

namespace DKO.Equaly.Projection.Documentos
{
    public class DocumentosProjection
    {
        public DocumentosProjection()
        {
            this.DocumentosDisponibilizados = new List<DocumentoDisponibilizadoProjection>();
            this.DocumentosSolicitados = new List<DocumentoSolicitadoProjection>();
        }
        public List<DocumentoDisponibilizadoProjection> DocumentosDisponibilizados { get; set; }
        public List<DocumentoSolicitadoProjection> DocumentosSolicitados { get; set; }
    }
}