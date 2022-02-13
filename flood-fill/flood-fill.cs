public class Solution {
    public int[][] FloodFill(int[][] image, int row, int col, int newColor) {
        FloodFill(image, row, col, newColor, image[row][col]);
        return image;
    }
    
    private void FloodFill(int[][] image, int row, int col, int newColor, int oldColor)
    {
        int rows = image.Length, cols = image[0].Length;
        
        if(row < 0 || row >= rows || col < 0 || col >= cols 
           || image[row][col] == newColor || image[row][col] != oldColor)
            return;
        
        image[row][col] = newColor;
        
        FloodFill(image, row - 1, col, newColor, oldColor);
        FloodFill(image, row + 1, col, newColor, oldColor);
        FloodFill(image, row, col - 1, newColor, oldColor);
        FloodFill(image, row, col + 1, newColor, oldColor);
    }
}