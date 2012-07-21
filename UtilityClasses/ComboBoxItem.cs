using System;
using System.Collections.Generic;
using System.Text;

namespace UtilityClasses
{
  public class ComboBoxItem
  {
    private int key;
    private string item;

    public ComboBoxItem(int Key, string Item)
    {
      key = Key;
      item = Item;
    }

    public string Item
    {
      get
      {
        return item;
      }
    }

    public int Key
    {
      get
      {
        return key;
      }
    }

    public override string ToString()
    {
      return item;
    }
  }
}
