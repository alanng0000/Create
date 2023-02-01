namespace Create.View;





public class ClassView : CompView
{
    public override bool Init()
    {
        base.Init();




        this.Grid = new ViewGrid();


        this.Grid.Init();


        this.Grid.Size.Width = this.Size.Width;


        this.Grid.Size.Height = this.Size.Height;



        this.Grid.Dest.Size.Width = this.Size.Width;


        this.Grid.Dest.Size.Height = this.Size.Height;




        ViewGridRow headRow;

        headRow = new ViewGridRow();

        headRow.Init();


        headRow.Height = this.HeadRowHeight;




        int h;

        h = this.Grid.Size.Height - this.HeadRowHeight;



        ViewGridRow row;

        row = new ViewGridRow();

        row.Init();

        row.Height = h;




        


        ViewGridCol colA;

        colA = new ViewGridCol();

        colA.Init();

        colA.Width = this.LeftColWidth;




        int colBWidth;


        colBWidth = this.Grid.Size.Width - this.LeftColWidth;



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






        this.Grid.Row.Add(headRow);


        this.Grid.Row.Add(row);



        this.Grid.Col.Add(colA);

        this.Grid.Col.Add(colB);



        this.Grid.Child.Add(headChild);




        this.Child = this.Grid;





        return true;
    }





    public override bool Set()
    {
        ClassResult result;


        result = this.Frame.Grid.Edit.Class.Result;



        




        return true;
    }





    private ViewGrid Grid { get; set; }






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