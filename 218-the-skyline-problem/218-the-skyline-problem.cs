public class Solution {
    public class Point {
        public int x;
        public int y;
        public bool IsStart;
        
        public Point(int x, int y, bool start){
            this.x = x;
            this.y = y;
            this.IsStart = start;
        }
    }
    public IList<IList<int>> GetSkyline(int[][] buildings) {
        var points = GetAllPoints(buildings);
        SortedSet<(int height, int indx)> heightsHeap = new SortedSet<(int height, int indx)>();
        
        int i =0;
        heightsHeap.Add((0, i));
        int curHeight = 0;
        IList<IList<int>> result = new List<IList<int>>();
        Dictionary<int, List<int>> elements = new Dictionary<int, List<int>>();
        
        foreach(var point in points){
            // Console.WriteLine($"{point.y}");
            if(point.IsStart){
                if(!elements.ContainsKey(point.y))
                    elements.Add(point.y, new List<int>());
                elements[point.y].Add(++i);
                heightsHeap.Add((point.y, i));
            }else {
                var list = elements[point.y];
                int last = list.Count - 1;
                
                heightsHeap.Remove((point.y, list[last]));
                list.RemoveAt(last);
            }
            
            var maxHeight = heightsHeap.Max.height;
            // Console.WriteLine($"{curHeight} -- {maxHeight}");
            if(curHeight != maxHeight){
                result.Add(new List<int>{point.x, maxHeight});
                curHeight = maxHeight;
            }
        }
        
        return result;
    }
    
    private List<Point> GetAllPoints(int[][] buildings){
        List<Point> points = new List<Point>();
        foreach(var building in buildings){
            int startX = building[0];
            int endX = building[1];
            int y = building[2];
            
            points.Add(new Point(startX, y, true));
            points.Add(new Point(endX, y, false));
        }
        
        points.Sort((a, b) => {
            if(a.x != b.x) 
               return a.x - b.x;
            
            //Consider larger height between same starts
            if(a.IsStart && b.IsStart)
                return b.y - a.y;
            //Consider shorter height between same ends
            if(!a.IsStart && !b.IsStart)
                return a.y - b.y;
            //Consider start over end between same start and end position
            if(a.IsStart)
                return -1;
            else
                return 1;
        });
        
        // foreach(var point in points){
        //     Console.WriteLine($"{point.x} - {point.y}");
        // }
        return points;
    }
}