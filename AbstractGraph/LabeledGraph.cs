using System;

namespace ZincOxide.AbstractGraph
{
	public class LabeledGraph<TNode,TLabel>
	{
		public LabeledGraph ()
		{
		}

		public class Node <TNode> : ITag<TNode>
		{
		}
	}
}

