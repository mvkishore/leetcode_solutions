public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        Dictionary<int, List<int>> requisites = new Dictionary<int, List<int>>();
        int[] indegree = new int[numCourses];
        for(int i=0; i<numCourses; i++)
            requisites.Add(i, new List<int>());
        
        foreach(var preReq in prerequisites){
            var a = preReq[0];
            var b = preReq[1];
            
            requisites[b].Add(a);
            indegree[a]++;
        }
        int[] res = new int[numCourses];
        Queue<int> queue = new Queue<int>();
        for(int i=0; i<numCourses; i++){
            if(indegree[i] == 0)
                queue.Enqueue(i);
        }
        int c = 0;
        while(queue.Count > 0){
            var course = queue.Dequeue();
            res[c++] = course;
            foreach(var next in requisites[course]){
                indegree[next]--;
                if(indegree[next] == 0)
                    queue.Enqueue(next);
            }
        }
        
        if(c == numCourses) return res;
        return new int[0];
    }
}