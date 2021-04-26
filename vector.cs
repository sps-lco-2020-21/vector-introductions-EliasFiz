using System;
using System.Collections;
using System.Collections.Generic;

namespace vector_introductions_EliasFiz
{
    public class Vector<T>
        : IEquatable<Vector<T>>,
            IEnumerable<T>
            where T : IEquatable<T>
    {
        int _size;

        List<T> _components;

        public Vector()
        {
            _components = new List<T>();
        }

        public Vector(IEnumerable<T> list)
        {
            foreach (T item in list)
            {
                _components.Add(item);
            }
        }

        public List<T> Values { get => _components; }

        public double Modulus
        {
            get
            {
                double sum = 0;
                foreach (T value in Values)
                {
                    sum += (dynamic)value * value;
                }
                return Math.Sqrt(sum);
            }
        }

        public Vector<T> Add(Vector<T> vector)
        {
            List<T> sumVector = new List<T>();

            for (int i = 0; i < _size; ++i)
            {
                T sum = (dynamic)_components[i] + (dynamic)vector._components[i];
                sumVector.Add(sum);
            }

            return new Vector<T>(sumVector);
        }

        public Vector<T> ScalarProd(T k)
        {
            List<T> scaledVector = new List<T>();

            foreach (T component in _components)
            {
                scaledVector.Add((dynamic)component * (dynamic)k);
            }

            return new Vector<T>(scaledVector);
        }

        public T DotProd(Vector<T> vector)
        {
            T dotProduct = (dynamic)0;

            for (int i = 0; i < _size; ++i)
            {
                dotProduct += (dynamic)_components[i] * (dynamic)vector._components[i];
            }

            return dotProduct;
        }

        public T Angle(Vector<T> vector, bool isDegrees)
        {

            if (isDegrees)
            {
                return Math.Acos((dynamic)DotProd(vector) / (dynamic)(_size * vector._size)) * (180 / Math.PI);
            }

            return Math.Acos((dynamic)DotProd(vector) / (dynamic)(_size * vector._size));
        }

        public T GeometricDot(Vector<T> vector)
        {
            return Modulus * vector.Modulus * Math.Cos((dynamic)Angle(vector, true));
        }

        public Vector<T> ConvexCombination(T val, Vector<T> vector)
        {
            Vector<T> v1 = ScalarProd(val);
            Vector<T> v2 = ScalarProd(1 - (dynamic)val);

            List<T> convexVector = v1.Add((dynamic)v2);

            return new Vector<T>(convexVector);
        }




        // Code below necessary to run code

        public bool Equals(Vector<T> other)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}