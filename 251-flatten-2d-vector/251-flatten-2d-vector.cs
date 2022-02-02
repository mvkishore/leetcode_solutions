public class Vector2D {
    List<int> vector;
    int cur = 0;
    public Vector2D(int[][] vec) {
        vector = new List<int>();
        foreach(var v in vec){
            foreach(var ele in v)
                vector.Add(ele);
        }
    }
    
    public int Next() {
        if(HasNext()){
            var val = vector[cur++];
            return val;
        }
        return -1;
    }
    
    public bool HasNext() {
        return cur < vector.Count;
    }
}

/**
 * Your Vector2D object will be instantiated and called as such:
 * Vector2D obj = new Vector2D(vec);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */