using System;
using System.Collections.Generic;

namespace ZincOxide.AbstractGraph {

	public class LabeledGraph<TNode,TLabel> {
		private readonly Dictionary<TNode,Node> nodes = new Dictionary<TNode, Node> ();

		public LabeledGraph (IEnumerable<TNode> nodes, params Tuple<TNode,TLabel,TNode>[] edges) : this (nodes, (IEnumerable<Tuple<TNode,TLabel,TNode>>)edges) {
		}

		public LabeledGraph (IEnumerable<TNode> nodes, IEnumerable<Tuple<TNode,TLabel,TNode>> edges) {
			foreach (TNode node in nodes) {
				this.nodes.Add (node, new Node (node));
			}
			foreach (Tuple<TNode,TLabel,TNode> edge in edges) {
				Node nod;
				TNode frm = edge.Item1;
				if (!this.nodes.TryGetValue (frm, out nod)) {
					nod = new Node (frm);
					this.nodes.Add (frm, nod);
				}
				nod.AddEdge (edge.Item2, edge.Item3);
			}
		}

		public class Node : TagBase<TNode> {
			private readonly Dictionary<TLabel,TNode> edges = new Dictionary<TLabel, TNode> ();

			public Node (TNode node, IEnumerable<Tuple<TLabel,TNode>> edges) : base (node) {
				foreach (Tuple<TLabel,TNode> edge in edges) {
					this.AddEdge (edge);
				}
			}

			public Node (TNode node, params Tuple<TLabel,TNode>[] edges) : this (node, (IEnumerable<Tuple<TLabel,TNode>>)edges) {
			}

			public void AddEdge (Tuple<TLabel,TNode> edge) {
				this.AddEdge (edge.Item1, edge.Item2);
			}

			public void AddEdge (TLabel label, TNode node) {
				this.edges.Add (label, node);
			}
		}
	}
}

