using ZincOxide.Utils;

namespace ZincOxide
{
	public abstract class TagBase<TTag>  : ITag<TTag>
	{
		private TTag tag;

		#region ITag implementation

		public TTag Tag {
			get {
				return this.tag;
			}
			protected set {
				this.tag = value;
			}
		}

		#endregion

		protected TagBase (TTag tag)
		{
			this.tag = tag;
		}
	}
}

