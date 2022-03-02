public class Solution {
    public int[] ExclusiveTime(int n, IList<string> logs) {
        Stack<int> callStack = new Stack<int>();
        int[] res = new int[n];
        int runningFunc = 0;
        int seenTime = 0;
        foreach(var log in logs){
            var tokens = log.Split(":");
            var func = Convert.ToInt32(tokens[0]);
            var isStart = tokens[1] == "start";
            var time = Convert.ToInt32(tokens[2]);
            
            if(!isStart) time++;
            
            res[runningFunc] += time - seenTime;
            seenTime = time;
            
            if(isStart){
                callStack.Push(runningFunc);
                runningFunc = func;
            } else {
                runningFunc = callStack.Pop();
            }
        }
        
        return res;
    }
}