public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        Dictionary<int, List<int>> preReqMap = new Dictionary<int, List<int>>();
        int[] dependents = new int[numCourses];
        
        foreach(var preReq in prerequisites){
            int a = preReq[0], b = preReq[1];
            
            if(!preReqMap.ContainsKey(a))
                preReqMap.Add(a, new List<int>());
            
            preReqMap[a].Add(b);
            dependents[b]++;
        }// preReqMap = [{1: 0}], dependents = [0, 0]
        int completedCourse = 0;
        Queue<int> queue = new Queue<int>();//[1]
        for(int i=0; i<numCourses; i++){
            if(dependents[i] == 0){
                queue.Enqueue(i);
                completedCourse++;//1
            }
        }
        
        while(queue.Count > 0){
            var course = queue.Dequeue();
            
            if(preReqMap.ContainsKey(course)){
                foreach(var nextCourse in preReqMap[course]){
                    dependents[nextCourse]--;
                    if(dependents[nextCourse] == 0)
                    {
                        queue.Enqueue(nextCourse);
                        completedCourse++;//2
                    }
                }
            }
        }
        
        return completedCourse == numCourses;
    } 
}