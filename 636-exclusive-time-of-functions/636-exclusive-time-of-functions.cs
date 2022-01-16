/*


 ["0:start:0","1:start:2","1:end:5","0:end:6"]
 
  
*/

public class Solution {
    public int[] ExclusiveTime(int n, IList<string> logs) {
        int runningId = 0, prevTime =0;
        int[] res = new int[n];
        Stack<int> callStack = new Stack<int>();
        
        for(int i=1; i < logs.Count; i++){
            var details = logs[i].Split(":");
            
            int task = Convert.ToInt32(details[0]);
            string action = details[1];
            int time = Convert.ToInt32(details[2]);
            
            if(action == "start"){
                callStack.Push(runningId);
                res[runningId] += time - prevTime;
                runningId = task;
            }else if(action == "end")
            {
                time++;
                res[runningId] += time - prevTime;
                if(callStack.Count > 0)
                    runningId = callStack.Pop();
            }
            prevTime = time;
        }
        return res;
    }
}