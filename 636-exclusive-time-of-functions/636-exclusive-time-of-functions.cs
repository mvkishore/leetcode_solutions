public class Solution {
    public int[] ExclusiveTime(int n, IList<string> logs) {
        int[] times = new int[n];//[3, 4]
        Stack<int> stack = new Stack<int>();
        int runningFunc = 0, time = 0;
        foreach(var log in logs){
            var values = log.Split(":");
            var func = Convert.ToInt32(values[0]);
            var act = values[1];
            var curTime = Convert.ToInt32(values[2]);
            
            if(act == "end")
                curTime++;
            times[runningFunc] += curTime - time;
            time = curTime;
            
            if(act == "start")
            {
                stack.Push(runningFunc);
                runningFunc = func;
            }else{
                runningFunc = stack.Pop();
            }
        }
        
        return times;
    }
}    