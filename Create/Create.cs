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
        KeyHandle keyHandle;


        keyHandle = new KeyHandle();


        keyHandle.Create = this;


        keyHandle.Init();
        



        this.Control.KeyInput.Handle.AddHandle(keyHandle);







        CharHandle charHandle;


        charHandle = new CharHandle();


        charHandle.Create = this;


        charHandle.Init();
        



        this.Control.CharInput.Handle.AddHandle(charHandle);





        return true;
    }

    





    public int Execute()
    {
        this.Frame.Execute();



        return 0;
    }
}