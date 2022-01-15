//"102"  => 12

//10 + 2 ==> val
//cur, prev, val, index



public class Solution {
    public IList<string> AddOperators(string num, int target) {
        IList<string> result = new List<string>();
        StringBuilder expr = new StringBuilder();
        
        AddOperators(num, 0, 0, 0, 0, target, expr, result);
        return result;
    }
    //"102" , 0, 0, 0
    public void AddOperators(string num, int index, long cur, long prev, long val, int target, StringBuilder expr, IList<string> result)
    {
        if(index == num.Length){
            if(val == target && cur == 0)
                result.Add(expr.ToString());
            return;
        }
        
        cur = cur * 10 + (num[index] - '0');
        var curNum = cur.ToString();
        if(cur > 0){
            AddOperators(num, index + 1, cur, prev, val, target, expr, result);
        }
        
        if(expr.Length == 0){
            expr.Append(curNum);
            AddOperators(num, index + 1, 0, cur, cur, target, expr, result);
            expr.Length -= curNum.Length;
        } else {
            //Add
            expr.Append('+');
            expr.Append(curNum);
            AddOperators(num, index + 1, 0, cur, val + cur, target, expr, result);
            expr.Length -= curNum.Length;
            expr.Length--;
            
            //Sub
            expr.Append('-');
            expr.Append(curNum);
            AddOperators(num, index + 1, 0, -cur, val - cur, target, expr, result);
            expr.Length -= curNum.Length;
            expr.Length--;
            //Mul
            expr.Append('*');
            expr.Append(curNum);
            AddOperators(num, index + 1, 0, (prev * cur), (val - prev) + (prev * cur) , target, expr, result);
            expr.Length -= curNum.Length;
            expr.Length--;
        }
    }
}