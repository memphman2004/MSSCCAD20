// PURPOSE: A Tiger IS A BigCat.

namespace BigCatHierarchy
{
    public class Tiger : BigCat
    {
        public Tiger()
        {
            Species = "Tiger";
        }

        public override string Sound() => "ROAR (tiger)!";
    }
}
