# Titulo : Especificação de avaliação das soluções para a execução dos planos de ações em relação as não conformidades
# Desenvolvedor : Riguel Figueiro

Funcionalidade: ManterAvaliacaoDaEficacia
	
	Quero avaliar as soluções propostas para a solução de uma não conformidade

Contexto: Estar cadastrado no sistema ,com situação ativo e permissão de acesso
 ao módulo de não conformidades (edição e novo registro)


# registrar uma pontuação de eficacia
Cenario: avaliar uma solução de nao conformidade

Dado as seguintes informações iniciais para a avaliação da eficacia
| Pontuacao | Observacao																	   |
| 5         | "Solução muito bem elaborada para resolver o problema de produto vencido"        |

Quando salvar a nao conformidade com os dados de avaliação de eficacia
Então eu espero receber a seguinte informação "Avaliação da não conformidade realizada com sucesso!" 
E um email de notificação para a equipe envolvida deve ser enviado com a seguinte mensagem "A definição de solução para a não conformidade XX foi avaliada com uma pontuação de YY"

