namespace Create;





class ControlCharHandle : ControlCharEventHandle
{
    public Develop Develop { get; set; }




    private Edit Edit { get; set; }





    private Control Control { get; set; }





    private ControlKeys Keys { get; set; }







    public override bool Init()
    {
        base.Init();




        this.Edit = this.Develop.Frame.Edit;





        this.Control = Control.This;




        this.Keys = this.Control.Keys;





        return true;
    }






    public override bool Execute(ControlCharEventArg arg)
    {
        char oc;

        oc = arg.Char;




        if (oc == '\'')
        {
            oc = '←';
        }





        if (this.Control.Get(this.Keys.Control))
        {
            return true;
        }

        




        this.Edit.InsertChar(oc);
        




        return true;
    }
}