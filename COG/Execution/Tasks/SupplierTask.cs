using Clockwork.Agents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork.Execution.Tasks
{
  public class SupplierTask : Task
  {
    private ManufacturerAgent manufacturer;
    private TransportAgent transport;
    private double order;

    public SupplierTask(SupplierAgent owner, ManufacturerAgent aManufacturer, double orderAmount)
    {
      agent = owner;
      manufacturer = aManufacturer;
      order = orderAmount;
    }

    public Agent Manufacturer { get { return manufacturer; } }
    public Agent Transport { get { return transport; } set { transport = (TransportAgent)value; } }
    public double OrderAmount { get { return order; } }

    public override string ToString()
    {
      return "Supplier Task::" + agent.ToString();
    }
  }
}
