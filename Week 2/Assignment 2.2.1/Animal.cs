namespace BigCatHierarchy;

public class Animal
{
    public string Name { get; set; } = "";
    public int Age { get; set; }

    public virtual string Sound() => "(animal sound)";
}


/* 
- One class per file, no duplicates.Search project (Cmd/Ctrl+Shift+F) for class BigCat and class Animal. 
- Make sure there’s only one of each.
- Same namespace in every file: first line should be namespace BigCatHierarchy; (or namespace BigCatHierarchy { ... } if you use block style). 
- Spelling and capitalization must match.
- Lion inherits BigCat: public class Lion : BigCat
- BigCat defines Species: public string Species { get; protected set; } = "Big Cat";
- Files are inside the project folder(same directory tree as the.csproj).
- Build cleanly: run dotnet build or click Build in VS Code.Fix any errors in Animal.cs or BigCat.cs first—if those 
  don’t compile, AfricanLion won’t see Species.
  */