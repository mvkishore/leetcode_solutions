public class LFUCache {
    Dictionary<int, LinkedListNode<(int key, int val)>> cacheValues;
    Dictionary<int, int> cacheFrequency;
    Dictionary<int, LinkedList<(int key, int val)>> cacheLinkedLists;
    int minFrequency = 1;
    int size;

    public LFUCache(int capacity) {
        cacheValues = new Dictionary<int, LinkedListNode<(int key, int val)>>();
        cacheFrequency = new Dictionary<int, int>();
        cacheLinkedLists = new Dictionary<int, LinkedList<(int key, int val)>>();
        cacheLinkedLists.Add(1, new LinkedList<(int, int)>());
        size = capacity;
    }
    
    public int Get(int key) {
        if(!cacheValues.ContainsKey(key))
            return -1;
        
        var node = cacheValues[key];
        var freq = cacheFrequency[key];
        var list = cacheLinkedLists[freq];
        
        list.Remove(node);
        cacheFrequency.Remove(key);
        cacheFrequency.Add(key, freq + 1);
        
        if(freq == minFrequency && list.Count == 0)
            minFrequency++;
        
        if(!cacheLinkedLists.ContainsKey(freq + 1))
            cacheLinkedLists[freq + 1] = new LinkedList<(int key, int val)>();
        
        list = cacheLinkedLists[freq+1];
        var updateNode = new LinkedListNode<(int, int)>((node.Value.key, node.Value.val));
        list.AddFirst(updateNode);
        cacheValues[key] = updateNode;
        
        return node.Value.val;
    }
    
    public void Put(int key, int value) {
        if(size == 0)
            return;
        
        var newNode = new LinkedListNode<(int, int)>((key, value));
        if(cacheValues.ContainsKey(key))
        {
            Get(key);
            var list = cacheLinkedLists[cacheFrequency[key]];
            var node = cacheValues[key];
            list.Remove(node);
            
            list.AddFirst(newNode);
            cacheValues[key] = newNode;
        }else{
            if(cacheValues.Count == size){
                var lfList = cacheLinkedLists[minFrequency];
                var last = lfList.Last;
                
                lfList.RemoveLast();
                cacheValues.Remove(last.Value.key);
                cacheFrequency.Remove(last.Value.key);
            }
            
            var list = cacheLinkedLists[1];
            list.AddFirst(newNode);
            cacheValues[key] = newNode;
            cacheFrequency[key] = 1;
            minFrequency = 1;
        }
    }
}

/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */