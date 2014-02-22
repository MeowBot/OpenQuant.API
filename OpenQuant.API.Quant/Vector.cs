using System;
namespace OpenQuant.API.Quant
{
	public class Vector
	{
		private int fNRows;
		private double[] fElements;
		public int NRows
		{
			get
			{
				return this.fNRows;
			}
		}
		public double[] Elements
		{
			get
			{
				return this.fElements;
			}
		}
		public double this[int index]
		{
			get
			{
				return this.fElements[index];
			}
			set
			{
				this.fElements[index] = value;
			}
		}
		private void Allocate(int nrows, int row_lwb)
		{
			if (nrows <= 0)
			{
				throw new ArgumentException("Number of rows has to be positive");
			}
			this.fNRows = nrows;
			this.fElements = new double[this.fNRows];
		}
		public Vector()
		{
			this.fNRows = -1;
		}
		public Vector(int nrows)
		{
			this.Allocate(nrows, 0);
		}
		public bool IsValid()
		{
			return this.fNRows != -1;
		}
		public static bool AreCompatible(Vector v1, Vector v2)
		{
			if (!v1.IsValid())
			{
				throw new ArgumentException("Vector 1 is not initialized");
			}
			if (!v2.IsValid())
			{
				throw new ArgumentException("Vector 2 is not initialized");
			}
			return v1.fNRows == v2.fNRows;
		}
		public void Zero()
		{
			for (int i = 0; i < this.fNRows; i++)
			{
				this.fElements[i] = 0.0;
			}
		}
		public void ResizeTo(int newNRows)
		{
			if (newNRows <= 0)
			{
				throw new ArgumentException("Number of rows has to be positive");
			}
			double[] array = new double[newNRows];
			int num = Math.Min(this.fNRows, newNRows);
			for (int i = 0; i < num; i++)
			{
				array[i] = this.fElements[i];
			}
			this.fNRows = newNRows;
			this.fElements = array;
		}
		public double Norm1()
		{
			if (!this.IsValid())
			{
				throw new ApplicationException("Vector is not initialized");
			}
			double num = 0.0;
			double[] array = this.fElements;
			for (int i = 0; i < array.Length; i++)
			{
				double num2 = array[i];
				num += num2;
			}
			return num;
		}
		public double Norm2Sqr()
		{
			if (!this.IsValid())
			{
				throw new ApplicationException("Vector is not initialized");
			}
			double num = 0.0;
			double[] array = this.fElements;
			for (int i = 0; i < array.Length; i++)
			{
				double num2 = array[i];
				num += num2 * num2;
			}
			return num;
		}
		public double NormInf()
		{
			if (!this.IsValid())
			{
				throw new ApplicationException("Vector is not initialized");
			}
			double num = 0.0;
			double[] array = this.fElements;
			for (int i = 0; i < array.Length; i++)
			{
				double value = array[i];
				num = Math.Max(num, Math.Abs(value));
			}
			return num;
		}
		public static double operator *(Vector v1, Vector v2)
		{
			if (!Vector.AreCompatible(v1, v2))
			{
				throw new ApplicationException("Vectors are not compatible");
			}
			double num = 0.0;
			for (int i = 0; i < v1.fNRows; i++)
			{
				num += v1[i] * v2[i];
			}
			return num;
		}
		public static Vector operator *(Vector vector, double val)
		{
			if (!vector.IsValid())
			{
				throw new ApplicationException("Vector is not initialized");
			}
			Vector vector2 = new Vector(vector.fNRows);
			for (int i = 0; i < vector.fNRows; i++)
			{
				vector2[i] = vector[i] * val;
			}
			return vector2;
		}
		public static Vector operator +(Vector vector, double val)
		{
			if (!vector.IsValid())
			{
				throw new ApplicationException("Vector is not initialized");
			}
			Vector vector2 = new Vector(vector.fNRows);
			for (int i = 0; i < vector.fNRows; i++)
			{
				vector2[i] = vector[i] + val;
			}
			return vector2;
		}
		public static Vector operator -(Vector vector, double val)
		{
			if (!vector.IsValid())
			{
				throw new ApplicationException("Vector is not initialized");
			}
			Vector vector2 = new Vector(vector.fNRows);
			for (int i = 0; i < vector.fNRows; i++)
			{
				vector2[i] = vector[i] - val;
			}
			return vector2;
		}
		public Vector Abs()
		{
			if (!this.IsValid())
			{
				throw new ApplicationException("Vector is not initialized");
			}
			Vector vector = new Vector(this.fNRows);
			for (int i = 0; i < this.fNRows; i++)
			{
				vector[i] = Math.Abs(this.fElements[i]);
			}
			return vector;
		}
		public Vector Sqr()
		{
			if (!this.IsValid())
			{
				throw new ApplicationException("Vector is not initialized");
			}
			Vector vector = new Vector(this.fNRows);
			for (int i = 0; i < this.fNRows; i++)
			{
				vector[i] = this.fElements[i] * this.fElements[i];
			}
			return vector;
		}
		public Vector Sqrt()
		{
			if (!this.IsValid())
			{
				throw new ApplicationException("Vector is not initialized");
			}
			Vector vector = new Vector(this.fNRows);
			for (int i = 0; i < this.fNRows; i++)
			{
				vector[i] = Math.Sqrt(this.fElements[i]);
			}
			return vector;
		}
		public static Vector operator +(Vector target, Vector source)
		{
			if (!source.IsValid())
			{
				throw new ApplicationException("Source vector is not initialized");
			}
			if (!target.IsValid())
			{
				throw new ApplicationException("Target vector is not initialized");
			}
			if (!Vector.AreCompatible(target, source))
			{
				throw new ApplicationException("Vectors are not compatible");
			}
			Vector vector = new Vector(target.fNRows);
			for (int i = 0; i < target.fNRows; i++)
			{
				vector[i] = target[i] + source[i];
			}
			return vector;
		}
		public static Vector operator -(Vector target, Vector source)
		{
			if (!source.IsValid())
			{
				throw new ApplicationException("Source vector is not initialized");
			}
			if (!target.IsValid())
			{
				throw new ApplicationException("Target vector is not initialized");
			}
			if (!Vector.AreCompatible(target, source))
			{
				throw new ApplicationException("Vectors are not compatible");
			}
			Vector vector = new Vector(target.fNRows);
			for (int i = 0; i < target.fNRows; i++)
			{
				vector[i] = target[i] - source[i];
			}
			return vector;
		}
		public Vector ElementMult(Vector target, Vector source)
		{
			if (!source.IsValid())
			{
				throw new ApplicationException("Source vector is not initialized");
			}
			if (!target.IsValid())
			{
				throw new ApplicationException("Target vector is not initialized");
			}
			if (!Vector.AreCompatible(target, source))
			{
				throw new ApplicationException("Vectors are not compatible");
			}
			Vector vector = new Vector(target.fNRows);
			for (int i = 0; i < this.fNRows; i++)
			{
				vector[i] = target[i] * source[i];
			}
			return vector;
		}
		public Vector ElementDiv(Vector target, Vector source)
		{
			if (!source.IsValid())
			{
				throw new ApplicationException("Source vector is not initialized");
			}
			if (!target.IsValid())
			{
				throw new ApplicationException("Target vector is not initialized");
			}
			if (!Vector.AreCompatible(target, source))
			{
				throw new ApplicationException("Vectors are not compatible");
			}
			Vector vector = new Vector(target.fNRows);
			for (int i = 0; i < this.fNRows; i++)
			{
				vector[i] = target[i] / source[i];
			}
			return vector;
		}
		public override bool Equals(object vector)
		{
			Vector vector2 = (Vector)vector;
			if (this.fNRows != vector2.fNRows)
			{
				return false;
			}
			for (int i = 0; i < vector2.fNRows; i++)
			{
				if (this[i] != vector2[i])
				{
					return false;
				}
			}
			return true;
		}
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		public override string ToString()
		{
			return base.ToString();
		}
		public void Print()
		{
			this.Print("F2");
		}
		public void Print(string Format)
		{
			for (int i = 0; i < this.fNRows; i++)
			{
				Console.WriteLine(this.fElements[i].ToString(Format) + " ");
			}
		}
	}
}
