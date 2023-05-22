using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyBag
{
    public  class Bag
    {

        #region Exceptions
        public class IncorrectInputException : Exception { };
        public class EmptyBagException : Exception { };
        #endregion

        #region Attribute
        private List<int> elems = new List<int>();
        private  List<int> freqs = new List<int>();
        private int maxValue;
        #endregion

        #region Constructors
        public Bag()
        {
            
        }
        public Bag(List<int> elems) 
        {
            foreach (int elem in elems)
            {
                insertElement(elem);
            }
           

        }

  
        #endregion

        #region Getters and Setters
        public List<int> Elements
        {
            get { return elems; }
            set { elems = value; }
        }

        public List<int> Frequencies
        {
            get { return freqs; }
            set { freqs = value; }
        }
        public int MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }
        #endregion




        public int getIndex(int elem)
        {

            int index = -1;
            for (int i = 0; i < elems.Count; i++)
            {
                if (elems[i] == elem)
                {
                    index = i;
                }
                

            }

            return index;
        }

        public void insertElement(int elem)
        {
            //get the index of the element if there is any in the list
            int index = getIndex(elem);

            //if there is such an element then increment the frequency
            if (index != -1)
            {
                freqs[index]++;
            }
            //otherwise add it to both elems and freq
            else
            {
                elems.Add(elem);
                freqs.Add(1);
            }


        }

        public bool Contains(int elem)
        {
            if(elems.Count==0) throw new EmptyBagException();
            for (int i = 0; i < elems.Count; i++)
            {
                if (elems[i] == elem)
                {
                    return true;
                }
             
            }
            return false;
        }

        public void removeElement(int elem)
        {
           
            if(elems.Count == 0)
            {
                throw new EmptyBagException();
            }
            int index = getIndex(elem);
         
            if(!elems.Contains(elem)) {
                throw new Bag.IncorrectInputException();
            
            }
            if (index != -1)
            {
                if (freqs[index] == 1)
                {
                    elems.RemoveAt(index);
                    freqs.RemoveAt(index);
                }
                else {
                    freqs[index]--;
                }

               
                
            }
        }

        public int returnFreq(int elem)
        {
            if (elems.Count == 0)
            {
                throw new EmptyBagException();
            }
            if (!elems.Contains(elem))
            {
                throw new Bag.IncorrectInputException();
            }
                int index = getIndex(elem);
                return freqs[index];
          
               
            
        }

        public int maxElem()
        {
            if(elems.Count == 0)
            {
                Console.WriteLine("The bag is empty!");
                throw new EmptyBagException();
                
            }

            maxValue = elems[0];
            for(int i  = 1; i < elems.Count; i++)
            {
                if (elems[i] > maxValue)
                {
                    maxValue = elems[i];
                }
            }
            return maxValue;
         
        }




    }
}
