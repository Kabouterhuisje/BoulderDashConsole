using BoulderDash_DennisTijbosch_StijnHendriks.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash_DennisTijbosch_StijnHendriks.Models
{
    public abstract class MoveableElement : Element
    {
        protected int interval;
        protected int lastInterval;

        public MoveableElement(out Block newBlock) : base(out newBlock)
        {

        }

        internal void moveTo(Block newBlock)
        {
            Block oldBlock = block;
            oldBlock.Element = null;
            newBlock.Element = this;
            block = newBlock;
        }

        internal bool moveOrKill(Block block)
        {
            if (block.getElementType() == ElementType.Block)
            {
                moveTo(block);
                return true;
            }
            else if (block.getElementType() == ElementType.Rockfort)
            {
                Rockford rockford = block.Element as Rockford;
                rockford.kill();
                return true;
            }
            else if (block.getElementType() == ElementType.Firefly)
            {
                moveTo(block);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
