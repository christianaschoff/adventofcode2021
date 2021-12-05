
var lst = Source.Coords;
var xAxis = lst.Where(x => x.Direction == DIRECTION.FORWARD).Sum(x => x.Step);
var yAxis = lst.Where(x => x.Direction == DIRECTION.DOWN).Sum(x => x.Step) - lst.Where(x => x.Direction == DIRECTION.UP).Sum(x => x.Step);
var result = xAxis * yAxis;
Console.WriteLine($"xAxis: {xAxis} yAxis: {yAxis} Result: {result}");


var forward = 0;
var depth = 0;
var aim = 0;

foreach(var position in lst) 
{
    if(position.Direction == DIRECTION.FORWARD) 
    {
        forward += position.Step;
        depth += position.Step * aim;
    }
    else 
    {
        aim += position.Direction == DIRECTION.UP ? position.Step  * -1: position.Step;
    }                                            
}

var resultAim = forward * depth;

Console.WriteLine($"forward: {forward} depth: {depth} aim: {aim} result: {resultAim}");