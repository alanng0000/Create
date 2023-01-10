namespace Create.View;





public class Edit : ViewView
{
    public Frame Frame { get; set; }





    private Text Text { get; set; }





    private TextInfra TextInfra { get; set; }





    private RangeInfra RangeInfra { get; set; }






    private ClassClass Clase { get; set; }





    private ClassNameTraverse ClassNameTraverse { get; set; }





    private TokenType[] TokensTypes { get; set; }





    internal TokenTypes TokenTypes { get; set; }





    private Font Font { get; set; }



    private int CharWidth { get; set; }



    private int CharHeight { get; set; }



    private int LineHeight { get; set; }




    

    private Size VisibleSize;





    private Pos ScrollPos;





    private TextFormatFlags TextFormatFlags { get; set; }



    

    private DrawBrush CaretBrush { get; set; }





    private DrawBrush SelectBrush { get; set; }






    private DrawColor CommentTextColor;






    private Graphics Graphics { get; set; }





    private DrawRectangle ClipRect;





    private DrawRectangle DrawRect;






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






    public override bool Init()
    {
        base.Init();

        



        this.Size.Width = this.Frame.Size.Width;



        this.Size.Height = this.Frame.Size.Height;







        this.PosA = new Pos();



        this.PosA.Init();




        this.PosB = new Pos();



        this.PosB.Init();






        this.OneChars = new char[1];




        this.CharRange = new Range();

        




        this.TokenTypes = TokenTypes.This;





        this.InitText();




        this.InitTextInfra();




        this.InitRangeInfra();




        this.InitClase();




        this.InitClassNameTraverse();




        this.InitIndentSpaces();






        this.InitSelect();





        this.InitCaret();





        this.InitTextFormatFlags();





        this.InitFont();





        this.InitCharSize();




        this.InitTextColors();




        this.InitCaretBrush();




        this.InitSelectBrush();





        this.InitDrawRect();





        this.LineHeight = 19;





        this.InitVisibleSize();





        





        return true;
    }








    private bool InitTextFormatFlags()
    {
        this.TextFormatFlags = 
        
        TextFormatFlags.Left | 
        TextFormatFlags.Top | 
        TextFormatFlags.NoPadding |
        TextFormatFlags.NoPrefix;


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






    private bool InitClase()
    {
        this.Clase = new ClassClass();



        this.Clase.Init();





        Task task;


        task = new Task();


        task.Init();




        task.Kind = this.Clase.TaskKinds.Node;



        task.Node = "Class";





        Source source;


        source = new Source();


        source.Index = 0;


        source.Name = "Source1";


        source.Path = "Source1";


        source.Text = this.Text;






        SourceList sources;


        sources = new SourceList();


        sources.Init();




        sources.Add(source);






        this.Clase.Task = task;



        this.Clase.Sources = sources;






        this.Compile();





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






    private bool InitVisibleSize()
    {
        int videoWidth;


        videoWidth = this.Size.Width;




        int videoHeight;


        videoHeight = this.Size.Height;





        int k;





        k = this.VisibleCount(videoWidth, this.CharWidth);
 



        this.VisibleSize.Width = k;





        k = this.VisibleCount(videoHeight, this.LineHeight);
 



        this.VisibleSize.Height = k;





        return true;
    }




    private int VisibleCount(int totalCount, int unitCount)
    {
        int t;


        t = totalCount / unitCount;



        int o;


        o = t * unitCount;




        int k;

        k = t;



        if (o < totalCount)
        {
            k = k + 1;
        }




        int ret;


        ret = k;


        return ret;
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



            this.Line = this.Text.Lines.Get(this.PosA.Row);



            this.PosA.Col = this.Line.Char.Count;





            this.MoveCaretCol();





            this.CaretUpDownCol = this.Caret.Pos.Value.Col;
        }






        if (b)
        {
            this.MoveCaretDown();





            this.PosA.Row = this.Caret.Pos.Value.Row;



            this.PosA.Col = this.CaretUpDownCol;




            this.Line = this.Text.Lines.Get(this.PosA.Row);




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



        this.Line = this.Text.Lines.Get(this.PosA.Row);




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



        this.Line = this.Text.Lines.Get(this.PosA.Row);



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




            this.Line = this.Text.Lines.Get(this.PosA.Row);



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




            this.Line = this.Text.Lines.Get(this.PosA.Row);




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



            this.Line = this.Text.Lines.Get(this.PosA.Row);



            this.PosA.Col = this.Line.Char.Count;





            this.MoveCaretCol();





            this.CaretUpDownCol = this.Caret.Pos.Value.Col;
        }






        if (b)
        {
            this.MoveCaretDown();





            this.PosA.Row = this.Caret.Pos.Value.Row;



            this.PosA.Col = this.CaretUpDownCol;




            this.Line = this.Text.Lines.Get(this.PosA.Row);




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

        line = this.Text.Lines.Get(this.Caret.Pos.Value.Row);





        if (!(this.Caret.Pos.Value.Col < line.Chars.Count))
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




        this.Line = this.Text.Lines.Get(this.PosA.Row);




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
            row = this.Text.Lines.Count - 1;
        }







        this.ScrollToRow(row);







        this.PosA.Row = row;


        this.PosA.Col = 0;




        this.MoveCaretRow();






        this.PosA.Row = this.Caret.Pos.Value.Row;



        this.PosA.Col = this.CaretUpDownCol;




        this.Line = this.Text.Lines.Get(this.PosA.Row);




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
        if (!(row < this.Text.Lines.Count))
        {
            return false;
        }


        return true;
    }





    private bool CheckColIndex(Line line, int col)
    {
        if (!(col < line.Chars.Count))
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


        k = this.Text.Lines.Get(this.PosA.Row).Chars.Count;



        int count;
        

        count = k - this.PosA.Col;



        this.Count = count;





        this.MoveRemainCharsToNewLine();






        this.MoveCaretDown();





        this.PosA.Col = 0;



        this.MoveCaretCol();






        this.CaretUpDownCol = this.Caret.Pos.Value.Col;








        this.Compile();







        this.UpdateArea();





        return true;
    }







    private bool AddNewLine()
    {
        Line line;


        line = new Line();


        line.Init();





        this.Text.Lines.Add(line);
        


        

        return true;
    }
    





    private bool InsertNewLine()
    {
        int index;


        index = this.PosA.Row;
        


        

        Line line;


        line = new Line();


        line.Init();




        this.Text.Lines.Insert(index, line);





        return true;
    }










    public bool InsertText(Text text)
    {
        int rowCount;


        rowCount = text.Lines.Count;



        bool b;


        b = (rowCount == 1);



        if (b)
        {
            Line line;


            line = text.Lines.Get(0);



            int charCount;


            charCount = line.Chars.Count;



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





        this.Line = this.Text.Lines.Get(this.PosA.Row);
        




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







        this.Compile();







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

            u = this.Text.Lines.Get(this.PosB.Row);



            int k;


            k = u.Chars.Count;





            Line line;

            line = this.Text.Lines.Get(this.PosA.Row);



            this.Count = line.Chars.Count;



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







        this.Compile();








        this.UpdateArea();





        return true;
    }






    private bool RemoveChar()
    {
        Line line;


        line = this.Text.Lines.Get(this.PosA.Row);



        line.Chars.Remove(this.PosA.Col);



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



        

        this.Line = this.Text.Lines.Get(this.PosA.Row);
        




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







        this.Compile();







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

        dest = this.Text.Lines.Get(this.PosB.Row);




        Line source;

        source = this.Text.Lines.Get(this.PosA.Row);




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



        this.Text.Lines.RemoveRange(range);



        return true;
    }





    private bool Compile()
    {
        this.Clase.ExecuteCompile();



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

        dest = this.Text.Lines.Get(this.PosB.Row);




        Line source;

        source = this.Text.Lines.Get(this.PosA.Row);




        int sourceIndex;

        sourceIndex = this.PosA.Col;




        int count;

        count = this.Count;





        this.AddCharsToLine(dest, source, sourceIndex, count);





        Range range;

        range = new Range();


        range.Start = sourceIndex;


        range.End = sourceIndex + count;
        

        
        source.Chars.RemoveRange(range);
        



        return true;
    }







    private bool AddCharsToLine(Line dest, Line source, int sourceIndex, int count)
    {
        Chars destChars;

        destChars = dest.Chars;



        Chars sourceChars;

        sourceChars = source.Chars;




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


        iter = this.Clase.Result.Node.Trees.Iter();


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
        this.Update(this.DrawRect);





        return true;
    }







    protected override bool Ops(Graphics graphics, DrawRectangle clipRect)
    {
        this.Graphics = graphics;



        this.ClipRect = clipRect;




        this.VideoOps();



        return true;
    }








    private bool VideoOps()
    {
        this.SetCode();





        this.SetTokensTypesArray();





        this.SetTokensTypes();






        this.SelectVideoOps();






        this.CodeVideoOps();






        
        
        this.CaretVideoOps();
        

        




        return true;
    }





    private Code Code { get; set; }





    private bool SetCode()
    {
        CodeList codes;


        codes = this.Clase.Result.Token.Codes;





        int u;

        u = codes.Count;



        if (u < 1)
        {
            return true;
        }




        this.Code = codes[0];



        return true;
    }





    private bool SetTokensTypesArray()
    {
        int count;


        count = this.Code.Tokens.Count;



        this.TokensTypes = new TokenType[count];



        return true;
    }






    private bool SetTokensTypes()
    {
        this.SetTokenTokensTypes();



        
        this.SetNodeTokensTypes();




        return true;
    }






    private bool SetTokenTokensTypes()
    {
        TokenList tokens;


        tokens = this.Code.Tokens;





        Token token;





        int count;


        count = tokens.Count;





        int i;

        i = 0;


        while (i < count)
        {
            token = tokens[i];



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


        type = this.TokenTypes.Default;




        if (!b)
        {
            b = this.IsString(ref token.Range);


            if (b)
            {
                type = this.TokenTypes.String;
            }
        }


        

        if (!b)
        {
            b = this.IsKeyword(ref token.Range);


            if (b)
            {
                type = this.TokenTypes.Keyword;
            }
        }




        this.SetTokenType(index, type);




        return true;
    }






    private bool SelectVideoOps()
    {
        Pos start;

        start = this.Select.Start.Value;




        Pos end;

        end = this.Select.End.Value;





        if (start.Row == end.Row)
        {
            int r;


            r = end.Col - start.Col;



            this.SelectOneRectVideoOps(start, r);




            return true;
        }









        Line firstLine;


        firstLine = this.Text.Lines.Get(start.Row);



        int firstCount;


        firstCount = firstLine.Chars.Count - start.Col;


        firstCount = firstCount + 1;




        this.SelectOneRectVideoOps(start, firstCount);





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



            line = this.Text.Lines.Get(row);



            u = line.Chars.Count - pos.Col;


            u = u + 1;



            this.SelectOneRectVideoOps(pos, u);



    
            i = i + 1;
        }







        int lastCount;


        lastCount = end.Col;



        Pos o;

        o = new Pos();

        o.Init();

        o.Row = end.Row;

        o.Col = 0;



        this.SelectOneRectVideoOps(o, lastCount);





        return true;
    }









    private bool SelectOneRectVideoOps(Pos pos, int count)
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


        left = this.VideoWidth(col);
        



        int up;


        up = this.VideoHeight(row);





        int width;


        width = this.VideoWidth(w);




        int height;


        height = this.VideoHeight(h);






        DrawRectangle rect;



        rect = new DrawRectangle(new DrawPoint(left, up), new DrawSize(width, height));





        this.Graphics.FillRectangle(this.SelectBrush, rect);




        return true;
    }







    private bool CodeVideoOps()
    {
        TokenList tokens;


        tokens = this.Code.Tokens;





        CommentList comments;


        comments = this.Code.Comments;





        this.TokensVideoOps(tokens);




        this.CommentsVideoOps(comments);





        return true;
    }




    private bool TokensVideoOps(TokenList tokens)
    {
        int count;


        count = tokens.Count;




        Token token;




        int i;

        i = 0;



        while (i < count)
        {
            token = tokens[i];


            this.TokenVideoOps(i, ref token);



            i = i + 1;
        }



        return true;
    }




    private bool TokenVideoOps(int index, ref Token token)
    {
        TokenType type;

        type = this.GetTokenType(index);






        TextRange range;


        range = token.Range;



        this.TextVideoOps(ref range, ref type.Color);




        return true;
    }






    private bool CommentsVideoOps(CommentList comments)
    {
        int count;


        count = comments.Count;




        Comment comment;




        int i;

        i = 0;



        while (i < count)
        {
            comment = comments[i];


            this.CommentVideoOps(ref comment);



            i = i + 1;
        }



        return true;
    }






    private bool CommentVideoOps(ref Comment comment)
    {
        TextRange range;


        range = comment.Range;



        this.TextVideoOps(ref range, ref this.CommentTextColor);




        return true;
    }






    private bool SetNodeTokensTypes()
    {
        this.ExecuteClassNameTraverse();



        return true;
    }









    private TokenType GetTokenType(int index)
    {
        return this.TokensTypes[index];
    }







    internal bool SetTokenType(int index, TokenType type)
    {
        this.TokensTypes[index] = type;


        return true;
    }






    private bool TextVideoOps(ref TextRange range, ref DrawColor color)
    {
        int row;


        row = range.Pos.Row;





        int col;
        
        
        col = range.Pos.Col;





        int count;


        count = range.Count;






        Line line;


        line = this.Text.Lines.Get(row);




        char[] data;


        data = line.Chars.Data;






        int ka;


        ka = row - this.ScrollPos.Row;





        int kb;


        kb = col - this.ScrollPos.Col;






        int left;


        left = this.VideoWidth(kb);





        int up;


        up = this.VideoHeight(ka);



        up = up - 1;



        



        DrawPoint pos;


        pos = new DrawPoint(left, up);





        


        ReadOnlySpanChar t;


        t = new ReadOnlySpanChar(data, col, count);




        TextRenderer.DrawText(this.Graphics, t, this.Font, pos, color, this.TextFormatFlags);





        return true;
    }






    private bool IsString(ref TextRange range)
    {
        char oc;
        

        oc = this.TextInfra.Char(range.Pos);



        bool b;
        
        b = (oc == '"');

        
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



            if (this.TextInfra.Equal(range, s))
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


        left = this.VideoWidth(col);
        



        int up;


        up = this.VideoHeight(row);




        int width;


        width = 2;




        int height;


        height = this.LineHeight;





        DrawRectangle rect;



        rect = new DrawRectangle(new DrawPoint(left, up), new DrawSize(width, height));





        this.Graphics.FillRectangle(this.CaretBrush, rect);




        return true;
    }





    private int VideoWidth(int col)
    {
        return this.CharWidth * col;
    }





    private int VideoHeight(int row)
    {
        return this.LineHeight * row;
    }









    private bool InitTextColors()
    {
        this.CommentTextColor = DrawColor.FromArgb(0xff, 0x00, 0x80, 0x00);




        return true;
    }







    private bool InitCaretBrush()
    {
        this.CaretBrush = new DrawSolidBrush(DrawColor.FromArgb(0xff, 0, 0, 0));




        return true;
    }







    private bool InitSelectBrush()
    {
        this.SelectBrush = new DrawSolidBrush(DrawColor.FromArgb(0xff, 0xad, 0xd6, 0xff));




        return true;
    }







    private bool InitDrawRect()
    {
        this.DrawRect = new DrawRectangle(new DrawPoint(0, 0), new DrawSize(this.Size.Width, this.Size.Height));


        return true;
    }





    private bool InitFont()
    {
        FontFamily fontFamily;


        fontFamily = new FontFamily("Cascadia Mono");


        
        this.Font = new Font(fontFamily, 14, FontStyle.Regular, GraphicsUnit.Pixel);



        return true;
    }






    private bool InitCharSize()
    {
        Graphics g;


        g = this.CreateGraphics();

        



        DrawSize d;
        
        d = TextRenderer.MeasureText(g, "M", this.Font, new DrawSize(100, 100), this.TextFormatFlags);


        


        this.CharWidth = d.Width;

        this.CharHeight = d.Height;



        //global::System.Console.Write("Develop.View:Edit.InitCharSize(), CharWidth" + ": " + this.CharWidth + ", " + "CharHeight" + ": " + this.CharHeight + "\n");




        g.Dispose();



        return true;
    }
}