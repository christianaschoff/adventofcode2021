var bingonumbers = new List<int> {13,47,64,52,60,69,80,85,57,1,2,6,30,81,86,40,27,26,97,77,70,92,43,94,8,78,3,88,93,17,55,49,32,59,51,28,33,41,83,67,11,91,53,36,96,7,34,79,98,72,39,56,31,75,82,62,99,66,29,58,9,50,54,12,45,68,4,46,38,21,24,18,44,48,16,61,19,0,90,35,65,37,73,20,22,89,42,23,15,87,74,10,71,25,14,76,84,5,63,95};
// var bingonumbersSample = new List<int> {7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1};
var toProcess = ReadInput("input.txt"); 

var sumOfWinningBoard = SumOfWinningBoard(toProcess, bingonumbers);
Console.WriteLine($"Sum of winning board: {sumOfWinningBoard}");

var sumOfLosingBoard = SumOfLosingBoard(toProcess, bingonumbers);
Console.WriteLine($"Sum of losing board: {sumOfLosingBoard}");


int SumOfLosingBoard(List<int[,]> boards, List<int> bingonumbers) 
{
    var gameState = GenerateBitField(toProcess.Count);
    var outList = GenerateOutField(toProcess.Count);

    foreach(var number in bingonumbers) 
    {        
        foreach(var board in boards) 
        {            
            for(int i = 0; i < 5; i++) 
            {                
                for(int j = 0; j < 5; j++) 
                {                    
                    if(board[i, j] == number) 
                    {     
                        var indexOfBoard = boards.IndexOf(board);
                        gameState[indexOfBoard][i, j] = 1;
                        var gameStateBoard = gameState[indexOfBoard];                        
                        if(CheckWinRow(gameStateBoard, i) || CheckWinCol(gameStateBoard, j))
                        {   
                            outList[indexOfBoard] = true;                            
                        }
                        if(outList.Count(x => x == false) == 0) 
                        {                            
                            PrintBoard(gameState[indexOfBoard], boards[indexOfBoard]);
                            return SumOfUnhitFields(gameState[indexOfBoard], boards[indexOfBoard]) * number;
                        }
                    }   
                }                                                   
            }
        }
    }
    return -1;
}

int SumOfWinningBoard(List<int[,]> boards, List<int> bingonumbers) {
    var gameState = GenerateBitField(toProcess.Count);

    foreach(var number in bingonumbers) 
    {    
        foreach(var board in boards) 
        {            
            for(int i = 0; i < 5; i++) 
            {
                bool hit = false;
                for(int j = 0; j < 5; j++) 
                { 
                    if(board[i, j] == number) 
                    {                         
                        gameState[boards.IndexOf(board)][i, j] = 1;
                        var gameStateBoard = gameState[boards.IndexOf(board)];
                        hit = true;
                        /*if(CheckWinRow(gameStateBoard, i)) 
                        {                             
                            PrintBoard(gameStateBoard, board);
                            return GetSumRow(board, i) * number;
                        } 
                        else if(CheckWinCol(gameStateBoard, j)) 
                        {
                            PrintBoard(gameStateBoard, board);
                            return GetSumCol(board, j) * number;
                        }*/
                        if(CheckWinRow(gameStateBoard, i) || CheckWinCol(gameStateBoard, j))
                        {
                            Console.WriteLine("done");
                            PrintBoard(gameStateBoard, board);                            
                            return SumOfUnhitFields(gameStateBoard, board) * number;
                        }

                    }   
                    if(hit)
                    break;
                }
                if(hit)
                break;                                     
            }
        }
    }
    return -1;
}

int SumOfUnhitFields(int[,] gameStateBoard, int[,] board)
{
    int sum = 0;
    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 5; j++)
        {            
            if(gameStateBoard[i,j] == 0) {
                sum += board[i,j];
            }
        }        
    }    
    return sum;
}

void PrintBoard(int[,] mask, int[,] board)
{
    Console.WriteLine("Mask:");
    for(var i =0; i < 5; i++) 
    {
        for(var j =0; j < 5; j++) 
        {
            Console.Write(" " + mask[i,j]);
        }
        Console.WriteLine("");
    }

    Console.WriteLine("Board:");
    for(var i =0; i < 5; i++) 
    {
        for(var j =0; j < 5; j++) 
        {
            Console.Write(" " + board[i,j]);
        }
        Console.WriteLine("");
    }    
}

bool CheckWinRow(int[,] board, int row) {

    for(int i =0; i < 5; i++)
    {
        if(board[row, i] != 1)  
        {
            return false;
        }
    }
    return true;
}

bool CheckWinCol(int[,] board, int col) {

    for(int i =0; i < 5; i++)
    {        
        if(board[i, col] != 1)  
        {
            return false;
        }
    }
    return true;
}

List<bool> GenerateOutField(int anzahl) {
    var returnList = new List<bool>();
    for(int i = 0; i < anzahl; i++) 
    {
        returnList.Add(false);
    }
    return returnList;
}

List<int[,]> GenerateBitField(int anzahl) {
    var retlist = new List<int[,]>();
    for(int i = 0; i < anzahl; i++) 
    {
        retlist.Add(new int [5, 5]);
    }
    return retlist;
}

List<int[,]> ReadInput(string filename)
{
    var retlist = new List<int[,]>();
    var matrix = new int [5, 5];
    var lineCnt = 0;
    foreach(var line in File.ReadLines(filename).Where(x => x != String.Empty)) 
    {    
        matrix[lineCnt, 0] = int.Parse(line.Substring(0, 2));
        matrix[lineCnt, 1] = int.Parse(line.Substring(3, 2));    
        matrix[lineCnt, 2] = int.Parse(line.Substring(6, 2));    
        matrix[lineCnt, 3] = int.Parse(line.Substring(9, 2));
        matrix[lineCnt, 4] = int.Parse(line.Substring(12, 2));
        if(lineCnt == 4) {
            retlist.Add(matrix);
            matrix = new int [5, 5];
            lineCnt = 0;
        } 
        else 
        {        
            lineCnt++;
        }       
    }
    return retlist;
}

/* some nice other perspectives
int GetSumCol(int[,] board, int colToSkip)
{
    int result = 0;
    for(int i=0; i < 5; i++)
    {        
        for(int j = 0; j <5; j++) 
        {
            if(j != colToSkip) 
            {
              result += board[i, j];
            }
        }
    }
    Console.WriteLine(result);
    return result;    
}

int GetSumRow(int[,] board, int rowToSkip)
{
    int result = 0;
    for(int i=0; i < 5; i++)
    {       
        if(i != rowToSkip)  {            
            for(int j = 0; j <5; j++) 
            {            
                result += board[i, j];
            }
        }
    }
    Console.WriteLine(result);
    return result; 
}
*/
