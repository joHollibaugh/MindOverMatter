// Lots O' Circles
//function onMouseDrag(event) {
//    var radius = event.delta.length / 2;
//    var circle = new Path.Circle(event.middlePoint, radius);
//    circle.fillColor = 'black';
//}
var Molecule = new Array();
var CList = new Array();
var path;
var circle;
var prevCircle;
function onMouseDown(event) {
    path = new Path();
    path.strokeColor = 'black';
    circle = new Path.Circle(event.downPoint, 5);
    circle.fillColor = 'black';
    CList.push(circle);
    path.add(event.downPoint, event.lastPoint);
    //if (typeof prevCircle !== 'undefined') {
    //    var shortest;
    //    var point;
    //    for (var i = 0; i < CList.length; i++) {

    //        Tshortest = CList[i].bounds.centerX + CList[i].bounds.centerY;
    //        if (typeof shortest == 'undefined' || Tshortest < shortest) {
    //            shortest = Tshortest;
    //            point = { x: CList[i].bounds.centerX, y: CList[i].bounds.centerY };
    //        }
    //    }
    //    path.add(new Path.Line(event.downPoint, new Point(point.x,point.y)));
    //    Cist.add('b');
    //}
    //prevCircle = circle;
}