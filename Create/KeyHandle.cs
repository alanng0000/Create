namespace Create;




class KeyHandle : Handle
{
    public Develop Develop { get; set; }




    private Edit Edit { get; set; }





    private Control Control { get; set; }






    private ControlKey Keys { get; set; }





    private delegate bool HandleMethod();




    private HandleMethod[] HandleMethodList { get; set; }





    private byte Key { get; set; }





    public override bool Init()
    {
        base.Init();




        this.Edit = this.Develop.Frame.Edit;





        this.Control = Control.This;





        this.Keys = global::System.Control.Key.This;






        this.InitHandleMethods();





        return true;
    }




    private bool InitHandleMethods()
    {
        int count;


        count = this.Keys.Count;




        this.HandleMethodList = new HandleMethod[count];





        this.SetHandleMethod(this.Keys.Enter, this.Edit.InsertLine);




        this.SetHandleMethod(this.Keys.Backspace, this.Edit.Backspace);




        this.SetHandleMethod(this.Keys.Left, this.KeyLeft);



        this.SetHandleMethod(this.Keys.Right, this.KeyRight);



        this.SetHandleMethod(this.Keys.Up, this.KeyUp);



        this.SetHandleMethod(this.Keys.Down, this.KeyDown);




        this.SetHandleMethod(this.Keys.Home, this.Edit.CaretStart);



        this.SetHandleMethod(this.Keys.End, this.Edit.CaretEnd);




        this.SetHandleMethod(this.Keys.PageUp, this.Edit.PageUp);



        this.SetHandleMethod(this.Keys.PageDown, this.Edit.PageDown);




        this.SetHandleMethod(this.Keys.Tab, this.Edit.InsertIndent);





        byte vKey;

        vKey = this.LetterToKey('V');



        this.SetHandleMethod(vKey, this.InsertText);









        return true;
    }








    private byte LetterToKey(char oc)
    {
        ulong u;


        u = (ulong)oc;




        byte o;


        o = (byte)u;




        byte ret;

        ret = o;


        return ret;
    }







    private bool KeyLeft()
    {
        bool b;


        b = this.Shift();


        
        if (b)
        {
            this.Edit.SelectLeft();
        }

        

        if (!b)
        {
            this.Edit.CaretLeft();
        }



        return true;
    }








    private bool KeyRight()
    {
        bool b;


        b = this.Shift();


        
        if (b)
        {
            this.Edit.SelectRight();
        }

        

        if (!b)
        {
            this.Edit.CaretRight();
        }



        return true;
    }








    private bool KeyUp()
    {
        bool b;


        b = this.Shift();


        
        if (b)
        {
            this.Edit.SelectUp();
        }

        

        if (!b)
        {
            this.Edit.CaretUp();
        }



        return true;
    }









    private bool KeyDown()
    {
        bool b;


        b = this.Shift();


        
        if (b)
        {
            this.Edit.SelectDown();
        }

        

        if (!b)
        {
            this.Edit.CaretDown();
        }



        return true;
    }









    private bool InsertText()
    {
        if (!this.ControlKey())
        {
            return true;
        }





        this.Edit.InsertText(this.Develop.Text);






        return true;
    }









    private bool ControlKey()
    {
        return this.Control.Get(this.Keys.Control);
    }







    private bool Shift()
    {
        return this.Control.Get(this.Keys.Shift);
    }






    private bool SetHandleMethod(byte key, HandleMethod method)
    {
        this.HandleMethodList[key] = method;


        return true;
    }








    public override bool Execute(object arg)
    {
        ControlKeyArg o;

        o = (ControlKeyArg)arg;




        byte key;

        key = o.Key;



        bool state;

        state = o.State;



        if (!state)
        {
            return true;
        }



        


        this.Key = key;






        HandleMethod method;



        method = this.HandleMethodList[key];




        if (!(method == null))
        {
            method();
        }






        return true;
    }
}