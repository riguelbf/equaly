var indicadores = function() {

    return {

        initIndicadoresIntervaloDatas: function() {

            $('#dashboard-report-range').daterangepicker({
                    ranges: {
                        'Hoje': ['today', 'today'],
                        'Ontem': ['yesterday', 'yesterday'],
                        'Últimos 7 Dias': [
                            Date.today().add({
                                days: -6
                            }), 'today'
                        ],
                        'Últimos 30 Days': [
                            Date.today().add({
                                days: -29
                            }), 'today'
                        ],
                        'Mês atual': [Date.today().moveToFirstDayOfMonth(), Date.today().moveToLastDayOfMonth()],
                        'Mês passado': [
                            Date.today().moveToFirstDayOfMonth().add({
                                months: -1
                            }), Date.today().moveToFirstDayOfMonth().add({
                                days: -1
                            })
                        ]
                    },
                    opens: (App.isRTL() ? 'right' : 'left'),
                    format: 'dd/MM/yyyy',
                    separator: ' to ',
                    startDate: Date.today().add({
                        days: -29
                    }),
                    endDate: Date.today(),
                    minDate: '01/01/2012',
                    maxDate: '12/31/2014',
                    locale: {
                        applyLabel: 'Pesquisar',
                        fromLabel: 'De',
                        toLabel: 'Para',
                        customRangeLabel: 'Intervalo personalizado',
                        daysOfWeek: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],
                        monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
                        firstDay: 1
                    },
                    showWeekNumbers: true,
                    buttonClasses: ['btn-danger']
                },
                function(start, end) {
                    $('#loader').show();


                    //funcao ajax
                    indicadores.onPesquisar(start, end);

                    setTimeout(function() {
                        $('#loader').hide();
                        $.gritter.add({
                            title: 'Indicadores',
                            text: 'Intervalo de datas atualizado.'
                        });
                        App.scrollTo();
                    }, 1000);
                    $('#dashboard-report-range span').html(start.toString('MMMM d, yyyy') + ' - ' + end.toString('MMMM d, yyyy'));

                });

            $('#dashboard-report-range').show();
            $('#dashboard-report-range span').html(Date.today().add({
                days: -29
            }).toString('MMMM d, yyyy') + ' - ' + Date.today().toString('MMMM d, yyyy'));
        },

        populaMiniGraficos: function(data) {

            if (!data)
                return;

            if (data) {

                $('#spanQtdRnc').text(data.QtdRncAbertas);
                $('#spanQtdCorretiva').text(data.QtdAcaoCorretiva);
                $('#spanQtdPreventiva').text(data.QtdAcaoPreventiva);
                $('#spanQtdDocumentos').text(data.QtdDocumentos);
            }
            
            $('.easy-pie-chart .number.transactions').easyPieChart({
                animate: 1000,
                size: 75,
                lineWidth: 3,
                barColor: App.getLayoutColorCode('yellow')
            });

            $('.easy-pie-chart .number.visits').easyPieChart({
                animate: 1000,
                size: 75,
                lineWidth: 3,
                barColor: App.getLayoutColorCode('green')
            });

            $('.easy-pie-chart .number.bounce').easyPieChart({
                animate: 1000,
                size: 75,
                lineWidth: 3,
                barColor: App.getLayoutColorCode('red')
            });
        },

        pupulaGraficosPizza: function(data) {

            if (!jQuery.plot ) {
                return;
            } else if (!data) {
                 return;
            }

            // pizza  ##################################

            var dataPieRegistrada = [],
                dataPieAvaliada = [];

            //series = Math.floor(Math.random() * 6) + 3;

            for (var i = 0; i < data.QuantidadeDeRNC.length; i++) {
                dataPieRegistrada[i] = {
                    label: data.QuantidadeDeRNC[i].NomeSerie, 
                    data: data.QuantidadeDeRNC[i].Valor
                };
            }

            for (var i = 0; i < data.QuantidadeDeRNCAvaliada.length; i++) {
                dataPieAvaliada[i] = {
                    label: data.QuantidadeDeRNCAvaliada[i].NomeSerie,
                    data: data.QuantidadeDeRNCAvaliada[i].Valor
                };
            }

            var pieQtdRNCPorArea = $.plot('#pieQtdPorArea', dataPieRegistrada, {
                series: {
                    pie: {
                        show: true,
                        radius: 1,
                        label: {
                            show: true,
                            radius: 3 / 4,
                            formatter: function(label, series) {
                                return '<div style="font-size:8pt;text-align:center;padding:2px;color:white;">' + label + '<br/>' + Math.round(series.percent) + '%</div>';
                            },
                            background: {
                                opacity: 0.5
                            }
                        }
                    }
                },
                legend: {
                    show: false
                }
            });

            var pieQtdRNCAvaliadaPorArea = $.plot('#pieQtdAvaliadaPorArea', dataPieAvaliada, {
                series: {
                    pie: {
                        show: true,
                        radius: 1,
                        label: {
                            show: true,
                            radius: 3 / 4,
                            formatter: function(label, series) {
                                return '<div style="font-size:8pt;text-align:center;padding:2px;color:white;">' + label + '<br/>' + Math.round(series.percent) + '%</div>';
                            },
                            background: {
                                opacity: 0.5
                            }
                        }
                    }
                },
                legend: {
                    show: false
                }
            });
        },

        populaGraficosLinha: function(data) {

            if (!data)
                return;

            var dadosDeNaoConformidadesRegistradas = [];

            for (var i = 0; i < data.NaoConformidadeRegistrada.length; i++) {

                dadosDeNaoConformidadesRegistradas[i] = [(new Date(data.NaoConformidadeRegistrada[i].Data).getTime()), data.NaoConformidadeRegistrada[i].Quantidade];
            }

            if ($('#graficoLinhaRncRegistrada').size() != 0) {

                $('#site_statistics_loading').hide();
                $('#site_statistics_content').show();

                var plot_statistics = $.plot($("#graficoLinhaRncRegistrada"), [
                    {
                        data: dadosDeNaoConformidadesRegistradas,
                        label: "Não conformidades"
                    }
                ], {
                    series: {
                        lines: {
                            show: true,
                            lineWidth: 2,
                            fill: true,
                            fillColor: {
                                colors: [
                                    {
                                        opacity: 0.05
                                    }, {
                                        opacity: 0.01
                                    }
                                ]
                            }
                        },
                        points: {
                            show: true
                        },
                        shadowSize: 2
                    },
                    grid: {
                        hoverable: true,
                        clickable: true,
                        tickColor: "#eee",
                        borderWidth: 0
                    },
                    colors: ["#d12610", "#37b7f3", "#52e136"],
                    xaxis: {
                        mode: "time",
                        minTickSize: [1, "day"]
                    },
                    yaxis: {
                        min: 0
                    }
                    //xaxis: {
                    //    ticks: 11,
                    //    tickDecimals: 0
                    //},
                    //yaxis: {
                    //    ticks: 11,
                    //    tickDecimals: 0
                    //}
                });

                var previousPoint = null;
                $("#site_statistics").bind("plothover", function(event, pos, item) {
                    $("#x").text(pos.x.toFixed(2));
                    $("#y").text(pos.y.toFixed(2));
                    if (item) {
                        if (previousPoint != item.dataIndex) {
                            previousPoint = item.dataIndex;

                            $("#tooltip").remove();
                            var x = item.datapoint[0].toFixed(2),
                                y = item.datapoint[1].toFixed(2);

                            showTooltip('24 Jan 2013', item.pageX, item.pageY, item.series.label + " of " + x + " = " + y);
                        }
                    } else {
                        $("#tooltip").remove();
                        previousPoint = null;
                    }
                });
            }

            if ($('#load_statistics').size() != 0) {
                //server load
                $('#load_statistics_loading').hide();
                $('#load_statistics_content').show();

                var updateInterval = 30;
                var plot_statistics = $.plot($("#load_statistics"), [getRandomData()], {
                    series: {
                        shadowSize: 1
                    },
                    lines: {
                        show: true,
                        lineWidth: 0.2,
                        fill: true,
                        fillColor: {
                            colors: [
                                {
                                    opacity: 0.1
                                }, {
                                    opacity: 1
                                }
                            ]
                        }
                    },
                    yaxis: {
                        min: 0,
                        max: 100,
                        tickFormatter: function(v) {
                            return v + "%";
                        }
                    },
                    xaxis: {
                        show: false
                    },
                    colors: ["#e14e3d"],
                    grid: {
                        tickColor: "#a8a3a3",
                        borderWidth: 0
                    }
                });
            }
        },

        populaGraficosBarra: function(data) {

            if (!data)
                return;

            var planoDeAcao = [];
            for (var i = 0; i < data.PlanoDeAcaoRegistrada.length; i++)
                planoDeAcao.push([(new Date(data.PlanoDeAcaoRegistrada[i].Data)).getTime(), data.PlanoDeAcaoRegistrada[i].Quantidade]);

            var rnc = [];
            for (var i = 0; i < data.NaoConformidadeRegistrada.length; i++)
                rnc.push([(new Date(data.NaoConformidadeRegistrada[i].Data)).getTime(), data.NaoConformidadeRegistrada[i].Quantidade]);

            var stack = 0,
                bars = true,
                lines = false,
                steps = false;

            var linhaPlanoAcaoXRnc = $.plot($("#linhaPlanoAcaoXRnc"), [planoDeAcao, rnc], {
                series: {
                    stack: stack,
                    //lines: {
                    //    show: lines,
                    //    fill: false,
                    //    steps: steps
                    //},
                    bars: {
                        show: true,
                        barWidth: 1,
                        align: "center"
                    },
                    
                },
                xaxis: {
                    mode: "time",
                    minTickSize: [1, "day"]
                },
                yaxis: {
                    min: 0
                }

            });

            //$(".stackControls input").click(function (e) {
            //    e.preventDefault();
            //    stack = $(this).val() == "With stacking" ? true : null;
            //    plotWithOptions();
            //});
            //$(".graphControls input").click(function (e) {
            //    e.preventDefault();
            //    bars = $(this).val().indexOf("Bars") != -1;
            //    lines = $(this).val().indexOf("Lines") != -1;
            //    steps = $(this).val().indexOf("steps") != -1;
            //    plotWithOptions();
            //});

            
        },

        onPesquisar : function(dataInicial,dataFinal) {

            var url = '/EQualy/Indicadores/PesquisaGeral';
            $.ajax({
                url: url,
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify({ dataInicial: dataInicial, dataFinal: dataFinal }),
                beforeSend: function () {
                    $('#loaderModal').show();
                },
                success: function (data, textStatus, xhr) {

                    $('#loadingChart').show();

                    indicadores.populaMiniGraficos(data);
                    indicadores.pupulaGraficosPizza(data);
                    indicadores.populaGraficosLinha(data);
                    indicadores.populaGraficosBarra(data);

                    $('#loadingChart').hide();  
                },
                error: function (xhr, textStatus, errorThrown) {

                    $('#loaderModal').hide();
                   // openDialogError(data, 'Erro - Plano de ação');
                },
                complete: function () {
                    $('#loaderModal').hide();
                }
            });
        }  
    };
}();

$(document).ready(function () {

    // load
    indicadores.initIndicadoresIntervaloDatas();
    indicadores.populaMiniGraficos();
    indicadores.pupulaGraficosPizza();
    indicadores.populaGraficosLinha();
    indicadores.populaGraficosBarra();
    indicadores.onPesquisar();
});

//*********************************

// events
