
# Titulo        : Especificação de consulta de documentos elaborados
# Data          : 10/06/2014
# Desenvolvedor : Riguel Figueiro

Funcionalidade: ListarDocumentos
	
	Quero consultar todos os documentos ja registrados e disponiveis em um determinado peridodo

Contexto: Estar cadastrado no sistema ,com situação ativo e permissão de acesso ao módulo de documentos

# listagem com registros existentes
Esquema do Cenario: Listar Documentos utilizando combinação de filtros sem retorno de dados
Dado os filtros por <Titulo> e <DataInicial> e <DataFinal> e <SetorId> e <Fase> e <Status> para pesquisa sem registros
Quando executar a consulta sem registros

Entao o número total de registros de documentos encontrados deve ser <QuantidadeTotalDeRegistros>

Exemplos: 
| Titulo   | DataInicial  | DataFinal    | SetorId | Fase | Status | QuantidadeDeRegistrosRetornados |
| "Titulo" | "01/01/2000" | "31/12/2020" | 1       | 1    | 1      | 0                               |


# listagem sem registros existentes
Esquema do Cenario: Listar Documentos utilizando combinação de filtros com retorno de dados
Dado os filtros por <Titulo> e <DataInicial> e <DataFinal> e <SetorId> e <Fase> e <Status> para pesquisa com registros
Quando executar a consulta com registros

Entao o número total de registros de documentos encontrados é  maior do que <QuantidadeTotalDeRegistrosComDados>

Exemplos: 
| Titulo   | DataInicial  | DataFinal    | SetorId | Fase | Status | QuantidadeTotalDeRegistrosComDados |
| "Titulo" | "01/01/2000" | "31/12/2020" | 1       | 1    | 1      | 1                                  |


