C# implementation of Heap with Removing random item using SortedSet
​
SortedSet<(int height, int indx)> heightsHeap = new SortedSet<(int height, int indx)>();
​
Add:
```
if(!elements.ContainsKey(point.y))
elements.Add(point.y, new List<int>());
elements[point.y].Add(++i);
heightsHeap.Add((point.y, i));
```
Remove:
```
var list = elements[point.y];
int last = list.Count - 1;
heightsHeap.Remove((point.y, list[last]));
list.RemoveAt(last);
```