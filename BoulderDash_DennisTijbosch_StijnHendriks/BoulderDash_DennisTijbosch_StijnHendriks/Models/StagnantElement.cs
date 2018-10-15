using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
