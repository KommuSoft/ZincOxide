using ZincOxide.Utils;

namespace ZincOxide {

	/// <summary>
	/// A base implementation class of a <see cref="ITag{T}"/>.
	/// </summary>
	public abstract class TagBase<TTag>  : ITag<TTag> {
		private TTag tag;

		#region ITag implementation

		/// <summary>
		/// Gets the tag of the object.
		/// </summary>
		/// <value>The tag of the object.</value>
		public TTag Tag {
			get {
				return this.tag;
			}
			protected set {
				this.tag = value;
			}
		}

		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxide.TagBase`1"/> class with a given tag.
		/// </summary>
		/// <param name="tag">The tag of the object.</param>
		protected TagBase (TTag tag) {
			this.Tag = tag;
		}
	}
}

