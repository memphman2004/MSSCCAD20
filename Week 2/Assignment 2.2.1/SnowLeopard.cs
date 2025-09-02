// PURPOSE: A SnowLeopard IS A Leopard.

namespace BigCatHierarchy
{
    public class SnowLeopard : Leopard
    {
        public SnowLeopard()
        {
            Species = "Snow Leopard";
        }

        // extra override for practice use:
        public override string Sound() => "Chuff (snow leopard)!";
    }
}
