using System.Collections.Generic;

namespace MyProject.Models
{
  public class Foo
  {
    public Foo()
    {
      this.JoinEntities = new HashSet<FooBar>();
    }

    public int FooId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<FooBar> JoinEntities { get; set; }
  }
}