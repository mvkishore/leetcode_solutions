public class LFUCache {
    Dictionary<int, LinkedListNode<(int key, int val)>> cacheValues;
    Dictionary<int, int> cacheFrequency;
    Dictionary<int, LinkedList<(int key, int val)>> cacheLists;
    int size;
    int minFrequency = 1;

    public LFUCache(int capacity) {
        cacheValues = new Dictionary<int, LinkedListNode<(int, int)>>();
        cacheFrequency = new Dictionary<int, int>();
        cacheLists = new Dictionary<int, LinkedList<(int, int)>>();
        cacheLists.Add(1, new LinkedList<(int, int)>());
        size = capacity;
    }
    
    public int Get(int key) {
        if(!cacheValues.ContainsKey(key))
            return -1;
        
        var node = cacheValues[key];
        var freq = cacheFrequency[key];
        var list = cacheLists[freq];
        
        list.Remove(node);
        cacheFrequency.Remove(key);
        cacheValues.Remove(key);
        if(!cacheLists.ContainsKey(freq + 1))
            cacheLists.Add(freq + 1, new LinkedList<(int, int)>());
        
        if(freq == minFrequency && list.Count == 0)
            minFrequency++;
        
        list = cacheLists[freq + 1];
        node = new LinkedListNode<(int,int)>((node.Value.key, node.Value.val));
        list.AddFirst(node);
        cacheValues.Add(key, node);
        cacheFrequency.Add(key, freq + 1);
        
        return node.Value.val;
    }
    
    public void Put(int key, int value) {
        if(size == 0)
            return;
        
        var newNode = new LinkedListNode<(int, int)>((key, value));
        if(cacheValues.ContainsKey(key)){
            Get(key);
            var freq = cacheFrequency[key];
            var list = cacheLists[freq];
            var oldNode = cacheValues[key];
            
            list.Remove(oldNode);
            list.AddFirst(newNode);
            cacheValues.Remove(key);
            cacheValues.Add(key, newNode);
        } else {
            if(cacheValues.Count == size){
                var lfList = cacheLists[minFrequency];
                var last = lfList.Last;
                
                lfList.RemoveLast();
                cacheValues.Remove(last.Value.key);
                cacheFrequency.Remove(last.Value.key);
            }
            
            var list = cacheLists[1];
            minFrequency = 1;
            list.AddFirst(newNode);
            cacheValues.Add(key, newNode);
            cacheFrequency.Add(key, 1);
        }
    }
}

/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */