public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        int[] preReqs = new int[numCourses];
        
        for(int i=0; i<prerequisites.Length; i++){
            var courseA = prerequisites[i][0];
            var courseB = prerequisites[i][1];
            
            if(!graph.ContainsKey(courseB))
                graph.Add(courseB, new List<int>());
            
            graph[courseB].Add(courseA);
            preReqs[courseA]++;
        }
        
        int[] results = new int[numCourses];
        Queue<int> leaves = new Queue<int>();
        int c=0;
        for(int i=0; i<numCourses; i++){
            if(preReqs[i] == 0){
                leaves.Enqueue(i);
            }
        }
        
        while(leaves.Count > 0){
            var curCourse = leaves.Dequeue();
            results[c++] = curCourse;
            
            if(!graph.ContainsKey(curCourse)) continue;
            
            foreach(var dep in graph[curCourse]){
                preReqs[dep]--;
                if(preReqs[dep] == 0)
                    leaves.Enqueue(dep);
            }
        }
        if(c == numCourses)
            return results;
        
        return new int[0];
    }
}