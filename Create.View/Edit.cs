namespace Create.View;





public class Edit : ViewView
{
    public Frame Frame { get; set; }





    private Text Text { get; set; }





    private TextInfra TextInfra { get; set; }





    private RangeInfra RangeInfra { get; set; }





    private Infra Infra { get; set; }





    private ClassClass Class { get; set; }





    private ClassNameTraverse ClassNameTraverse { get; set; }





    private TokenType[] TokenListType { get; set; }





    internal TokenTypeList TokenType { get; set; }





    private Font Font { get; set; }




    private int CharWidth { get; set; }




    private int LineHeight { get; set; }







    private Pos ScrollPos;




    

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





    private int Count { get; set; }





    private char[] OneChars { get; set; }





    private char[] Chars { get; set; }




    private Range CharRange;





    private int IndentWidth { get; set; }




    private char[] IndentSpaces { get; set; }





    private DrawSize DrawSize;




    

    private PortPort Port { get; set; }





    public override bool Init()
    {
        base.Init();

        



        this.Size.Width = this.Frame.Size.Width;



        this.Size.Height = this.Frame.Size.Height;




        

        this.Infra = Infra.This;



    
        this.TokenType = TokenTypeList.This;





        this.DrawSize = this.Infra.CreateSize(this.Size.Width, this.Size.Height);






        this.PosA = new Pos();



        this.PosA.Init();




        this.PosB = new Pos();



        this.PosB.Init();






        this.OneChars = new char[1];




        this.CharRange = new Range();


        this.CharRange.Init();






        this.InitText();




        this.InitTextInfra();




        this.InitRangeInfra();




        this.InitClass();




        this.InitClassNameTraverse();




        this.InitIndentSpaces();






        this.InitSelect();





        this.InitCaret();





        this.InitFont();





        this.InitCharSize();




        this.InitTextColor();




        this.InitCaretBrush();




        this.InitSelectBrush();





        this.LineHeight = 19;


        





        return true;
    }








    private bool InitText()
    {
        this.Text = new Text();



        this.Text.Init();






        this.AddNewLine();




        string s;

        s = File.ReadAllText("Demo");

        

        this.SetText(s);




        return true;
    }






    private bool InitTextInfra()
    {
        this.TextInfra = new TextInfra();



        this.TextInfra.Init();



        this.TextInfra.Text = this.Text;



        return true;
    }





    private bool InitRangeInfra()
    {
        this.RangeInfra = new RangeInfra();


        this.RangeInfra.Init();



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





        this.Class.Task = task;
        




        this.Class.Execute();





        return true;
    }








    private bool ExecutePort()
    {
        this.Port = this.Infra.CreatePort();




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






    private bool InitIndentSpaces()
    {
        this.IndentWidth = 4;




        this.IndentSpaces = new char[this.IndentWidth];




        int count;


        count = this.IndentSpaces.Length;




        int i;

        i = 0;


        while (i < count)
        {
            this.IndentSpaces[i] = ' ';


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






    private bool SetText(string s)
    {
        Line line;


        line = this.Text.Line.Get(0);




        int count;


        count = s.Length;



        char oc;



        bool b;



        int i;

        i = 0;


        while (i < count)
        {
            oc = s[i];



            b = (oc == '\n');



            if (b)
            {
                line = new Line();


                line.Init();


                this.Text.Line.Add(line);
            }



            if (!b)
            {
                line.Char.Add(oc);
            }



            i = i + 1;
        }
        

        return true;
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







        this.UpdateArea();





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






        this.UpdateArea();






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







        this.UpdateArea();






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







        this.UpdateArea();





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







        this.UpdateArea();







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






        this.UpdateArea();






        return true;
    }









    public bool SelectLeft()
    {
        if (!this.CheckSelectActive())
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






        this.UpdateArea();





        return true;
    }









    public bool SelectRight()
    {
        if (!this.CheckSelectActive())
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






        this.UpdateArea();






        return true;
    }









    public bool SelectUp()
    {
        if (!this.CheckSelectActive())
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







        this.UpdateArea();






        return true;
    }











    public bool SelectDown()
    {
        if (!this.CheckSelectActive())
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







        this.UpdateArea();





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









    private bool CheckSelectEmpty()
    {
        return this.CheckPosEqual(this.Select.Start.Value, this.Select.End.Value);
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




    


    
    private bool CheckSelectActive()
    {
        return !(this.Select.Start == this.Select.End);
    }







    private bool SelectCaretValue()
    {
        this.SelectPosA.Value = this.Caret.Pos.Value;



        this.SelectPosB.Value = this.SelectPosA.Value;




        this.Select.Start = this.SelectPosA;




        this.Select.End = this.SelectPosB;





        return true;
    }







    public bool PageUp()
    {
        this.CaretSelectValue();





        int row;


        row = this.ScrollPos.Row;


        row = row - 25;



        if (row < 0)
        {
            row = 0;
        }




        this.ScrollToRow(row);






        this.PosA.Row = row;


        this.PosA.Col = 0;




        this.MoveCaretRow();






        this.PosA.Row = this.Caret.Pos.Value.Row;



        this.PosA.Col = this.CaretUpDownCol;




        this.Line = this.Text.Line.Get(this.PosA.Row);




        bool b;


        b = this.CheckInsertCol();


        if (!b)
        {
            this.Caret.Pos.Value.Col = this.Line.Char.Count;
        }



        if (b)
        {
            this.Caret.Pos.Value.Col = this.PosA.Col;
        }


        





        this.UpdateArea();






        return true;
    }










    public bool PageDown()
    {
        this.CaretSelectValue();





        int row;


        row = this.ScrollPos.Row;


        row = row + 25;



        if (!this.CheckRowIndex(row))
        {
            row = this.Text.Line.Count - 1;
        }







        this.ScrollToRow(row);







        this.PosA.Row = row;


        this.PosA.Col = 0;




        this.MoveCaretRow();






        this.PosA.Row = this.Caret.Pos.Value.Row;



        this.PosA.Col = this.CaretUpDownCol;




        this.Line = this.Text.Line.Get(this.PosA.Row);




        bool b;


        b = this.CheckInsertCol();


        if (!b)
        {
            this.Caret.Pos.Value.Col = this.Line.Char.Count;
        }



        if (b)
        {
            this.Caret.Pos.Value.Col = this.PosA.Col;
        }







        this.UpdateArea();







        return true;
    }









    private bool ScrollToRow(int row)
    {
        this.ScrollPos.Row = row;




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






    public bool InsertLine()
    {
        Pos pos;


        pos = this.Caret.Pos.Value;




        this.PosA.Row = pos.Row + 1;


        this.PosA.Col = 0;






        bool b;


        b = this.CheckRowIndex(this.PosA.Row);
        



        if (b)
        {
            this.InsertNewLine();
        }
        



        if (!b)
        {
            this.AddNewLine();
        }








        this.PosA = pos;




        this.PosB.Row = pos.Row + 1;


        this.PosB.Col = 0;





        int k;


        k = this.Text.Line.Get(this.PosA.Row).Char.Count;



        int count;
        

        count = k - this.PosA.Col;



        this.Count = count;





        this.MoveRemainCharsToNewLine();






        this.MoveCaretDown();





        this.PosA.Col = 0;



        this.MoveCaretCol();






        this.CaretUpDownCol = this.Caret.Pos.Value.Col;








        this.ExecuteClass();







        this.UpdateArea();





        return true;
    }







    private bool AddNewLine()
    {
        Line line;


        line = new Line();


        line.Init();





        this.Text.Line.Add(line);
        


        

        return true;
    }
    





    private bool InsertNewLine()
    {
        int index;


        index = this.PosA.Row;
        


        

        Line line;


        line = new Line();


        line.Init();




        this.Text.Line.Insert(index, line);





        return true;
    }










    public bool InsertText(Text text)
    {
        int rowCount;


        rowCount = text.Line.Count;



        bool b;


        b = (rowCount == 1);



        if (b)
        {
            Line line;


            line = text.Line.Get(0);



            int charCount;


            charCount = line.Char.Count;



            int selectRowCount;


            selectRowCount = this.Select.End.Value.Row - this.Select.Start.Value.Row + 1;



            if (rowCount < selectRowCount)
            {
                int u;

                u = selectRowCount - rowCount;


                
            }
        }






        return true;
    }










    public bool InsertChar(char oc)
    {
        this.PosA = this.Caret.Pos.Value;
        




        this.OneChars[0] = oc;





        this.Chars = this.OneChars;




        this.CharRange.Start = 0;


        this.CharRange.End = this.CharRange.Start + this.Chars.Length;





        this.Line = this.Text.Line.Get(this.PosA.Row);
        




        bool b;
        

        b = this.CheckColIndex(this.Line, this.PosA.Col);
        
        


        if (b)
        {
            this.InsertNewChars();
        }
        



        if (!b)
        {
            this.AddNewChars();
        }
        






        int k;


        k = this.RangeInfra.Count(this.CharRange);




        this.PosA.Row = 0;


        this.PosA.Col = this.Caret.Pos.Value.Col + k;





        this.MoveCaretCol();






        this.CaretUpDownCol = this.Caret.Pos.Value.Col;







        this.ExecuteClass();







        this.UpdateArea();






        return true;
    }
    





    private bool InsertNewChars()
    {
        int index;


        index = this.PosA.Col;





        this.Line.Char.InsertRange(index, this.Chars, this.CharRange);






        return true;
    }






    private bool AddNewChars()
    {
        this.Line.Char.AddRange(this.Chars, this.CharRange);





        return true;
    }







    public bool Backspace()
    {
        Pos pos;


        pos = this.Caret.Pos.Value;
        



        bool b;
        

        b = (pos.Col < 1);






        if (b)
        {
            if (pos.Row < 1)
            {
                return true;
            }



            
            this.PosA = pos;



            this.PosB.Row = pos.Row - 1;


            this.PosB.Col = 0;




            Line u;

            u = this.Text.Line.Get(this.PosB.Row);



            int k;


            k = u.Char.Count;





            Line line;

            line = this.Text.Line.Get(this.PosA.Row);



            this.Count = line.Char.Count;



            this.AddLineChars();




            

            this.Count = 1;



            this.RemoveLinesRange();






            this.PosA.Row = this.PosB.Row;


            this.PosA.Col = k;






            this.MoveCaretRow();




            this.MoveCaretCol();





            this.CaretUpDownCol = this.Caret.Pos.Value.Col;
        }

        




        if (!b)
        {
            this.PosA.Row = pos.Row;


            this.PosA.Col = pos.Col - 1;





            this.RemoveChar();






            this.MoveCaretLeft();





            this.CaretUpDownCol = this.Caret.Pos.Value.Col;
        }







        this.ExecuteClass();








        this.UpdateArea();





        return true;
    }






    private bool RemoveChar()
    {
        Line line;


        line = this.Text.Line.Get(this.PosA.Row);



        line.Char.Remove(this.PosA.Col);



        return true;
    }

    

  



    public bool InsertIndent()
    {
        this.PosA = this.Caret.Pos.Value;




        int remainWidth;


        remainWidth = this.IndentRemainWidth();




        this.Chars = this.IndentSpaces;




        this.CharRange.Start = 0;


        this.CharRange.End = this.CharRange.Start + remainWidth;



        

        this.Line = this.Text.Line.Get(this.PosA.Row);
        




        bool b;
        

        b = this.CheckColIndex(this.Line, this.PosA.Col);
        
        


        if (b)
        {
            this.InsertNewChars();
        }
        



        if (!b)
        {
            this.AddNewChars();
        }
        






        int k;


        k = this.RangeInfra.Count(this.CharRange);




        this.PosA.Row = 0;


        this.PosA.Col = this.Caret.Pos.Value.Col + k;





        this.MoveCaretCol();






        this.CaretUpDownCol = this.Caret.Pos.Value.Col;







        this.ExecuteClass();







        this.UpdateArea();






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






    private bool AddLineChars()
    {
        Line dest;

        dest = this.Text.Line.Get(this.PosB.Row);




        Line source;

        source = this.Text.Line.Get(this.PosA.Row);




        int sourceIndex;

        sourceIndex = this.PosA.Col;




        int count;

        count = this.Count;





        this.AddCharsToLine(dest, source, sourceIndex, count);



        return true;
    }





    private bool RemoveLinesRange()
    {
        Range range;


        range = new Range();


        range.Start = this.PosA.Row;


        range.End = range.Start + this.Count;



        this.Text.Line.RemoveRange(range);



        return true;
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









    private bool MoveRemainCharsToNewLine()
    {
        Line dest;

        dest = this.Text.Line.Get(this.PosB.Row);




        Line source;

        source = this.Text.Line.Get(this.PosA.Row);




        int sourceIndex;

        sourceIndex = this.PosA.Col;




        int count;

        count = this.Count;





        this.AddCharsToLine(dest, source, sourceIndex, count);





        Range range;

        range = new Range();


        range.Start = sourceIndex;


        range.End = sourceIndex + count;
        

        
        source.Char.RemoveRange(range);
        



        return true;
    }







    private bool AddCharsToLine(Line dest, Line source, int sourceIndex, int count)
    {
        Chars destChars;

        destChars = dest.Char;



        Chars sourceChars;

        sourceChars = source.Char;




        int i;


        i = 0;


        while (i < count)
        {
            char o;
            
            o = sourceChars.Get(sourceIndex + i);



            destChars.Add(o);



            i = i + 1;
        }




        return true;
    }








    private bool ExecuteClassNameTraverse()
    {
        ListIter iter;


        iter = this.Class.Result.Node.Tree.Iter();


        iter.Next();




        Tree tree;


        tree = (Tree)iter.Value;




        Node root;

        root = tree.Root;



        if (root == null)
        {
            return true;
        }




        NodeClass nodeClass;

        nodeClass = (NodeClass)root;





        this.ClassNameTraverse.ExecuteClass(nodeClass);




        return true;
    }








    private bool UpdateArea()
    {

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






        
        
        this.CaretVideoOps();
        

        




        return true;
    }





    private Code Code { get; set; }





    private bool SetCode()
    {
        CodeList codes;


        codes = this.Class.Result.Token.Code;





        int u;

        u = codes.Count;



        if (u < 1)
        {
            return true;
        }




        this.Code = (Code)codes.Get(0);



        return true;
    }







    private bool SetTokenListType()
    {
        int count;


        count = this.Code.Token.Count;



        this.TokenListType = new TokenType[count];




        this.SetTokenTokenListType();



        
        this.SetNodeTokensTypes();




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




        TokenType type;


        type = this.TokenType.Default;




        if (!b)
        {
            b = this.IsString(ref token.Range);


            if (b)
            {
                type = this.TokenType.String;
            }
        }


        

        if (!b)
        {
            b = this.IsKeyword(ref token.Range);


            if (b)
            {
                type = this.TokenType.Keyword;
            }
        }




        this.SetTokenType(index, type);




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




        DrawRect rect;

        rect = this.Infra.CreateRect(this.Infra.CreatePos(left, up), this.Infra.CreateSize(width, height));





        this.DrawOp.Rect(rect, this.SelectBrush);




        return true;
    }










    private bool DrawCode()
    {
        TokenList tokens;


        tokens = this.Code.Token;





        CommentList comments;


        comments = this.Code.Comment;





        this.DrawTokenList(tokens);




        this.DrawCommentList(comments);





        return true;
    }




    private bool DrawTokenList(TokenList tokens)
    {
        int count;


        count = tokens.Count;




        Token token;




        int i;

        i = 0;



        while (i < count)
        {
            token = tokens.Get(i);


            this.DrawToken(i, ref token);



            i = i + 1;
        }



        return true;
    }




    private bool DrawToken(int index, ref Token token)
    {
        TokenType type;

        type = this.GetTokenType(index);






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






    private bool SetNodeTokensTypes()
    {
        this.ExecuteClassNameTraverse();



        return true;
    }









    private TokenType GetTokenType(int index)
    {
        return this.TokenListType[index];
    }







    internal bool SetTokenType(int index, TokenType type)
    {
        this.TokenListType[index] = type;


        return true;
    }






    private bool DrawText(ref TextRange range, ref DrawColor color)
    {
        int row;


        row = range.Row;





        int col;
        
        
        col = range.Range.Start;






        Line line;


        line = this.Text.Line.Get(row);




        char[] data;


        data = line.Char.Data;






        int ka;


        ka = row - this.ScrollPos.Row;





        int kb;


        kb = col - this.ScrollPos.Col;






        int left;


        left = this.DrawWidth(kb);





        int up;


        up = this.DrawHeight(ka);



        up = up - 1;

        



        DrawPos pos;

        pos = this.Infra.CreatePos(left, up);



        DrawRect destRect;

        destRect = this.Infra.CreateRect(pos, this.DrawSize);





        DrawCharSpan charSpan;


        charSpan = new DrawCharSpan();


        charSpan.Init();



        charSpan.Array = data;


        charSpan.Range = range.Range;




        this.DrawOp.Text(charSpan, this.Font, color, destRect);





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
        Keywords keywords;

        keywords = Keywords.Instance;



        return this.StringListContain(keywords.All, ref range);
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









    private bool CaretVideoOps()
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





        DrawRect rect;



        rect = this.Infra.CreateRect(this.Infra.CreatePos(left, up), this.Infra.CreateSize(width, height));





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









    private bool InitTextColor()
    {
        this.CommentTextColor = this.Infra.CreateColor(0xff, 0x00, 0x80, 0x00);




        return true;
    }







    private bool InitCaretBrush()
    {
        this.CaretBrush = this.Infra.CreateColorBrush(this.Infra.CreateColor(0xff, 0, 0, 0));




        return true;
    }







    private bool InitSelectBrush()
    {
        this.SelectBrush = this.Infra.CreateColorBrush(this.Infra.CreateColor(0xff, 0xad, 0xd6, 0xff));




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
        this.CharWidth = 8;




        return true;
    }
}