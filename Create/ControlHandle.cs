namespace Create;




class ControlHandle : Handle
{
    public Create Create { get; set; }




    private Edit Edit { get; set; }




    private Frame Frame { get; set; }





    private Control Control { get; set; }






    private ControlKeyList Key { get; set; }






    private KeyHandle[][][][] KeyMethodList { get; set; }






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




        this.KeyMethodList = new KeyHandle[count][][][];



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





        this.SetHandleMethod(this.Key.LetterQ, false, false, false, this.Edit.CaretViewRow);



        this.SetHandleMethod(this.Key.LetterE, false, false, false, this.Edit.CaretViewCol);





        this.SetHandleMethod(this.Key.LetterA, false, false, true, this.Edit.CaretStart);



        this.SetHandleMethod(this.Key.LetterD, false, false, true, this.Edit.CaretEnd);





        this.SetHandleMethod(this.Key.LetterA, false, true, false, this.Edit.SelectLeft);



        this.SetHandleMethod(this.Key.LetterD, false, true, false, this.Edit.SelectRight);



        this.SetHandleMethod(this.Key.LetterW, false, true, false, this.Edit.SelectUp);



        this.SetHandleMethod(this.Key.LetterS, false, true, false, this.Edit.SelectDown);






        this.SetHandleMethod(this.Key.LetterJ, false, false, false, this.ViewUnitLeft);



        this.SetHandleMethod(this.Key.LetterL, false, false, false, this.ViewUnitRight);



        this.SetHandleMethod(this.Key.LetterI, false, false, false, this.ViewUnitUp);



        this.SetHandleMethod(this.Key.LetterK, false, false, false, this.ViewUnitDown);





        this.SetHandleMethod(this.Key.LetterJ, false, true, false, this.ViewEntireLeft);



        this.SetHandleMethod(this.Key.LetterL, false, true, false, this.ViewEntireRight);



        this.SetHandleMethod(this.Key.LetterI, false, true, false, this.ViewEntireUp);



        this.SetHandleMethod(this.Key.LetterK, false, true, false, this.ViewEntireDown);








        this.SetHandleMethod(this.Key.LetterH, true, false, true, this.Edit.InsertIndent);




        this.SetHandleMethod(this.Key.LetterV, true, false, true, this.ReplaceText);





        
        this.InitKeyMethodListLetter();





        return true;
    }





    private bool InitKeyMethodListLetter()
    {
        ControlConstant constant;

        constant = ControlConstant.This;



        int count;

        count = constant.LetterKeyCount;



        int i;

        i = 0;


        while (i < count)
        {
            ControlKey key;


            key = this.Control.Key.LetterKey(i);




            this.SetHandleMethod(key, true, false, false, this.ReplaceText);




            i = i + 1;
        }



        return true;
    }






    private bool InitKeyMethodArrayKey(ControlKey key)
    {
        int keyIndex;

        keyIndex = key.Index;



        int boolCount;


        boolCount = this.BoolCount;




        this.KeyMethodList[keyIndex] = new KeyHandle[boolCount][][];


        this.KeyMethodList[keyIndex][this.BoolIndex(false)] = new KeyHandle[boolCount][];


        this.KeyMethodList[keyIndex][this.BoolIndex(true)] = new KeyHandle[boolCount][];



        this.KeyMethodList[keyIndex][this.BoolIndex(false)][this.BoolIndex(false)] = new KeyHandle[boolCount];


        this.KeyMethodList[keyIndex][this.BoolIndex(true)][this.BoolIndex(false)] = new KeyHandle[boolCount];


        this.KeyMethodList[keyIndex][this.BoolIndex(false)][this.BoolIndex(true)] = new KeyHandle[boolCount];


        this.KeyMethodList[keyIndex][this.BoolIndex(true)][this.BoolIndex(true)] = new KeyHandle[boolCount];






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




        this.KeyMethodList[keyIndex][tabIndex][shiftIndex][controlIndex] = this.CreateKeyHandle(key, tab, shift, control);




        return true;
    }






    private KeyHandle CreateKeyHandle(ControlKey key, bool tab, bool shift, bool control)
    {
        KeyHandle a;


        a = new KeyHandle();


        a.Init();


        a.Key = key;


        a.Tab = tab;


        a.Shift = shift;


        a.Control = control;




        KeyHandle ret;

        ret = a;


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






    private int ViewUnitCount
    {
        get
        {
            return 1;
        }
        set
        {
        }
    }





    private int ViewHorzCount
    {
        get
        {
            return this.Edit.VisibleSize.Width;
        }
        set
        {
        }
    }




    private int ViewVertCount
    {
        get
        {
            return this.Edit.VisibleSize.Height;
        }
        set
        {
        }
    }






    private bool ViewUnitLeft(KeyHandle a)
    {
        this.Edit.ViewLeft(this.ViewUnitCount);



        return true;
    }




    private bool ViewUnitRight(KeyHandle a)
    {
        this.Edit.ViewRight(this.ViewUnitCount);



        return true;
    }




    private bool ViewUnitUp(KeyHandle a)
    {
        this.Edit.ViewUp(this.ViewUnitCount);



        return true;
    }




    private bool ViewUnitDown(KeyHandle a)
    {
        this.Edit.ViewDown(this.ViewUnitCount);



        return true;
    }






    private bool ViewEntireLeft(KeyHandle a)
    {
        this.Edit.ViewLeft(this.ViewHorzCount);



        return true;
    }




    private bool ViewEntireRight(KeyHandle a)
    {
        this.Edit.ViewRight(this.ViewHorzCount);



        return true;
    }




    private bool ViewEntireUp(KeyHandle a)
    {
        this.Edit.ViewUp(this.ViewVertCount);



        return true;
    }




    private bool ViewEntireDown(KeyHandle a)
    {
        this.Edit.ViewDown(this.ViewVertCount);



        return true;
    }





    private bool ReplaceText(KeyHandle a)
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





    private KeyHandle GetHandle(ControlKey key, bool tab, bool shift, bool control)
    {
        int keyIndex;

        keyIndex = key.Index;



        int tabIndex;

        tabIndex = this.BoolIndex(tab);



        int shiftIndex;

        shiftIndex = this.BoolIndex(shift);



        int controlIndex;

        controlIndex = this.BoolIndex(control);




        
        KeyHandle handle;


        handle = this.KeyMethodList[keyIndex][tabIndex][shiftIndex][controlIndex];




        KeyHandle ret;

        ret = handle;

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







        KeyHandle handle;



        handle = this.GetHandle(key, this.IsTab, this.IsShift, this.IsControl);




        HandleMethod method;


        method = handle.Handle;



        if (!(method == null))
        {
            method(handle);
        }




        this.Frame.Update();





        return true;
    }





    private bool Toggle(bool state)
    {
        return !state;
    }
}