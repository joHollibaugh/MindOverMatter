// Lots O' Circles
//function onMouseDrag(event) {
//    var radius = event.delta.length / 2;
//    var circle = new Path.Circle(event.middlePoint, radius);
//    circle.fillColor = 'black';
//}
var Molecule = new Array();
var PointList = new Array();
var path;
var circle;
var prevCircle;
function onMouseDown(event) {
    path = new Path();
    path.strokeColor = 'black';
    circle = new Path.Circle(event.downPoint, 5);
    circle.fillColor = 'black';
    if (typeof prevCircle !== 'undefined') {
        var shortest;
        var distance;
        var point;
        for (var i = 0; i < PointList.length; i++) {
            
            distance = PointList[i].getDistance(event.downPoint);
            if (typeof shortest == 'undefined' || distance < shortest) {
                shortest = distance;
                point = PointList[i];
            }
        }
        path.add(event.downPoint, point);
    }
    PointList.push(event.downPoint);
    prevCircle = circle;
}