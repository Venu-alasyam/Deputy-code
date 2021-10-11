using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

public class Role
{
// please note that ideally class attributes should be private
// but as this class is for demonstration purposes, this is not necessary

public int id, parent;
public string name;

// constructor

public Role(int id, string name, int parent)
{
this.id = id;
this.name = name;
this.parent = parent;

}
}
