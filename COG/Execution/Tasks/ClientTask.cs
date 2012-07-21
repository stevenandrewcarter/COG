using Clockwork.Agents;
using System.Collections.Generic;

namespace Clockwork.Execution.Tasks
{
  /// <summary>
  /// A client request is stored as a task in the execution tree.
  /// The Controller agent can choose to expand the task to include a 
  /// manufacturer task if no valid manufacturers exist nearby.
  /// </summary>
  public class ClientTask : Task
  {    
    public ClientTask(Agent client)
    {
      agents = new List<TaskComparer>();
      agent = client;
    }
    
    public override string ToString()
    {
      return "Client Task::" + agent.ToString();
    }
  }
}
