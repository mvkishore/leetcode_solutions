**Annonymous Comparer in C#**
​
```new SortedSet<string>(Comparer<string>.Create((a, b) => b.CompareTo(a)))```