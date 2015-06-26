# Titulo : Especificação de registro de reclamativa e abertura de nova não conformidade
# Desenvolvedor : Riguel Figueiro

Funcionalidade: ManterReclamativa
	
	Quero registrar uma não reclamativa e que automaticamente uma nova não conformidade seja aberta

Contexto: Estar cadastrado no sistema ,com situação ativo e permissão de acesso
 ao módulo de não conformidades (edição e novo registro)

# registrar uma reclamativa
Cenario: registrar uma reclamativa

Dado as seguintes informações iniciais para a o cadastro de uma reclamativa
| TituloDaOcorrencia	| DataDeAbertura	  | NumeroDePedido | NomeDoReclamante      | TelefoneContato    | EmailDoReclamante			   | ReponsavelPelaAbertura | Descricao													   |
| "Produto vencido"     | "20/09/2014"        | "00100"        | "Riguel Figueiro"     | "(51)84059454"     | "riguel@equaly.com.br"       | "Ana Paukner"          |  "O cliente esta reclamando que recebeu um produto vencido"  |

Quando registrar uma reclamativa
Então automaticamente deve ser aberta uma não conformidade
E um email de notificação para a o usuario <UsuarioId> deve ser enviado com a seguinte mensagem "Uma nova reclamaiva foi registrada para você."

