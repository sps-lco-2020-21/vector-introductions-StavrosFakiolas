using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectors.App
{ 
    public class Vector 
    {
        readonly List<double> _collection; //cannot be alterted outside constructor
        readonly double magnitude; //cannot be alterted outside constructor

        public Vector(List<double> collection)
        {
            _collection = collection;

            double result = 0;
            for (int i = 0; i < this._collection.Count; ++i)
            {
                result += (this._collection[i] * this._collection[i]);
            }
            magnitude = Math.Sqrt(result);
        }

        public Vector Add(Vector myVector2) // Creates a new vector of larger size if a smaller size vector is used
        {
            List<double> sum = new List<double>();
            int oneAdditions = 0;
            int twoAdditions = 0;
            int maxLength = Math.Max(this._collection.Count, myVector2._collection.Count);
            for(int i = 0; i < maxLength; ++i)
            {
                if(myVector2._collection.Count == i)
                {
                    myVector2._collection.Add(0);
                    twoAdditions += 1;
                }
                else if(this._collection.Count == i)
                {
                    this._collection.Add(0);
                    oneAdditions += 1;
                }
                sum.Add(this._collection[i] + myVector2._collection[i]);
            }
            if(twoAdditions > 0)
            {
                for (int i = 0; i < twoAdditions; ++i)
                {
                    myVector2._collection.RemoveAt(myVector2._collection.Count - 1);
                }
            }
            else if(oneAdditions > 0)
            {
                for (int i = 0; i < oneAdditions; ++i)
                {
                    this._collection.RemoveAt(this._collection.Count - 1);
                }
            }
            return new Vector(sum);
        }

        public Vector ScalarMultiple(double scalar) // No size issues
        {
            List<double> multiple = new List<double>();
            foreach(double item in this._collection)
            {
                multiple.Add(item * scalar);
            }
            return new Vector(multiple);
        }

        public double DotProductA(Vector myVector2) // Exception if different sizes
        {
            if(this._collection.Count != myVector2._collection.Count)
            {
                throw new DifferentSizesException();
            }
            
            double result = 0;
            for(int i = 0; i < this._collection.Count; ++i)
            {
                result += this._collection[i] * myVector2._collection[i];
            }
            return result;
        }

        public bool SameVector(Vector myVector2) // if different sizes its always false (intentionally)
        {
            if (myVector2._collection.Count != this._collection.Count)
            {
                return false;
            }
            for(int i = 0; i < this._collection.Count; ++i)
            {
                if(this._collection[i] != myVector2._collection[i])
                {
                    return false;
                }
            }
            return true;
        }

        // Convex Combination

        // Geometric Dot Product
        public double AngleBetween(Vector myVector2, bool radians) //exception for different sizes
        {
            if (this._collection.Count != myVector2._collection.Count)
            {
                throw new DifferentSizesException();
            }

            // angle code
            return 1;
        }

        public double Magnitude {
            get => magnitude;
        }
    }

    public class DifferentSizesException : Exception
    {
        //Overriding the Message property
        public override string Message
        {
            get
            {
                return "The vectors have different sizes";
            }
        }
    }
}
