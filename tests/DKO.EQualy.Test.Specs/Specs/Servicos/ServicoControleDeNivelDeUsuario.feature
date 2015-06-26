# Titulo : Especificação de controle de nivel de usuário
# Desenvolvedor : Riguel Figueiro

Funcionalidade: ServicoControleDeNivelDeUsuario
	
	Quero realizar o controle de nivel do usuario para garantir o acesso aos modulos permitidos

Contexto: Existir um usuaro cadastrado e ativo

# solicitação de dados do usuário
Cenario: solicitar os dados do usuário logado

Dado o código do usuario
| CodigoDoUsuario	|
| 1				    |

Quando o serviço solicitar os dados do usuário
Então o serviço que contém os dados do usuário deve retornar os mesmo
Mas caso o usuário esteja inativo ou seja inexistente
Entao retornar a seguinte mensagem "Usuário inexistente ou inativo"


