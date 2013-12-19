using System;
using System.Collections.Generic;

namespace ZincOxide.AbstractGraph {

	/// <summary>
	/// A representation of a labeled graph as described in "Arend Rensink (2005), Abstract Graph Transformation".
	/// </summary>
	public class LabeledGraph<TNode,TLabel> {
		private readonly Dictionary<TNode,Node> nodes = new Dictionary<TNode, Node> ();

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxide.AbstractGraph.LabeledGraph`2"/> class with a given set of nodes and edges.
		/// </summary>
		/// <param name="nodes">The set of nodes.</param>
		/// <param name="edges">The set of edges.</param>
		public LabeledGraph (IEnumerable<TNode> nodes, params Tuple<TNode,TLabel,TNode>[] edges) : this (nodes, (IEnumerable<Tuple<TNode,TLabel,TNode>>)edges) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxide.AbstractGraph.LabeledGraph`2"/> class with a given set of nodes and edges.
		/// </summary>
		/// <param name="nodes">The set of nodes.</param>
		/// <param name="edges">The set of edges.</param>
		public LabeledGraph (IEnumerable<TNode> nodes, IEnumerable<Tuple<TNode,TLabel,TNode>> edges) {
			foreach (TNode node in nodes) {
				this.nodes.Add (node, new Node (node));
			}
			foreach (Tuple<TNode,TLabel,TNode> edge in edges) {
				Node nod, noe;
				TNode frm = edge.Item1, ton = edge.Item3;
				if (!this.nodes.TryGetValue (frm, out nod)) {
					nod = new Node (frm);
					this.nodes.Add (frm, nod);
				}
				if (!this.nodes.TryGetValue (ton, out noe)) {
					noe = new Node (ton);
					this.nodes.Add (ton, noe);
				}
				nod.AddEdge (edge.Item2, noe);
			}
		}

		private class Node : TagBase<TNode> {
			private readonly Dictionary<TLabel,Node> edges = new Dictionary<TLabel, Node> ();

			public Node (TNode node, IEnumerable<Tuple<TLabel,Node>> edges) : base (node) {
				foreach (Tuple<TLabel,Node> edge in edges) {
					this.AddEdge (edge);
				}
			}

			public Node (TNode node, params Tuple<TLabel,Node>[] edges) : this (node, (IEnumerable<Tuple<TLabel,Node>>)edges) {
			}

			public void AddEdge (Tuple<TLabel,Node> edge) {
				this.AddEdge (edge.Item1, edge.Item2);
			}

			public void AddEdge (TLabel label, Node node) {
				this.edges.Add (label, node);
			}
		}
	}
}

