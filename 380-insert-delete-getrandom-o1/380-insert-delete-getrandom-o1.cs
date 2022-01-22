public class RandomizedSet {
    Dictionary<int, int> data;
    List<int> list;
    Random r;
    public RandomizedSet() {
        data = new Dictionary<int, int>();
        list = new List<int>();
        r = new Random();
    }
    
    public bool Insert(int val) {
        if(data.ContainsKey(val))
           return false;
        data.Add(val, list.Count);
        list.Add(val);
        return true;
    }
    
    public bool Remove(int val) {
        if(data.ContainsKey(val)){
            var index = data[val];
            data.Remove(val);
            
            var last = list[list.Count - 1];
            if(index != list.Count - 1){
                list[index] = last;
                data[last] = index;
            }
            
            list.RemoveAt(list.Count - 1);
            return true;
        }
        return false;
    }
    
    public int GetRandom() {
        int i = r.Next(list.Count);
        return list[i];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */