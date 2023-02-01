namespace Create.View;






class ClassHeadView : ViewGrid
{
    public ClassView ClassView { get; set; }



    public override bool Init()
    {
        base.Init();




        this.Size.Width = this.ClassView.LeftColWidth;



        this.Size.Height = this.ClassView.HeadRowHeight;





        this.Dest.Size.Width = this.Size.Width;


        this.Dest.Size.Height = this.Size.Height;




        

        Infra infra;

        infra = Infra.This;



        infra.SetTransparentBack(this);





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





        
        this.NameText = new ViewText();


        this.NameText.Init();



        infra.SetTransparentBack(this.NameText);

        



        Font font;

        font = this.NameText.Font;


        font.Size = 24;


        font.Style.Bold = true;





        ViewGridChild nameTextChild;

        nameTextChild = new ViewGridChild();

        nameTextChild.Init();



        infra.GridRangeOne(nameTextChild.Range, 0, 1);
        

        nameTextChild.View = this.NameText;






        this.BaseText = new ViewText();


        this.BaseText.Init();



        infra.SetTransparentBack(this.BaseText);

;

        font = this.BaseText.Font;


        font.Size = 18;




        ViewGridChild baseTextChild;

        baseTextChild = new ViewGridChild();

        baseTextChild.Init();



        infra.GridRangeOne(baseTextChild.Range, 1, 1);
        

        baseTextChild.View = this.BaseText;
        
        



        this.Child.Add(nameTextChild);


        this.Child.Add(baseTextChild);




        this.SetClassText();
        



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
        string nameS;

        nameS = null;


        string baseS;

        baseS = null;




        bool b;

        b = this.Null(this.Class);


        if (b)
        {
            nameS = "";

            baseS = "";
        }
        


        if (!b)
        {

            nameS = this.Class.Name;
        



            CheckClass baseClass;

            baseClass = this.Class.Base;




            bool ba;

            ba = this.Null(baseClass);



            if (ba)
            {
                baseS = "";
            }



            if (!ba)
            {
                baseS = baseClass.Name;
            }
        }



        this.SetTextValue(this.NameText, nameS);


        this.SetTextValue(this.BaseText, baseS);

        


        return true;
    }




    private bool SetTextValue(ViewText a, string s)
    {
        RangeInfra infra;

        infra = RangeInfra.This;



        a.Value.Span.String = s;


        a.Value.Span.Range = infra.Range(0, s.Length);


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