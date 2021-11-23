using System;
using System.Collections;
using System.Collections.Generic;
using PolynomialObject.Exceptions;

namespace PolynomialObject
{
    public sealed class Polynomial : IEnumerable<PolynomialMember>
    {
        readonly List<PolynomialMember> polynomialMembers;

        public Polynomial()
        {
            polynomialMembers = new List<PolynomialMember>();
        }

        public Polynomial(PolynomialMember member)
        {
            polynomialMembers = new List<PolynomialMember>() { member };
        }

        public Polynomial(IEnumerable<PolynomialMember> members)
        {
            polynomialMembers = new List<PolynomialMember>(members);
        }

        public Polynomial((double degree, double coefficient) member)
        {
            polynomialMembers = new List<PolynomialMember>() { new PolynomialMember(member.degree, member.coefficient) };
        }

        public Polynomial(IEnumerable<(double degree, double coefficient)> members)
        {
            polynomialMembers = new List<PolynomialMember>();
            foreach (var member in members)
            {
                polynomialMembers.Add(new PolynomialMember(member.degree, member.coefficient));
            }
        }

        /// <summary>
        /// The amount of not null polynomial members in polynomial 
        /// </summary>
        public int Count
        {
            get
            {
                int count = 0;
                foreach (var member in polynomialMembers)
                {
                    if (member != null)
                        count++;
                }
                return count;
            }
        }

        /// <summary>
        /// The biggest degree of polynomial member in polynomial
        /// </summary>
        public double Degree
        {
            get
            {
                double _degree = 0;
                foreach (var member in polynomialMembers)
                {
                    if (member.Degree > _degree)
                        _degree = member.Degree;
                }
                return _degree;
            }
        }

        /// <summary>
        /// Adds new unique member to polynomial 
        /// </summary>
        /// <param name="member">The member to be added</param>
        /// <exception cref="PolynomialArgumentException">Throws when member to add with such degree already exist in polynomial</exception>
        /// <exception cref="PolynomialArgumentNullException">Throws when trying to member to add is null</exception>
        public void AddMember(PolynomialMember member)
        {
            if (member == null)
                throw new PolynomialArgumentNullException();
			if (member.Coefficient == 0)
			{
                throw new PolynomialArgumentException();
			}
            foreach (var polynom in polynomialMembers)
            {
                if (polynom.Degree == member.Degree)
                    throw new PolynomialArgumentException();
            }
            polynomialMembers.Add(member);
        }

        /// <summary>
        /// Adds new unique member to polynomial from tuple
        /// </summary>
        /// <param name="member">The member to be added</param>
        /// <exception cref="PolynomialArgumentException">Throws when member to add with such degree already exist in polynomial</exception>
        public void AddMember((double degree, double coefficient) member)
        {
			if (member.coefficient == 0)
				throw new PolynomialArgumentException();
			foreach (var polynom in this)
            {
                if (polynom.Degree == member.degree)
                    throw new PolynomialArgumentException();
            }
            polynomialMembers.Add(new PolynomialMember(member.degree, member.coefficient));
        }

        /// <summary>
        /// Removes member of specified degree
        /// </summary>
        /// <param name="degree">The degree of member to be deleted</param>
        /// <returns>True if member has been deleted</returns>
        public bool RemoveMember(double degree)
        {
            bool isDone = false;
            foreach (var polynom in polynomialMembers)
            {
                if (polynom.Degree == degree)
                {
                    isDone = polynomialMembers.Remove(polynom);
                    break;
                }
            }
            return isDone;
        }

        /// <summary>
        /// Searches the polynomial for a method of specified degree
        /// </summary>
        /// <param name="degree">Degree of member</param>
        /// <returns>True if polynomial contains member</returns>
        public bool ContainsMember(double degree)
        {
            bool thereIs = false;
            foreach (var polynom in polynomialMembers)
            {
                if (polynom.Degree == degree)
                    thereIs = true;
            }
            return thereIs;
        }

        /// <summary>
        /// Finds member of specified degree
        /// </summary>
        /// <param name="degree">Degree of member</param>
        /// <returns>Returns the found member or null</returns>
        public PolynomialMember Find(double degree)
        {
            foreach (var polynom in polynomialMembers)
            {
                if (polynom.Degree == degree)
                    return polynom;
            }
            return null;
        }

        /// <summary>
        /// Gets and sets the coefficient of member with provided degree
        /// If there is no null member for searched degree - return 0 for get and add new member for set
        /// </summary>
        /// <param name="degree">The degree of searched member</param>
        /// <returns>Coefficient of found member</returns>
        public double this[double degree]
        {
            get
            {
                if (ContainsMember(degree))
                    return Find(degree).Coefficient;
                return 0;
            }
            set
            {
                if (Find(degree) != null)
                {
                    if (value == 0)
                        RemoveMember(degree);
                    else Find(degree).Coefficient = value;
                }
                else if (value != 0)
                    AddMember(new PolynomialMember(degree, value));
            }
        }

        /// <summary>
        /// Convert polynomial to array of included polynomial members 
        /// </summary>
        /// <returns>Array with not null polynomial members</returns>
        public PolynomialMember[] ToArray()
        {
            PolynomialMember[] polynomials = polynomialMembers.ToArray();
            return polynomials;
        }

        /// <summary>
        /// Adds two polynomials
        /// </summary>
        /// <param name="a">The first polynomial</param>
        /// <param name="b">The second polynomial</param>
        /// <returns>New polynomial after adding</returns>
        /// <exception cref="PolynomialArgumentNullException">Throws if either of provided polynomials is null</exception>
        public static Polynomial operator +(Polynomial a, Polynomial b)
        {
            if (a == null || b == null)
                throw new PolynomialArgumentNullException();
            Polynomial result = new Polynomial(a.polynomialMembers);
            for (int i = 0; i < b.polynomialMembers.Count; i++)
            {
                result[b.polynomialMembers[i].Degree] += b.polynomialMembers[i].Coefficient;
            }
            return result;
        }

        /// <summary>
        /// Subtracts two polynomials
        /// </summary>
        /// <param name="a">The first polynomial</param>
        /// <param name="b">The second polynomial</param>
        /// <returns>Returns new polynomial after subtraction</returns>
        /// <exception cref="PolynomialArgumentNullException">Throws if either of provided polynomials is null</exception>
        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            if (a == null || b == null)
                throw new PolynomialArgumentNullException();
            Polynomial validA = new Polynomial();
            for (int i = 0; i < a.polynomialMembers.Count; i++)
            {
                validA[a.polynomialMembers[i].Degree] += a.polynomialMembers[i].Coefficient;
            }
            Polynomial result = new Polynomial(validA);
            for (int i = 0; i < b.polynomialMembers.Count; i++)
            {
                result[b.polynomialMembers[i].Degree] -= b.polynomialMembers[i].Coefficient;
            }
            return result;
        }

        /// <summary>
        /// Multiplies two polynomials
        /// </summary>
        /// <param name="a">The first polynomial</param>
        /// <param name="b">The second polynomial</param>
        /// <returns>Returns new polynomial after multiplication</returns>
        /// <exception cref="PolynomialArgumentNullException">Throws if either of provided polynomials is null</exception>
        public static Polynomial operator *(Polynomial a, Polynomial b)
        {
            if (a == null || b == null)
                throw new PolynomialArgumentNullException();
            Polynomial result = new Polynomial();
            for (int i = 0; i < a.polynomialMembers.Count; i++)
            {
                for (int j = 0; j < b.polynomialMembers.Count; j++)
                {
                    double degree = a.polynomialMembers[i].Degree + b.polynomialMembers[j].Degree;
                    double coeficcient = a.polynomialMembers[i].Coefficient * b.polynomialMembers[j].Coefficient;
					if (result.Find(degree) is PolynomialMember member)
					{
                        coeficcient += member.Coefficient;
                        result.RemoveMember(degree);
					}
					if (coeficcient != 0)
					{
                        PolynomialMember polynomMember = new PolynomialMember(degree, coeficcient);
                        result.AddMember(polynomMember);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Adds polynomial to polynomial
        /// </summary>
        /// <param name="polynomial">The polynomial to add</param>
        /// <returns>Returns new polynomial after adding</returns>
        /// <exception cref="PolynomialArgumentNullException">Throws if provided polynomial is null</exception>
        public Polynomial Add(Polynomial polynomial)
        {
            if (polynomial == null)
                throw new PolynomialArgumentNullException();
            Polynomial result = new Polynomial(polynomialMembers);
            result += polynomial;
            return result;
        }

        /// <summary>
        /// Subtracts polynomial from polynomial
        /// </summary>
        /// <param name="polynomial">The polynomial to subtract</param>
        /// <returns>Returns new polynomial after subtraction</returns>
        /// <exception cref="PolynomialArgumentNullException">Throws if provided polynomial is null</exception>
        public Polynomial Subtraction(Polynomial polynomial)
        {
            if (polynomial == null)
                throw new PolynomialArgumentNullException();
            Polynomial result = new Polynomial(polynomialMembers);
            result -= polynomial;
            return result;
        }

        /// <summary>
        /// Multiplies polynomial with polynomial
        /// </summary>
        /// <param name="polynomial">The polynomial for multiplication </param>
        /// <returns>Returns new polynomial after multiplication</returns>
        /// <exception cref="PolynomialArgumentNullException">Throws if provided polynomial is null</exception>
        public Polynomial Multiply(Polynomial polynomial)
        {
            if (polynomial == null)
                throw new PolynomialArgumentNullException();
            Polynomial result = new Polynomial(polynomialMembers);
            result *= polynomial;
            return result;
        }

        /// <summary>
        /// Adds polynomial and tuple
        /// </summary>
        /// <param name="a">The polynomial</param>
        /// <param name="b">The tuple</param>
        /// <returns>Returns new polynomial after adding</returns>
        public static Polynomial operator +(Polynomial a, (double degree, double coefficient) b)
        {
            Polynomial result = new Polynomial(a.polynomialMembers);
            Polynomial temp = new Polynomial((b.degree, b.coefficient));
            for (int i = 0; i < temp.Count; i++)
            {
                result[temp.polynomialMembers[i].Degree] += temp.polynomialMembers[i].Coefficient;
            }
            return result;
        }

        /// <summary>
        /// Subtract polynomial and tuple
        /// </summary>
        /// <param name="a">The polynomial</param>
        /// <param name="b">The tuple</param>
        /// <returns>Returns new polynomial after subtraction</returns>
        public static Polynomial operator -(Polynomial a, (double degree, double coefficient) b)
        {
            Polynomial result = new Polynomial(a.polynomialMembers);
            Polynomial temp = new Polynomial((b.degree, b.coefficient));
            for (int i = 0; i < temp.Count; i++)
            {
                result[temp.polynomialMembers[i].Degree] -= temp.polynomialMembers[i].Coefficient;
            }
            return result;
        }

        /// <summary>
        /// Multiplies polynomial and tuple
        /// </summary>
        /// <param name="a">The polynomial</param>
        /// <param name="b">The tuple</param>
        /// <returns>Returns new polynomial after multiplication</returns>
        public static Polynomial operator *(Polynomial a, (double degree, double coefficient) b)
        {
            Polynomial result = new Polynomial();
            Polynomial temp = new Polynomial((b.degree, b.coefficient));
            for (int i = 0; i < a.polynomialMembers.Count; i++)
            {
                for (int j = 0; j < temp.polynomialMembers.Count; j++)
                {
                    double degree = a.polynomialMembers[i].Degree + temp.polynomialMembers[j].Degree;
                    double coeficcient = a.polynomialMembers[i].Coefficient * temp.polynomialMembers[j].Coefficient;
                    if (result.Find(degree) is PolynomialMember member)
                    {
                        coeficcient += member.Coefficient;
                        result.RemoveMember(degree);
                    }
                    if (coeficcient != 0)
                    {
                        PolynomialMember polynomMember = new PolynomialMember(degree, coeficcient);
                        result.AddMember(polynomMember);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Adds tuple to polynomial
        /// </summary>
        /// <param name="member">The tuple to add</param>
        /// <returns>Returns new polynomial after adding</returns>
        public Polynomial Add((double degree, double coefficient) member)
        {
            Polynomial result = new Polynomial(polynomialMembers);
            Polynomial temp = new Polynomial((member.degree, member.coefficient));
            result += temp;
            return result;
        }

        /// <summary>
        /// Subtracts tuple from polynomial
        /// </summary>
        /// <param name="member">The tuple to subtract</param>
        /// <returns>Returns new polynomial after subtraction</returns>
        public Polynomial Subtraction((double degree, double coefficient) member)
        {
            Polynomial result = new Polynomial(polynomialMembers);
            Polynomial temp = new Polynomial((member.degree, member.coefficient));
            result -= temp;
            return result;
        }

        /// <summary>
        /// Multiplies tuple with polynomial
        /// </summary>
        /// <param name="member">The tuple for multiplication </param>
        /// <returns>Returns new polynomial after multiplication</returns>
        public Polynomial Multiply((double degree, double coefficient) member)
        {
            Polynomial result = new Polynomial(polynomialMembers);
            Polynomial temp = new Polynomial ((member.degree, member.coefficient));
            result *= temp;
            return result;
        }

		public IEnumerator<PolynomialMember> GetEnumerator()
		{
			return ((IEnumerable<PolynomialMember>)polynomialMembers).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)polynomialMembers).GetEnumerator();
		}
	}
}
