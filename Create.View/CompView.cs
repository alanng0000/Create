namespace Create.View;




public class Comp : ViewView
{
    public Frame Frame { get; set; }




    public int Index { get; set; }




    public override bool Init()
    {
        base.Init();



        this.Size.Width = this.Frame.Size.Width;


        this.Size.Height = this.Frame.Size.Height;




        return true;
    }




    public virtual bool Set()
    {
        return true;
    }
}