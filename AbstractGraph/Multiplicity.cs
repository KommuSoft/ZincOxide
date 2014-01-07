using System;

namespace ZincOxide.AbstractGraph
{
	public struct Multiplicity
	{
		private int lower;
		private int upper;

		/// <summary>
		/// Gets or sets the lower bound of the multiplicity.
		/// </summary>
		/// <value>The lower of the multiplicity.</value>
		public int Lower {
			get {
				return this.lower;
			}
			set {
				if (value >= 0x00 && value <= upper) {
					this.lower = value;
				} else {
					throw new ArgumentException ("The lower bound must be greater or equal to zero and less than or equal to the upper bound.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the upper bound of the multiplicity.
		/// </summary>
		/// <value>The upper bound of the multiplicity.</value>
		public int Upper {
			get {
				return this.upper;
			}
			set {
				if (value >= this.lower) {
					this.upper = value;
				} else {
					throw new ArgumentException ("The upper bound must be greater or equal to the lower bound.");
				}
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxide.AbstractGraph.Multiplicity"/> struct with a given lower and upper bound.
		/// </summary>
		/// <param name="lower">The lower bound of the multiplicity.</param>
		/// <param name="upper">The upper bound of the multiplicity.</param>
		public Multiplicity (int lower, int upper)
		{
			if (checkConsistent (lower, upper)) {
				this.lower = lower;
				this.upper = upper;
			} else {
				throw new ArgumentException ("The lower bound must be greater or equal to zero and the upper bound must be greater or equal to the lower bound.");
			}
		}

		/// <summary>
		/// Sets the lower and upper bound of the multiplicity.
		/// </summary>
		/// <param name="lower">The lower bound of the multiplicity.</param>
		/// <param name="upper">The upper bound of the multiplicity.</param>
		public void SetLowerUpper (int lower, int upper)
		{
			if (checkConsistent (lower, upper)) {
				this.lower = lower;
				this.upper = upper;
			} else {
				throw new ArgumentException ("The lower bound must be greater or equal to zero and the upper bound must be greater or equal to the lower bound.");
			}
		}

		/// <summary>
		/// Checks if the given multiplicity is consistent with the rules.
		/// </summary>
		/// <param name="low">The lower bound of the multiplicity.</param>
		/// <param name="up">The upper bound of the multiplicity.</param>
		/// <returns><c>true</c>, if the multiplicity is consistent, <c>false</c> otherwise.</returns>
		private static bool checkConsistent (int low, int up)
		{
			return (low >= 0x00 && up >= low);
		}

		/// <summary>
		/// Tests if a given value <paramref name="x"/> is part of the multiplicity.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		public bool Contains (int x)
		{
			return this.lower <= x && x <= this.upper;
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="ZincOxide.AbstractGraph.Multiplicity"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="ZincOxide.AbstractGraph.Multiplicity"/>.</returns>
		public override string ToString ()
		{
			if (this.lower == this.upper) {
				return string.Format ("= {0}", this.lower);
			} else if (this.upper == int.MaxValue) {
				return string.Format ("{0}..*", this.lower);
			} else {
				return string.Format ("{0}..{1}", this.lower, this.upper);
			}
		}

		/// <summary>
		/// Serves as a hash function for a <see cref="ZincOxide.AbstractGraph.Multiplicity"/> object.
		/// </summary>
		/// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a hash table.</returns>
		public override int GetHashCode ()
		{
			return this.lower.GetHashCode () ^ this.upper.GetHashCode ();
		}

		/// <summary>
		/// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="ZincOxide.AbstractGraph.Multiplicity"/>.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with the current <see cref="ZincOxide.AbstractGraph.Multiplicity"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to the current
		/// <see cref="ZincOxide.AbstractGraph.Multiplicity"/>; otherwise, <c>false</c>.</returns>
		public override bool Equals (object obj)
		{
			if (obj != null && obj is Multiplicity) {
				Multiplicity mul = (Multiplicity)obj;
				return this.lower == mul.lower && this.upper == mul.upper;
			}
			return false;
		}
	}
}

