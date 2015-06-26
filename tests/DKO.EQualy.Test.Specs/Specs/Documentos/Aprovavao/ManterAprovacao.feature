# Titulo        : Especificação de aprovação/reprovação de documento para publicação
# Data          : 11/07/2014
# Desenvolvedor : Riguel Figueiro

Funcionalidade: ManterAprovacaoDocumento
	
	Quero realizar a aprovação do documento para publicação

Contexto: Estar cadastrado no sistema ,com situação ativo e permissão de acesso ao módulo de não conformidades (edição e novo registro)

# download do documento
Cenario: Realizar o download documento para analise
	Dado  que exista um documento como nome "testeEqualy.doc" salvo no servidor
	
Quando  realizar o download
Entao  o download deve ser iniciado


# Aprovação de documento
Cenario: Realizar a aprovação do documento
	Dado  que ja tenha sido feita a analise do documento
	
Quando  realizar a aprovação
Entao  o documento é disponibilizado para publicação


# Reprovação de documento
Cenario: Realizar a reprovação do documento
	Dado  que ja tenha sido feita a analise do documento 
	E o mesmo não esteja em conformidade com a solicitação
	E tenha justificado a reprovação com o texto "Documento fora das conformidades com o solicitado"
	
Quando  realizar a reprovação
Entao  o documento é colocado em status de "Elaboracao"