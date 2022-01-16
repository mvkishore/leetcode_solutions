public class LRUCache {
    Dictionary<int, LinkedListNode<(int key, int val)>> cache;
    LinkedList<(int key, int val)> list;
    int size;
    int capacity;
    public LRUCache(int capacity) {
        cache = new Dictionary<int, LinkedListNode<(int key, int val)>>(capacity);
        this.capacity = capacity;
        list = new LinkedList<(int key, int val)>();
        this.size = 0;
    }
    
    public int Get(int key) {
        if(!cache.ContainsKey(key))
            return -1;
        
        var node = cache[key];
        list.Remove(node);
        
        list.AddFirst(new LinkedListNode<(int key, int val)>((key, node.Value.val)));
        cache[key] = list.First;
        return node.Value.val;
    }
    
    public void Put(int key, int value) {
        var newNode = new LinkedListNode<(int key, int val)>((key, value));
        
        if(cache.ContainsKey(key)) {
            var node = cache[key];
            list.Remove(node);
        } 
        else if(size == capacity){
            var last = list.Last;
            list.Remove(list.Last);
            cache.Remove(last.Value.key);
        }
        else size++;

        list.AddFirst(newNode);
        cache[key] = list.First;
    }
    
    
    
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */