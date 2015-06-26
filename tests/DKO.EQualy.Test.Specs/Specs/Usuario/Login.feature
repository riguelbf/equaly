# Titulo : Especificação de Login de usuário
# Data : 08/05/2014
# Desenvolvedor : Riguel Figueiro



Funcionalidade: Efetuar o login Como um usuário cadastrado no sistema 
	Eu quero realizar autenticação no sistema

Contexto: Estar cadastrado no sistema e com situação ativo

Cenario: Realizar login
	Dado  que exista um usuario "adminUser" e estar acom status "ativo"
	E  que o usuario inpute as informações 
		| NomeUsuario | Senha  |
		| riguel      | 123456 |

Quando  visita "/"
Entao  eu tente efetuar o login


