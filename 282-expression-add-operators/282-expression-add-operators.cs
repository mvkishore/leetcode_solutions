public class Solution {
    public IList<string> AddOperators(string num, int target) {
        IList<string> res = new List<string>();
        StringBuilder exp = new StringBuilder();
        AddOperators(num, 0, 0, 0, 0, exp, target, res);
        return res;
    }
    
    private void AddOperators(string num, int indx, long cur, long prev, long val, StringBuilder exp, int target, IList<string> res){
        if(indx == num.Length)
        {
            if(cur == 0 && val == target)
                res.Add(exp.ToString());
            return;
        }
        
        cur = cur * 10 + (num[indx] - '0');
        var curNum = cur.ToString();
        if(cur > 0){
            AddOperators(num, indx + 1, cur, prev, val, exp, target, res);
        }
        
        if(exp.Length == 0){
            exp.Append(curNum);
            AddOperators(num, indx + 1, 0, cur, cur, exp, target, res);
            exp.Length -= curNum.Length;
        } else {
            //Add
            exp.Append("+");
            exp.Append(curNum);
            AddOperators(num, indx + 1, 0, cur, val + cur, exp, target, res);
            exp.Length -= curNum.Length;
            exp.Length--;
            
            //Subtract
            exp.Append("-");
            exp.Append(curNum);
            AddOperators(num, indx + 1, 0, -cur, val - cur, exp, target, res);
            exp.Length -= curNum.Length;
            exp.Length--;
            
            //Multiplication
            exp.Append("*");
            exp.Append(curNum);
            AddOperators(num, indx + 1, 0, prev * cur, (val - prev) + (prev * cur), exp, target, res);
            exp.Length -= curNum.Length;
            exp.Length--;
        }
    }
}