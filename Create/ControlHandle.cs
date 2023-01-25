namespace Create;




class ControlHandle : Handle
{
    public Create Create { get; set; }




    private Edit Edit { get; set; }




    private Frame Frame { get; set; }





    private Control Control { get; set; }






    private ControlKeyList Key { get; set; }






    private KeyMethod[][][] KeyMethodList { get; set; }






    public override bool Init()
    {
        base.Init();





        this.Frame = this.Create.Frame;




        this.Edit = this.Frame.Edit;





        this.Control = this.Create.Control;





        this.Key = this.Control.Key;






        this.InitKeyMethodList();





        return true;
    }

    




    private bool InitKeyMethodList()
    {
        int count;


        count = this.Key.Count;




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





        this.SetHandleMethod(this.Key.Enter, false, false, this.Edit.InsertLine);




        this.SetHandleMethod(this.Key.Backspace, false, false, this.Edit.BackSpace);




    
        this.SetHandleMethod(this.Key.Left, false, false, this.Edit.CaretLeft);


        
        this.SetHandleMethod(this.Key.Right, false, false, this.Edit.CaretRight);



        this.SetHandleMethod(this.Key.Up, false, false, this.Edit.CaretUp);


        
        this.SetHandleMethod(this.Key.Down, false, false, this.Edit.CaretDown);





        this.SetHandleMethod(this.Key.Left, true, false, this.Edit.SelectLeft);



        this.SetHandleMethod(this.Key.Right, true, false, this.Edit.SelectRight);



        this.SetHandleMethod(this.Key.Up, true, false, this.Edit.SelectUp);



        this.SetHandleMethod(this.Key.Down, true, false, this.Edit.SelectDown);





        this.SetHandleMethod(this.Key.Home, false, false, this.Edit.CaretStart);



        this.SetHandleMethod(this.Key.End, false, false, this.Edit.CaretEnd);




        this.SetHandleMethod(this.Key.PageUp, false, false, this.Edit.PageUp);



        this.SetHandleMethod(this.Key.PageDown, false, false, this.Edit.PageDown);




        this.SetHandleMethod(this.Key.Tab, false, false, this.Edit.InsertIndent);







        this.SetHandleMethod(this.LetterKey('V'), false, true, this.ReplaceText);









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





    private int LetterIndex(char oc)
    {
        int a;

        a = oc - 'A';


        return a;
    }




    private byte LetterKey(char oc)
    {
        int index;

        index = this.LetterIndex(oc);



        byte o;

        o = this.Key.LetterKey(index);



        byte ret;

        ret = o;


        return ret;
    }







    private bool ReplaceText()
    {
        this.Edit.ReplaceText(this.Create.Text);




        return true;
    }









    private bool IsControl()
    {
        return this.Control.Get(this.Key.Control);
    }







    private bool IsShift()
    {
        return this.Control.Get(this.Key.Shift);
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




        this.Frame.Update();





        return true;
    }
}