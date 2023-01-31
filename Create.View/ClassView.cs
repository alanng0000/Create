namespace Create.View;





class ClassView : ViewGrid
{
    public Frame Frame { get; set; }




    public override bool Init()
    {
        base.Init();





        this.Size.Width = this.Frame.Size.Width;


        this.Size.Height = this.Frame.Size.Height;




        ViewGridRow row;

        row = new ViewGridRow();

        row.Init();

        row.Height = this.Size.Height;




        


        ViewGridCol colA;

        colA = new ViewGridCol();

        colA.Init();

        colA.Width = this.LeftColWidth;



        int colBWidth;


        colBWidth = this.Size.Width - this.LeftColWidth;



        ViewGridCol colB;

        colB = new ViewGridCol();

        colB.Init();

        colB.Width = colBWidth;




        this.Row.Add(row);



        this.Col.Add(colA);

        this.Col.Add(colB);




        return true;
    }




    private int LeftColWidth
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