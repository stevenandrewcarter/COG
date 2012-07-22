using System.Collections.Generic;
using Clockwork.Agents;

namespace Clockwork.Execution.Tasks {
  public class TransportTask : Task {
    private Agent source;
    private Agent destination;
    private double quantity;

    /// <summary>
    /// Internal representation of a logistic task from one agent to another.
    /// </summary>
    /// <param name="sourceAgent">Source agent to collect from</param>
    /// <param name="destinationAgent">Destination agent to deliver to</param>
    /// <param name="amount">Amount to deliver</param>
    public TransportTask(Agent sourceAgent, Agent destinationAgent, double amount) {
      source = sourceAgent;
      // agent = sourceAgent;
      destination = destinationAgent;
      quantity = amount;
      agents = new List<TaskComparer>();
    }

    public Agent Source { get { return source; } }
    public Agent Destination { get { return destination; } }
    public double Load { get { return quantity; } }

    public override string ToString() {
      return "Transport Task::" + agent.ToString();
    }
  }
}
