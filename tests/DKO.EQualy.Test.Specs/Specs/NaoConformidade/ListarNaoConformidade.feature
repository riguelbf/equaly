# Titulo : Especificação de consulta de nao conformidades registradas
# Data : 10/06/2014
# Desenvolvedor : Riguel Figueiro

Funcionalidade: ListarNaoConformidades
	
	Quero consultar todas as não conformidades registradas e disponiveis com determinados critérios

Contexto: Estar cadastrado no sistema ,com situação ativo e permissão de acesso ao módulo de documentos

Esquema do Cenario: Listar NaoConformidades utilizando combinação de filtros sem retorno de dados
Dado os filtros por <UsuarioResponsavelId> e <SetorId> e <DataInicial> e <DataFinal> e <Status>
Quando executar a consulta 

Entao o número total de registros encontrados deve igual a <QuantidadeTotalDeRegistros>

Exemplos: 
| UsuarioResponsavelId | SetorId | DataInicial | DataFinal    | Status  | QuantidadeDeRegistrosRetornados |
| 1                  |     1    | "01/01/2000" | "31/12/2020" | 1       | 0                               |

Esquema do Cenario: Listar NaoConformidades utilizando combinação de filtros com retorno de dados
Dado os filtros por <UsuarioResponsavelId> e <SetorId> e <DataInicial> e <DataFinal> e <Status>
Quando executar a consulta 

Entao o número total de registros encontrados deve ser  é <QuantidadeTotalDeRegistrosComDados>

Exemplos: 
| UsuarioResponsavelId | SetorId | DataInicial | DataFinal    | Status  | QuantidadeTotalDeRegistrosComDados |
| 1                  |     1    | "01/01/2000" | "31/12/2020" | 1       | 1                               |


