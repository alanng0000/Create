namespace Create;




class ControlHandle : Handle
{
    public Create Create { get; set; }




    private Edit Edit { get; set; }




    private Frame Frame { get; set; }





    private Control Control { get; set; }






    private ControlKeyList Key { get; set; }






    private KeyHandle[][][][] KeyHandleList { get; set; }





    private Text TextOneChar { get; set; }
    



    private char[] CharOneList { get; set; }




    private TextLine[] LineOneList { get; set; }




    private Range OneRange;





    private Text TextNewLine { get; set; }




    private Text TextEmpty { get; set; }





    public override bool Init()
    {
        base.Init();





        this.Frame = this.Create.Frame;




        this.Edit = this.Frame.Main.Edit;





        this.Control = this.Create.Control;





        this.Key = this.Control.Key;






        this.InitKeyHandleList();




        
        this.InitText();




        return true;
    }

    




    private bool InitKeyHandleList()
    {
        int count;


        count = this.Key.Count;




        this.KeyHandleList = new KeyHandle[count][][][];



        int i;

        i = 0;


        while (i < count)
        {
            ControlKey key;

            key = this.Key.Get(i);



            this.InitKeyHandleArrayKey(key);            



            i = i + 1;
        }






        this.InitKeyHandleListComp();





    
        this.SetHandleMethod(this.Key.LeftLeft, false, false, false, this.CaretLeft);


        
        this.SetHandleMethod(this.Key.LeftRight, false, false, false, this.CaretRight);



        this.SetHandleMethod(this.Key.LeftUp, false, false, false, this.CaretUp);


        
        this.SetHandleMethod(this.Key.LeftDown, false, false, false, this.CaretDown);






        this.SetHandleMethod(this.Key.LeftLeft, false, true, false, this.SelectLeft);



        this.SetHandleMethod(this.Key.LeftRight, false, true, false, this.SelectRight);



        this.SetHandleMethod(this.Key.LeftUp, false, true, false, this.SelectUp);



        this.SetHandleMethod(this.Key.LeftDown, false, true, false, this.SelectDown);






        this.SetHandleMethod(this.Key.LetterQ, false, false, false, this.CaretViewRow);



        this.SetHandleMethod(this.Key.LetterE, false, false, false, this.CaretViewCol);





        this.SetHandleMethod(this.Key.LetterX, false, false, false, this.CaretStart);



        this.SetHandleMethod(this.Key.LetterC, false, false, false, this.CaretEnd);







        this.SetHandleMethod(this.Key.RightLeft, false, false, false, this.ViewUnitLeft);



        this.SetHandleMethod(this.Key.RightRight, false, false, false, this.ViewUnitRight);



        this.SetHandleMethod(this.Key.RightUp, false, false, false, this.ViewUnitUp);



        this.SetHandleMethod(this.Key.RightDown, false, false, false, this.ViewUnitDown);





        this.SetHandleMethod(this.Key.RightLeft, false, true, false, this.ViewEntireLeft);



        this.SetHandleMethod(this.Key.RightRight, false, true, false, this.ViewEntireRight);



        this.SetHandleMethod(this.Key.RightUp, false, true, false, this.ViewEntireUp);



        this.SetHandleMethod(this.Key.RightDown, false, true, false, this.ViewEntireDown);






        
        this.InitKeyHandleListInsertChar();



        
        this.SetHandleMethod(this.Key.Enter, true, false, false, this.InsertLine);



        
        this.SetHandleMethod(this.Key.Backspace, true, false, false, this.BackSpace);




        this.SetKeyHandle(this.Key.LetterC, true, false, true, false, this.CopyText);



        this.SetHandleMethod(this.Key.LetterV, true, false, true, this.PasteText);




        return true;
    }





    private bool InitKeyHandleListInsertChar()
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




            this.SetHandleMethod(key, true, false, false, this.InsertKeyChar);



            this.SetHandleMethod(key, true, true, false, this.InsertKeyChar);




            i = i + 1;
        }



        return true;
    }







    private bool InitKeyHandleListComp()
    {
        int index;



        int count;

        count = this.Frame.Main.CompCount;


        int i;

        i = 0;

        while (i < count)
        {
            index = i + 1;



            ControlKey key;


            key = this.Control.Key.DigitKey(index);




            this.SetHandleMethod(key, false, false, false, this.SelectComp);





            i = i + 1;
        }


        return true;
    }







    private bool InitKeyHandleArrayKey(ControlKey key)
    {
        int keyIndex;

        keyIndex = key.Index;



        int boolCount;


        boolCount = this.BoolCount;




        this.KeyHandleList[keyIndex] = new KeyHandle[boolCount][][];


        this.KeyHandleList[keyIndex][this.BoolIndex(false)] = new KeyHandle[boolCount][];


        this.KeyHandleList[keyIndex][this.BoolIndex(true)] = new KeyHandle[boolCount][];



        this.KeyHandleList[keyIndex][this.BoolIndex(false)][this.BoolIndex(false)] = new KeyHandle[boolCount];


        this.KeyHandleList[keyIndex][this.BoolIndex(true)][this.BoolIndex(false)] = new KeyHandle[boolCount];


        this.KeyHandleList[keyIndex][this.BoolIndex(false)][this.BoolIndex(true)] = new KeyHandle[boolCount];


        this.KeyHandleList[keyIndex][this.BoolIndex(true)][this.BoolIndex(true)] = new KeyHandle[boolCount];






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




        this.KeyHandleList[keyIndex][tabIndex][shiftIndex][controlIndex] = this.CreateKeyHandle(key, tab, shift, control);




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





    private bool SelectComp(KeyHandle a)
    {
        int index;

        index = a.Key.Index;



        ControlConstant constant;

        constant = ControlConstant.This;



        int digitIndex;

        digitIndex = index - constant.LetterIndexEnd;



        int compIndex;

        compIndex = digitIndex - 1;



        Comp comp;

        comp = this.Frame.Main.Get(compIndex);



        this.Frame.Main.Comp = comp;




        return true;
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
        this.Edit.ReplaceText(this.TextNewLine);
        


        return true;
    }






    private bool InsertChar(char oc)
    {
        this.CharOneList[0] = oc;




        TextLine line;


        line = this.TextOneChar.Line.Get(0);
        
        

        line.Char.Set(0, this.CharOneList, this.OneRange);





        this.Edit.ReplaceText(this.TextOneChar);



        return true;
    }






    private bool BackSpace(KeyHandle a)
    {
        bool b;


        b = this.Edit.SelectActive;



        if (!b)
        {
            this.Edit.SelectLeft();
        }




        this.Edit.ReplaceText(this.TextEmpty);




        return true;
    }






    private bool CopyText(KeyHandle a)
    {
        bool b;

        b = this.Edit.SelectActive;



        if (b)
        {
            this.Edit.CopyText();
        }



        if (!b)
        {
            this.Edit.StoreText = null;
        }
        



        return true;
    }






    private bool PasteText(KeyHandle a)
    {
        Text text;

        text = this.Edit.StoreText;
        

        if (this.Null(text))
        {
            return true;
        }



        this.Edit.ReplaceText(text);
        



        return true;
    }








    private bool InitText()
    {
        this.CharOneList = new char[1];



        this.LineOneList = new TextLine[1];





        RangeInfra infra;

        infra = RangeInfra.This;



        this.OneRange = infra.Range(0, this.CharOneList.Length);






        this.InitTextOneChar();




        

        this.InitTextNewLine();





        this.InitTextEmpty();





        return true;
    }






    private bool InitTextOneChar()
    {
        this.TextOneChar = new Text();


        this.TextOneChar.Init();
        




        TextLine line;

        line = new TextLine();

        line.Init();



        line.Char.Insert(this.OneRange);





        this.LineOneList[0] = line;





        this.TextOneChar.Line.Insert(this.OneRange);



        this.TextOneChar.Line.Set(0, this.LineOneList, this.OneRange);




        return true;
    }





    private bool InitTextNewLine()
    {
        Text text;


        text = new Text();


        text.Init();




        TextLine lineA;

        lineA = new TextLine();

        lineA.Init();



        TextLine lineB;

        lineB = new TextLine();

        lineB.Init();




        TextLine[] lineList;


        lineList = new TextLine[2];


        lineList[0] = lineA;

        lineList[1] = lineB;




        RangeInfra infra;

        infra = RangeInfra.This;


        Range range;

        range = infra.Range(0, lineList.Length);




        text.Line.Insert(range);


        text.Line.Set(0, lineList, range);




        this.TextNewLine = text;



        return true;
    }






    private bool InitTextEmpty()
    {
        Text text;
        
        text = new Text();


        text.Init();
        




        TextLine line;

        line = new TextLine();

        line.Init();





        this.LineOneList[0] = line;





        text.Line.Insert(this.OneRange);



        text.Line.Set(0, this.LineOneList, this.OneRange);





        this.TextEmpty = text;




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
        this.SetKeyHandle(key, tab, shift, control, true, method);


        return true;
    }




    private bool SetKeyHandle(ControlKey key, bool tab, bool shift, bool control, bool update, HandleMethod method)
    {
        KeyHandle handle;


        handle = this.GetHandle(key, tab, shift, control);



        handle.Update = update;



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


        handle = this.KeyHandleList[keyIndex][tabIndex][shiftIndex][controlIndex];




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


                this.IsShift = false;


                this.IsControl = false;
            }


            if (key == this.Key.Shift)
            {
                this.IsShift = this.Toggle(this.IsShift);


                this.IsControl = false;
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



        if (handle.Update)
        {
            this.Frame.Update();
        }


        




        return true;
    }





    private bool Toggle(bool state)
    {
        return !state;
    }





    private bool Null(object o)
    {
        ObjectInfra infra;

        infra = ObjectInfra.This;


        return infra.Null(o);
    }
}