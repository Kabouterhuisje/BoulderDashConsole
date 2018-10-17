using BoulderDash_DennisTijbosch_StijnHendriks.Enums;

namespace BoulderDash_DennisTijbosch_StijnHendriks.Models
{
    public class FireFly : MoveableElement
    {
        Movement lastMovement;
        public FireFly(out Block newBlock) : base(out newBlock)
        {
            interval = 0;
            lastInterval = 0;
            lastMovement = Movement.Up;
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
                lastInterval = 0;
                // Laatste move was links
                if (lastMovement == Movement.Left)
                {
                    if (block.Down.getElementType() == ElementType.Block || block.Down.getElementType() == ElementType.Rockfort)
                    {
                        moveOrKill(block.Down);
                        lastMovement = Movement.Down;
                        return;
                    }
                    else if (block.Left.getElementType() == ElementType.Block || block.Left.getElementType() == ElementType.Rockfort)
                    {
                        moveOrKill(block.Left);
                        lastMovement = Movement.Left;
                        return;
                    }
                    else if (block.Up.getElementType() == ElementType.Block || block.Up.getElementType() == ElementType.Rockfort)
                    {
                        moveOrKill(block.Up);
                        lastMovement = Movement.Up;
                        return;
                    }
                    else
                    {
                        lastMovement = Movement.Up;
                        return;
                    }
                }
                
                // Laatste move was onder
                else if (lastMovement == Movement.Down)
                {
                    if (block.Right.getElementType() == ElementType.Block || block.Right.getElementType() == ElementType.Rockfort)
                    {
                        moveOrKill(block.Right);
                        lastMovement = Movement.Right;
                        return;
                    }
                    else if (block.Down.getElementType() == ElementType.Block || block.Down.getElementType() == ElementType.Rockfort)
                    {
                        moveOrKill(block.Down);
                        lastMovement = Movement.Down;
                        return;
                    }
                    else if (block.Left.getElementType() == ElementType.Block || block.Left.getElementType() == ElementType.Rockfort)
                    {
                        moveOrKill(block.Left);
                        lastMovement = Movement.Left;
                        return;
                    }
                    else
                    {
                        lastMovement = Movement.Left;
                        return;
                    }
                }
                
                // Laatste move was boven
                else if (lastMovement == Movement.Up)
                {
                    if (block.Left.getElementType() == ElementType.Block || block.Left.getElementType() == ElementType.Rockfort)
                    {
                        moveOrKill(block.Left);
                        lastMovement = Movement.Left;
                        return;
                    }
                    else if (block.Up.getElementType() == ElementType.Block || block.Up.getElementType() == ElementType.Rockfort)
                    {
                        moveOrKill(block.Up);
                        lastMovement = Movement.Up;
                        return;
                    }
                    else if (block.Right.getElementType() == ElementType.Block || block.Right.getElementType() == ElementType.Rockfort)
                    {
                        moveOrKill(block.Right);
                        lastMovement = Movement.Right;
                        return;
                    }
                    else
                    {
                        lastMovement = Movement.Right;
                        return;
                    }
                }
                
                // Laatste move was rechts
                else if (lastMovement == Movement.Right)
                {
                    if (block.Up.getElementType() == ElementType.Block || block.Up.getElementType() == ElementType.Rockfort)
                    {
                        moveOrKill(block.Up);
                        lastMovement = Movement.Up;
                        return;
                    }
                    else if (block.Right.getElementType() == ElementType.Block || block.Right.getElementType() == ElementType.Rockfort)
                    {
                        moveOrKill(block.Right);
                        lastMovement = Movement.Right;
                        return;
                    }
                    else if (block.Down.getElementType() == ElementType.Block || block.Down.getElementType() == ElementType.Rockfort)
                    {
                        moveOrKill(block.Down);
                        lastMovement = Movement.Down;
                        return;
                    }
                    else
                    {
                        lastMovement = Movement.Down;
                        return;
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
