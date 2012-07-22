using Clockwork.Execution.Tasks;

namespace Clockwork {
  public interface ICoordinationAgent {
    /// <summary>
    /// Determines the overall ability for an agent to perform a task.
    /// </summary>
    /// <param name="aTask">Task to check against</param>
    /// <returns>A value between 0 and 1 indicating the ability to perform the task</returns>
    double CalculateTaskPotential(Task aTask);

    /// <summary>
    /// Allows the Controller to assign the task to the current agent.
    /// (Could be done as a message instead)
    /// </summary>
    /// <param name="aTask">Currently assigned task</param>
    void AssignTask(Task aTask);

  }
}
