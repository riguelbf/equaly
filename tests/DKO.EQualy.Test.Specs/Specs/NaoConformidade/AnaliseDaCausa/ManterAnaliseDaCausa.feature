
# Titulo        : Especificação de cadastro e edição de analise de causa. Estágio 1 do registro de uma não conformidade
# Data          : 11/07/2014
# Desenvolvedor : Riguel Figueiro

Funcionalidade: ManterAnaliseDeCausa
	Quero cadastrar e editar uma anlise de causa raiz para uma nova não conformidade

Contexto: Estar cadastrado no sistema ,com situação ativo e permissão de acesso
 ao módulo de não conformidades (edição e novo registro)

 # cadastrar uma analise de causa raiz
Cenario: cadastrar uma analise de causa raiz
Dado as seguintes informações iniciais para analise de causa raiz
| DataDeConclusao | Descrição   |
| ""              | true        |

Quando salvar a nao conformidade com os dados de analise da causa
Então eu espero receber a seguinte informação "Não conformidade atualizada com registro de analise de causa raiz com sucesso!" 
E um email de notificação para a equipe envolvida deve ser enviado com a seguinte mensagem "Definida uma causa raiz para a não conformidade código XX"

# cadastrar um por que
Cenario: cadastrar um por que(5PorQue) para encontrar a causa raiz da nao conformidade
Dado as seguintes informações da pergunta
| UsuarioDeDestinoId | Pergunta|
| 1                  | "Qual a forma de transporte para o produto XX?"       |

Quando adicionar o porque
Então adicionar o registrno na tabela
E mostrar a mensagem "Pergunta adicionada com sucesso!"

# adicionar usuarios na equipe
Cenario: adicionar usuarios na equipe responsavel para solução da nao conformidade
Dado as seguintes informações da pergunta
| UsuarioDeDestinoId | NomeUsuario|
| 1                  | "Riguel Figueiro"       |
| 1                  | "Ana Paukner"       |

Quando adicionar o usuario
Então adicionar o registrno na tabela de equipe selecionada