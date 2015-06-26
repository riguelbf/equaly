using System.Web;
using DKO.EQualy.Domain.Enum;
//using DKO.Equaly.Service.DTO.Documentos;
//using DKO.Equaly.Service.Enum;
using DKO.Equaly.DTO.Documentos;

namespace DKO.EQualy.Domain.Interfaces.Service
{
    public interface IArquivoService
    {
        Arquivo.Tipo ObterTipoArquivo(string nomeArquivo);
        string SalvarArquivoDocumento(HttpPostedFileBase arquivo, Documento.FaseDocumento? faseDocumento, int documentoId);
        string ObterCodigoNome(Documento.FaseDocumento? faseDocumento);
        string ObterDiretorioDestino(Arquivo.Tipo tipoArquivo);
        DadosDownloadDto ObterDadosDownload(int documentoId);
        string MontaNomeDocumentoPorFase(EQualy.Domain.Entities.Documento documento);
        string ObterContentType(string fileName);
        void DownloadArquivo(DadosDownloadDto dadosDownloadDto);
        void AtualizaNomeDoArquivoFisico(EQualy.Domain.Entities.Documento documento);
    }
}