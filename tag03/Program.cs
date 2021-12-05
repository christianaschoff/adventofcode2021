var toProcess = new List<char[]>(); 
foreach(var line in File.ReadAllLines("input.txt")) 
{
    toProcess.Add(line.Trim().ToCharArray());
}

var gammaEpsilon = CalculateGammaEpsilon(toProcess);
var resultGammaEpsilonInt = IntFromBinary(gammaEpsilon);
Console.WriteLine($"Gamma {gammaEpsilon.Gamma} Epsilon: {gammaEpsilon.Epsilon}");
Console.WriteLine($"Gamma {resultGammaEpsilonInt.One} Epsilon: {resultGammaEpsilonInt.Two}");
Console.WriteLine($"PowerConsumption: {resultGammaEpsilonInt.One * resultGammaEpsilonInt.Two}");

var oxyScrubber = CalculateOxygenScrubber(toProcess);
var resultOxyScrubberInt = IntFromBinary(oxyScrubber);
Console.WriteLine($"Oxygen: {oxyScrubber.Oxygen} Scrubber: {oxyScrubber.Scrubber}");
Console.WriteLine($"Oxygen: {resultOxyScrubberInt.One} Scrubber: {resultOxyScrubberInt.Two}");
Console.WriteLine($"LifeSupportRating: {resultOxyScrubberInt.One * resultOxyScrubberInt.Two}");


(string Gamma, string Epsilon) CalculateGammaEpsilon(List<char[]> lst) 
{    
    var index = lst[0].Length;
    var gamma = "";
    var epsilon = "";
    for(var i = 0; i < index; i++) 
    {                    
        if(lst.Count(x =>x[i] == '1') > lst.Count(x =>x[i] == '0')) 
        {
            gamma += "1";
            epsilon += "0";
        }
         else 
        {
            gamma += "0";
            epsilon += "1";
        }
    }
    return (gamma, epsilon);
}

(string Oxygen, string Scrubber) CalculateOxygenScrubber(List<char[]> lst) 
{
    var oxygen = Oxygen(lst, 0);
    var scrubber = Scrubber(lst, 0);    
    return (oxygen, scrubber);
}

string Scrubber(IEnumerable<char[]> lst, int position) 
{
    var filterOne = lst.Where(x => x[position] == '1');
    var filterZero = lst.Where(x => x[position] == '0');
   
    if(filterZero.Count() <= filterOne.Count()) 
    { 
        if(filterZero.Count() == 1) {
            return new string(filterZero.First());
        }
    }
    else if(filterOne.Count() == 1) 
    { 
        return new String(filterOne.First());
    }

    return filterZero.Count() <= filterOne.Count() ? Scrubber(filterZero.ToList(), ++position) : Scrubber(filterOne.ToList(), ++position);
}

string Oxygen(IEnumerable<char[]> lst, int position) 
{   
    var filterOne = lst.Where(x => x[position] == '1');
    var filterZero = lst.Where(x => x[position] == '0');

    if(filterOne.Count() >= filterZero.Count()) 
    { 
        if(filterOne.Count() == 1) 
        {            
            return new string(filterOne.First());
        }
    }
    else if(filterZero.Count() == 1) 
    {         
        return new String(filterZero.First());
    }

    return filterOne.Count() >= filterZero.Count() ? Oxygen(filterOne.ToList(), ++position) : Oxygen(filterZero.ToList(), ++position);
}

(int One, int Two) IntFromBinary((string one, string two) input) 
{
    return (Convert.ToInt32(input.one, 2), Convert.ToInt32(input.two, 2));
}

/*
void Print(IEnumerable<char[]> lst) {
    foreach(var l in lst) {
        Console.WriteLine(new String(l));
    }
}
*/