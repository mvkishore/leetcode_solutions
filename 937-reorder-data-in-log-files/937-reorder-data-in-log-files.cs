public class Solution {
    public string[] ReorderLogFiles(string[] logs) {
        List<string> letter_logs = new List<string>();
        List<string> digit_logs = new List<string>();
        
        foreach(var log in logs){
            int idx = log.IndexOf(" ");
            
            if(idx < log.Length && char.IsDigit(log[idx + 1]))
               digit_logs.Add(log);
            else
               letter_logs.Add(log);
        }
        
        letter_logs.Sort((a, b) => {
            int idx = a.IndexOf(" ");
            var aId = a.Substring(0, idx);
            var aLog = a.Substring(idx + 1);
            
            idx = b.IndexOf(" ");
            var bId = b.Substring(0, idx);
            var bLog = b.Substring(idx + 1);
            if(aLog == bLog)
                return a.CompareTo(b);
            
            return aLog.CompareTo(bLog);
        });
               
        string[] res = new string[logs.Length];
        int i=0;
        for(int j=0; j<letter_logs.Count; j++){
            res[i++] = letter_logs[j];
        }
        
        for(int j=0; j<digit_logs.Count; j++){
            res[i++] = digit_logs[j];
        }
        
        return res;
    }
}