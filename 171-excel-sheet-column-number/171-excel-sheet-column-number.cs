/*ZY

A
AA
26+1 =27
26*26 + 25 => 
*/
public class Solution {
    public int TitleToNumber(string columnTitle) {
        int num = 0;
        for(int i=0; i<columnTitle.Length; i++){
            num = num * 26 + (columnTitle[i] - 'A' + 1);
        }
        return num;
    }
}