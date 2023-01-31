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




        ViewGridCol col;

        col = new ViewGridCol();

        col.Init();

        col.Width = this.Size.Width;




        this.Row.Add(nameRow);


        this.Row.Add(baseRow);


        this.Col.Add(col);




        this.Dest.Size.Width = this.Size.Width;


        this.Dest.Size.Height = this.Size.Height;




        
        this.NameText = new ViewText();


        this.NameText.Init();



        Font font;

        font = this.NameText.Font;


        font.Size = 24;



        FontStyle fontStyle;

        fontStyle = font.Style;

        fontStyle.Bold = true;


        font.Style = fontStyle;








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
}