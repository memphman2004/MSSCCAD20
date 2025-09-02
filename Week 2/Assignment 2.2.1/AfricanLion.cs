namespace BigCatHierarchy;

// AfricanLion IS A Lion (→ BigCat → Animal)
public class AfricanLion : Lion
{
    public AfricanLion()
    {
        Species = "African Lion";  // must compile if BigCat has Species
    }

}
