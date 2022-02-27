public class Solution {
    public int[] ExclusiveTime(int n, IList<string> logs) {
        int[] times = new int[n];
        Stack<int> stack = new Stack<int>();
        int runningFunc = 0, time = 0;
        foreach(var log in logs){
            var values = log.Split(":");
            var func = Convert.ToInt32(values[0]);
            var isStart = values[1] == "start";
            var curTime = Convert.ToInt32(values[2]);
            
            if(!isStart) 
                curTime++;
            times[runningFunc] += curTime - time;

            time = curTime;
            if(isStart) {
                stack.Push(runningFunc);
                runningFunc = func;
            } else {
                runningFunc = stack.Pop();
            }
        }
        
        return times;
    }
}    