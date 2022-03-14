public class Solution {
    public string SimplifyPath(string path) {
        var directories = path.Split("/");
        Stack<string> paths = new Stack<string>();
        
        foreach(var directory in directories){
            if(directory == "" || directory == ".")
                continue;
            if(directory == ".."){
                if(paths.Count > 0) paths.Pop();
                continue;
            }
            paths.Push(directory);
        }
        
        StringBuilder result = new StringBuilder();
        while(paths.Count > 0){
            result.Insert(0, paths.Pop());
            result.Insert(0, '/');
        }
        
        if(result.Length == 0)
            result.Append('/');
        
        return result.ToString();
    }
}