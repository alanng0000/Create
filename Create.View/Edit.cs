namespace Create.View;





public class Edit : Comp
{
    private Text Text { get; set; }





    private TextInfra TextInfra { get; set; }






    internal ClassClass Class { get; set; }





    private ClassNameTraverse ClassNameTraverse { get; set; }





    internal TokenListType TokenListType { get; set; }






    private Font Font { get; set; }




    private int CharWidth { get; set; }




    private int LineHeight { get; set; }




    private DrawRect CharDestRect;




    private Pos ScrollPos;




    public Size VisibleSize;




    private int MaxColCount { get; set; }




    private DrawColorBrush TextBrush { get; set; }


    

    private DrawBrush CaretBrush { get; set; }




    private DrawBrush SelectBrush { get; set; }





    private DrawColor CommentTextColor;





    private Draw DrawOp { get; set; }






    private Caret Caret { get; set; }





    private int CaretUpDownCol { get; set; }






    private Select Select { get; set; }




    private CaretPos SelectPosA { get; set; }




    private CaretPos SelectPosB { get; set; }







    private Pos PosA;




    private Pos PosB;





    private Line Line { get; set; }





    private char[] CharOneList { get; set; }





    private char[] Char { get; set; }




    private Range CharRange;




    private Range LineRange;




    private Line[] LineData { get; set; }




    private Line[] LineOneList { get; set; }




    private Range OneRange;





    public Text StoreText { get; set; }






    private int IndentWidth { get; set; }




    private char[] IndentSpace { get; set; }





    private DrawSize DrawSize;




    

    private PortPort Port { get; set; }





    public override bool Init()
    {
        base.Init();




        

        DrawInfra infra;

        infra = DrawInfra.This;



        this.DrawSize = infra.CreateSize(this.Size.Width, this.Size.Height);






        this.PosA = new Pos();



        this.PosA.Init();




        this.PosB = new Pos();



        this.PosB.Init();






        this.CharOneList = new char[1];



        this.LineOneList = new Line[1];




        this.CharRange = this.Range(0, 0);




        this.LineRange = this.Range(0, 0);




        this.OneRange = this.Range(0, this.CharOneList.Length);





        this.TokenListType = new TokenListType();


        this.TokenListType.Init();






        this.InitText();




        this.InitTextInfra();





        this.InitClass();




        this.InitClassNameTraverse();




        this.InitIndentSpace();






        this.InitSelect();





        this.InitCaret();





        this.InitFont();





        this.InitCharSize();




        this.InitCommentColor();



        this.InitTextBrush();



        this.InitCaretBrush();



        this.InitSelectBrush();





        this.LineHeight = 19;




        this.InitVisibleSize();




        DrawSize destSize;

        destSize = infra.CreateSize(2 * this.CharWidth, 2 * this.LineHeight);



        this.CharDestRect = infra.CreateRect(infra.CreatePos(0, 0), destSize);



        


        this.CharSpan = new CharSpan();


        this.CharSpan.Init();




        return true;
    }








    private bool InitText()
    {
        this.Text = new Text();



        this.Text.Init();





        string[] lineData;


        lineData = File.ReadAllLines("Demo");

        


        this.SetText(lineData);




        return true;
    }






    private bool InitTextInfra()
    {
        this.TextInfra = new TextInfra();



        this.TextInfra.Init();



        this.TextInfra.Text = this.Text;



        return true;
    }







    private bool InitClass()
    {
        this.Class = new ClassClass();



        this.Class.Init();




        
        this.ExecutePort();





        TaskKindList k;

        k = TaskKindList.This;




        Task task;


        task = new Task();


        task.Init();




        task.Kind = k.Check;






        Source source;


        source = new Source();


        source.Index = 0;


        source.Name = "SourceA";


        source.Text = this.Text;






        SourceArray sourceArray;


        sourceArray = new SourceArray();


        sourceArray.Count = 1;


        sourceArray.Init();




        sourceArray.Set(0, source);




        task.Source = sourceArray;




        task.Out = null;

        



        this.Class.ErrorWrite = false;




        this.Class.Task = task;
        




        this.Class.Execute();





        return true;
    }








    private bool ExecutePort()
    {
        Infra infra;

        infra = Infra.This;



        this.Port = infra.CreatePort();




        TaskKindList k;

        k = TaskKindList.This;





        Task task;



        task = new Task();



        task.Init();



        task.Kind = k.Port;



        task.Port = this.Port;



        task.Out = null;

        


        this.Class.Task = task;




        this.Class.Execute();




        return true;
    }






    private bool InitClassNameTraverse()
    {
        this.ClassNameTraverse = new ClassNameTraverse();



        this.ClassNameTraverse.Edit = this;



        this.ClassNameTraverse.Init();



        return true;
    }






    private bool InitIndentSpace()
    {
        this.IndentWidth = 4;




        this.IndentSpace = new char[this.IndentWidth];




        Constant constant;


        constant = Constant.This;




        int count;


        count = this.IndentSpace.Length;




        int i;

        i = 0;


        while (i < count)
        {
            this.IndentSpace[i] = constant.Space;


            i = i + 1;
        }



        return true;
    }






    private bool InitSelect()
    {
        this.Select = new Select();


        this.Select.Init();





        this.SelectPosA = new CaretPos();


        this.SelectPosA.Init();


        this.SelectPosA.Value = new Pos();


        this.SelectPosA.Value.Init();





        this.SelectPosB = new CaretPos();


        this.SelectPosB.Init();


        this.SelectPosB.Value = new Pos();


        this.SelectPosB.Value.Init();





        this.Select.Start = this.SelectPosA;



        this.Select.End = this.Select.Start;




        return true;
    }







    private bool InitCaret()
    {
        this.Caret = new Caret();



        this.Caret.Init();






        this.Caret.Pos = this.Select.End;





        this.CaretUpDownCol = 0;






        return true;
    }






    private bool SetText(string[] lineData)
    {
        Text text;

        text = this.Text;
        





        int count;

        count = lineData.Length;




        Range lineRange;

        lineRange = this.Range(0, count);




        text.Line.Insert(lineRange);






        int i;

        i = 0;



        while (i < count)
        {
            string s;

            s = lineData[i];



            Line line;

            line = this.CreateTextLine(s);



            this.SetLineOneList(line);




            text.Line.Set(i, this.LineOneList, this.OneRange);




            this.MaxColCount = this.Max(this.MaxColCount, line.Char.Count);




            i = i + 1;
        }

        

        return true;
    }








    private Line CreateTextLine(string s)
    {
        Line line;

        line = new Line();

        line.Init();






        int count;

        count = s.Length;




        Range charRange;


        charRange = this.Range(0, count);




        line.Char.Insert(charRange);





        char oc;




        int i;

        i = 0;


        while (i < count)
        {
            oc = s[i];



            this.SetCharOneList(oc);




            line.Char.Set(i, this.CharOneList, this.OneRange);




            i = i + 1;
        }



        Line ret;


        ret = line;


        return ret;
    }








    public bool CaretLeft()
    {
        this.CaretSelectValue();






        bool b;


        b = this.CheckCaretHasLeft();







        if (!b)
        {
            if (!this.CheckCaretHasUp())
            {
                return true;
            }
        }








        if (!b)
        {
            this.MoveCaretUp();





            this.PosA.Row = this.Caret.Pos.Value.Row;




            this.Line = this.Text.Line.Get(this.PosA.Row);



            this.PosA.Col = this.Line.Char.Count;




            this.MoveCaretCol();





            this.CaretUpDownCol = this.Caret.Pos.Value.Col;
        }





        if (b)
        {
            this.MoveCaretLeft();






            this.CaretUpDownCol = this.Caret.Pos.Value.Col;
        }





        this.PosA = this.Caret.Pos.Value;



        this.ScrollVisible();






        return true;
    }






    public bool CaretRight()
    {
        this.CaretSelectValue();






        bool b;


        b = this.CheckCaretHasRight();







        if (!b)
        {
            if (!this.CheckCaretHasDown())
            {
                return true;
            }
        }








        if (!b)
        {
            this.MoveCaretDown();


        

            this.PosA.Row = this.Caret.Pos.Value.Row;


            this.PosA.Col = 0;


            this.MoveCaretCol();




            this.CaretUpDownCol = this.Caret.Pos.Value.Col;
        }




        if (b)
        {
            this.MoveCaretRight();






            this.CaretUpDownCol = this.Caret.Pos.Value.Col;
        }





        this.PosA = this.Caret.Pos.Value;



        this.ScrollVisible();





        return true;
    }







    public bool CaretUp()
    {
        this.CaretSelectValue();






        bool b;


        b = this.CheckCaretHasUp();




        if (!b)
        {   
            this.PosA.Row = this.Caret.Pos.Value.Row;



            this.PosA.Col = 0;





            this.MoveCaretCol();
        }
        
        




        if (b)
        {
            this.MoveCaretUp();






            this.PosA.Row = this.Caret.Pos.Value.Row;



            this.PosA.Col = this.CaretUpDownCol;




            this.Line = this.Text.Line.Get(this.PosA.Row);




            bool ba;


            ba = this.CheckInsertCol();


            if (!ba)
            {
                this.Caret.Pos.Value.Col = this.Line.Char.Count;
            }



            if (ba)
            {
                this.Caret.Pos.Value.Col = this.PosA.Col;
            }
        }





        this.PosA = this.Caret.Pos.Value;



        this.ScrollVisible();





        return true;
    }









    public bool CaretDown()
    {
        this.CaretSelectValue();






        bool b;


        b = this.CheckCaretHasDown();






        if (!b)
        {
            this.PosA.Row = this.Caret.Pos.Value.Row;



            this.Line = this.Text.Line.Get(this.PosA.Row);



            this.PosA.Col = this.Line.Char.Count;





            this.MoveCaretCol();
        }






        if (b)
        {
            this.MoveCaretDown();





            this.PosA.Row = this.Caret.Pos.Value.Row;



            this.PosA.Col = this.CaretUpDownCol;




            this.Line = this.Text.Line.Get(this.PosA.Row);




            bool ba;


            ba = this.CheckInsertCol();


            if (!ba)
            {
                this.Caret.Pos.Value.Col = this.Line.Char.Count;
            }



            if (ba)
            {
                this.Caret.Pos.Value.Col = this.PosA.Col;
            }
        }





        this.PosA = this.Caret.Pos.Value;



        this.ScrollVisible();





        return true;
    }






    public bool CaretStart()
    {
        this.CaretSelectValue();





        this.PosA.Row = this.Caret.Pos.Value.Row;



        this.Line = this.Text.Line.Get(this.PosA.Row);




        this.PosA.Col = 0;




        if (!this.CheckInsertCol())
        {
            return true;
        }





        this.MoveCaretCol();





        this.CaretUpDownCol = this.Caret.Pos.Value.Col;





        this.PosA = this.Caret.Pos.Value;



        this.ScrollVisible();





        return true;
    }









    public bool CaretEnd()
    {
        this.CaretSelectValue();





        this.PosA.Row = this.Caret.Pos.Value.Row;



        this.Line = this.Text.Line.Get(this.PosA.Row);



        this.PosA.Col = this.Line.Char.Count;





        if (!this.CheckInsertCol())
        {
            return true;
        }






        this.MoveCaretCol();





        this.CaretUpDownCol = this.Caret.Pos.Value.Col;





        this.PosA = this.Caret.Pos.Value;



        this.ScrollVisible();





        return true;
    }







    public bool CaretViewRow()
    {
        this.CaretSelectValue();






        this.PosA.Row = this.ScrollPos.Row;


        this.PosA.Col = 0;




        
        this.MoveCaretRow();



        this.MoveCaretCol();





        this.CaretUpDownCol = this.Caret.Pos.Value.Col;





        this.PosA = this.Caret.Pos.Value;


        this.ScrollVisible();
        




        return true;
    }







    public bool CaretViewCol()
    {
        this.CaretSelectValue();






        this.PosA.Col = this.ScrollPos.Col;





        this.MoveCaretCol();





        this.CaretUpDownCol = this.Caret.Pos.Value.Col;





        this.PosA = this.Caret.Pos.Value;


        this.ScrollVisible();
        




        return true;
    }









    public bool SelectLeft()
    {
        if (!this.SelectActive)
        {
            this.SelectCaretValue();



            this.Caret.Pos = this.Select.Start;
        }






        bool b;


        b = this.CheckCaretHasLeft();







        if (!b)
        {
            if (!this.CheckCaretHasUp())
            {
                return true;
            }
        }








        if (!b)
        {
            this.MoveCaretUp();





            this.PosA.Row = this.Caret.Pos.Value.Row;




            this.Line = this.Text.Line.Get(this.PosA.Row);



            this.PosA.Col = this.Line.Char.Count;




            this.MoveCaretCol();





            this.CaretUpDownCol = this.Caret.Pos.Value.Col;
        }





        if (b)
        {
            this.MoveCaretLeft();






            this.CaretUpDownCol = this.Caret.Pos.Value.Col;
        }






        if (!this.CheckSelectRange())
        {
            this.FlipSelectRange();
        }






        this.PosA = this.Caret.Pos.Value;



        this.ScrollVisible();





        return true;
    }









    public bool SelectRight()
    {
        if (!this.SelectActive)
        {
            this.SelectCaretValue();



            this.Caret.Pos = this.Select.End;
        }
        






        bool b;


        b = this.CheckCaretHasRight();







        if (!b)
        {
            if (!this.CheckCaretHasDown())
            {
                return true;
            }
        }








        if (!b)
        {
            this.MoveCaretDown();


        

            this.PosA.Row = this.Caret.Pos.Value.Row;


            this.PosA.Col = 0;


            this.MoveCaretCol();




            this.CaretUpDownCol = this.Caret.Pos.Value.Col;
        }




        if (b)
        {
            this.MoveCaretRight();






            this.CaretUpDownCol = this.Caret.Pos.Value.Col;
        }






        if (!this.CheckSelectRange())
        {
            this.FlipSelectRange();
        }






        this.PosA = this.Caret.Pos.Value;



        this.ScrollVisible();
        




        return true;
    }









    public bool SelectUp()
    {
        if (!this.SelectActive)
        {
            this.SelectCaretValue();



            this.Caret.Pos = this.Select.Start;
        }






        bool b;


        b = this.CheckCaretHasUp();




        if (!b)
        {   
            this.PosA.Row = this.Caret.Pos.Value.Row;



            this.PosA.Col = 0;





            this.MoveCaretCol();





            this.CaretUpDownCol = this.Caret.Pos.Value.Col;
        }
        
        




        if (b)
        {
            this.MoveCaretUp();






            this.PosA.Row = this.Caret.Pos.Value.Row;



            this.PosA.Col = this.CaretUpDownCol;




            this.Line = this.Text.Line.Get(this.PosA.Row);




            bool ba;


            ba = this.CheckInsertCol();


            if (!ba)
            {
                this.Caret.Pos.Value.Col = this.Line.Char.Count;
            }



            if (ba)
            {
                this.Caret.Pos.Value.Col = this.PosA.Col;
            }
        }







        if (!this.CheckSelectRange())
        {
            this.FlipSelectRange();
        }






        this.PosA = this.Caret.Pos.Value;



        this.ScrollVisible();
        




        return true;
    }







    public bool SelectDown()
    {
        if (!this.SelectActive)
        {
            this.SelectCaretValue();



            this.Caret.Pos = this.Select.End;
        }






        bool b;


        b = this.CheckCaretHasDown();






        if (!b)
        {
            this.PosA.Row = this.Caret.Pos.Value.Row;



            this.Line = this.Text.Line.Get(this.PosA.Row);



            this.PosA.Col = this.Line.Char.Count;





            this.MoveCaretCol();





            this.CaretUpDownCol = this.Caret.Pos.Value.Col;
        }






        if (b)
        {
            this.MoveCaretDown();





            this.PosA.Row = this.Caret.Pos.Value.Row;



            this.PosA.Col = this.CaretUpDownCol;




            this.Line = this.Text.Line.Get(this.PosA.Row);




            bool ba;


            ba = this.CheckInsertCol();


            if (!ba)
            {
                this.Caret.Pos.Value.Col = this.Line.Char.Count;
            }



            if (ba)
            {
                this.Caret.Pos.Value.Col = this.PosA.Col;
            }
        }







        if (!this.CheckSelectRange())
        {
            this.FlipSelectRange();
        }






        this.PosA = this.Caret.Pos.Value;



        this.ScrollVisible();
        




        return true;
    }










    private bool CheckInsertCol()
    {
        int charCount;

        charCount = this.Line.Char.Count;



        int k;


        k = charCount + 1;



        if (!(this.PosA.Col < k))
        {
            return false;
        }



        return true;
    }








    private bool MoveCaretRow()
    {
        this.Caret.Pos.Value.Row = this.PosA.Row;





        return true;
    }






    private bool MoveCaretCol()
    {
        this.Caret.Pos.Value.Col = this.PosA.Col;



        return true;
    }






    private bool CheckCaretHasLeft()
    {
        if (this.Caret.Pos.Value.Col < 1)
        {
            return false;
        }
        



        return true;
    }





    private bool CheckCaretHasRight()
    {
        Line line;

        line = this.Text.Line.Get(this.Caret.Pos.Value.Row);





        if (!(this.Caret.Pos.Value.Col < line.Char.Count))
        {
            return false;
        }
        



        return true;
    }





    private bool CheckCaretHasUp()
    {
        if (this.Caret.Pos.Value.Row < 1)
        {
            return false;
        }
        



        return true;
    }









    private bool CheckCaretHasDown()
    {
        int row;


        row = this.Caret.Pos.Value.Row + 1;




        if (!this.CheckRowIndex(row))
        {
            return false;
        }
        
        



        return true;
    }






    private bool MoveCaretLeft()
    {
        int col;



        col = this.Caret.Pos.Value.Col;



        col = col - 1;



        this.Caret.Pos.Value.Col = col;




        return true;
    }





    private bool MoveCaretRight()
    {
        int col;



        col = this.Caret.Pos.Value.Col;



        col = col + 1;



        this.Caret.Pos.Value.Col = col;




        return true;
    }






    private bool MoveCaretUp()
    {
        int row;



        row = this.Caret.Pos.Value.Row;



        row = row - 1;



        this.Caret.Pos.Value.Row = row;




        return true;
    }







    private bool MoveCaretDown()
    {
        int row;



        row = this.Caret.Pos.Value.Row;



        row = row + 1;



        this.Caret.Pos.Value.Row = row;




        return true;
    }






    private bool CheckPosEqual(Pos a, Pos b)
    {
        return (a.Row == b.Row) & (a.Col == b.Col);
    }









    private bool CheckSelectRange()
    {
        Pos start;


        start = this.Select.Start.Value;



        Pos end;

        
        end = this.Select.End.Value;




        if (end.Row < start.Row)
        {
            return false;
        }



        if (start.Row < end.Row)
        {
            return true;
        }




        if (end.Col < start.Col)
        {
            return false;
        }




        return true;
    }









    private bool FlipSelectRange()
    {
        CaretPos pos;



        pos = this.Select.Start;





        this.Select.Start = this.Select.End;




        this.Select.End = pos;





        this.SelectPosA = this.Select.Start;




        this.SelectPosB = this.Select.End;







        return true;
    }







    private bool CaretSelectValue()
    {
        this.SelectPosA.Value = this.Caret.Pos.Value;




        this.Select.Start = this.SelectPosA;



        this.Select.End = this.Select.Start;




        this.Caret.Pos = this.Select.End;





        return true;
    }




    


    
    public bool SelectActive
    {
        get
        {
            return !(this.Select.Start == this.Select.End);
        }
        set
        {
        }
    }







    private bool SelectCaretValue()
    {
        this.SelectPosA.Value = this.Caret.Pos.Value;



        this.SelectPosB.Value = this.SelectPosA.Value;




        this.Select.Start = this.SelectPosA;




        this.Select.End = this.SelectPosB;





        return true;
    }





    public bool ViewLeft(int count)
    {
        int col;


        col = this.ScrollPos.Col;


        col = col - count;



        if (col < 0)
        {
            col = 0;
        }





        this.ScrollToCol(col);






        return true;
    }






    public bool ViewRight(int count)
    {
        int col;


        col = this.ScrollPos.Col;


        col = col + count;



        if (!(col < this.MaxColCount))
        {
            col = this.MaxColCount - 1;
        }





        this.ScrollToCol(col);






        return true;
    }





    public bool ViewUp(int count)
    {
        int row;


        row = this.ScrollPos.Row;


        row = row - count;



        if (row < 0)
        {
            row = 0;
        }





        this.ScrollToRow(row);






        return true;
    }








    public bool ViewDown(int count)
    {
        int row;


        row = this.ScrollPos.Row;


        row = row + count;



        if (!this.CheckRowIndex(row))
        {
            row = this.Text.Line.Count - 1;
        }





        this.ScrollToRow(row);






        return true;
    }









    private bool ScrollToRow(int row)
    {
        this.ScrollPos.Row = row;




        return true;
    }





    private bool ScrollToCol(int col)
    {
        this.ScrollPos.Col = col;




        return true;
    }






    private bool ScrollVisible()
    {
        bool b;



        b = false;



        if (this.PosA.Row < this.ScrollPos.Row)
        {
            this.ScrollPos.Row = this.PosA.Row;


            b = true;
        }



        if (!b)
        {
            int scrollDown;

            scrollDown = this.ScrollPos.Row + this.VisibleSize.Height;



            if (!(this.PosA.Row < scrollDown))
            {
                scrollDown = this.PosA.Row + 1;


                this.ScrollPos.Row = scrollDown - this.VisibleSize.Height;
            }
        }




        b = false;



        if (this.PosA.Col < this.ScrollPos.Col)
        {
            this.ScrollPos.Col = this.PosA.Col;


            b = true;
        }



        if (!b)
        {
            int scrollRight;

            scrollRight = this.ScrollPos.Col + this.VisibleSize.Width;



            if (!(this.PosA.Col < scrollRight))
            {
                scrollRight = this.PosA.Col + 1;


                this.ScrollPos.Col = scrollRight - this.VisibleSize.Width;
            }
        }




        return true;
    }







    private bool CheckRowIndex(int row)
    {
        if (!(row < this.Text.Line.Count))
        {
            return false;
        }


        return true;
    }





    private bool CheckColIndex(Line line, int col)
    {
        if (!(col < line.Char.Count))
        {
            return false;
        }


        return true;
    }





    private bool SetLineOneList(Line line)
    {
        this.LineOneList[0] = line;


        return true;
    }




    private bool SetCharOneList(char oc)
    {
        this.CharOneList[0] = oc;


        return true;
    }









    public bool ReplaceText(Text text)
    {
        if (text.Line.Count == 0)
        {
            return true;
        }
        




        Pos startPos;

        startPos = this.Select.Start.Value;



        Pos endPos;

        endPos = this.Select.End.Value;








        int thisStartRow;

        thisStartRow = startPos.Row;



        int thisEndRow;

        thisEndRow = endPos.Row + 1;




        Range thisRowRange;

        thisRowRange = this.Range(thisStartRow, thisEndRow);




        int uStartRow;

        uStartRow = 0;


        int uEndRow;

        uEndRow = text.Line.Count;




        Range uRowRange;

        uRowRange = this.Range(uStartRow, uEndRow);




        int thisRowCount;

        thisRowCount = this.Count(thisRowRange);
    



        int uRowCount;

        uRowCount = this.Count(uRowRange);



    

        int count;

        

        
        int start;

        start = 0;



        int end;

        end = 0;



        int i;



        bool b;


        b = (thisRowCount < uRowCount);



        bool ba;

        ba = false;


        if (b)
        {
            count = uRowCount - thisRowCount;




            int insertIndex;

            insertIndex = thisRowRange.End - 1;




            ba = (thisRowCount == 1);



            if (ba)
            {
                insertIndex = thisRowRange.End;
            }



            start = insertIndex;


            end = start + count;



            this.LineRange = this.Range(start, end);



            this.InsertLineList();



            


            int row;



            this.LineData = this.LineOneList;
                

            this.LineRange = this.OneRange;


            
            i = 0;

            while (i < count)
            {
                Line line;

                line = new Line();

                line.Init();



                this.SetLineOneList(line);



                row = start + i;



                this.PosA.Row = row;



                this.SetLineList();



                i = i + 1;
            }            
        }




        
        int startIndex;

        startIndex = 0;




        bool bb;

        bb = (uRowCount == 1);




        bool bbd;

        bbd = (thisRowCount == uRowCount);



        if (!b & !bbd)
        {
            Line lastLine;


            if (bb)
            {
                Line firstLine;


                firstLine = this.Text.Line.Get(thisRowRange.Start);





                this.Line = firstLine;


                this.CharRange = this.Range(startPos.Col, firstLine.Char.Count);




                this.RemoveCharList();





                int hh;

                hh = firstLine.Char.Count;





                lastLine = this.Text.Line.Get(thisRowRange.End - 1);



                Range kk;

                kk = this.Range(endPos.Col, lastLine.Char.Count);



                int k;

                k = this.Count(kk);





                Line uFirstLine;

                uFirstLine = text.Line.Get(uRowRange.Start);



                int uCount;

                uCount = uFirstLine.Char.Count;





                int uu;


                uu = uCount + k;


                

                this.Line = firstLine;



                start = hh;


                end = start + uu;



                this.CharRange = this.Range(start, end);



                this.InsertCharList();





                
                this.Line = firstLine;


                this.PosA.Col = start;


                this.Char = uFirstLine.Char.Data;


                this.CharRange = this.Range(0, uCount);



                this.SetCharList();
                




                this.PosA.Col = this.PosA.Col + uCount;


                this.Char = lastLine.Char.Data;


                this.CharRange = kk;


                
                this.SetCharList();




                startIndex = startIndex + 1;
            }





            int d;

            d = thisRowCount - uRowCount;



            start = thisRowRange.Start + 1;



            end = start + d;

            

            this.LineRange = this.Range(start, end);



            this.RemoveLineList();
        }





        count = uRowCount;




        if (b)
        {
            if (ba)
            {
                Line firstLine;

                firstLine = this.Text.Line.Get(thisRowRange.Start);



                int lastRow;

                lastRow = thisRowRange.Start + uRowCount - 1;



                Line lastLine;

                lastLine = this.Text.Line.Get(lastRow);




                Line sourceLastLine;

                sourceLastLine = text.Line.Get(uRowRange.End - 1);



                int ka;

                ka = sourceLastLine.Char.Count;




                start = endPos.Col;


                end = firstLine.Char.Count;



                Range kRange;

                kRange = this.Range(start, end);



                int kb;

                kb = this.Count(kRange);



                
                int kk;

                kk = ka + kb;




                this.Line = lastLine;



                start = 0;


                end = kk;



                this.CharRange = this.Range(start, end);



                this.InsertCharList();






                this.Line = lastLine;


                this.PosA.Col = 0;


                this.Char = sourceLastLine.Char.Data;


                this.CharRange = this.Range(0, ka);



                this.SetCharList();





                this.Line = lastLine;


                this.PosA.Col = ka;


                this.Char = firstLine.Char.Data;


                this.CharRange = kRange;



                this.SetCharList();





                this.Line = firstLine;


                this.RemoveCharList();




                count = count - 1;
            }
        }





        int ku;

        ku = uRowCount - 1;




        i = startIndex;

        while (i < count)
        {
            int row;

            row = thisRowRange.Start + i;



            Line destLine;
            
            destLine = this.Text.Line.Get(row);



            int uRow;

            uRow = uRowRange.Start + i;



            Line sourceLine;

            sourceLine = text.Line.Get(uRow);




            Range destRange;

            destRange = new Range();



            bool bba;

            bba = (i == 0);


            bool bbb;

            bbb = (i == ku);



            

            if (bba)
            {
                if (bbb)
                {
                    destRange = this.Range(startPos.Col, endPos.Col);
                }

                if (!bbb)
                {
                    destRange = this.Range(startPos.Col, destLine.Char.Count);
                }
            }



            if (!bba)
            {
                if (bbb)
                {
                    destRange = this.Range(0, endPos.Col);
                }

                if (!bbb)
                {
                    destRange = this.Range(0, destLine.Char.Count);
                }
            }




            Range sourceRange;

            sourceRange = this.Range(0, sourceLine.Char.Count);
            




            this.ReplaceLine(destLine, destRange, sourceLine, sourceRange);




            i = i + 1;
        }





        if (bb)
        {
            int k;

            k = startPos.Col;



            Line uFirstLine;

            uFirstLine = text.Line.Get(0);



            int uk;

            uk = uFirstLine.Char.Count;



            k = k + uk;



            this.PosA.Row = startPos.Row;


            this.PosA.Col = k;



            this.Select.End.Value = this.PosA;
        }




        if (!bb)
        {
            int uLastRow;

            uLastRow = uRowRange.End - 1;

            


            int row;


            row = startPos.Row;


            row = row + uLastRow;

            


            Line uLastLine;

            uLastLine = text.Line.Get(uLastRow);



            int k;

            k = uLastLine.Char.Count;




            int col;

            col = k;



            this.PosA.Row = row;


            this.PosA.Col = col;



            this.Select.End.Value = this.PosA;
        }





        this.CaretUpDownCol = this.Caret.Pos.Value.Col;






        Pos posStart;

        posStart = this.Select.Start.Value;


        Pos posEnd;

        posEnd = this.Select.End.Value;


        if (posStart.Row == posEnd.Row & 
            posStart.Col == posEnd.Col)
        {
            this.CaretSelectValue();
        }






        this.PosA = this.Caret.Pos.Value;



        this.ScrollVisible();






        this.ExecuteClass();






        return true;
    }






    private bool ReplaceLine(Line destLine, Range destRange, Line sourceLine, Range sourceRange)
    {
        int destCount;

        destCount = this.Count(destRange);




        int sourceCount;

        sourceCount = this.Count(sourceRange);

        


        int start;


        int end;




        bool b;
        
        b = (destCount < sourceCount);


        if (b)
        {
            int d;


            d = sourceCount - destCount;



            this.Line = destLine;



            start = destRange.End;


            end = start + d;


            this.CharRange = this.Range(start, end);



            this.InsertCharList();
        }




        if (!b)
        {
            this.Line = destLine;

            


            start = destRange.Start + sourceCount;


            end = destRange.End;



            this.CharRange = this.Range(start, end);



            this.RemoveCharList();
        }





        this.Line = destLine;



        this.PosA.Col = destRange.Start;



        this.Char = sourceLine.Char.Data;



        this.CharRange = sourceRange;



        this.SetCharList();




        return true;
    }







    public bool CopyText()
    {
        if (!this.SelectActive)
        {
            return true;
        }




        Pos startPos;

        startPos = this.Select.Start.Value;



        Pos endPos;

        endPos = this.Select.End.Value;








        int startRow;

        startRow = startPos.Row;



        int endRow;

        endRow = endPos.Row + 1;




        Range rowRange;

        rowRange = this.Range(startRow, endRow);



        int rowCount;

        rowCount = this.Count(rowRange);




        int uu;

        uu = rowCount - 1;





        Text text;

        text = this.Text;




        Range rowRangeA;

        rowRangeA = this.Range(0, rowCount);




        Text textA;

        textA = new Text();

        textA.Init();


        textA.Line.Insert(rowRangeA);
        



        int count;

        count = rowCount;

        


        int i;

        i = 0;

        while (i < count)
        {
            int row;

            row = rowRange.Start + i;



            Line line;
            
            line = text.Line.Get(row);



            Range range;

            range = new Range();



            bool bba;

            bba = (i == 0);


            bool bbb;

            bbb = (i == uu);



            

            if (bba)
            {
                if (bbb)
                {
                    range = this.Range(startPos.Col, endPos.Col);
                }

                if (!bbb)
                {
                    range = this.Range(startPos.Col, line.Char.Count);
                }
            }



            if (!bba)
            {
                if (bbb)
                {
                    range = this.Range(0, endPos.Col);
                }

                if (!bbb)
                {
                    range = this.Range(0, line.Char.Count);
                }
            }




            int countA;

            countA = this.Count(range);



            Range rangeA;

            rangeA = this.Range(0, countA);




            Line lineA;

            lineA = new Line();

            lineA.Init();


            lineA.Char.Insert(rangeA);




            int start;

            start = range.Start;



            int index;



            char oc;




            int j;

            j = 0;


            while (j < countA)
            {
                index = start + j;



                oc = line.Char.Get(index);



                this.SetCharOneList(oc);



                lineA.Char.Set(j, this.CharOneList, this.OneRange);



                j = j + 1;
            }




            this.SetLineOneList(lineA);



            textA.Line.Set(i, this.LineOneList, this.OneRange);




            i = i + 1;
        }




        this.StoreText = textA;





        return true;
    }









    private bool InsertCharList()
    {
        this.Line.Char.Insert(this.CharRange);






        return true;
    }






    private bool RemoveCharList()
    {
        this.Line.Char.Remove(this.CharRange);



        return true;
    }





    private bool SetCharList()
    {
        int index;


        index = this.PosA.Col;





        this.Line.Char.Set(index, this.Char, this.CharRange);






        return true;
    }



    

  



    public bool InsertIndent()
    {
        this.PosA = this.Caret.Pos.Value;




        int remainWidth;


        remainWidth = this.IndentRemainWidth();




        this.Char = this.IndentSpace;




        this.CharRange.Start = 0;


        this.CharRange.End = this.CharRange.Start + remainWidth;



        

        this.Line = this.Text.Line.Get(this.PosA.Row);
        




        this.InsertCharList();
        
        






        int k;


        k = this.Count(this.CharRange);




        this.PosA.Row = 0;


        this.PosA.Col = this.Caret.Pos.Value.Col + k;





        this.MoveCaretCol();






        this.CaretUpDownCol = this.Caret.Pos.Value.Col;






        this.ExecuteClass();







        return true;
    }






    private int IndentRemainWidth()
    {
        int k;

        k = this.PosA.Col;



        int j;

        j = k / this.IndentWidth;



        int f;

        f = j + 1;



        int d;


        d = f * this.IndentWidth;



        int h;
        

        h = d - k;



        int ret;

        ret = h;


        return ret;
    }






    private bool InsertLineList()
    {
        this.Text.Line.Insert(this.LineRange);




        return true;
    }





    private bool RemoveLineList()
    {
        this.Text.Line.Remove(this.LineRange);



        return true;
    }






    private bool SetLineList()
    {
        int index;


        index = this.PosA.Row;



        this.Text.Line.Set(index, this.LineData, this.LineRange);




        return true;
    }


    






    private Range Range(int start, int end)
    {
        RangeInfra infra;

        infra = RangeInfra.This;


        return infra.Range(start, end);
    }






    private Range IndexRange(int index)
    {
        return this.Range(index, index + 1);
    }





    private int Count(Range range)
    {
        RangeInfra infra;

        infra = RangeInfra.This;


        return infra.Count(range);
    }







    private bool ExecuteClass()
    {
        this.Class.Execute();



        return true;
    }









    
    private int Min(int a, int b)
    {
        int h;


        h = a;


        if (b < h)
        {
            h = b;
        }



        int ret;

        ret = h;

        return ret;
    }




    private int Max(int a, int b)
    {
        int h;


        h = a;


        if (h < b)
        {
            h = b;
        }



        int ret;

        ret = h;

        return ret;
    }








    private bool ExecuteClassNameTraverse()
    {
        Tree tree;


        
        tree = (Tree)this.Class.Result.Node.Tree.Get(0);





        Node root;

        root = tree.Root;



        if (this.Null(root))
        {
            return true;
        }




        NodeClass nodeClass;

        nodeClass = (NodeClass)root;





        this.ClassNameTraverse.ExecuteClass(nodeClass);




        return true;
    }







    protected override bool DrawThis(Draw draw)
    {
        base.DrawThis(draw);




        this.DrawOp = draw;




        this.DrawAll();




        this.DrawOp = null;




        return true;
    }





    private bool DrawAll()
    {
        this.SetCode();






        this.SetTokenListType();






        this.DrawSelect();






        this.DrawCode();






        
        
        this.DrawCaret();
        

        




        return true;
    }





    private Code Code { get; set; }





    private bool SetCode()
    {
        CodeList codeList;


        codeList = this.Class.Result.Token.Code;





        int u;

        u = codeList.Count;



        if (u < 1)
        {
            return true;
        }




        this.Code = (Code)codeList.Get(0);



        return true;
    }







    private bool SetTokenListType()
    {
        int count;


        count = this.Code.Token.Count;



        this.TokenListType.SetCount(count);




        this.SetTokenTokenListType();



        
        this.SetNodeTokenListType();




        return true;
    }






    private bool SetTokenTokenListType()
    {
        TokenList tokenList;


        tokenList = this.Code.Token;





        Token token;





        int count;


        count = tokenList.Count;





        int i;

        i = 0;


        while (i < count)
        {
            token = tokenList.Get(i);



            this.SetTokenTokenType(i, ref token);




            i = i + 1;
        }



        return true;
    }






    private bool SetTokenTokenType(int index, ref Token token)
    {
        bool b;


        b = false;



        TokenTypeList typeList;


        typeList = TokenTypeList.This;




        TokenType type;


        type = typeList.Default;




        if (!b)
        {
            b = this.IsInt(ref token.Range);


            if (b)
            {
                type = typeList.Int;
            }
        }




        if (!b)
        {
            b = this.IsString(ref token.Range);


            if (b)
            {
                type = typeList.String;
            }
        }


        

        if (!b)
        {
            b = this.IsKeyword(ref token.Range);


            if (b)
            {
                type = typeList.Keyword;
            }
        }





        this.TokenListType.Set(index, type);




        return true;
    }






    private bool DrawSelect()
    {
        Pos start;

        start = this.Select.Start.Value;




        Pos end;

        end = this.Select.End.Value;





        if (start.Row == end.Row)
        {
            int r;


            r = end.Col - start.Col;



            this.DrawSelectOneRect(start, r);




            return true;
        }





        Line firstLine;


        firstLine = this.Text.Line.Get(start.Row);



        int firstCount;


        firstCount = firstLine.Char.Count - start.Col;


        firstCount = firstCount + 1;




        this.DrawSelectOneRect(start, firstCount);





        int count;


        count = end.Row - start.Row - 1;



        int row;


        row = 0;



        int k;

        k = start.Row + 1;



        Line line;

        line = null;




        Pos pos;

        pos = new Pos();

        pos.Init();




        int u;

        u = 0;




        int i;

        i = 0;



        while (i < count)
        {
            row = i + k;



            pos.Row = row;

            pos.Col = 0;



            line = this.Text.Line.Get(row);



            u = line.Char.Count - pos.Col;


            u = u + 1;



            this.DrawSelectOneRect(pos, u);



    
            i = i + 1;
        }







        int lastCount;


        lastCount = end.Col;



        Pos o;

        o = new Pos();

        o.Init();

        o.Row = end.Row;

        o.Col = 0;



        this.DrawSelectOneRect(o, lastCount);





        return true;
    }







    private bool DrawSelectOneRect(Pos pos, int count)
    {
        int row;


        row = pos.Row - this.ScrollPos.Row;




        int col;


        col = pos.Col - this.ScrollPos.Col;





        int w;


        w = count;



        int h;


        h = 1;





        int left;


        left = this.DrawWidth(col);
        



        int up;


        up = this.DrawHeight(row);





        int width;


        width = this.DrawWidth(w);




        int height;


        height = this.DrawHeight(h);




        DrawInfra infra;

        infra = DrawInfra.This;



        DrawRect rect;

        rect = infra.CreateRect(infra.CreatePos(left, up), infra.CreateSize(width, height));





        this.DrawOp.Rect(rect, this.SelectBrush);




        return true;
    }










    private bool DrawCode()
    {
        TokenList tokenList;


        tokenList = this.Code.Token;





        CommentList commentList;


        commentList = this.Code.Comment;





        this.DrawTokenList(tokenList);




        this.DrawCommentList(commentList);





        return true;
    }




    private bool DrawTokenList(TokenList tokenList)
    {
        int count;


        count = tokenList.Count;




        Token token;




        int i;

        i = 0;



        while (i < count)
        {
            token = tokenList.Get(i);


            this.DrawToken(i, ref token);



            i = i + 1;
        }



        return true;
    }




    private bool DrawToken(int index, ref Token token)
    {
        TokenType type;

        type = this.TokenListType.Get(index);






        TextRange range;


        range = token.Range;



        this.DrawText(ref range, ref type.Color);




        return true;
    }






    private bool DrawCommentList(CommentList comments)
    {
        int count;


        count = comments.Count;




        Comment comment;




        int i;

        i = 0;



        while (i < count)
        {
            comment = comments.Get(i);


            this.DrawComment(ref comment);



            i = i + 1;
        }



        return true;
    }






    private bool DrawComment(ref Comment comment)
    {
        TextRange range;


        range = comment.Range;



        this.DrawText(ref range, ref this.CommentTextColor);




        return true;
    }






    private bool SetNodeTokenListType()
    {
        this.ExecuteClassNameTraverse();



        return true;
    }







    private bool DrawText(ref TextRange range, ref DrawColor color)
    {
        int row;


        row = range.Row;




        Line line;


        line = this.Text.Line.Get(row);




        char[] data;


        data = line.Char.Data;




        int ka;


        ka = row - this.ScrollPos.Row;





        int up;


        up = this.DrawHeight(ka);


        
        up = up + 1;






        DrawInfra infra;

        infra = DrawInfra.This;





        this.CharSpan.Array = data;





        this.CharDestRect.Pos.Up = up;





        this.TextBrush.Color = color;




        int start;
        
        
        start = range.Range.Start;




        int index;




        int count;


        count = this.Count(range.Range);




        int i;

        i = 0;

        while (i < count)
        {
            index = start + i;


            
            this.CharSpan.Range = this.IndexRange(index);





            int kb;


            kb = index - this.ScrollPos.Col;
            




            int left;


            left = this.DrawWidth(kb);


            left = left - 1;





            this.CharDestRect.Pos.Left = left;

        


            
            this.DrawOp.Text(this.CharSpan, this.CharDestRect, this.Font, this.TextBrush);




            i = i + 1;
        }





        return true;
    }





    private CharSpan CharSpan;






    private bool IsInt(ref TextRange range)
    {
        Pos pos;

        pos = new Pos();

        pos.Init();

        pos.Row = range.Row;

        pos.Col = range.Range.Start;




        char oc;
        

        oc = this.TextInfra.Char(pos);



        bool b;
        
        b = this.TextInfra.IsDigit(oc);


        
        if (!b)
        {
            return false;
        }


        return true;
    }

    






    private bool IsString(ref TextRange range)
    {
        Pos pos;

        pos = new Pos();

        pos.Init();

        pos.Row = range.Row;

        pos.Col = range.Range.Start;




        Constant constant;

        constant = Constant.This;




        char oc;
        

        oc = this.TextInfra.Char(pos);



        bool b;
        
        b = (oc == constant.Quote);


        
        if (!b)
        {
            return false;
        }


        return true;
    }






    private bool IsKeyword(ref TextRange range)
    {
        KeywordList keywordList;

        keywordList = KeywordList.Instance;



        return this.StringListContain(keywordList.All, ref range);
    }






    private bool StringListContain(List list, ref TextRange range)
    {
        ListIter iter;


        iter = list.Iter();



        while (iter.Next())
        {
            string s;


            s = (string)iter.Value;



            if (this.TextInfra.Equal(range.Row, range.Range, s))
            {
                return true;
            }
        }



        return false;
    }









    private bool DrawCaret()
    {
        Pos pos;


        pos = this.Caret.Pos.Value;
        





        int row;


        row = pos.Row - this.ScrollPos.Row;




        int col;


        col = pos.Col - this.ScrollPos.Col;




        int left;


        left = this.DrawWidth(col);
        



        int up;


        up = this.DrawHeight(row);




        int width;


        width = 2;




        int height;


        height = this.LineHeight;





        DrawInfra infra;

        infra = DrawInfra.This;




        DrawRect rect;


        rect = infra.CreateRect(infra.CreatePos(left, up), infra.CreateSize(width, height));





        this.DrawOp.Rect(rect, this.CaretBrush);




        return true;
    }





    private int DrawWidth(int col)
    {
        return this.CharWidth * col;
    }




    private int DrawHeight(int row)
    {
        return this.LineHeight * row;
    }






    private bool InitCommentColor()
    {
        DrawInfra infra;

        infra = DrawInfra.This;


        this.CommentTextColor = infra.CreateColor(0xff, 0x00, 0x80, 0x00);




        return true;
    }





    private bool InitTextBrush()
    {
        this.TextBrush = new DrawColorBrush();

        this.TextBrush.Init();


        return true;
    }






    private bool InitCaretBrush()
    {
        DrawInfra infra;

        infra = DrawInfra.This;




        DrawColorBrush brush;


        brush = new DrawColorBrush();
        

        brush.Init();

        
        brush.Color = infra.CreateColor(0xff, 0, 0, 0);




        this.CaretBrush = brush;



        return true;
    }







    private bool InitSelectBrush()
    {
        DrawInfra infra;

        infra = DrawInfra.This;



        DrawColorBrush brush;


        brush = new DrawColorBrush();
        

        brush.Init();

        
        brush.Color = infra.CreateColor(0xff, 0xad, 0xd6, 0xff);



        this.SelectBrush = brush;




        return true;
    }







    private bool InitFont()
    {
        FontFamily fontFamily;

        fontFamily = new FontFamily();

        fontFamily.Name = "Cascadia Mono";

        fontFamily.Init();




        FontStyle fontStyle;

        fontStyle = new FontStyle();

        fontStyle.Init();




        Font font;


        font = new Font();


        font.Family = fontFamily;


        font.Size = 14;

        
        font.Style = fontStyle;


        font.Init();

        


        this.Font = font;




        return true;
    }






    private bool InitCharSize()
    {
        this.CharWidth = 9;




        return true;
    }




    private bool InitVisibleSize()
    {
        int row;

        row = this.DrawSize.Height / this.LineHeight;



        int col;

        col = this.DrawSize.Width / this.CharWidth;




        this.VisibleSize = new Size();


        this.VisibleSize.Init();


        this.VisibleSize.Width = col;


        this.VisibleSize.Height = row;



        return true;
    }
}