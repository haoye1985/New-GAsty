using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GAsty.Network.Core;
using GAsty.Utility;
using Microsoft.SolverFoundation.Services;
using Oasis;
using Pan.Optimisation;
using Pan.Utilities;
using GAsty.Network.Visualisation;

namespace GAsty.Algorithm
{
    public static class CoreModel
    {
        public static void BuildStaticModel()
        {
            Messages.Print("Input Output Model starts to implement!");
            Messages.Print("");

            if (State.network.GetInfraNodeCollection().Count == 0 || State.network.GetInfraLinkCollection().Count == 0)
            {
                MessageBox.Show("No available network!");
                Messages.Print("The network dataset initialization failed!");
                Messages.Print("");
            }
            else
            {
                Messages.Print("Model starts to run!");
                Messages.Print("");

                List<GeoNode> Node = State.network.GetInfraNodeCollection();
                List<GeoLink> Link = State.network.GetInfraLinkCollection();

                float[,] A = new float[Node.Count, Node.Count];
                float[] C = new float[Node.Count];

                // Populate Coefficient Matrix
                for (int i = 0; i < Node.Count; i++)
                {
                    for (int j = 0; j < Node.Count; j++)
                    {
                        foreach (GeoLink ij in Link)
                        {
                            //if (ij.FromNode.ID == Node[i].ID && ij.ToNode.ID == Node[j].ID)
                            if (ij.FromNodeID == Node[i].ID && ij.ToNodeID == Node[j].ID)
                            {
                                A[i, j] = ij.RiskAij;
                            }
                        }
                    }
                }

                // Populate Ci
                for (int i = 0; i < Node.Count; i++)
                {
                    C[i] = Node[i].RiskCi;
                }

                Messages.Print("LEONTIEF MODEL");
                Messages.Print("");

                for (int i = 0; i < Node.Count; i++)
                {
                    string x_ij = "";
                    for (int j = 0; j < Node.Count; j++)
                    {
                        if (i != j)
                        {
                            x_ij += string.Format("x{1} * a{1}{0} + ", i, j);
                        }
                    }

                    Messages.Print("x{0}={1} c{0}", i, x_ij);
                }

                Messages.Print("");
                Messages.Print("LEONTIEF MODEL VALUES");

                Messages.Print("\nLEONTIEF MODEL Formula\n");
                Messages.Print(BuildMathematica(Node, A, C));
                Messages.Print("");
                Messages.Print("Solver Foundation start to implement!");

                SolverContext _Context = SolverContext.GetContext();
                Model Model = _Context.CreateModel();

                //Add Decision Variables for Solver Foundation
                var x = new Decision[Node.Count];
                for (int i = 0; i < Node.Count; i++)
                    x[i] = new Decision(Domain.RealNonnegative, "x" + i);
                Model.AddDecisions(x);

                var xD = new Decision[Node.Count];
                for (int i = 0; i < Node.Count; i++)
                    xD[i] = new Decision(Domain.RealNonnegative, "xD" + i);
                Model.AddDecisions(xD);

                //Add Expressions
                var _SumDummies = SolverOperators.Sum();
                foreach (var _Decision in xD)
                    _SumDummies.Add(_Decision);
                Model.AddGoal("Go", GoalKind.Maximize, _SumDummies.ToTerm());

                for (int i = 0; i < Node.Count; i++)
                {
                    SumTermBuilder SumXiAij = SolverOperators.Sum();
                    for (int j = 0; j < Node.Count; j++)
                        if (i != j)
                            SumXiAij.Add(xD[j]*A[j, i]);

                    Model.AddConstraints("xD1_" + i, xD[i] <= 1, xD[i] <= x[i]);

                    Model.AddConstraints("Value_x" + i, x[i] == SumXiAij.ToTerm() + C[i]);
                }
                Solution sol = _Context.Solve(new SimplexDirective());
                Report report = sol.GetReport();

                for (int i = 0; i < Node.Count; i++)
                {
                    Decision _Decision = xD[i];
                    Node[i].RiskXi = (float) Math.Round(_Decision.ToDouble(), 5);
                    Messages.Print("x[ ]" + i + " = " + Node[i].RiskXi.ToString());
                }

                _Context.ClearModel();
            }

            //State.UpdateService = NetRiskLayer.CreateNodeRiskLayer(State.network);
            State.RenderInfrastructure = true;
           
        }

        private static string BuildMathematica(List<GeoNode> Node, float[,] A, float[] C)
        {
            string _Command = "Solve[{ ";
            for (int i = 0; i < Node.Count; i++)
            {
                string x_ij = "";
                for (int j = 0; j < Node.Count; j++)
                    if (i != j)
                        x_ij += String.Format("x{0} * {1} + ", j, A[j, i]);

                string _Formula = String.Format("x{0} == {1} {2}", i, x_ij, C[i]);

                Messages.Print(_Formula);
                _Command += _Formula + ",";
            }
            _Command = _Command.Remove(_Command.Length - 1);
            _Command += " } , {";

            for (int i = 0; i < Node.Count; i++)
                _Command += " x" + i.ToString() + " ,";

            _Command = _Command.Remove(_Command.Length - 1);
            _Command += "}]";
            return _Command;
        }
    }
}
