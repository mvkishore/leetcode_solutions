public class HitCounter {
    int count = 0;
    LinkedList<(int time, int count)> list;
    public HitCounter() {
        list = new LinkedList<(int time, int count)>();
    }
    
    public void Hit(int timestamp) {
        while(list.Count > 0 && timestamp - list.First.Value.time > 300){
            count = count - list.First.Value.count;
            list.RemoveFirst();
        }
        int cnt = 1;
        if(list.Count > 0 && list.Last.Value.time == timestamp){
            cnt += list.Last.Value.count;
            list.RemoveLast();
        }
        
        list.AddLast(new LinkedListNode<(int time, int count)>((timestamp, cnt)));
        count++;
    }
    
    public int GetHits(int timestamp) {
        while(list.Count > 0 && timestamp - list.First.Value.time >= 300){
            count = count - list.First.Value.count;
            list.RemoveFirst();
        }
        return count;
    }
}

/**
 * Your HitCounter object will be instantiated and called as such:
 * HitCounter obj = new HitCounter();
 * obj.Hit(timestamp);
 * int param_2 = obj.GetHits(timestamp);
 */