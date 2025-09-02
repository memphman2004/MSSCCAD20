namespace BigCatHierarchy;

// BigCat is an Animal and defines Species
public class BigCat : Animal
{
    // Any file can read; only this class or its children can set
    public string Species { get; protected set; } = "Big Cat";

    public override string Sound() => "Roar!";
}
