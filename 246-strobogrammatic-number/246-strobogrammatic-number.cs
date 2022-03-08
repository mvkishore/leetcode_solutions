public class Solution {
    public bool IsStrobogrammatic(string num) {
        int left = 0, right = num.Length - 1;
        Dictionary<char, char> stroboDigits = new Dictionary<char, char>()
        {
            {'0', '0'},
            {'1', '1'},
            {'6', '9'},
            {'8', '8'},
            {'9', '6'},
        };
        
        while(left <= right){
            if(!stroboDigits.ContainsKey(num[left]) || !stroboDigits.ContainsKey(num[right]))
                return false;
            
            if(num[left] != stroboDigits[num[right]])
                return false;
            
            left++;
            right--;
        }
        
        return true;
    }
}