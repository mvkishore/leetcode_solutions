public class LRUCache {
    LinkedList<(int val, int key)> list;
    Dictionary<int, LinkedListNode<(int val, int key)>> cache;
    int capacity;
    int size;
    
    public LRUCache(int capacity) {
        cache = new Dictionary<int, LinkedListNode<(int, int)>>();
        this.capacity = capacity;
        list = new LinkedList<(int val, int key)>();
        size = 0;
    }
    
    public int Get(int key) {
        if(!cache.ContainsKey(key))
            return -1;
        var node = cache[key];
        list.Remove(node);
        list.AddFirst(node);
        return node.Value.val;
    }
    
    public void Put(int key, int value) {
        var newNode = new LinkedListNode<(int, int)>((value, key));
        if(cache.ContainsKey(key)){
            var node = cache[key];
            list.Remove(node);
            cache.Remove(node.Value.key);
        }else{
            size++;
            if(size > this.capacity){
                var last = list.Last;
                list.RemoveLast();
                cache.Remove(last.Value.key);
                size--;
            }
            
        }
        list.AddFirst(newNode);
        cache.Add(key, newNode);
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */