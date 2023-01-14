namespace Create;




class KeyHandle : Handle
{
    public Create Create { get; set; }




    private Edit Edit { get; set; }




    private Frame Frame { get; set; }





    private Control Control { get; set; }






    private ControlKey Keys { get; set; }






    private KeyMethod[][][] KeyMethodList { get; set; }





    private byte Key { get; set; }





    public override bool Init()
    {
        base.Init();





        this.Frame = this.Create.Frame;




        this.Edit = this.Frame.Edit;





        this.Control = Control.This;





        this.Keys = global::System.Control.Key.This;






        this.InitHandleMethods();





        return true;
    }




    private bool InitHandleMethods()
    {
        int count;


        count = this.Keys.Count;




        this.KeyMethodList = new KeyMethod[count][][];



        int i;

        i = 0;


        while (i < count)
        {
            byte key;

            key = (byte)i;



            this.SetKeyMethod(key);            



            i = i + 1;
        }





        this.SetHandleMethod(this.Keys.Enter, false, false, this.InsertLine);




        this.SetHandleMethod(this.Keys.Backspace, false, false, this.Edit.Backspace);




        this.SetHandleMethod(this.Keys.Left, this.KeyLeft);



        this.SetHandleMethod(this.Keys.Right, this.KeyRight);



        this.SetHandleMethod(this.Keys.Up, this.KeyUp);



        this.SetHandleMethod(this.Keys.Down, this.KeyDown);




        this.SetHandleMethod(this.Keys.Home, false, false, this.Edit.CaretStart);



        this.SetHandleMethod(this.Keys.End, false, false, this.Edit.CaretEnd);




        this.SetHandleMethod(this.Keys.PageUp, false, false, this.Edit.PageUp);



        this.SetHandleMethod(this.Keys.PageDown, false, false, this.Edit.PageDown);




        this.SetHandleMethod(this.Keys.Tab, false, false, this.Edit.InsertIndent);





        byte vKey;

        vKey = this.LetterToKey('V');



        this.SetHandleMethod(vKey, false, true, this.InsertText);









        return true;
    }





    private bool SetKeyMethod(byte key)
    {
        int boolCount;


        boolCount = 2;




        this.KeyMethodList[key] = new KeyMethod[boolCount][];


        this.KeyMethodList[key][this.BoolIndex(false)] = new KeyMethod[boolCount];


        this.KeyMethodList[key][this.BoolIndex(true)] = new KeyMethod[boolCount];




        this.SetKeyMethodOne(key, false, false);


        this.SetKeyMethodOne(key, true, false);


        this.SetKeyMethodOne(key, false, true);


        this.SetKeyMethodOne(key, true, true);



        return true;
    }




    private bool SetKeyMethodOne(byte key, bool shift, bool control)
    {
        int shiftIndex;

        shiftIndex = this.BoolIndex(shift);



        int controlIndex;

        controlIndex = this.BoolIndex(control);



        this.KeyMethodList[key][shiftIndex][controlIndex] = this.CreateKeyMethod(key, shift, control);



        return true;
    }





    private KeyMethod CreateKeyMethod(byte key, bool shift, bool control)
    {
        KeyMethod method;


        method = new KeyMethod();


        method.Init();


        method.Key = key;


        method.Shift = shift;


        method.Control = control;




        KeyMethod ret;

        ret = method;


        return ret;
    }






    private int BoolIndex(bool b)
    {
        int k;

        k = 0;


        if (b)
        {
            k = 1;
        }


        return k;
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






    private bool InsertLine()
    {
        this.Edit.InsertLine();



        this.Create.Frame.Update();
        


        return true;
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
            
        }

        

        if (!b)
        {
            this.Edit.CaretDown();
        }



        return true;
    }




    private bool SelectDown()
    {
        this.Edit.SelectDown();



        this.Frame.Update();



        return true;
    }








    private bool InsertText()
    {
        this.Edit.InsertText(this.Create.Text);




        this.Frame.Update();




        return true;
    }









    private bool IsControl()
    {
        return this.Control.Get(this.Keys.Control);
    }







    private bool IsShift()
    {
        return this.Control.Get(this.Keys.Shift);
    }






    private bool SetHandleMethod(byte key, bool shift, bool control, HandleMethod method)
    {
        int shiftIndex;

        shiftIndex = this.BoolIndex(shift);



        int controlIndex;

        controlIndex = this.BoolIndex(control);




        this.KeyMethodList[key][shiftIndex][controlIndex].Handle = method;


        return true;
    }





    private HandleMethod GetHandleMethod(byte key, bool shift, bool control)
    {
        int shiftIndex;

        shiftIndex = this.BoolIndex(shift);



        int controlIndex;

        controlIndex = this.BoolIndex(control);




        HandleMethod method;
        
        method = this.KeyMethodList[key][shiftIndex][controlIndex].Handle;




        HandleMethod ret;

        ret = method;

        return ret;
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







        HandleMethod method;



        method = this.GetHandleMethod(key, this.IsShift(), this.IsControl());




        if (!(method == null))
        {
            method();
        }






        return true;
    }
}