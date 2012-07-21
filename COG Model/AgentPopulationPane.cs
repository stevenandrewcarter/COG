using Clockwork;
using Clockwork.Agents;
using Clockwork.Agents.ServiceAgents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace COG_Model
{
  public partial class AgentPopulationPane : UserControl
  {
    delegate void NodeCallback(Agent agent);

    private string[] agentTypes = { "Transport", "Suppliers", "Manufacturers", "Clients", "Operator", "Controller" };

    public AgentPopulationPane()
    {
      InitializeComponent();
    }

    public void AddNewAgent(Agent agent)
    {
      if (trvCurPln.InvokeRequired)
      {
        NodeCallback d = new NodeCallback(AddNewAgent);
        trvCurPln.Invoke(d, new object[] { agent });
      }
      else
      {
        // Check if a simulation agent has been added
        if ((int)agent.Type < 4)
        {
          trvCurPln.Nodes[1].Nodes[(int)agent.Type].Nodes.Add(agent);
          trvCurPln.Nodes[1].Nodes[(int)agent.Type].Text = agentTypes[(int)agent.Type] + " (" + trvCurPln.Nodes[1].Nodes[(int)agent.Type].Nodes.Count + ")";
        }
        else
        {
          int newNode = trvCurPln.Nodes[0].Nodes.Add(agent);
          trvCurPln.Nodes[0].Nodes[newNode].Text = agentTypes[(int)agent.Type];
        }
        int totAgents = 0;
        for(int i = 0; i < trvCurPln.Nodes[1].Nodes.Count; i++)
        {
          totAgents += trvCurPln.Nodes[1].Nodes[i].Nodes.Count;
        }
        trvCurPln.Nodes[1].Text = "Simulation Agents (" + totAgents + ")";
      }
    }

    public void SelectNode(Agent agent)
    {
      trvCurPln.SelectedNode = agent;
    }

    public void RemoveAgent(Agent agent)
    {
      if (trvCurPln.InvokeRequired)
      {
        NodeCallback d = new NodeCallback(RemoveAgent);
        trvCurPln.Invoke(d, new object[] { agent });
      }
      else
      {
        if (agent is Operator || agent is Controller)
        {
          trvCurPln.Nodes[0].Nodes.Remove(agent);
        }
        else
        {
          trvCurPln.Nodes[1].Nodes[(int)agent.Type].Nodes.Remove(agent);
          trvCurPln.Nodes[1].Nodes[(int)agent.Type].Text = agentTypes[(int)agent.Type] + " (" + trvCurPln.Nodes[1].Nodes[(int)agent.Type].Nodes.Count + ")";
        }
      }
    }
  }
}
