namespace Create;




public class Create : Object
{
    internal Frame Frame { get; set; }





    internal Control Control { get; set; }





    internal Text Text { get; set; }






    public override bool Init()
    {
        base.Init();




        this.Frame = new Frame();



        this.Frame.Title = "Create";



        this.Frame.Init();




        this.Control = new Control();


        this.Control.Init();




        this.Frame.Control = this.Control;





        this.InitControlHandle();





        return true;
    }





    private bool InitControlHandle()
    {
        ControlHandle controlHandle;


        controlHandle = new ControlHandle();


        controlHandle.Create = this;


        controlHandle.Init();
        



        this.Control.Input.Handle.AddHandle(controlHandle);






        return true;
    }

    





    public int Execute()
    {
        this.Frame.Execute();



        return 0;
    }
}