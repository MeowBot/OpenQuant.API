using System;
namespace OpenQuant.API.Quant
{
	public class Matrix
	{
		internal double[,] fElements;
		internal int fRows;
		internal int fCols;
		internal MatrixDiag fDiagonal;
		public MatrixDiag Diagonal
		{
			get
			{
				return this.fDiagonal;
			}
		}
		public int M
		{
			get
			{
				return this.fRows;
			}
		}
		public int N
		{
			get
			{
				return this.fCols;
			}
		}
		public int Rows
		{
			get
			{
				return this.fRows;
			}
		}
		public int Cols
		{
			get
			{
				return this.fCols;
			}
		}
		public double[,] Elements
		{
			get
			{
				return this.fElements;
			}
		}
		public double this[int row, int col]
		{
			get
			{
				if (row >= 0 && row < this.M && col >= 0 && col < this.N)
				{
					return this.fElements[row, col];
				}
				return 0.0;
			}
			set
			{
				if (row >= 0 && row < this.M && col >= 0 && col < this.N)
				{
					this.fElements[row, col] = value;
				}
			}
		}
		public Matrix Inverted
		{
			get
			{
				return new Matrix(this).Invert();
			}
		}
		public Matrix Transposed
		{
			get
			{
				return new Matrix(this).Transpose();
			}
		}
		public bool IsSymmetric
		{
			get
			{
				if (this.fCols != this.fRows)
				{
					return false;
				}
				for (int i = 0; i < this.fRows; i++)
				{
					for (int j = 0; j < i; j++)
					{
						if (this.fElements[i, j] != this.fElements[j, i])
						{
							return false;
						}
					}
				}
				return true;
			}
		}
		public Matrix()
		{
		}
		public Matrix(Matrix matrix)
		{
			this.fElements = new double[matrix.M, matrix.N];
			this.fDiagonal = new MatrixDiag(this);
			this.fRows = matrix.fRows;
			this.fCols = matrix.fCols;
			for (int i = 0; i < this.M; i++)
			{
				for (int j = 0; j < this.N; j++)
				{
					this.fElements[i, j] = matrix.fElements[i, j];
				}
			}
		}
		public Matrix(int m, int n)
		{
			this.fRows = m;
			this.fCols = n;
			this.fElements = new double[m, n];
			this.fDiagonal = new MatrixDiag(this);
		}
		public Matrix(int Size)
		{
			this.fRows = Size;
			this.fCols = Size;
			this.fElements = new double[Size, Size];
			this.fDiagonal = new MatrixDiag(this);
		}
		public Matrix(int m, int n, double val)
		{
			this.fRows = m;
			this.fCols = n;
			this.fElements = new double[m, n];
			this.fDiagonal = new MatrixDiag(this);
			for (int i = 0; i < m; i++)
			{
				for (int j = 0; j < n; j++)
				{
					this.fElements[i, j] = val;
				}
			}
		}
		public Matrix(double[] values)
		{
			this.fRows = 1;
			this.fCols = values.Length;
			this.fElements = new double[this.M, this.N];
			this.fDiagonal = new MatrixDiag(this);
			for (int i = 0; i < this.N; i++)
			{
				this.fElements[0, i] = values[i];
			}
		}
		public Matrix(double[,] values)
		{
			this.fRows = values.GetLength(0);
			this.fCols = values.GetLength(1);
			this.fElements = new double[this.M, this.N];
			this.fDiagonal = new MatrixDiag(this);
			for (int i = 0; i < this.fRows; i++)
			{
				for (int j = 0; j < this.fCols; j++)
				{
					this.fElements[i, j] = values[i, j];
				}
			}
		}
		public void MakeEigenVectors(Vector d, Vector e, Matrix z)
		{
			int rows = z.Rows;
			double[] elements = d.Elements;
			double[] elements2 = e.Elements;
			double[] array = new double[rows * rows];
			for (int i = 0; i < rows * rows; i++)
			{
				array[i] = z.Elements[i / rows, i % rows];
			}
			int j;
			for (j = 1; j < rows; j++)
			{
				elements2[j - 1] = elements2[j];
			}
			elements2[rows - 1] = 0.0;
			j = 0;
			while (j < rows)
			{
				int num = 0;
				int k;
				do
				{
					for (k = j; k < rows - 1; k++)
					{
						double num2 = Math.Abs(elements[k]) + Math.Abs(elements[k + 1]);
						if (Math.Abs(elements2[k]) + num2 == num2)
						{
							break;
						}
					}
					if (k != j)
					{
						if (num++ == 30)
						{
							goto Block_5;
						}
						double num3 = (elements[j + 1] - elements[j]) / (2.0 * elements2[j]);
						double num4 = Math.Sqrt(num3 * num3 + 1.0);
						num3 = elements[k] - elements[j] + elements2[j] / (num3 + ((num3 >= 0.0) ? Math.Abs(num4) : (-Math.Abs(num4))));
						double num5 = 1.0;
						double num6 = 1.0;
						double num7 = 0.0;
						int l;
						for (l = k - 1; l >= j; l--)
						{
							double num8 = num5 * elements2[l];
							double num9 = num6 * elements2[l];
							num4 = Math.Sqrt(num8 * num8 + num3 * num3);
							elements2[l + 1] = num4;
							if (num4 == 0.0)
							{
								elements[l + 1] -= num7;
								elements2[k] = 0.0;
								break;
							}
							num5 = num8 / num4;
							num6 = num3 / num4;
							num3 = elements[l + 1] - num7;
							num4 = (elements[l] - num3) * num5 + 2.0 * num6 * num9;
							num7 = num5 * num4;
							elements[l + 1] = num3 + num7;
							num3 = num6 * num4 - num9;
							for (int m = 0; m < rows; m++)
							{
								num8 = array[m + (l + 1) * rows];
								array[m + (l + 1) * rows] = num5 * array[m + l * rows] + num6 * num8;
								array[m + l * rows] = num6 * array[m + l * rows] - num5 * num8;
							}
						}
						if (num4 != 0.0 || l < j)
						{
							elements[j] -= num7;
							elements2[j] = num3;
							elements2[k] = 0.0;
						}
					}
				}
				while (k != j);
				j++;
				continue;
				Block_5:
				this.Error("MakeEigenVectors", "too many iterationsn");
				return;
			}
			for (int n = 0; n < rows * rows; n++)
			{
				z.Elements[n / rows, n % rows] = array[n];
			}
		}
		public void EigenSort(Matrix eigenVectors, Vector eigenValues)
		{
			int rows = eigenVectors.Rows;
			double[] array = new double[rows * rows];
			for (int i = 0; i < rows * rows; i++)
			{
				array[i] = eigenVectors.Elements[i / rows, i % rows];
			}
			double[] elements = eigenValues.Elements;
			for (int j = 0; j < rows; j++)
			{
				int num = j;
				double num2 = elements[j];
				for (int k = j + 1; k < rows; k++)
				{
					if (elements[k] >= num2)
					{
						num = k;
						num2 = elements[k];
					}
				}
				if (num != j)
				{
					elements[num] = elements[j];
					elements[j] = num2;
					for (int k = 0; k < rows; k++)
					{
						num2 = array[k + j * rows];
						array[k + j * rows] = array[k + num * rows];
						array[k + num * rows] = num2;
					}
				}
			}
			for (int l = 0; l < rows * rows; l++)
			{
				eigenVectors.Elements[l / rows, l % rows] = array[l];
			}
		}
		public Matrix EigenVectors(Vector eigenValues)
		{
			if (this.IsSymmetric)
			{
				Matrix matrix = new Matrix(this.Rows, this.Cols);
				for (int i = 0; i < this.Rows; i++)
				{
					for (int j = 0; j < this.Cols; j++)
					{
						matrix[i, j] = this[i, j];
					}
				}
				eigenValues.ResizeTo(this.Rows);
				Vector e = new Vector(this.Rows);
				this.MakeTridiagonal(matrix, eigenValues, e);
				this.MakeEigenVectors(eigenValues, e, matrix);
				this.EigenSort(matrix, eigenValues);
				return matrix;
			}
			throw new ApplicationException("Not yet implemented for non-symmetric matrix");
		}
		public void MakeTridiagonal(Matrix a, Vector d, Vector e)
		{
			int num = a.fRows;
			if (a.fRows != a.fCols)
			{
				throw new ApplicationException("Matrix to tridiagonalize must be square");
			}
			if (!a.IsSymmetric)
			{
				throw new ApplicationException("Can only tridiagonalise symmetric matrix");
			}
			double[] array = new double[this.M * this.N];
			for (int i = 0; i < this.M * this.N; i++)
			{
				array[i] = a.Elements[i / this.M, i % this.N];
			}
			double[] elements = d.Elements;
			double[] elements2 = e.Elements;
			for (int j = num - 1; j > 0; j--)
			{
				int num2 = j - 1;
				double num3 = 0.0;
				double num4 = 0.0;
				if (num2 > 0)
				{
					for (int k = 0; k <= num2; k++)
					{
						num4 += Math.Abs(array[j + k * num]);
					}
					if (num4 == 0.0)
					{
						elements2[j] = array[j + num2 * num];
					}
					else
					{
						for (int l = 0; l <= num2; l++)
						{
							array[j + l * num] /= num4;
							num3 += array[j + l * num] * array[j + l * num];
						}
						double num5 = array[j + num2 * num];
						double num6;
						if (num5 >= 0.0)
						{
							num6 = -Math.Sqrt(num3);
						}
						else
						{
							num6 = Math.Sqrt(num3);
						}
						elements2[j] = num4 * num6;
						num3 -= num5 * num6;
						array[j + num2 * num] = num5 - num6;
						num5 = 0.0;
						for (int m = 0; m <= num2; m++)
						{
							array[m + j * num] = array[j + m * num] / num3;
							num6 = 0.0;
							for (int l = 0; l <= m; l++)
							{
								num6 += array[m + l * num] * array[j + l * num];
							}
							for (int l = m + 1; l <= num2; l++)
							{
								num6 += array[l + m * num] * array[j + l * num];
							}
							elements2[m] = num6 / num3;
							num5 += elements2[m] * array[j + m * num];
						}
						double num7 = num5 / (num3 + num3);
						for (int m = 0; m <= num2; m++)
						{
							num5 = array[j + m * num];
							num6 = (elements2[m] -= num7 * num5);
							for (int l = 0; l <= m; l++)
							{
								array[m + l * num] -= num5 * elements2[l] + num6 * array[j + l * num];
							}
						}
					}
				}
				else
				{
					elements2[j] = array[j + num2 * num];
				}
				elements[j] = num3;
			}
			elements[0] = 0.0;
			elements2[0] = 0.0;
			for (int j = 0; j < num; j++)
			{
				int num8 = j - 1;
				if (elements[j] != 0.0)
				{
					for (int n = 0; n <= num8; n++)
					{
						double num9 = 0.0;
						for (int num10 = 0; num10 <= num8; num10++)
						{
							num9 += array[j + num10 * num] * array[num10 + n * num];
						}
						for (int num10 = 0; num10 <= num8; num10++)
						{
							array[num10 + n * num] -= num9 * array[num10 + j * num];
						}
					}
				}
				elements[j] = array[j + j * num];
				array[j + j * num] = 1.0;
				for (int num11 = 0; num11 <= num8; num11++)
				{
					array[num11 + j * num] = (array[j + num11 * num] = 0.0);
				}
			}
			for (int num12 = 0; num12 < this.M * this.N; num12++)
			{
				a.Elements[num12 / this.M, num12 % this.N] = array[num12];
			}
		}
		public static Matrix operator +(Matrix Matrix1, Matrix Matrix2)
		{
			if (Matrix1.M == Matrix2.M && Matrix1.N == Matrix2.N)
			{
				Matrix matrix = new Matrix(Matrix1.M, Matrix1.N);
				for (int i = 0; i < Matrix1.M; i++)
				{
					for (int j = 0; j < Matrix1.N; j++)
					{
						matrix[i, j] = Matrix1[i, j] + Matrix2[i, j];
					}
				}
				return matrix;
			}
			return new Matrix();
		}
		public static Matrix operator -(Matrix Matrix1, Matrix Matrix2)
		{
			if (Matrix1.M == Matrix2.M && Matrix1.N == Matrix2.N)
			{
				Matrix matrix = new Matrix(Matrix1.M, Matrix1.N);
				for (int i = 0; i < Matrix1.M; i++)
				{
					for (int j = 0; j < Matrix1.N; j++)
					{
						matrix[i, j] = Matrix1[i, j] - Matrix2[i, j];
					}
				}
				return matrix;
			}
			return new Matrix();
		}
		public static Matrix operator *(Matrix Matrix1, Matrix Matrix2)
		{
			if (Matrix1.N == Matrix2.M)
			{
				Matrix matrix = new Matrix(Matrix1.M, Matrix2.N);
				for (int i = 0; i < Matrix1.M; i++)
				{
					for (int j = 0; j < Matrix2.N; j++)
					{
						double num = 0.0;
						for (int k = 0; k < Matrix1.N; k++)
						{
							num += Matrix1[i, k] * Matrix2[k, j];
						}
						matrix[i, j] = num;
					}
				}
				return matrix;
			}
			return Matrix1;
		}
		public static Matrix operator /(Matrix Matrix1, Matrix Matrix2)
		{
			if (Matrix1.M == Matrix2.M && Matrix1.N == Matrix2.N)
			{
				Matrix matrix = new Matrix(Matrix1.M, Matrix1.N);
				for (int i = 0; i < Matrix1.M; i++)
				{
					for (int j = 0; j < Matrix1.N; j++)
					{
						matrix[i, j] = Matrix1[i, j] / Matrix2[i, j];
					}
				}
				return matrix;
			}
			return Matrix1;
		}
		public static Matrix operator +(Matrix matrix, double Scalar)
		{
			Matrix matrix2 = new Matrix(matrix.M, matrix.N);
			for (int i = 0; i < matrix.M; i++)
			{
				for (int j = 0; j < matrix.N; j++)
				{
					matrix2[i, j] = matrix[i, j] + Scalar;
				}
			}
			return matrix2;
		}
		public static Matrix operator -(Matrix matrix, double Scalar)
		{
			return matrix + -Scalar;
		}
		public static Matrix operator *(Matrix matrix, double Scalar)
		{
			Matrix matrix2 = new Matrix(matrix.M, matrix.N);
			for (int i = 0; i < matrix.M; i++)
			{
				for (int j = 0; j < matrix.N; j++)
				{
					matrix2[i, j] = matrix[i, j] * Scalar;
				}
			}
			return matrix2;
		}
		public static Matrix operator /(Matrix matrix, double Scalar)
		{
			return matrix * (1.0 / Scalar);
		}
		public static bool AreComparable(Matrix Matrix1, Matrix Matrix2)
		{
			return Matrix1.fRows == Matrix2.fRows && Matrix1.fCols == Matrix2.fCols;
		}
		public static bool operator ==(Matrix Matrix1, Matrix Matrix2)
		{
			if (!Matrix.AreComparable(Matrix1, Matrix2))
			{
				return false;
			}
			for (int i = 0; i < Matrix1.fRows; i++)
			{
				for (int j = 0; j < Matrix1.fCols; j++)
				{
					if (Matrix1.fElements[i, j] != Matrix2.fElements[i, j])
					{
						return false;
					}
				}
			}
			return true;
		}
		public static bool operator !=(Matrix Matrix1, Matrix Matrix2)
		{
			if (!Matrix.AreComparable(Matrix1, Matrix2))
			{
				return false;
			}
			for (int i = 0; i < Matrix1.fRows; i++)
			{
				for (int j = 0; j < Matrix1.fCols; j++)
				{
					if (Matrix1.fElements[i, j] == Matrix2.fElements[i, j])
					{
						return false;
					}
				}
			}
			return true;
		}
		public static bool operator ==(Matrix matrix, double Scalar)
		{
			for (int i = 0; i < matrix.fRows; i++)
			{
				for (int j = 0; j < matrix.fCols; j++)
				{
					if (matrix.fElements[i, j] != Scalar)
					{
						return false;
					}
				}
			}
			return true;
		}
		public static bool operator !=(Matrix matrix, double Scalar)
		{
			for (int i = 0; i < matrix.fRows; i++)
			{
				for (int j = 0; j < matrix.fCols; j++)
				{
					if (matrix.fElements[i, j] == Scalar)
					{
						return false;
					}
				}
			}
			return true;
		}
		public static bool operator <(Matrix matrix, double Scalar)
		{
			for (int i = 0; i < matrix.fRows; i++)
			{
				for (int j = 0; j < matrix.fCols; j++)
				{
					if (matrix.fElements[i, j] >= Scalar)
					{
						return false;
					}
				}
			}
			return true;
		}
		public static bool operator <=(Matrix matrix, double Scalar)
		{
			for (int i = 0; i < matrix.fRows; i++)
			{
				for (int j = 0; j < matrix.fCols; j++)
				{
					if (matrix.fElements[i, j] > Scalar)
					{
						return false;
					}
				}
			}
			return true;
		}
		public static bool operator >(Matrix matrix, double Scalar)
		{
			for (int i = 0; i < matrix.fRows; i++)
			{
				for (int j = 0; j < matrix.fCols; j++)
				{
					if (matrix.fElements[i, j] <= Scalar)
					{
						return false;
					}
				}
			}
			return true;
		}
		public static bool operator >=(Matrix matrix, double Scalar)
		{
			for (int i = 0; i < matrix.fRows; i++)
			{
				for (int j = 0; j < matrix.fCols; j++)
				{
					if (matrix.fElements[i, j] < Scalar)
					{
						return false;
					}
				}
			}
			return true;
		}
		public Matrix Abs()
		{
			for (int i = 0; i < this.fRows; i++)
			{
				for (int j = 0; j < this.fCols; j++)
				{
					this.fElements[i, j] = Math.Abs(this.fElements[i, j]);
				}
			}
			return this;
		}
		public Matrix Sqr()
		{
			for (int i = 0; i < this.fRows; i++)
			{
				for (int j = 0; j < this.fCols; j++)
				{
					this.fElements[i, j] = Math.Pow(this.fElements[i, j], 2.0);
				}
			}
			return this;
		}
		public Matrix Sqrt()
		{
			for (int i = 0; i < this.fRows; i++)
			{
				for (int j = 0; j < this.fCols; j++)
				{
					this.fElements[i, j] = Math.Sqrt(this.fElements[i, j]);
				}
			}
			return this;
		}
		public double RowNorm()
		{
			double num = 0.0;
			for (int i = 0; i < this.fRows; i++)
			{
				double num2 = 0.0;
				for (int j = 0; j < this.fCols; j++)
				{
					num2 += Math.Abs(this.fElements[i, j]);
				}
				num = Math.Max(num2, num);
			}
			return num;
		}
		public double ColNorm()
		{
			double num = 0.0;
			for (int i = 0; i < this.fCols; i++)
			{
				double num2 = 0.0;
				for (int j = 0; j < this.fRows; j++)
				{
					num2 += Math.Abs(this.fElements[j, i]);
				}
				num = Math.Max(num2, num);
			}
			return num;
		}
		public double E2Norm()
		{
			double num = 0.0;
			for (int i = 0; i < this.fRows; i++)
			{
				for (int j = 0; j < this.fCols; j++)
				{
					num += Math.Pow(this.fElements[i, j], 2.0);
				}
			}
			return num;
		}
		public double E2Norm(Matrix Matrix1, Matrix Matrix2)
		{
			double num = 0.0;
			for (int i = 0; i < this.fRows; i++)
			{
				for (int j = 0; j < this.fCols; j++)
				{
					num += Math.Pow(Matrix1.fElements[i, j] - Matrix2.fElements[i, j], 2.0);
				}
			}
			return num;
		}
		public Matrix NormByDiag()
		{
			if (this.fRows != this.fCols)
			{
				this.Error("NormByDiag", "Not square");
				return this;
			}
			double[] array = new double[this.Diagonal.NDiag];
			for (int i = 0; i < this.Diagonal.NDiag; i++)
			{
				array[i] = this.Diagonal[i];
				if (array[i] == 0.0)
				{
					this.Error("NormByDiag", "Zeros in diagonal");
					return this;
				}
			}
			for (int j = 0; j < this.fRows; j++)
			{
				for (int k = 0; k < this.fCols; k++)
				{
					this[j, k] /= Math.Sqrt(array[j] * array[k]);
				}
			}
			return this;
		}
		public Matrix Transpose()
		{
			double[,] array = new double[this.fCols, this.fRows];
			for (int i = 0; i < this.fRows; i++)
			{
				for (int j = 0; j < this.fCols; j++)
				{
					array[j, i] = this.fElements[i, j];
				}
			}
			this.fElements = array;
			int num = this.fCols;
			this.fCols = this.fRows;
			this.fRows = num;
			return this;
		}
		public Matrix Invert()
		{
			double num;
			return this.Invert(out num);
		}
		public Matrix Invert(out double det)
		{
			det = 1.0;
			if (this.Rows != this.Cols)
			{
				this.Error("Invert", "#columns != #rows");
			}
			int rows = this.Rows;
			Matrix matrix = new Matrix(rows, 2 * rows);
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < rows; j++)
				{
					matrix[i, j] = this[i, j];
				}
			}
			for (int k = 0; k < rows; k++)
			{
				for (int l = rows; l < 2 * rows; l++)
				{
					matrix[k, l] = (double)((k == l - rows) ? 1 : 0);
				}
			}
			for (int m = 0; m < rows; m++)
			{
				double num = 0.0;
				int num2 = -1;
				for (int n = m; n < rows; n++)
				{
					if (Math.Abs(matrix[n, m]) > num)
					{
						num = Math.Abs(matrix[n, m]);
						num2 = n;
					}
				}
				if (num < 1E-35)
				{
					throw new ApplicationException("Element max value less than required minimum.");
				}
				if (num2 != m)
				{
					for (int num3 = m; num3 < 2 * rows; num3++)
					{
						double value = matrix[m, num3];
						matrix[m, num3] = matrix[num2, num3];
						matrix[num2, num3] = value;
					}
					det = -det;
				}
				for (int num4 = 0; num4 < rows; num4++)
				{
					if (num4 != m)
					{
						double num5 = matrix[num4, m] / matrix[m, m];
						for (int num6 = m; num6 < 2 * rows; num6++)
						{
							matrix[num4, num6] -= matrix[m, num6] * num5;
						}
					}
				}
				double num7 = matrix[m, m];
				for (int num8 = m; num8 < 2 * rows; num8++)
				{
					matrix[m, num8] /= num7;
				}
				det *= num7;
			}
			for (int num9 = 0; num9 < rows; num9++)
			{
				for (int num10 = 0; num10 < rows; num10++)
				{
					this[num9, num10] = matrix[num9, rows + num10];
				}
			}
			return this;
		}
		public Matrix MakeSymetric()
		{
			if (this.fCols != this.fRows)
			{
				this.Error("MakeSymetric", "Matrix to symmetrize must be square");
				return this;
			}
			for (int i = 0; i < this.fRows; i++)
			{
				for (int j = 0; j < this.fCols; j++)
				{
					this.fElements[i, j] = (this.fElements[i, j] + this.fElements[j, i]) / 2.0;
					this.fElements[j, i] = this.fElements[i, j];
				}
			}
			return this;
		}
		public Matrix UnitMatrix()
		{
			for (int i = 0; i < this.fRows; i++)
			{
				for (int j = 0; j < this.fCols; j++)
				{
					if (i == j)
					{
						this.fElements[i, j] = 1.0;
					}
					else
					{
						this.fElements[i, j] = 0.0;
					}
				}
			}
			return this;
		}
		public Matrix HilbertMatrix()
		{
			for (int i = 0; i < this.fRows; i++)
			{
				for (int j = 0; j < this.fCols; j++)
				{
					if (i == j)
					{
						this.fElements[i, j] = 1.0 / ((double)(i + j) + 1.0);
					}
				}
			}
			return this;
		}
		public Matrix HilbertMatrix2()
		{
			for (int i = 0; i < this.fRows; i++)
			{
				for (int j = 0; j < this.fCols; j++)
				{
					if (i == j)
					{
						this.fElements[i, j] = 1.0 / ((double)(i + j) + 1.0);
					}
				}
			}
			return this;
		}
		public void Print()
		{
			this.Print("F2");
		}
		public void Print(string Format)
		{
			for (int i = 0; i < this.M; i++)
			{
				for (int j = 0; j < this.N; j++)
				{
					Console.Write(" " + this[i, j].ToString(Format));
				}
				Console.WriteLine("");
			}
		}
		public override bool Equals(object matrix)
		{
			Matrix matrix2 = (Matrix)matrix;
			return this == matrix2;
		}
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		public override string ToString()
		{
			return base.ToString();
		}
		protected void Error(string Where, string What)
		{
			Console.WriteLine("Matrix: " + Where + " : " + What);
		}
	}
}
