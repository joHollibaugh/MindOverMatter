﻿// Lots O' Circles
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
    debugger;
    path = new Path();
    path.strokeColor = 'black';
    if (typeof prevCircle !== 'undefined') {
        var shortest;
        var distance;
        var point;
        var CRef;
        for (var i = 0; i < PointList.length; i++) {
            distance = PointList[i].getDistance(event.downPoint);
            if (distance <= 50) {
                if (typeof shortest == 'undefined' || distance < shortest) {
                    shortest = distance;
                    point = PointList[i];
                }
            }
        }
        if (typeof point !== 'undefined') {
            path.add(event.downPoint, point);
            //CRef = Molecule.find(obj => {
            //    return obj.P === point;
            //});
            var C = { b: [CRef.ID], ID: "C" + event.count, P: event.downPoint }
            Molecule.push(C);
            CRef.b.push(C.ID);
            circle = new Path.Circle(event.downPoint, 5);
            circle.fillColor = 'black';
            PointList.push(event.downPoint);
            prevCircle = circle;

        }
    }
    else {
        debugger;
            circle = new Path.Circle(event.downPoint, 5);
            circle.fillColor = 'black';
            prevCircle = circle;
        PointList.push(event.downPoint);
        var C = { b: new Array(), ID: "C" + event.count, P: null, Loc: event.downPoint}
        Molecule.push(C);

    }
}