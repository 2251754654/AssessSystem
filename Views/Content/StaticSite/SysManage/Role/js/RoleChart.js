$(document).ready(function () {
    var title = {
        text: '角色表访问量统计'
    };
    var subtitle = {
        text: 'Source:Fbw.com'
    };
    var xAxis = {
        categories: ['6:00', '8:00', '10:00', '12:00', '14:00', '16:00', '18:00', '20:00', '22:00', '24:00', '2:00', '4:00']
    };
    var yAxis = {
        title: {
            text: '访问量(n/s)'
        },
        plotLines: [{
            value: 0,
            width: 1,
            color: '#808080'
        }]
    };

    var tooltip = {
        valueSuffix: '\xB0C'
    }

    var legend = {
        layout: 'vertical',
        align: 'right',
        verticalAlign: 'middle',
        borderWidth: 0
    };

    //根据数据库数据动态加载
    var series = [
        {
            name: '昨天',
            data: [7.0, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2,
                26.5, 23.3, 18.3, 13.9, 9.6]
        },
        {
            name: '今天',
            data: [-0.2, 0.8, 5.7, 11.3, 17.0, 22.0, 24.8,
                24.1, 20.1, 14.1, 8.6, 2.5]
        },
    ];

    var json = {};

    json.title = title;
    json.subtitle = subtitle;
    json.xAxis = xAxis;
    json.yAxis = yAxis;
    json.tooltip = tooltip;
    json.legend = legend;
    json.series = series;

    //屏幕可见区域高度
    var height = document.height;
    $('#container').css("height", height);
    $('#container').highcharts(json);
});