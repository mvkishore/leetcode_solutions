public class Solution {
    public string[] ReorderLogFiles(string[] logs) {
        return logs.OrderBy(x=>x, Comparer<string>.Create((a, b) => {
            int idx = a.IndexOf(" ");
            var aId = a.Substring(0, idx);
            var aLog = a.Substring(idx + 1);
            
            idx = b.IndexOf(" ");
            var bId = b.Substring(0, idx);
            var bLog = b.Substring(idx + 1);
            
            var isADigitLog = char.IsDigit(aLog[0]);
            var isBDigitLog = char.IsDigit(bLog[0]);
            
            if(!isADigitLog && !isBDigitLog){
                if(aLog == bLog)
                    return aId.CompareTo(bId);
            
                return aLog.CompareTo(bLog);
            }else if(!isADigitLog && isBDigitLog){
                return -1;
            }else if(isADigitLog && !isBDigitLog) {
                return 1;
            }else return 0;
        })).ToArray();
    }
}