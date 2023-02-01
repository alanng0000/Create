namespace Create.View;





public class ClassView : ViewGrid
{
    public Frame Frame { get; set; }




    public override bool Init()
    {
        base.Init();





        this.Size.Width = this.Frame.Size.Width;


        this.Size.Height = this.Frame.Size.Height;



        this.Dest.Size.Width = this.Size.Width;


        this.Dest.Size.Height = this.Size.Height;




        ViewGridRow headRow;

        headRow = new ViewGridRow();

        headRow.Init();


        headRow.Height = this.HeadRowHeight;




        int h;

        h = this.Size.Height - this.HeadRowHeight;



        ViewGridRow row;

        row = new ViewGridRow();

        row.Init();

        row.Height = h;




        


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







        this.Head = new ClassHeadView();


        this.Head.ClassView = this;


        this.Head.Init();





        ViewGridChild headChild;

        headChild = new ViewGridChild();

        headChild.Init();


        Infra infra;

        infra = Infra.This;

        infra.GridRangeOne(headChild.Range, 0, 0);



        headChild.View = this.Head;






        this.Row.Add(headRow);


        this.Row.Add(row);



        this.Col.Add(colA);

        this.Col.Add(colB);



        this.Child.Add(headChild);



        return true;
    }





    private ClassHeadView Head { get; set; }





    public int HeadRowHeight
    {
        get
        {
            return 70;
        }
        set
        {
        }
    }




    public int LeftColWidth
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