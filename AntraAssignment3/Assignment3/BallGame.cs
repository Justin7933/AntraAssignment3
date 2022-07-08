using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Color
    {
        private int red;
        private int green;
        private int blue;
        private int alpha;

     
        public Color(int red, int green, int blue, int alpha = 255)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = alpha;
        }
  
        public int getRed()
        {
            return red;
        }
        public int getGreen()
        {
            return green;
        }
        public int getBlue()
        {
            return blue;
        }

        public int getAlpha()
        {
            return alpha;
        }

     
        public void setRed(int red)
        {
            this.red = red;
        }
        public void setGreen(int green)
        {
            this.green = green;
        }
        public void setBlue(int blue)
        {
            this.blue = blue;
        }

        public void setAlpha(int alpha)
        {
            this.alpha = alpha;
        }

  
        public double getGrayScaleValue()
        {
            return ((red + green + blue) * 1.0) / 3;
        }
    }

    class Ball
    {
        private int size;
        private Color color;
        private int numThrows;

     
        public Ball(int size, Color color)
        {
            this.size = size;
            this.color = color;
            numThrows = 0;
        }

    
        public int getSize()
        {
            return size;
        }

        public Color getColor()
        {
            return color;
        }

        public void Pop()
        {
            size = 0;
        }

        public void Throw()
        {
         
            if (size != 0)
            {
                numThrows++;
            }
        }

        public int getNumThrows()
        {
            return numThrows;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Color color1 = new Color(18, 243, 107);
            Ball ball1 = new Ball(4, color1);

            
            ball1.Throw();
            ball1.Throw();
            ball1.Throw();
            Console.WriteLine("Throw count of Ball 1 before popping: " + ball1.getNumThrows());

            ball1.Pop();

       
            ball1.Throw();
            ball1.Throw();

          
            Console.WriteLine("Throw count of Ball 1 after popping: " + ball1.getNumThrows());


            Console.WriteLine();

         
            Color color2 = new Color(27, 87, 94, 148);
            Ball ball2 = new Ball(2, color2);

            ball2.Pop(); 

         
            for (int i = 0; i < 5; i++) ball2.Throw();

            Console.WriteLine("Ball 2 throw count: " + ball2.getNumThrows());
        }
    }
}

