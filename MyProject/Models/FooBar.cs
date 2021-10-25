namespace MyProject.Models {
  public class FooBar {
    public int FooBarId {get; set;}
    public int BarId {get; set;}
    public int FooId {get; set;}
    public virtual Bar Bar {get; set;}
    public virtual Foo Foo {get; set;}
  }
}