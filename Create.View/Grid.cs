namespace Create.View;





public class Grid : ViewGrid
{
    public Frame Frame { get; set; }




    public override bool Init()
    {
        base.Init();




        this.Size.Width = this.Frame.Size.Width;


        this.Size.Height = this.Frame.Size.Height;



        this.Dest.Size.Width = this.Size.Width;


        this.Dest.Size.Height = this.Size.Height;





        ViewGridRow row;

        row = new ViewGridRow();

        row.Init();

        row.Height = this.Size.Height;





        ViewGridCol col;

        col = new ViewGridCol();

        col.Init();

        col.Width = this.Size.Width;





        
        
        this.Edit = new Edit();



        this.Edit.Frame = this.Frame;



        this.Edit.Init();





        this.ClassView = new ClassView();



        this.ClassView.Frame = this.Frame;



        this.ClassView.Init();








        Infra infra;

        infra = Infra.This;



        ViewGridChild editChild;

        editChild = new ViewGridChild();

        editChild.Init();


        infra.GridRangeOne(editChild.Range, 0, 0);


        editChild.View = this.Edit;






        ViewGridChild classViewChild;

        classViewChild = new ViewGridChild();

        classViewChild.Init();


        infra.GridRangeOne(classViewChild.Range, 0, 0);


        classViewChild.View = this.ClassView;




        this.Row.Add(row);


        this.Col.Add(col);



        this.Child.Add(editChild);


        this.Child.Add(classViewChild);





        this.ViewArray = new Array();


        this.ViewArray.Count = 2;


        this.ViewArray.Init();




        this.ViewArray.Set(0, this.Edit);




        this.ViewArray.Set(1, this.ClassView);





        this.Edit.Visible = true;



        this.ClassView.Visible = false;




        return true;
    }




    public ViewView Get(int index)
    {
        return (ViewView)this.ViewArray.Get(index);
    }





    private bool SetViewIndex(int value)
    {
        ViewView view;

        view = this.Get(this.ViewIndexData);

        view.Visible = false;



        this.ViewIndexData = value;



        view = this.Get(this.ViewIndexData);

        view.Visible = true;



        return true;
    }






    public int ViewIndex
    {
        get
        {
            return this.ViewIndexData;
        }
        set
        {
            this.SetViewIndex(value);
        }
    }




    public int ViewCount
    {
        get
        {
            return this.ViewArray.Count;
        }
        set
        {

        } 
    }



    
    private int ViewIndexData { get; set; }





    private Array ViewArray { get; set; }





    public Edit Edit { get; set; }



    public ClassView ClassView { get; set; }
}