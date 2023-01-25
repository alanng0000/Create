namespace Create;




class ControlHandle : Handle
{
    public Create Create { get; set; }




    private Edit Edit { get; set; }




    private Frame Frame { get; set; }





    private Control Control { get; set; }






    private ControlKeyList Key { get; set; }






    private KeyMethod[][][][] KeyMethodList { get; set; }






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




        this.KeyMethodList = new KeyMethod[count][][][];



        int i;

        i = 0;


        while (i < count)
        {
            ControlKey key;

            key = this.Key.Get(i);



            this.InitKeyMethodArrayKey(key);            



            i = i + 1;
        }





        this.SetHandleMethod(this.Key.Enter, false, false, false, this.Edit.InsertLine);




        this.SetHandleMethod(this.Key.Backspace, false, false, false, this.Edit.BackSpace);




    
        this.SetHandleMethod(this.Key.LetterA, false, false, false, this.Edit.CaretLeft);


        
        this.SetHandleMethod(this.Key.LetterD, false, false, false, this.Edit.CaretRight);



        this.SetHandleMethod(this.Key.LetterW, false, false, false, this.Edit.CaretUp);


        
        this.SetHandleMethod(this.Key.LetterS, false, false, false, this.Edit.CaretDown);





        this.SetHandleMethod(this.Key.LetterA, false, true, false, this.Edit.SelectLeft);



        this.SetHandleMethod(this.Key.LetterD, false, true, false, this.Edit.SelectRight);



        this.SetHandleMethod(this.Key.LetterW, false, true, false, this.Edit.SelectUp);



        this.SetHandleMethod(this.Key.LetterS, false, true, false, this.Edit.SelectDown);





        this.SetHandleMethod(this.Key.LetterA, false, false, true, this.Edit.CaretStart);



        this.SetHandleMethod(this.Key.LetterD, false, false, true, this.Edit.CaretEnd);




        this.SetHandleMethod(this.Key.LetterJ, false, false, false, this.Edit.ScrollLeft);



        this.SetHandleMethod(this.Key.LetterL, false, false, false, this.Edit.ScrollRight);



        this.SetHandleMethod(this.Key.LetterI, false, false, false, this.Edit.ScrollUp);



        this.SetHandleMethod(this.Key.LetterK, false, false, false, this.Edit.ScrollDown);





        this.SetHandleMethod(this.Key.Tab, true, false, false, this.Edit.InsertIndent);







        this.SetHandleMethod(this.Key.LetterV, true, false, true, this.ReplaceText);









        return true;
    }





    private bool InitKeyMethodArrayKey(ControlKey key)
    {
        int keyIndex;

        keyIndex = key.Index;



        int boolCount;


        boolCount = this.BoolCount;




        this.KeyMethodList[keyIndex] = new KeyMethod[boolCount][][];


        this.KeyMethodList[keyIndex][this.BoolIndex(false)] = new KeyMethod[boolCount][];


        this.KeyMethodList[keyIndex][this.BoolIndex(true)] = new KeyMethod[boolCount][];



        this.KeyMethodList[keyIndex][this.BoolIndex(false)][this.BoolIndex(false)] = new KeyMethod[boolCount];


        this.KeyMethodList[keyIndex][this.BoolIndex(true)][this.BoolIndex(false)] = new KeyMethod[boolCount];


        this.KeyMethodList[keyIndex][this.BoolIndex(false)][this.BoolIndex(true)] = new KeyMethod[boolCount];


        this.KeyMethodList[keyIndex][this.BoolIndex(true)][this.BoolIndex(true)] = new KeyMethod[boolCount];






        this.InitKeyMethodOne(key, false, false, false);


        this.InitKeyMethodOne(key, true, false, false);


        this.InitKeyMethodOne(key, false, true, false);


        this.InitKeyMethodOne(key, true, true, false);


        this.InitKeyMethodOne(key, false, false, true);


        this.InitKeyMethodOne(key, true, false, true);


        this.InitKeyMethodOne(key, false, true, true);


        this.InitKeyMethodOne(key, true, true, true);



        return true;
    }






    private bool InitKeyMethodOne(ControlKey key, bool tab, bool shift, bool control)
    {
        int keyIndex;

        keyIndex = key.Index;



        int tabIndex;

        tabIndex = this.BoolIndex(tab);



        int shiftIndex;

        shiftIndex = this.BoolIndex(shift);



        int controlIndex;

        controlIndex = this.BoolIndex(control);




        this.KeyMethodList[keyIndex][tabIndex][shiftIndex][controlIndex] = this.CreateKeyMethod(key, tab, shift, control);




        return true;
    }






    private KeyMethod CreateKeyMethod(ControlKey key, bool tab, bool shift, bool control)
    {
        KeyMethod method;


        method = new KeyMethod();


        method.Init();


        method.Key = key;


        method.Tab = tab;


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




    private ControlKey LetterKey(char oc)
    {
        int index;

        index = this.LetterIndex(oc);



        ControlKey o;

        o = this.Key.LetterKey(index);



        ControlKey ret;

        ret = o;


        return ret;
    }







    private bool ReplaceText()
    {
        this.Edit.ReplaceText(this.Create.Text);




        return true;
    }





    private int BoolCount
    {
        get
        {
            return 2;
        }
    }




    private bool IsTab
    {
        get; set;
    }




    private bool IsControl
    {
        get; set;
    }




    private bool IsShift
    {
        get; set;
    }






    private bool SetHandleMethod(ControlKey key, bool tab, bool shift, bool control, HandleMethod method)
    {
        int keyIndex;

        keyIndex = key.Index;



        int tabIndex;

        tabIndex = this.BoolIndex(tab);



        int shiftIndex;

        shiftIndex = this.BoolIndex(shift);



        int controlIndex;

        controlIndex = this.BoolIndex(control);




        this.KeyMethodList[keyIndex][tabIndex][shiftIndex][controlIndex].Handle = method;


        return true;
    }





    private HandleMethod GetHandleMethod(ControlKey key, bool tab, bool shift, bool control)
    {
        int keyIndex;

        keyIndex = key.Index;



        int tabIndex;

        tabIndex = this.BoolIndex(tab);



        int shiftIndex;

        shiftIndex = this.BoolIndex(shift);



        int controlIndex;

        controlIndex = this.BoolIndex(control);




        HandleMethod method;
        
        method = this.KeyMethodList[keyIndex][tabIndex][shiftIndex][controlIndex].Handle;




        HandleMethod ret;

        ret = method;

        return ret;
    }






    public override bool Execute(object arg)
    {
        ControlKeyArg o;

        o = (ControlKeyArg)arg;




        ControlKey key;

        key = o.Key;




        bool state;

        state = o.State;




        if (!state)
        {
            if (key == this.Key.Tab)
            {
                this.IsTab = this.Toggle(this.IsTab);
            }


            if (key == this.Key.Shift)
            {
                this.IsShift = this.Toggle(this.IsShift);
            }


            if (key == this.Key.Control)
            {
                this.IsControl = this.Toggle(this.IsControl);
            }



            return true;
        }







        HandleMethod method;



        method = this.GetHandleMethod(key, this.IsTab, this.IsShift, this.IsControl);




        if (!(method == null))
        {
            method();
        }




        this.Frame.Update();





        return true;
    }





    private bool Toggle(bool state)
    {
        return !state;
    }
}