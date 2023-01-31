namespace Create.View;






class ClassHeadView : ViewGrid
{
    public ClassView ClassView { get; set; }



    public override bool Init()
    {
        base.Init();




        this.Size.Width = this.ClassView.LeftColWidth;



        this.Size.Height = 70;





        ViewGridRow nameRow;


        nameRow = new ViewGridRow();


        nameRow.Init();


        nameRow.Height = this.NameRowHeight;





        this.BaseRowHeight = this.Size.Height - this.NameRowHeight;




        ViewGridRow baseRow;


        baseRow = new ViewGridRow();


        baseRow.Init();


        baseRow.Height = this.BaseRowHeight;

        



        ViewGridCol leftCol;

        leftCol = new ViewGridCol();

        leftCol.Init();

        leftCol.Width = this.LeftColWidth;




        this.RightColWidth = this.Size.Width - this.LeftColWidth;




        ViewGridCol rightCol;

        rightCol = new ViewGridCol();

        rightCol.Init();

        rightCol.Width = this.RightColWidth;




        this.Row.Add(nameRow);


        this.Row.Add(baseRow);


        this.Col.Add(leftCol);


        this.Col.Add(rightCol);





        this.Dest.Size.Width = this.Size.Width;


        this.Dest.Size.Height = this.Size.Height;






        
        this.NameText = new ViewText();


        this.NameText.Init();



        this.SetTransparentBack(this.NameText);

        



        Font font;

        font = this.NameText.Font;


        font.Size = 24;


        font.Style.Bold = true;




        ViewGridChild nameTextChild;

        nameTextChild = new ViewGridChild();

        nameTextChild.Init();



        this.GridRangeOne(nameTextChild.Range, 0, 1);
        

        nameTextChild.View = this.NameText;






        this.BaseText = new ViewText();


        this.BaseText.Init();



        this.SetTransparentBack(this.BaseText);

;

        font = this.BaseText.Font;


        font.Size = 18;




        ViewGridChild baseTextChild;

        baseTextChild = new ViewGridChild();

        baseTextChild.Init();



        this.GridRangeOne(baseTextChild.Range, 1, 1);
        

        baseTextChild.View = this.BaseText;
        
        



        this.Child.Add(nameTextChild);


        this.Child.Add(baseTextChild);



        return true;
    }




    private bool SetTransparentBack(ViewView view)
    {        
        DrawConstant constant;

        constant = DrawConstant.This;




        DrawColorBrush brush;

        brush = (DrawColorBrush)view.Back;



        brush.Color = constant.TransparentColor;



        return true;
    }




    private bool GridRangeOne(ViewGridRange range, int row, int col)
    {
        range.Start.Row = row;

        range.Start.Col = col;



        range.End.Row = range.Start.Row + 1;


        range.End.Col = range.Start.Col + 1;


        return true;
    }





    public CheckClass Class
    {
        get
        {
            return this.ClassData;
        } 
        set
        {
            this.ClassData = value;


            this.SetClassText();
        }
    }



    private CheckClass ClassData { get; set; }

    


    private bool SetClassText()
    {        
        this.SetTextValueString(this.NameText.Value, this.Class.Name);
        



        CheckClass baseClass;

        baseClass = this.Class.Base;




        string s;


        s = null;



        bool b;
        
        b = (baseClass == null);


        if (b)
        {
            s = "";
        }


        if (!b)
        {
            s = baseClass.Name;
        }


        this.SetTextValueString(this.BaseText.Value, s);



        return true;
    }




    private bool SetTextValueString(ViewTextValue a, string s)
    {
        RangeInfra infra;

        infra = RangeInfra.This;



        a.Span.String = s;


        a.Span.Range = infra.Range(0, s.Length);


        return true;
    }




    private ViewText NameText { get; set; }





    private ViewText BaseText { get; set; }






    private int NameRowHeight
    {
        get
        {
            return 40;
        }
        set
        {
        }
    }



    private int BaseRowHeight { get; set; }




    private int LeftColWidth
    {
        get
        {
            return 100;
        }
        set
        {
        }
    }



    private int RightColWidth { get; set; }
}