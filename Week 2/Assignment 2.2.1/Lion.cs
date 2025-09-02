namespace BigCatHierarchy;

// Lion IS A BigCat
public class Lion : BigCat
{
    public Lion()
    {
        Species = "Lion";  // OK: protected setter from BigCat
    }

    public override string Sound() => "ROAR (lion)!";
}
