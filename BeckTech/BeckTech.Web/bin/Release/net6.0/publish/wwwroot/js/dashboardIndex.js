
$(document).ready(function () {
    var yearlyArticlesUrl = app.Urls.yearlyArticlesUrl;
    var yearlyArticlesForUserUrl = app.Urls.yearlyArticlesForUserUrl;
    var totalArticleCountUrl = app.Urls.totalArticleCountUrl;
    var totalArticleCountForUserUrl = app.Urls.totalArticleCountForUserUrl;
    var totalCategoryCountUrl = app.Urls.totalCategoryCountUrl;
    var totalCategoryCountForUserUrl = app.Urls.totalCategoryCountForUserUrl;
    var totalViewCountsUrl = app.Urls.totalViewCountsUrl;
    var totalViewCountForUsersUrl = app.Urls.totalViewCountForUsersUrl;
    $.ajax({
        type: "GET",
        url: totalArticleCountUrl,
        dataType: "json",
        success: function (data) {
            $("h3#totalArticleCount").append(data);
        },
        error: function () {
            toastr.error("Makale Analizleri yüklenirken hata oluştu", "Hata");
        }

    });
    $.ajax({
        type: "GET",
        url: totalArticleCountForUserUrl,
        dataType: "json",
        success: function (data) {
            $("h3#totalArticleCountForUser").append(data);
        },
        error: function () {
            toastr.error("Makale Analizleri yüklenirken hata oluştu", "Hata");
        }

    });
    $.ajax({
        type: "GET",
        url: totalCategoryCountUrl,
        dataType: "json",
        success: function (data) {
            $("h3#totalCategoryCount").append(data);
        },
        error: function () {
            toastr.error("Makale Analizleri yüklenirken hata oluştu", "Hata");
        }

    });
    $.ajax({
        type: "GET",
        url: totalCategoryCountForUserUrl,
        dataType: "json",
        success: function (data) {
            $("h3#totalCategoryCountForUser").append(data);
        },
        error: function () {
            toastr.error("Makale Analizleri yüklenirken hata oluştu", "Hata");
        }

    });
    $.ajax({
        type: "GET",
        url: totalViewCountsUrl,
        dataType: "json",
        success: function (data) {
            $("h3#totalViewCount").append(data);
        },
        error: function () {
            toastr.error("Makale Analizleri yüklenirken hata oluştu", "Hata");
        }

    });
    $.ajax({
        type: "GET",
        url: totalViewCountForUsersUrl,
        dataType: "json",
        success: function (data) {
            $("h3#totalViewCountForUser").append(data);
        },
        error: function () {
            toastr.error("Makale Analizleri yüklenirken hata oluştu", "Hata");
        }

    });

    $.ajax({
        type: "GET",
        url: yearlyArticlesUrl,
        dataType: "json",
        success: function (data) {
            var parsedData = JSON.parse(data);
            var chartData = parsedData;

            // Fetch user's yearly article counts
            $.ajax({
                type: "GET",
                url: yearlyArticlesForUserUrl,
                dataType: "json",
                success: function (userData) {
                    var parsedUserData = JSON.parse(userData);
                    var userChartData = parsedUserData;

                    // Define month names array
                    var monthNames = [
                        "Ocak", "Şubat", "Mart", "Nisan",
                        "Mayıs", "Haziran", "Temmuz", "Ağustos",
                        "Eylül", "Ekim", "Kasım", "Aralık"
                    ];

                    // Merge data for total articles and user's articles
                    var mergedData = [];
                    for (var i = 0; i < chartData.length; i++) {
                        mergedData.push({
                            month: monthNames[i],
                            totalArticles: chartData[i],
                            userArticles: userChartData[i]
                        });
                    }

                    let cardColor, headingColor, axisColor, shadeColor, borderColor;
                    // Your color definitions here...

                    // Chart options and rendering
                    const totalRevenueChartEl = document.querySelector('#customTotalRevenueChart'),
                        totalRevenueChartOptions = {
                            series: [
                                {
                                    name: "Toplam Makale",
                                    data: mergedData.map(item => item.totalArticles)
                                },
                                {
                                    name: "Eklediğin Makale",
                                    data: mergedData.map(item => item.userArticles)
                                }
                            ],
                            chart: {
                                height: 300,
                                type: 'bar',
                                toolbar: { show: false }
                            },
                            plotOptions: {
                                bar: {
                                    horizontal: false,
                                    columnWidth: '30%',
                                    endingShape: 'rounded'
                                }
                            },
                            dataLabels: {
                                enabled: false
                            },
                            colors: [config.colors.primary, config.colors.info],
                            xaxis: {
                                categories: mergedData.map(item => item.month),
                                labels: {
                                    style: {
                                        fontSize: '13px',
                                        colors: axisColor
                                    }
                                }
                            },
                            yaxis: {
                                labels: {
                                    style: {
                                        fontSize: '13px',
                                        colors: axisColor
                                    }
                                }
                            },
                            legend: {
                                show: true,
                                position: 'top',
                                markers: {
                                    radius: 12,
                                    offsetX: -3
                                },
                                labels: {
                                    colors: axisColor
                                },
                                itemMargin: {
                                    horizontal: 10
                                }
                            },
                            grid: {
                                borderColor: borderColor
                            }
                        };

                    if (typeof totalRevenueChartEl !== undefined && totalRevenueChartEl !== null) {
                        const totalRevenueChart = new ApexCharts(totalRevenueChartEl, totalRevenueChartOptions);
                        totalRevenueChart.render();
                    }
                }
            });
        },
        error: function () {
            toastr.error("Makale Analizleri yüklenirken hata oluştu", "Hata");
        }
    });


});