var toProcess = ReadInput("input.txt");
var mask = new List<int>() {2, 3, 4, 7};

var result = 0;
toProcess.ForEach(x => {
    result += x.output.Where(y => mask.Contains(y.Length)).Count();
});
Console.WriteLine($"{result}");

List<(string[] input, string[] output)> ReadInput(string filename)
{
    List<(string[] left, string[] right)> returnVal = new List<(string[] left, string[] right)>();
    foreach(var line in File.ReadLines(filename)) 
    {
        var segment = line.Split("|");
        returnVal.Add((segment[0].Trim().Split(" "), segment[1].Trim().Split(" ")));
    }
    return returnVal;
}
