# Titulo : Especificação de publicação de documento
# Data : 11/07/2014
# Desenvolvedor : Riguel Figueiro

Funcionalidade: ManterPublicacaoDocumento
	
	Quero realizar a publicação do documento para uso do setor que solicitou o documentos

Contexto: Estar cadastrado no sistema ,com situação ativo e permissão de acesso ao módulo de documentos e (editar, solicitar)

# publicação de documento com copia controlada
Esquema do Cenario: publicar o documento solicitado pelo setor do tipo fisico para uso com copia controlada
Dado as informações  <Titulo> e <DataPublicacao> e <DataValidade> e <LocalFisico> e <QtdCopiasPermitidas> para uso nas rotinas de trabalho com uso de documentos com copia controlada
Quando executar a publicação do documento com copia controlada

Entao o documento deve ser atualizado para o status "Publicado"
E um email de aviso com a informação "Documento publicado para uso" deve ser enviado para os <CodigoDosRevisores>


Exemplos: 
| Titulo				| DataPublicacao  | DataValidade    | QtdCopiasPermitidas |
| "Titulo do documento" | "20/11/2014"	  | "31/12/2020"    | 1					  |


# publicação de documento sem copia controlada
Esquema do Cenario: publicar o documento solicitado pelo setor do tipo fisico para uso com sem copia controlada
Dado as informações  <Titulo> e <DataPublicacao> e <DataValidade> e <LocalFisico> para uso nas rotinas de trabalho
Quando executar a publicação do documento sem copia controlada

Entao o documento deve ser atualizado para o status "Publicado"
E um email de aviso com a informação "Documento sem copia controlada foi publicado para uso" deve ser enviado para os <CodigoDosRevisores>

Exemplos: 
| Titulo				| DataPublicacao  | DataValidade    |
| "Titulo do documento" | "20/11/2014"	  | "31/12/2020"    |