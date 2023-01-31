namespace Create.View;






class ClassHeadView : ViewGrid
{
    public CheckClass Class { get; set; }




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











        return true;
    }






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