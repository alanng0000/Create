namespace Create.View;






class ClassHead : ViewGrid
{
    public Class ClassView { get; set; }



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





        ViewConstant constant;

        constant = ViewConstant.This;





        ViewText nameLabel;

        nameLabel = new ViewText();

        nameLabel.Init();


        this.SetTextSize(nameLabel, this.LeftColWidth, this.NameRowHeight);


        infra.SetTransparentBack(nameLabel);








        ViewText baseLabel;

        baseLabel = new ViewText();

        baseLabel.Init();


        this.SetTextSize(baseLabel, this.LeftColWidth, this.BaseRowHeight);


        infra.SetTransparentBack(baseLabel);






        
        this.NameText = new ViewText();


        this.NameText.Init();


        this.SetTextSize(this.NameText, this.RightColWidth, this.NameRowHeight);



        infra.SetTransparentBack(this.NameText);

        

        Font font;


        font = new Font();
        
        
        font.Family = constant.DefaultFont.Family;


        font.Size = 24;


        font.Style.Bold = true;



        font.Init();



        this.NameText.Font = font;






        this.BaseText = new ViewText();


        this.BaseText.Init();



        this.SetTextSize(this.BaseText, this.RightColWidth, this.BaseRowHeight);



        infra.SetTransparentBack(this.BaseText);





        font = new Font();
        
        
        font.Family = constant.DefaultFont.Family;


        font.Size = 16;


        font.Init();



        this.BaseText.Font = font;

        



        nameLabel.Font = this.NameText.Font;



        baseLabel.Font = this.BaseText.Font;




        this.SetTextValue(nameLabel, "Class:");



        this.SetTextValue(baseLabel, "Base:");





        ViewGridChild nameLabelChild;

        nameLabelChild = new ViewGridChild();

        nameLabelChild.Init();



        infra.GridRangeOne(nameLabelChild.Range, 0, 0);
        

        nameLabelChild.View = nameLabel;






        ViewGridChild baseLabelChild;

        baseLabelChild = new ViewGridChild();

        baseLabelChild.Init();



        infra.GridRangeOne(baseLabelChild.Range, 1, 0);
        

        baseLabelChild.View = baseLabel;








        ViewGridChild nameTextChild;

        nameTextChild = new ViewGridChild();

        nameTextChild.Init();



        infra.GridRangeOne(nameTextChild.Range, 0, 1);
        

        nameTextChild.View = this.NameText;






        ViewGridChild baseTextChild;

        baseTextChild = new ViewGridChild();

        baseTextChild.Init();



        infra.GridRangeOne(baseTextChild.Range, 1, 1);
        

        baseTextChild.View = this.BaseText;
        
        
        


        this.Child.Add(nameLabelChild);


        this.Child.Add(baseLabelChild);



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






    private bool SetTextSize(ViewText a, int width, int height)
    {
        a.Size.Width = width;


        a.Size.Height = height;



        a.Dest.Size.Width = a.Size.Width;


        a.Dest.Size.Height = a.Size.Height;



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