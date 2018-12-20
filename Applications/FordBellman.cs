using System;
using System.Collections.Generic;
using System.Text;
using MathGraph.Entities;

namespace MathGraph.Applications
{
	public static class FordBellman
	{
		private static Graph _graph { get; set; }
		private static int _startNode { get; set; }
		private static float MAX_WEIGHT = float.MaxValue;
		private static List<float> _costs { get; set; }
		private static List<Tuple<int, int, float>> _edges { get; set; }
		private static string _error { get; set; }

		public static Scenario GetScenario() => new Scenario(Init, Run, DisplayResult, GetError);
		private static bool Init(string[] args)
		{
			try
			{
				_graph = GraphLoader.LoadGraph(args[0]);
				int tmp;
				if (!int.TryParse(args[1], out tmp) || !_graph.Nodes.Contains(tmp))
				{
					_error = "Given node value isn't an integer or doesn't exist in given graph";
					return false;
				}

				_costs = new List<float>(_graph.Count);
				for (int i = 0; i < _graph.Count - 1; i++)
					_costs.Add(MAX_WEIGHT);
				_costs[_startNode] = 0;

				_edges = new List<Tuple<int, int, float>>();
				List<float?> nodeEdges;
				for (int i = 0; i < _graph.Count; i++)
				{
					nodeEdges = _graph.Edges[i];
					for (int j = 0; j < nodeEdges.Count; j++)
						if (nodeEdges[j].HasValue)
							_edges.Add(new Tuple<int, int, float>(i, j, nodeEdges[j].Value));
				}
				
				return true;
			}
			catch (Exception ex)
			{
				_error = ex.Message + '\n';
				_error += ex.StackTrace;
				return false;
			}
		}
		private static bool Run(string[] args)
		{
			try
			{
				for (int i = 0; i < _graph.Count-1; i++)
					for (int j = 0; j < _edges.Count; j++)
						if (_costs[_edges[j].Item1] < MAX_WEIGHT)
							if (_costs[_edges[j].Item2] > _costs[_edges[j].Item1] + _edges[j].Item3)
								_costs[_edges[j].Item2] = _costs[_edges[j].Item1] + _edges[j].Item3;

				return true;
			}
			catch (Exception ex)
			{
				_error = ex.Message;
				_error += ex.StackTrace;
				return false;
			}
		}
		private static string DisplayResult(string[] args)
		{
			try
			{
				var result = new StringBuilder();
				result.AppendLine("Results of Ford-Bellman's algorithm:");
				for (int i = 0; i < _costs.Count; i++)
				{
					result.AppendLine($"[{i}] ==> {_costs[i]}");
				}
				result.AppendLine(_graph.ToString(Graph.TO_STRING_MODE_MATRIX));
				return result.ToString();
			}
			catch (Exception ex)
			{
				return ex.Message + '\n' + ex.StackTrace;
			}
		}
		private static string GetError() => _error;
	}
}