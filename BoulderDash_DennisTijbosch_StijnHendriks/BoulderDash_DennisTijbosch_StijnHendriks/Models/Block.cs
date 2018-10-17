using BoulderDash_DennisTijbosch_StijnHendriks.Enums;
using System;

namespace BoulderDash_DennisTijbosch_StijnHendriks.Models
{
    public class Block
    {
        public Element Element { get; set; }
        public Block Up { get; set; }
        public Block Down { get; set; }
        public Block Left { get; set; }
        public Block Right { get; set; }

        public Block(Element element)
        {
            Element = element;
        }

        public Block()
        {

        }

        // Elementen binnen het level specificeren
        public ElementType getElementType()
        {
            ElementType returnType;
            if (Element == null)
            {
                returnType = ElementType.Block;
            }             
            else if (Element.GetType() == typeof(Steelwall))
            {
                returnType = ElementType.Steelwall;
            }    
            else if (Element.GetType() == typeof(Boulder))
            {
                returnType = ElementType.Boulder;
            }
            else if (Element.GetType() == typeof(Diamond))
            {
                returnType = ElementType.Diamond;
            }
            else if (Element.GetType() == typeof(Exit))
            {
                returnType = ElementType.Exit;
            }
            else if (Element.GetType() == typeof(FireFly))
            {
                returnType = ElementType.Firefly;
            }
            else if (Element.GetType() == typeof(Mud))
            {
                returnType = ElementType.Mud;
            }
            else if (Element.GetType() == typeof(Rockford))
            {
                returnType = ElementType.Rockfort;
            }   
            else if (Element.GetType() == typeof(Wall))
            {
                returnType = ElementType.Wall;
            } 
            else
            {
                throw new Exception("Geen bestaand element type");
            }   
            return returnType;
        }

        public Element putOnBlock(Element newElement)
        {
            Element oldElement = Element;

            if (oldElement != null)
            {
                oldElement.block = null;
            }          
            newElement.block = this;
            Element = newElement;
            return oldElement;
        }
    }
}
