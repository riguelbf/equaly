# Titulo : Especificação de solicitação de documentos para elaboração
# Data : 14/09/2014
# Desenvolvedor : Riguel Figueiro

Funcionalidade: ManterSolicitacao
	
	Quero realizar a solicitação de elaboração de documentos

Contexto: Estar cadastrado no sistema ,com situação ativo e permissão de acesso ao módulo de documentos

# solicitar documentos
Cenario: solicitar documentos com informações iniciais

Dado as seguintes informações iniciais
| Titulo | DataCriacao | Versao | TipoDeDocumento | TipoDeArmazenamento | SetorId | SolicitanteId | AprovadorId | RevisoresId |
| 148212 | true        | false  | 1               | 1                   | 2       | 1             | 1           | 1,2,3       |

Quando salvar o documento
Então eu espero receber a seguinte informação "Documento solicitado com sucesso!" 
E um email de notificação para o elaborador deve ser enviado com a seguinte mensagem "O Documento com o código XX foi solicitado para elaboração"
