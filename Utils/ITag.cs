using System;

namespace ZincOxide.Utils {

	/// <summary>
	/// An interface that contains a tag-object.
	/// </summary>
	public interface ITag<TTag> {
		/// <summary>
		/// Gets the tag of the object.
		/// </summary>
		/// <value>The tag of the object.</value>
		TTag Tag {
			get;
		}
	}
}

