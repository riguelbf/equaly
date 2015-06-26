# Titulo : Especificação de inclusão de planos de ações para a solução de não conformidades
# Desenvolvedor : Riguel Figueiro

Funcionalidade: ManterPlanoDeAcao
	
	Quero incluir planos de ações

Contexto: Estar cadastrado no sistema ,com situação ativo e permissão de acesso
 ao módulo de não conformidades (edição e novo registro)


# plano de acao do tipo acao corretiva
Cenario: registrar um plano de acao do tipo acao corretiva

Dado as seguintes informações iniciais para a o cadastro de acao corretiva
| Oque | Quando | Quem | Tipo | Como | PorQue | QuantoCusta | Quando |
| "O que aconteceu?"     | "Quando ocorreu ?"        | "Riguel Figueiro"     | "Acao Corretiva"     | "Como quebrou o produto?"     | "Por que quebrou o produto"       |     "Quanto custou o prejuizo?"        |     "Quando quebrou o produto?"   |

Quando registrar um plano de ação do tipo acao corretiva
Então eu espero receber a seguinte informação "Plano de ação do tipo ação corretiva registrada com sucesso!" 
E um email de notificação para a o usuario <UsuarioId> deve ser enviado com a seguinte mensagem "Um questionamento aguarda sua resposta"


# plano de acao do tipo acao preventiva
Cenario: registrar um plano de acao do tipo acao preventiva

Dado as seguintes informações iniciais para a o cadastro de acao preventiva
| Oque | Quando | Quem | Tipo | Como | PorQue | QuantoCusta | Quando |
| "O que aconteceu?"     | "Quando ocorreu ?"        | "Riguel Figueiro"     | "Acao Preventiva"     | "Como quebrou o produto?"     | "Por que quebrou o produto"       |     "Quanto custou o prejuizo?"        |     "Quando quebrou o produto?"   |

Quando registrar um plano de ação do tipo acao preventiva
Então eu espero receber a seguinte informação "Plano de ação do tipo ação preventiva registrada com sucesso!" 
E um email de notificação para a o usuario <UsuarioId> deve ser enviado com a seguinte mensagem "A ação preventiva codigo aguarda sua elaboração"
