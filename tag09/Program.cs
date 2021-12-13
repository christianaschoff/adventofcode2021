
var toProcess = ReadInput("sample.txt");

List<int> result = new List<int>();
for(var i = 0; i < toProcess.Count(); i++)
 {     
    for(var j = 0; j < toProcess[i].Length; j++)
    {        
        if(isLocalLowpoint(toProcess, i, j)) 
        {
            result.Add(toProcess[i][j]);
        }        
    }    
}

Console.WriteLine($"low items {result.Sum(x => ++x)}");

bool isLocalLowpoint(List<int[]> coords, int row, int col) 
{   
    var toCheck = coords[row][col];
    var siblings = new List<int>();
    
    bool xMinus1 = col > 0 ? toCheck < coords[row][col-1] : true;
    bool xPlus1 = col < coords[row].Length-1 ? toCheck < coords[row][col+1] : true;    
    if(row == 0)
    {                                
        bool x = toCheck < coords[row+1][col];    
        return xMinus1 && x && xPlus1;
    } 
    else if(row == coords.Count() -1)
    {        
        bool x = toCheck < coords[row-1][col];        
        return xMinus1 && x && xPlus1;
    }
    else 
    {        
        bool xyMinus1 = toCheck < coords[row-1][col];
        bool xyPlus1 = toCheck < coords[row+1][col];             
        return xMinus1 && xyMinus1 && xyPlus1 && xPlus1;

    }    
}

List<int[]> ReadInput(string filename)
{
    List<int[]> retVal = new List<int[]>();    
    foreach(var line in File.ReadLines(filename)) 
    {
        retVal.Add(line.ToIntList());
    }
    return retVal;
}

public static class Extensions 
{
    public static int[] ToIntList (this string input) 
    {        
        var retList = new int[input.Length];
        var chars = input.ToCharArray() ;
        for(int i = 0; i < input.Length; i++)
        {
            retList[i] = (int.Parse(chars[i].ToString()));
        }
        return retList;
    }
}
