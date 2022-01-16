public class LRUCache {
    Dictionary<int, Node> cache;
    Node head, tail;
    int size;
    int capacity;
    public LRUCache(int capacity) {
        cache = new Dictionary<int, Node>(capacity);
        this.capacity = capacity;
        
        head = new Node(0, 0);
        tail = new Node(0, 0);
        
        head.next = tail;
        tail.prev = head;
        
        this.size = 0;
    }
    
    private void AddFirst(Node node){
        var next = head.next;
        
        head.next = node;
        node.next = next;
        
        next.prev = node;
        node.prev = head;
    }
    
    private void Remove(Node node)
    {
        var next = node.next;
        var prev = node.prev;
        
        next.prev = prev;
        prev.next = next;
    }
    
    private Node RemoveLast()
    {
        var last = tail.prev;
        Remove(last);
        return last;
    }
    
    private void MoveToFirst(Node node)
    {
        Remove(node);
        AddFirst(node);
    }
    
    public int Get(int key) {
        if(!cache.ContainsKey(key))
            return -1;
        var node = cache[key];
        MoveToFirst(node);
        return node.value;
    }
    
    public void Put(int key, int value) {
        if(cache.ContainsKey(key))
        {
            var node = cache[key];
            node.value = value;
            MoveToFirst(node);
        } else {
            var node = new Node(key, value);
            if(size == capacity){
                var last = RemoveLast();
                cache.Remove(last.key);
            }
            else size++;
            AddFirst(node);
            cache.Add(key, node);
        }
    }
    
    public class Node
    {
        public int key;
        public int value;
        public Node prev;
        public Node next;
        
        public Node(int key, int value)
        {
            this.key = key;
            this.value = value;
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */