// //Lots O' Circles
//var i = 1;
//function onMouseDrag(event) {
//    var radius = event.delta.length / 2;
//    var circle = new Path.Circle(event.middlePoint, radius);

    //if (i % 2 === 0) {
    //    circle.fillColor = "#f64f59";
    //}
    //else if (i % 3 === 0) {
    //    circle.fillColor = '#c471ed';

    //}
    //else {
    //    circle.fillColor = "#12c2e9";
    //}
    //i+= 1;
    

//    circle.fillColor = '#' + Math.floor(Math.random() * 16777215).toString(16);
//}
var Molecule = new Array();
var PointList = new Array();
var path;
var circle;
var _circle;

var prevCircle;

$('input[id$="btnGetName"]').on('click', function () {
    getName(paper.Molecule);
}); 

function getName(Mol) {
    Mol.Neighbors = Mol.b;
    Mol.NodeID = Mol.ID;
    JSONModalPost("/Chemical/getMolecule", { input: JSON.stringify(Mol) } , successCallback);
    function successCallback(response) {
        var data = response;
        var name;
        switch (data){
            case 1:
                name = "Methane";
                break;
            case 2:
                name = "Ethane";
                break;
            case 3:
                name = "Propane";
                break;
            case 4:
                name = "Butane";
                break;
            case 5:
                name = "Pentane";
                break;
            case 6:
                name = "Hexane";
                break;
            case 7:
                name = "Octane";
                break;

        }
        showRating(data);
        colorMain();
    }
}

function showRating(data) {
    $('#modalContent').html(data);
    $('#modal-container').modal('show');
    bindEvents();
}

function bindEvents() {
    $('#close').on('click', function () {
        $('#modal-container').modal('hide');
    })
}

function colorMain() {
    debugger;
    var mainIDs = JSON.parse($('input[id$="MainChainJson"]').val());
    var pt;
    for (var i in mainIDs) {
           var C = Molecule.find(function (obj) {
                 return obj.ID === mainIDs[i][0];
        });
        pt = PointList.find(function (obj) {
            return obj.x === C.Loc.x && obj.y === C.Loc.y;
        });
        circle = new Path.Circle(pt, 7);
        circle.fillColor = "blue";
        }

    }


function onMouseDown(event) {
    path = new Path();
    path.strokeColor = '#00ff00';
    if (typeof prevCircle !== 'undefined') {
        var shortest;
        var distance;
        var point;
        var CRef;
        for (var i = 0; i < PointList.length; i++) {
            distance = PointList[i].getDistance(event.downPoint);
            if (distance <= 75) {
                if (typeof shortest == 'undefined' || distance < shortest) {
                    shortest = distance;
                    point = PointList[i];
                }
            }
        }
        if (typeof point !== 'undefined') {
            path.add(event.downPoint, point);


            CRef = Molecule.find(function (obj) {
                return obj.Loc.x === point.x && obj.Loc.y === point.y;
            });

            var C = { b: [CRef.ID], ID: "C" + Molecule.length, P: null, Loc: event.downPoint }
            Molecule.push(C);
            CRef.b.push(C.ID);
            circle = new Path.Circle(event.downPoint, 7);
            circle.fillColor = '#00ff00';
            PointList.push(event.downPoint);
            prevCircle = circle;
        }
    }
    else {
        circle = new Path.Circle(event.downPoint, 7);
        circle.fillColor = '#00ff00';
        prevCircle = circle;
        PointList.push(event.downPoint);
        var C = { b: new Array(), ID: "C" + event.count, P: null, Loc: event.downPoint };
        Molecule.push(C);

    }
    paper.Molecule = Molecule;
    paper.PointList = PointList;
}
$.ajaxSetup({
    global: false,
    type: "POST"
});







