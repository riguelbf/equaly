# Titulo : Especificação de revisão de documento para solicitar a aprovação de publicação
# Data : 11/07/2014
# Desenvolvedor : Riguel Figueiro

Funcionalidade: ManterRevisaoDocumento
	
	Quero realizar a revisão do documento para solicitação de aprovação de publicação

Contexto: Estar cadastrado no sistema ,com situação ativo e permissão de acesso ao módulo de documentos (edição e novo registro)

# download do documento
Cenario: Realizar o download documento para analise em fase de revisão
	Dado  que exista um documento como nome "testeEqualy.doc" salvo no servidor
	
Quando  realizar o download para revisar
Entao  o download deve ser iniciado


# Aprovação de documento
Cenario: Realizar a aprovação do documento em fase de revisão
	Dado  que ja tenha sido feita a analise do documento na fase de revisão
	
Quando  realizar a aprovação em fase de revisão
Entao  o documento é disponibilizado para publicação apos a revisao


# Reprovação de documento
Cenario: Realizar a reprovação do documento em fase de revisão
	Dado  que ja tenha sido feita a analise do documento 
	E o mesmo não esteja em conformidade com a solicitação apos a revisão
	E tenha justificado a reprovação com o texto "Documento fora das conformidades do solicitado"
	
Quando  realizar a reprovação
Entao  o documento é colocado em status de "Elaboracao"