using System.Collections.Generic;
using System.Web;
using DKO.EQualy.Domain.Entities;
using DKO.Equaly.DTO.Documentos;
using DKO.Equaly.Projection.Documentos;

namespace DKO.EQualy.Domain.Interfaces.Service
{
    public interface IDocumentoService
    {
        DocumentosProjection ObterDocumentos(FiltroDocumentosDto filtroDocumentosDto);

        void ExcluirDocumento(int documentoId);

        EQualy.Domain.Enum.Documento.FaseDocumento ObterProximaFase(EQualy.Domain.Enum.Documento.FaseDocumento faseDocumento);

        #region [ Fase 1 ]

        void RegistrarSolicitacaoDocumento(SolicitacaoDocumentoDto solicitacaoDocumentoDto);
        SolicitacaoDocumentoDto ObterSolicitacaoDocumentoPorId(int solicitacaoDocumentoId);
        void RegistrarTarefaElaboracao(Documento documento);

        #endregion

        #region [ Fase 2 ]

        void RegistraSolicitacaoDeRevisão(int documentoId, HttpPostedFileBase arquivo);

        #endregion

        #region [ Fase 3 ]

        void RegistrarAprovacaoDeRevisao(SolicitacaoDocumentoDto solicitacaoDocumentoDto);
        int ObterTotalDeAprocacoesDeRevisao(int documentoId);
        void RegistrarReprovacaoDeRevisao(SolicitacaoDocumentoDto solicitacaoDocumentoDto);

        #endregion

        #region [ Fase 4 ]

        void RegistrarAprovacaoDeDocumento(SolicitacaoDocumentoDto solicitacaoDocumentoDto);

        void RegistrarReprovacaoDeDocumento(SolicitacaoDocumentoDto solicitacaoDocumentoDto);

        #endregion

        #region [ Fase 5 ]

        void RegistrarPublicacaoDeDocumento(SolicitacaoDocumentoDto solicitacaoDocumentoDto);

        #endregion
    }
}