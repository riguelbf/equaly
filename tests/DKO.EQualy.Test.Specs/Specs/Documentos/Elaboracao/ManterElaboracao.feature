# Titulo : Especificação elaboração de documento para publicação
# Data : 11/07/2014
# Desenvolvedor : Riguel Figueiro

Funcionalidade: ManterElaboracaoDocumento
	
	Quero realizar a solicitação de revisão do documento para os revisores


Contexto: Estar cadastrado no sistema ,com situação ativo e permissão de acesso ao módulo de não conformidades (edição e novo registro)

# upload do documento
Cenario: Realizar upload do documento para revisão
	Dado  que exista um documento com o nome "testeEqualy.doc" salvo no servidor
	
Quando  realizar o upload
Entao  arquivo com o nome "testeEqualy.doc" deve ser salvo no servidor
E um email de aviso aos revisores deve ser enviado
E alterar o status do documento para "Revisando"

