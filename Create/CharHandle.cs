namespace Create;





class CharHandle : Handle
{
    public Develop Develop { get; set; }




    private Edit Edit { get; set; }





    private Control Control { get; set; }





    private ControlKey Keys { get; set; }







    public override bool Init()
    {
        base.Init();




        this.Edit = this.Develop.Frame.Edit;





        this.Control = Control.This;




        this.Keys = ControlKey.This;





        return true;
    }






    public override bool Execute(object arg)
    {
        ControlCharEventArg o;


        o = (ControlCharEventArg)arg;





        char oc;

        oc = o.Char;




        if (oc == '\'')
        {
            oc = '←';
        }





        if (this.Control.GetKeyState(this.Keys.Control))
        {
            return true;
        }

        




        this.Edit.InsertChar(oc);
        




        return true;
    }
}