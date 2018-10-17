using BoulderDash_DennisTijbosch_StijnHendriks.Enums;

namespace BoulderDash_DennisTijbosch_StijnHendriks.Models
{
    public class Rockford : MoveableElement
    {
        public int Score { get; set; }

        public Rockford(out Block newBlock) : base(out newBlock)
        {
            status = ElementState.Alive;
        }

        internal override void trigger(int updateFrame)
        {
            return;
        }

        public void move(Movement movement)
        {
            Block possibleNewBlock = null;

            switch (movement)
            {
                case Movement.Left:
                    possibleNewBlock = block.Left;
                    break;
                case Movement.Right:
                    possibleNewBlock = block.Right;
                    break;
                case Movement.Up:
                    possibleNewBlock = block.Up;
                    break;
                case Movement.Down:
                    possibleNewBlock = block.Down;
                    break;
                default:
                    break;
            }

            bool isAbleToMove = false;

            if (possibleNewBlock != null)
            {
                if (possibleNewBlock.Element == null)
                {
                    isAbleToMove = true;
                }
                else if (possibleNewBlock.getElementType() == ElementType.Exit)
                {
                    status = ElementState.Winning;
                } 
                else if (possibleNewBlock.getElementType() == ElementType.Firefly)
                {
                    status = ElementState.Death;
                }
                else if (possibleNewBlock.getElementType() == ElementType.Mud)
                {
                    isAbleToMove = true;
                }
                else if (possibleNewBlock.getElementType() == ElementType.Diamond)
                {
                    isAbleToMove = true;
                    Score += 100;
                }
                else if (possibleNewBlock.getElementType() == ElementType.Boulder)
                {
                    Block targetBlock = null;
                    switch (movement)
                    {
                        case Movement.Left:
                            targetBlock = possibleNewBlock.Left;
                            break;
                        case Movement.Right:
                            targetBlock = possibleNewBlock.Right;
                            break;
                        case Movement.Up:
                            targetBlock = possibleNewBlock.Up;
                            break;
                        case Movement.Down:
                            targetBlock = possibleNewBlock.Down;
                            break;
                    }
                    if (targetBlock != null)
                    {
                        if (targetBlock.getElementType() == ElementType.Block)
                        {
                            targetBlock.putOnBlock(possibleNewBlock.Element);
                            possibleNewBlock.Element = null;
                            isAbleToMove = true;
                        }
                    }
                }
                else
                {
                    isAbleToMove = false;
                }      
            }
            else
            {
                return;
            }
            if (isAbleToMove)
            {
                moveTo(possibleNewBlock);
            }
        }

        internal void kill()
        {
            status = ElementState.Death;
        }
    }
}
