public class Solution {
    public class Point : IComparable<Point> {
        public int X;
        public int Y;
        
        public bool IsStart;
        
        public Point(int x, int y, bool start){
            X = x;
            Y = y;
            IsStart = start;
        }
        
        public int CompareTo(Point p)
        {
            if(p.X != this.X)
                return X - p.X;
            
            if(this.IsStart && p.IsStart)
                return p.Y - this.Y;
            if(!this.IsStart && !p.IsStart)
                return this.Y - p.Y;
            
            if(this.IsStart)
                return -1;
            else
                return 1;
        }
    }
    public IList<IList<int>> GetSkyline(int[][] buildings) {
        var points = GetSortedPoints(buildings);
        
        SortedSet<(int height, int indx)> heap = new SortedSet<(int height, int indx)>();
        Dictionary<int, List<int>> heapElements = new Dictionary<int, List<int>>();
        IList<IList<int>> result = new List<IList<int>>();

        int curHeight = 0, i=0;
        heap.Add((0, i));
        
        foreach(var point in points){
            if(point.IsStart){
                if(!heapElements.ContainsKey(point.Y))
                    heapElements.Add(point.Y, new List<int>());

                heapElements[point.Y].Add(++i);
                heap.Add((point.Y, i));
            }else {
                var list = heapElements[point.Y];
                var lastIndx = list.Count - 1;
                heap.Remove((point.Y, list[lastIndx]));
                list.RemoveAt(lastIndx);
            }
            
            int maxHeight = heap.Max.height;
            if(curHeight != maxHeight){
                result.Add(new List<int> {point.X, maxHeight});
                curHeight = maxHeight;
            }
        }
        
        return result;
    }
    
    private List<Point> GetSortedPoints(int[][] buildings)
    {
        List<Point> points = new List<Point>();
        foreach(var building in buildings){
            int startX = building[0], endX = building[1];
            int height = building[2];
            points.Add(new Point(startX, height, true));
            points.Add(new Point(endX, height, false));
        }
        
        points.Sort();
        return points;
    }
}