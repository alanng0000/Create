namespace Create.View;





class Grid : ViewGrid
{
    public Frame Frame { get; set; }




    public override bool Init()
    {
        base.Init();




        this.Size.Width = this.Frame.Size.Width;


        this.Size.Height = this.Frame.Size.Height;




        int rowAHeight;

        rowAHeight = this.Size.Height - this.RowBHeight;



        ViewGridRow rowA;

        rowA = new ViewGridRow();

        rowA.Init();

        rowA.Height = rowAHeight;



        ViewGridRow rowB;

        rowB = new ViewGridRow();

        rowB.Init();

        rowB.Height = this.RowBHeight;




        ViewGridCol colA;

        colA = new ViewGridCol();

        colA.Init();

        colA.Width = this.ColAWidth;



        int colBWidth;

        colBWidth = this.Size.Width - this.ColAWidth;



        ViewGridCol colB;

        colB = new ViewGridCol();

        colB.Init();

        colB.Width = colBWidth;



        
        this.Edit = new Edit();



        this.Edit.Frame = this.Frame;



        this.Edit.Init();




        ViewGridChild editChild;

        editChild = new ViewGridChild();

        editChild.Init();

        editChild.Range.Start.Row = 0;

        editChild.Range.Start.Col = 1;

        editChild.Range.End.Row = 1;

        editChild.Range.End.Col = 2;


        editChild.View = this.Edit;




        this.Row.Add(rowA);

        this.Row.Add(rowB);


        this.Col.Add(colA);

        this.Col.Add(colB);



        this.Child.Add(editChild);



        return true;
    }





    public Edit Edit { get; set; }





    private int RowBHeight
    {
        get
        {
            return 240;
        }
        set
        {
        }
    }


    private int ColAWidth
    {
        get
        {
            return 400;
        }
        set
        {
        }
    }
}