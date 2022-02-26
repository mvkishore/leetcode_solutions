public class Solution {
    public int CompareVersion(string version1, string version2) {
        var rev1 = version1.Split(".").Select(x=> Convert.ToInt32(x)).ToArray();
        var rev2 = version2.Split(".").Select(x=> Convert.ToInt32(x)).ToArray();
        
        int i=0, j=0;
        while(i < rev1.Length && j < rev2.Length){
            
            if(rev1[i] < rev2[j])
                return -1;
            else if(rev1[i] > rev2[j])
                return 1;
            
            i++;j++;
        }
        
        while(i < rev1.Length && rev1[i] == 0)
            i++;
        if(i < rev1.Length) return 1;
        
        while(j < rev2.Length && rev2[j] == 0)
            j++;
        if(j < rev2.Length) return -1;
                
        return 0;    
    }
}