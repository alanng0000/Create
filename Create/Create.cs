namespace Create;




public class Create : Object
{
    internal Frame Frame { get; set; }






    internal Text Text { get; set; }







    public override bool Init()
    {
        base.Init();




        this.Frame = new Frame();



        this.Frame.Title = "Create";



        this.Frame.Init();








        this.InitControlHandle();




        return true;
    }





    private bool InitControlHandle()
    {
        KeyHandle handle;


        handle = new KeyHandle();


        handle.Create = this;


        handle.Init();
        



        Control.This.KeyInput.Handle.AddHandle(handle);







        CharHandle charHandle;


        charHandle = new CharHandle();


        charHandle.Create = this;


        charHandle.Init();
        



        Control.This.CharInput.Handle.AddHandle(charHandle);







        return true;
    }

    





    public int Execute()
    {
        this.Frame.Execute();



        return 0;
    }
}