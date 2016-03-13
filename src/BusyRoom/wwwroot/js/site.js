// Write your Javascript code.




var now = new Date().getTime();

var states = [];
var dates = [];
var occupied = [];

var chartOptions = {
    low: 0,
    high: 1,
    showArea: true,
    axisY: {
        onlyInteger: true,
    },
    lineSmooth: Chartist.Interpolation.step(),
    showPoint: false
}

// Assuming you have referenced jQuery
$(function() {
    $.getJSON("/api/rooms/Arduino/states", function(response) {
        states = response;

        dates = $.map(states, function (el) {
            var date = new Date(el.createdOn).getTime() - now;
            return Math.round(date / 60000);
            
        });

        occupied = $.map(states, function (el) {
            return el.isOccupied ? 1 : 0;
        });

        var data = {
            labels: dates.slice(Math.max(dates.length - 30)),
            series: [
                occupied.slice(Math.max(occupied.length - 30))
            ]
    };

        new Chartist.Line('#chart1', data, chartOptions);
    });

});