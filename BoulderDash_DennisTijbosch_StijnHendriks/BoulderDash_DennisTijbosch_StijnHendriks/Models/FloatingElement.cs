using BoulderDash_DennisTijbosch_StijnHendriks.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash_DennisTijbosch_StijnHendriks.Models
{
    public abstract class FloatingElement : MoveableElement
    {

        public FloatingElement(out Block newBlock) : base(out newBlock)
        {
            interval = 1;
            lastInterval = 0;
            status = ElementState.Idle;
        }

        internal override void trigger(int updateGUI)
        {
            if (lastUpdated == updateGUI)
            {
                return;
            }
            else
            {
                lastUpdated = updateGUI;
            }
                         
            if (lastInterval == interval)
            {
                if (status == ElementState.Idle)
                {
                    if (block.Down != null && block.Down.getElementType() == ElementType.Block)
                    {
                        moveTo(block.Down);
                        status = ElementState.Falling;
                        lastInterval = 0;
                    }
                    else if (block.Down != null && block.Left != null && block.Down.Left != null && block.Down.getElementType() == ElementType.Boulder && block.Left.getElementType() == ElementType.Block && block.Down.Left.getElementType() == ElementType.Block || block.Down != null && block.Left != null && block.Down.Left != null && block.Down.getElementType() == ElementType.Diamond && block.Left.getElementType() == ElementType.Block && block.Down.Left.getElementType() == ElementType.Block)
                    {
                        moveTo(block.Down.Left);
                        status = ElementState.Falling;
                        lastInterval = 0;
                    }
                    else if (block.Down != null && block.Right != null && block.Down.Right != null && block.Down.getElementType() == ElementType.Boulder && block.Right.getElementType() == ElementType.Block && block.Down.Right.getElementType() == ElementType.Block || block.Down != null && block.Right != null && block.Down.Right != null && block.Down.getElementType() == ElementType.Diamond && block.Right.getElementType() == ElementType.Block && block.Down.Right.getElementType() == ElementType.Block)
                    {
                        moveTo(block.Down.Right);
                        status = ElementState.Falling;
                        lastInterval = 0;
                    }
                }
                else if (status == ElementState.Falling)
                {
                    if (block.Down != null && block.Down.getElementType() == ElementType.Block)
                    {
                        moveTo(block.Down);
                        status = ElementState.Falling;
                        lastInterval = 0;
                    }
                    else if (block.Down != null && block.Down.getElementType() == ElementType.Rockfort)
                    {
                        Rockford rf = block.Down.Element as Rockford;
                        rf.kill();
                    }
                    else if (block.Down != null && block.Left != null && block.Down.Left != null && block.Down.getElementType() == ElementType.Boulder && block.Left.getElementType() == ElementType.Block && block.Down.Left.getElementType() == ElementType.Block || block.Down != null && block.Left != null && block.Down.Left != null && block.Down.getElementType() == ElementType.Diamond && block.Left.getElementType() == ElementType.Block && block.Down.Left.getElementType() == ElementType.Block)
                    {
                        moveTo(block.Down.Left);
                        status = ElementState.Falling;
                        lastInterval = 0;
                    }
                    else if (block.Down != null && block.Left != null && block.Down.Left != null && block.Down.getElementType() == ElementType.Boulder && block.Left.getElementType() == ElementType.Block && block.Down.Left.getElementType() == ElementType.Rockfort || block.Down != null && block.Left != null && block.Down.Left != null && block.Down.getElementType() == ElementType.Diamond && block.Left.getElementType() == ElementType.Block && block.Down.Left.getElementType() == ElementType.Rockfort)
                    {
                        Rockford rf = block.Down.Element as Rockford;
                        rf.kill();
                    }
                    else if (block.Down != null && block.Right != null && block.Down.Right != null && block.Down.getElementType() == ElementType.Boulder && block.Right.getElementType() == ElementType.Block && block.Down.Right.getElementType() == ElementType.Block || block.Down != null && block.Right != null && block.Down.Right != null && block.Down.getElementType() == ElementType.Diamond && block.Right.getElementType() == ElementType.Block && block.Down.Right.getElementType() == ElementType.Block)
                    {
                        moveTo(block.Down.Right);
                        status = ElementState.Falling;
                        lastInterval = 0;
                    }
                    else if (block.Down != null && block.Right != null && block.Down.Right != null && block.Down.getElementType() == ElementType.Boulder && block.Right.getElementType() == ElementType.Block && block.Down.Right.getElementType() == ElementType.Rockfort || block.Down != null && block.Right != null && block.Down.Right != null && block.Down.getElementType() == ElementType.Diamond && block.Right.getElementType() == ElementType.Block && block.Down.Right.getElementType() == ElementType.Rockfort)
                    {
                        Rockford rf = block.Down.Element as Rockford;
                        rf.kill();
                    }
                    else
                    {
                        status = ElementState.Idle;
                    }
                }
            }
            else
            {
                lastInterval++;
            }

        }
    }
}
