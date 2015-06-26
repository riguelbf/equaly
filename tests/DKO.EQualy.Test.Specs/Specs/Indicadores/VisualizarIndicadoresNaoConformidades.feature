# Titulo : Especificação de visualização analitica dos dados registrados de documentos, não conformidades
# Data : 12/06/2014
# Desenvolvedor : Riguel Figueiro

Funcionalidade: VisualizarIndicadores
Quero consultar os dados registrados de documentos e não conformidade, consolidar os dados para gerar gráficos

Contexto: Estar cadastrado no sistema ,com situação ativo e permissão de acesso ao módulo de documentos

Cenario: Gerar gráficos geral com os dados consolidados
Dado as datas de <DataInicial> e <DataFinal>
Quando executar a consulta 
Entao os gráficos devem ser gerados contendo dados <DadosConsolidados>


#grafico Quantidade de RNC registrada por área
Cenario: Gerar Quantidade de RNC registrada por área
Dado as datas de <DataInicial> e <DataFinal>
Quando executar a consulta 
Entao o gráfico de quantidade de RNC registrada deve ser gerado contendo dados <DadosConsolidados>


#grafico Quantidade RNC avaliada por área
Cenario: Gerar Quantidade RNC avaliada por área
Dado as datas de <DataInicial> e <DataFinal>
Quando executar a consulta 
Entao o gráfico de quantidade de RNC avaliada deve ser gerado contendo dados <DadosConsolidados>

#grafico Quantidade's registradas

Cenario: Gerar Quantidade's registradas
Dado as datas de <DataInicial> e <DataFinal>
Quando executar a consulta 
Entao o gráfico de quantidade's registradas deve ser gerado contendo dados <DadosConsolidados>

#grafico Quantidade de ação X RNC
Cenario: Gerar Quantidade de ação X RNC
Dado as datas de <DataInicial> e <DataFinal>
Quando executar a consulta 
Entao o gráfico de quantidade de ação X RNC deve ser gerado contendo dados <DadosConsolidados>