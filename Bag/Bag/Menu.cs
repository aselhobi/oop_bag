using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;



namespace MyBag
{
    internal class Menu
    {
        Bag mybag = new Bag();

        public Menu() { }

        public void Run()
        {
            int n;
            do
            {
                PrintMenu();
                try
                {
                    n = int.Parse(Console.ReadLine()!);
                }
             
                catch (System.FormatException) { n = -1; }
                catch (System.OverflowException) { Console.WriteLine("The number is too large!"); n = -1; }
             
                switch (n)
                {
                    case 1:
                        insertElement();
                        break;
                    case 2:
                        removeElement();
                        break;
                    case 3:
                       retFreq();
                       break;
                    case 4:
                       maxElem();
                      break;
                    case 5:
                      printBag();
                       break;
                    
                }
                if (n < 0 && n > 5)
                {
                    Console.WriteLine("Please, choose one of the options in the menu!");
                }

            } while (n != 0 && n<6);

        }

        #region Menu operations

        static private void PrintMenu()
        {
            Console.WriteLine("\n\n 0. - Quit");
            Console.WriteLine(" 1. - Insert an element");
            Console.WriteLine(" 2. - Remove an element");
            Console.WriteLine(" 3. - Get the frequency of an element");
            Console.WriteLine(" 4. - Get the largest element");
            Console.WriteLine(" 5. - Print the bag");
            Console.Write(" Choose: ");
        }

        public void insertElement()
        {
            Console.WriteLine("Please type an element you want to insert: ");
            try{
                int i = int.Parse(Console.ReadLine()!);
                mybag.insertElement(i);
                printBag();
            }
            catch(System.FormatException) { Console.WriteLine("Please, insert an integer only!"); }
            catch(System.OverflowException) { Console.WriteLine("The number is too large!"); }
            

        }

        public void removeElement()
        {
            try
            { 
                    Console.WriteLine("Please type an element you want to remove: ");
                    int i = int.Parse(Console.ReadLine()!);
                    //if (!mybag.Elements.Contains(i) && mybag.Elements.Count != 0)
                    //{
                    //    Console.WriteLine("Invalid input! Please insert an element which is IN the bag!");
                    //}
                    mybag.removeElement(i);
                    printBag();
                
            }
            catch(Bag.EmptyBagException) { Console.WriteLine("The bag is empty, insert an element first!"); }
            catch (System.FormatException) { Console.WriteLine("Please, insert an integer only!"); }
            catch (Bag.IncorrectInputException) { Console.WriteLine("The given element is not in the bag!"); }

        }

        public void retFreq()
        {
            try
            {
                Console.WriteLine("Please type an element you want to know the frequency for: ");
                int i = int.Parse(Console.ReadLine()!);
                int freq= mybag.returnFreq(i);
                Console.WriteLine("The frequency of the given element " + i + ": " + freq);

            }
            catch (System.FormatException ) { Console.WriteLine("Please enter an integer!"); }
            catch (Bag.IncorrectInputException) { Console.WriteLine("The given element is not in the bag!"); }
            catch (Bag.EmptyBagException) { Console.WriteLine("The bag is empty, insert an element first!"); }


        }

        public void maxElem()
        {
            try
            {
               int largest = mybag.maxElem();
                Console.WriteLine("The largest element of the bag is: " + largest);
            }

            catch(Exception e) 
            { Console.WriteLine(); }
        }
        public void printBag() {

            if(mybag.Elements.Count == 0) 
            {
                Console.WriteLine("Please, set a bag first!");
            }
            for (int i = 0; i < mybag.Elements.Count; i++)
            {
                Console.WriteLine("{0}: {1}", mybag.Elements[i], mybag.Frequencies[i]);
            }
        }
       
       
        #endregion
    
}
}
