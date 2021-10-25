$(document).ready(function () {
    this.go = function () {
        var ctx = document.getElementById("canvas").getContext("2d");
        var radius = 100;
        var count = 13;
        for (var i = 0; i < count; i++) {
            ctx.beginPath();
            ctx.fillStyle = 'rgb(' + Math.floor(300 - 45 * i) + ', ' + Math.floor(50 + (2 * (i * -1))) + ',' + Math.floor(180 + 20 * i) + ')';
            ctx.moveTo(300, 300);

            ctx.arc(300, 300, radius, i * Math.PI / (count / 2), (i + 1) * ((Math.PI / (count / 2))), false);
            ctx.closePath();
            ctx.fill();
        }
    }
}