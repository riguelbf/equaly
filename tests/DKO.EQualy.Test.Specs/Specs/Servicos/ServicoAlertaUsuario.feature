# Titulo : Especificação de serviço de alertas para o usuário
# Desenvolvedor : Riguel Figueiro

Funcionalidade: ServicoDeAlertaParaOUsuario
	
	O sistema deve realizar alertas aos usuários

Contexto: Existir alertas pendentes de aviso

# Alerta de tarefa
Cenario: alertar o usuário que existem novas tarefas

Dado as seguintes informações iniciais para a o envio de alerta do tipo tarefa
| Titulo        | DataDeCriacao | DataDeConclusao | Tipo                      | Status   | UsuarioDestinoId | Descricao                                                    |
| "Nova tarefa" | "02/11/2014"  | "10/11/2014"    | "Elaboração de documento" | "Criada" | 1                | "O usuário XX solicita a criação do documento com código YY" |

Quando enviar o alerta de nova tarefa
Então o serviço deve automaticamente registrar a nova tarefa
E um email de notificação para a o usuario <UsuarioId> deve ser enviado com a seguinte mensagem "Uma nova tarefa foi registrada para você."


# listagem com registros de novas tarefas
Esquema do Cenario: Listar as tarefas pendentes para o usuario
Dado o codigo do usuário
Quando executar a consulta das tarefas pertencentes ao usuário

Exemplos: 
| Titulo            | Tipo                     | Status   | DataConclusao |
| "Tarefa de teste" | "Aprovação de documento" | "Criada" | "20/09/2014"  |