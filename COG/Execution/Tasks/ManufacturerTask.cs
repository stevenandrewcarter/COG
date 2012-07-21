using Clockwork.Agents;
using System;
using System.Collections.Generic;

namespace Clockwork.Execution.Tasks
{
  public class ManufacturerTask : Task
  {
    private ClientAgent clientAgent;
    private SupplierAgent supplierAgent;
    private TransportAgent transportAgent;

    public ManufacturerTask(ClientAgent client)
    {
      clientAgent = client;
      supplierAgent = null;
      transportAgent = null;
      agents = new List<TaskComparer>();
    }

    public double Demand { get { return clientAgent.Demand; } }

    public Agent Supplier { get { return supplierAgent; } set { supplierAgent = (SupplierAgent)value; } }
    public Agent Transport { get { return transportAgent; } set { transportAgent = (TransportAgent)value; } }
    public Agent Client { get { return clientAgent; } }

    public override string ToString()
    {
      return "Manufacturer Task::" + agent.ToString();
    }
  }
}
