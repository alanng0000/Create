namespace Develop;




public class Develop : Object
{
    internal Frame Frame { get; set; }






    internal Text Text { get; set; }







    public override bool Init()
    {
        base.Init();




        this.Frame = new Frame();



        this.Frame.Title = "Develop";



        this.Frame.Init();








        this.InitControlHandle();




        return true;
    }





    private bool InitControlHandle()
    {
        ControlHandle handle;


        handle = new ControlHandle();


        handle.Develop = this;


        handle.Init();
        



        Control.This.StateChanged.AddHandle(handle);







        ControlCharHandle charHandle;


        charHandle = new ControlCharHandle();


        charHandle.Develop = this;


        charHandle.Init();
        



        Control.This.CharInput.AddHandle(charHandle);







        return true;
    }

    





    public bool Main(string arg)
    {
        this.Frame.Execute();



        return true;
    }
}