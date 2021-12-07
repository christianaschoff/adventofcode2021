
var toProcess = BuildHorizontalVerticalCoords("input.txt");
Console.WriteLine($"{toProcess.Count }");
var result = toProcess.GroupBy(a => new { x = a.x, y = a.y } )
                      .Select(a => Tuple.Create(a.Key, a.Count()));
Console.WriteLine($" Dangerous Grounds: {result.Count(x => x.Item2 > 1)}");

 List<CoordField> BuildHorizontalVerticalCoords(string filename) 
 {    
    var retList = new List<CoordField>();
    foreach(var line in File.ReadLines(filename))
    {
        var coords = line.Split(" -> ");
        var x = int.Parse(coords[0].Split(",")[0]);
        var y = int.Parse(coords[0].Split(",")[1]);
        var x2 = int.Parse(coords[1].Split(",")[0]);
        var y2 = int.Parse(coords[1].Split(",")[1]);

        if(x == x2) 
        {
            foreach(var a in (y > y2 ? Enumerable.Range(y2, y-y2+1) : Enumerable.Range(y, y2-y+1)))
                retList.Add(new CoordField(x,  a));      
        }        
        if(y == y2) 
        {
            foreach(var a in (x > x2 ? Enumerable.Range(x2, x-x2+1) : Enumerable.Range(x, x2-x+1)))
                retList.Add(new CoordField(a,  y));  
        }        
    }    
    return retList;
 }
  
 public class CoordField
 {
     public int x { get; set; }
     public int y { get; set; }
     public CoordField(int x, int y)
     {
         this.x = x;
         this.y = y;
     }

     public override string ToString()
     {
         return $"{this.x}, {this.y}";
     }
 }