public class Solution {
    public double ChampagneTower(int poured, int query_row, int query_glass) {
        double[,] tower = new double[query_row + 2, 2*(query_row + 1)];
        
        tower[0,0] = poured;
        for(int row=0; row<= query_row; row++){
            for(int col=0; col<= row; col++){
                double v = (tower[row,col] - 1) / 2.0;
                if(v > 0){
                    tower[row + 1,col] += v;
                    tower[row + 1,col + 1] += v;
                }
            }
        }
        
        
        return Math.Min(1, tower[query_row, query_glass]);
    }
}