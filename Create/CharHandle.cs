namespace Create;





class CharHandle : Handle
{
    public Create Create { get; set; }




    private Frame Frame { get; set; }

    


    private Edit Edit { get; set; }





    private Control Control { get; set; }





    private ControlKey Key { get; set; }







    public override bool Init()
    {
        base.Init();




        this.Frame = this.Create.Frame;




        this.Edit = this.Frame.Edit;





        this.Control = Control.This;




        this.Key = ControlKey.This;





        return true;
    }






    public override bool Execute(object arg)
    {
        ControlCharArg o;


        o = (ControlCharArg)arg;





        char oc;

        oc = o.Char;






        if (this.Control.Get(this.Key.Control))
        {
            return true;
        }

        




        this.Edit.InsertChar(oc);
        



        this.Frame.Update();




        return true;
    }
}