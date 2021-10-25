using System.Collections.Generic;

namespace MyProject.Models {
  public class Bar {
    public Bar() {
      this.JoinEntities = new HashSet <FooBar> ();
    }

    public int BarId {get; set;}
    public string Description {get; set;}
    public virtual ApplicationUser User {get; set;}

    public virtual ICollection <FooBar> JoinEntities {
      get;
    }
  }
}