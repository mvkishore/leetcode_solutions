public class Solution {
    public IList<string> FindStrobogrammatic(int n) {
        return Generate(n, n);
    }
    private string[][] stroboNums = new string[][]
    {
        new []{"0", "0"}, new []{"1", "1"}, new []{"8", "8"},
        new []{"6", "9"}, new []{"9", "6"}
    };
        
    private IList<string> Generate(int n, int targetLen){
        if(n == 0)
            return new List<string>(){""};
        
        if(n == 1)
            return new List<string>(){"0", "1", "8"};
        
        var prevStrings = Generate(n - 2, targetLen);
        var curStrings = new List<string>();
        
        foreach(var str in prevStrings){
            foreach(var stroboNum in stroboNums){
                if(stroboNum[0] != "0" || n != targetLen){
                    curStrings.Add(string.Concat(stroboNum[0], str, stroboNum[1]));
                }
            }
        }
        
        return curStrings;
    }
}
/*
1  -> 1 
6  -> 9 ==> 
8  -> 8
0  -> 0
9  -> 6 ==>

[0, 1, 8]

n = 2 => 11 69 88 96
n = 3 => 101 111 181, 609, 619, 689, 808,818,888, 906, 916, 986
n = 4 => 1001,1881,1111,6009,6119,6889,6969,8008,8118,8888, 9006,9116, 9886, 9696
n = 5 => 1 (101 111 181, 609, 619, 689, 808,818,888, 906, 916, 986) 1 
    */