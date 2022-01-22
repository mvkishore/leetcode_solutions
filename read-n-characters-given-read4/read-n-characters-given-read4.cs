/**
 * The Read4 API is defined in the parent class Reader4.
 *     int Read4(char[] buf4);
 */

public class Solution : Reader4 {
    /**
     * @param buf Destination buffer
     * @param n   Number of characters to read
     * @return    The number of actual characters read
     */
    public int Read(char[] buf, int n) {
        int i=0;
        char[] buf4 = new char[4];
        
        while(i < n)
        {
            int j = this.Read4(buf4);
            int k = 0;
            while(i < n && k < j){
                buf[i++]=buf4[k++];
            }
            if(j < 4)
                break;
        }
        return i;
    }
}