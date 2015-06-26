Funcionalidade: Efetuar o login Como um usuário cadastrado no sistema 
Eu quero realizar autenticação no sistema

Contexto: Estar cadastrado no sistema e com situação ativo

Cenario : Realizar login
Dado  que exista um usuario "adminUser" e estar acom status "ativo"
E  que o usuario inpute as informações 
| NomeUsuario | Senha  |
| riguel      | 123456 |

Quando  visita "~/EQualy"
Entao  eu tente efetuar o login


