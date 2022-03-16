public class SnapshotArray {
    
    int curSnapId = 0;
    Dictionary<int, Dictionary<int, int>> data;

    public SnapshotArray(int length) {
        data = new Dictionary<int, Dictionary<int, int>>();
    }
    
    public void Set(int index, int val) {
        if(!data.ContainsKey(curSnapId))
            data.Add(curSnapId, new Dictionary<int, int>());
        
        data[curSnapId][index] = val;
    }
    
    public int Snap() {
        int val = curSnapId;
        curSnapId++;
        return val;
    }
    
    public int Get(int index, int snap_id) {
        while(snap_id >= 0 && (!data.ContainsKey(snap_id) || !data[snap_id].ContainsKey(index)))
            snap_id--;
        
        if(snap_id < 0)
            return 0;
        
        return data[snap_id][index];
    }
}
/*
[5, 0, 0] --- 
[6, 0, 0] --- 
[0, 0, 0] ->   [0 -> 0-> 5]
[1, 0, 0] -->  [1 -> {(0-> 0), (1->6)}]



*/


/**
 * Your SnapshotArray object will be instantiated and called as such:
 * SnapshotArray obj = new SnapshotArray(length);
 * obj.Set(index,val);
 * int param_2 = obj.Snap();
 * int param_3 = obj.Get(index,snap_id);
 */