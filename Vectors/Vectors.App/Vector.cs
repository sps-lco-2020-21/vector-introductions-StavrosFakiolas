using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Vectors.App
{
    public class Vector
    {
        readonly List<double> _collection; //cannot be alterted outside constructor
        readonly double _magnitude; //cannot be alterted outside constructor

        public Vector(List<double> collection)
        {
            _collection = collection;

            double result = 0;
            for (int i = 0; i < this._collection.Count; ++i)
            {
                result += (this._collection[i] * this._collection[i]);
            }
            _magnitude = Math.Sqrt(result);
        }

        public Vector Add(Vector other) // Creates a new vector of larger size if a smaller size vector is used
        {
            int maxLength = Math.Max(this._collection.Count, other._collection.Count);
            List<double> sum = new List<double>(maxLength);
            for (int i = 0; i < maxLength; ++i)
            {
                double value = 0;
                if (i < _collection.Count)
                    value += _collection[i];
                if (i < other._collection.Count)
                    value += other._collection[i];
                sum.Add(value);
            }
            return new Vector(sum);
        }

        public Vector ScalarMultiple(double scalar) // No size issues
        {
            List<double> multiple = new List<double>();
            foreach (double item in this._collection)
            {
                multiple.Add(item * scalar);
            }
            return new Vector(multiple);
        }

        public double DotProductA(Vector other) // Exception if different sizes
        {
            if (this._collection.Count != other._collection.Count)
            {
                throw new DifferentSizesException();
            }

            double result = 0;
            for (int i = 0; i < this._collection.Count; ++i)
            {
                result += this._collection[i] * other._collection[i];
            }
            return result;
        }

        public override bool Equals(object otherObj) // if different sizes its always false (intentionally)
        {
            if (!(otherObj is Vector))
                return false;
            Vector other = (Vector)otherObj;
            if (other._collection.Count != this._collection.Count)
            {
                return false;
            }
            for (int i = 0; i < this._collection.Count; ++i)
            {
                if (this._collection[i] != other._collection[i])
                {
                    return false;
                }
            }
            return true;
        }

        public Vector ConvexCombinationG(Vector other, double a) // exception for sizes and value of a
        {
            if (this._collection.Count != other._collection.Count)
            {
                throw new DifferentSizesException();
            }
            if (a < 0 || a > 1)
            {
                throw new WrongValueException();
            }

            List<double> result = new List<double>();
            double b = 1 - a;
            for (int i = 0; i < this._collection.Count; ++i)
            {
                result.Add(this._collection[i] * a + other._collection[i] * b);
            }
            return new Vector(result);
        }

        public double AngleBetween(Vector other, bool radians = true) //exception for different sizes
        {
            if (this._collection.Count != other._collection.Count)
            {
                throw new DifferentSizesException();
            }

            double dot = this.DotProductA(other);
            double cosAngle = dot / (Magnitude * other.Magnitude);
            double rad = Math.Acos(cosAngle);
            if (radians)
                return rad;
            else
                return rad * (180 / Math.PI);
        }

        public double Magnitude {
            get => _magnitude;
        }

        public override int GetHashCode()
        {
            int value = 0;
            foreach(double v in _collection)
            {
                value ^= v.GetHashCode();
            }
            return value;
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

    public class WrongValueException : Exception
    {
        //Overriding the Message property
        public override string Message
        {
            get
            {
                return "Please use a value that is as such: 0 <= x <= 1";
            }
        }
    }
}
