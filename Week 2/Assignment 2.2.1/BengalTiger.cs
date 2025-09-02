// PURPOSE: A BengalTiger IS A Tiger.

namespace BigCatHierarchy
{
    public class BengalTiger : Tiger
    {
        public BengalTiger()
        {
            Species = "Bengal Tiger";
        }

        // Optional extra override:
        // public override string Sound() => "ROAR (Bengal tiger)!";
    }
}
