namespace BoulderDash_DennisTijbosch_StijnHendriks.Models
{
    public abstract class StagnantElement : Element
    {
        public StagnantElement(out Block newBlock) : base(out newBlock)
        {

        }

        internal override void trigger(int updateFrame)
        {
            return;
        }
    }
}
