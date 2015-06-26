# Titulo : Especificação de serviço de importação de usuarios
# Desenvolvedor : Riguel Figueiro

Funcionalidade: ServicoImportacaoDeUsuario
	
	O sistema deve realizar a importação dos dados dos usuários a partir de um arquivo *.txt

Contexto: Existir um arquivo disponivel com as informaçoes dos usuários

#importação dos dados
Cenario: importar os dados dos usuarios

Dado as seguintes dados dos usuarios
| Nome             | NomeDoUsuario | Matricula | Email                 | SetorId |
| "Riguel Figueiro | "riguel"      | 100       | "riguel@equaly.com.br | 1       |

Quando realizar a importação de usuarios
Então o serviço deve automaticamente ler o arquivo disponibilizado e salvar os dados na base de dados do sistema

