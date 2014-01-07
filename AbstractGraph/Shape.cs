using System;
using System.Collections.Generic;

namespace ZincOxide.AbstractGraph {

	public class Shape<TNode,TLabel> : LabeledGraph<TNode,TLabel> {
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxide.AbstractGraph.Shape{T,Q}"/> class with a given set of edges.
		/// </summary>
		/// <param name="edges">The set of edges.</param>
		public Shape (params Tuple<TNode,TLabel,TNode>[] edges) : base (edges) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxide.AbstractGraph.Shape{T,Q}"/> class with a given set of edges.
		/// </summary>
		/// <param name="edges">The set of edges.</param>
		public Shape (IEnumerable<Tuple<TNode,TLabel,TNode>> edges) : base (edges) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxide.AbstractGraph.Shape{T,Q}"/> class with a given set of nodes and edges.
		/// </summary>
		/// <param name="nodes">The set of nodes.</param>
		/// <param name="edges">The set of edges.</param>
		public Shape (IEnumerable<TNode> nodes, params Tuple<TNode,TLabel,TNode>[] edges) : base (nodes, edges) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxide.AbstractGraph.Shape{T,Q}"/> class with a given set of nodes and edges.
		/// </summary>
		/// <param name="nodes">The set of nodes.</param>
		/// <param name="edges">The set of edges.</param>
		public Shape (IEnumerable<TNode> nodes, IEnumerable<Tuple<TNode,TLabel,TNode>> edges) : base (nodes, edges) {
		}
	}
}

