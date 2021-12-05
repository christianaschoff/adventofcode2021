// See https://aka.ms/new-console-template for more information


var src = Source.Depth;
var deepest = src.Aggregate((p, q) => q.CompareTo(q) > 0 ? p : q);

var deeper = 0;
for(int i = 1; i < src.Length; i++) {
    if(src[i-1] < src[i]) {
        deeper++;
    }
}

var slidingWindow = 0;
for(int i = 3; i < src.Length; i++) {
    var firstWindow = src[i-3] + src[i-2] + src[i-1];
    var currentWindow = src[i-2] + src[i-1] + src[i];
    if(firstWindow < currentWindow) {
        slidingWindow++;
    }
}



Console.WriteLine("Dips down {0} slidingWindow {1} deepest: {2}", deeper, slidingWindow, deepest);
