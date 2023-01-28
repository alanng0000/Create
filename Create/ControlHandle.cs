namespace Create;




class ControlHandle : Handle
{
    public Create Create { get; set; }




    private Edit Edit { get; set; }




    private Frame Frame { get; set; }





    private Control Control { get; set; }






    private ControlKeyList Key { get; set; }






    private KeyHandle[][][][] KeyMethodList { get; set; }





    private Text TextOneChar { get; set; }
    



    private char[] CharOneList { get; set; }




    private Range CharOneListRange;





    public override bool Init()
    {
        base.Init();





        this.Frame = this.Create.Frame;




        this.Edit = this.Frame.Edit;





        this.Control = this.Create.Control;





        this.Key = this.Control.Key;






        this.InitKeyMethodList();




        
        this.InitText();




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







        this.SetHandleMethod(this.Key.Backspace, false, false, false, this.Edit.BackSpace);




    
        this.SetHandleMethod(this.Key.LetterA, false, false, false, this.CaretLeft);


        
        this.SetHandleMethod(this.Key.LetterD, false, false, false, this.CaretRight);



        this.SetHandleMethod(this.Key.LetterW, false, false, false, this.CaretUp);


        
        this.SetHandleMethod(this.Key.LetterS, false, false, false, this.CaretDown);






        this.SetHandleMethod(this.Key.LetterA, false, true, false, this.SelectLeft);



        this.SetHandleMethod(this.Key.LetterD, false, true, false, this.SelectRight);



        this.SetHandleMethod(this.Key.LetterW, false, true, false, this.SelectUp);



        this.SetHandleMethod(this.Key.LetterS, false, true, false, this.SelectDown);






        this.SetHandleMethod(this.Key.LetterQ, false, false, false, this.CaretViewRow);



        this.SetHandleMethod(this.Key.LetterE, false, false, false, this.CaretViewCol);





        this.SetHandleMethod(this.Key.LetterX, false, false, false, this.CaretStart);



        this.SetHandleMethod(this.Key.LetterC, false, false, false, this.CaretEnd);







        this.SetHandleMethod(this.Key.LetterJ, false, false, false, this.ViewUnitLeft);



        this.SetHandleMethod(this.Key.LetterL, false, false, false, this.ViewUnitRight);



        this.SetHandleMethod(this.Key.LetterI, false, false, false, this.ViewUnitUp);



        this.SetHandleMethod(this.Key.LetterK, false, false, false, this.ViewUnitDown);





        this.SetHandleMethod(this.Key.LetterJ, false, true, false, this.ViewEntireLeft);



        this.SetHandleMethod(this.Key.LetterL, false, true, false, this.ViewEntireRight);



        this.SetHandleMethod(this.Key.LetterI, false, true, false, this.ViewEntireUp);



        this.SetHandleMethod(this.Key.LetterK, false, true, false, this.ViewEntireDown);






        
        this.InitKeyMethodListInsertChar();



        
        this.SetHandleMethod(this.Key.Enter, true, false, false, this.InsertLine);




        return true;
    }





    private bool InitKeyMethodListInsertChar()
    {
        ControlConstant constant;

        constant = ControlConstant.This;



        int count;

        count = constant.CharKeyCount;



        int i;

        i = 0;


        while (i < count)
        {
            ControlKey key;


            key = this.Control.Key.Get(i);




            this.SetHandleMethod(key, true, false, false, this.InsertChar);



            this.SetHandleMethod(key, true, true, false, this.InsertChar);




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





    private bool CaretLeft(KeyHandle a)
    {
        this.Edit.CaretLeft();


        return true;
    }




    private bool CaretRight(KeyHandle a)
    {
        this.Edit.CaretRight();


        return true;
    }




    private bool CaretUp(KeyHandle a)
    {
        this.Edit.CaretUp();


        return true;
    }




    private bool CaretDown(KeyHandle a)
    {
        this.Edit.CaretDown();


        return true;
    }





    private bool SelectLeft(KeyHandle a)
    {
        this.Edit.SelectLeft();


        return true;
    }




    private bool SelectRight(KeyHandle a)
    {
        this.Edit.SelectRight();


        return true;
    }




    private bool SelectUp(KeyHandle a)
    {
        this.Edit.SelectUp();


        return true;
    }




    private bool SelectDown(KeyHandle a)
    {
        this.Edit.SelectDown();


        return true;
    }





    private bool CaretViewRow(KeyHandle a)
    {
        this.Edit.CaretViewRow();


        return true;
    }




    private bool CaretViewCol(KeyHandle a)
    {
        this.Edit.CaretViewCol();


        return true;
    }





    private bool CaretStart(KeyHandle a)
    {
        this.Edit.CaretStart();


        return true;
    }




    private bool CaretEnd(KeyHandle a)
    {
        this.Edit.CaretEnd();


        return true;
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







    private bool InsertKeyChar(KeyHandle a)
    {
        ControlKeyChar c;

        c = a.Key.Char;




        char oc;

        oc = c.Default;



        if (a.Shift)
        {
            oc = c.Shift;
        }




        this.InsertChar(oc);



        
        return true;
    }





    private bool InsertLine(KeyHandle a)
    {
        ClassConstant constant;


        constant = ClassConstant.This;



        char oc;

        oc = constant.NewLine;



        this.InsertChar(oc);



        return true;
    }





    private bool InsertChar(char oc)
    {
        this.CharOneList[0] = oc;



        this.TextOneChar.Line.Get(0).Char.Replace(0, this.CharOneList, this.CharOneListRange);





        this.Edit.ReplaceText(this.TextOneChar);



        return true;
    }








    private bool InitText()
    {
        this.InitTextOneChar();



        this.InitCharOneList();




        return true;
    }






    private bool InitTextOneChar()
    {
        this.TextOneChar = new Text();




        TextLine[] a;

        a = new TextLine[1];



        TextLine line;

        line = new TextLine();

        line.Init();

        line.Char.SetCount(1);



        a[0] = line;



        RangeInfra infra;

        infra = RangeInfra.This;



        Range range;

        range = infra.Range(0, a.Length);




        this.TextOneChar.Line.Insert(0, a, range);



        return true;
    }




    private bool InitCharOneList()
    {
        this.CharOneList = new char[1];




        RangeInfra infra;

        infra = RangeInfra.This;



        this.CharOneListRange = infra.Range(0, this.CharOneList.Length);




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
        KeyHandle handle;


        handle = this.GetHandle(key, tab, shift, control);


        handle.Handle = method;


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