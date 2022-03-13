public class Solution {
    public int WordsTyping(string[] sentence, int rows, int cols) {
        int n = sentence.Length, col = 0, row = 0, count = 0, indx = 0;
        int len = 0;
        
        while(row < rows){
            while(len + sentence[indx].Length <= cols)
            {
                len += sentence[indx].Length;
                len++;
                indx++;
                if(indx == sentence.Length){
                    indx = 0;
                    count++;
                }
            }
            row++;
            len = 0;
        }
        return count;
    }
}