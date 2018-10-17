using BoulderDash_DennisTijbosch_StijnHendriks.Enums;

namespace BoulderDash_DennisTijbosch_StijnHendriks.Models
{
    public abstract class Element
    {
        internal Block block;
        internal ElementState status;
        internal int lastUpdated;

        public Element(out Block newBlock)
        {
            block = new Block(this);
            newBlock = block;
        }

        // Logica
        internal abstract void trigger(int updateGUI);
    }
}
