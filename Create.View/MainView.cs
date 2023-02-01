namespace Create.View;





public class MainView : ViewGrid
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





        this.CompArray = new Array();


        this.CompArray.Count = 2;


        this.CompArray.Init();




        this.AddComp(this.Edit);



        this.AddComp(this.ClassView);





        this.Edit.Visible = true;



        this.ClassView.Visible = false;




        return true;
    }





    private int Index { get; set; }





    private bool AddComp(Comp a)
    {
        a.Index = this.Index;



        this.CompArray.Set(a.Index, a);



        this.Index = this.Index + 1;



        return true;
    }
    




    public Comp Get(int index)
    {
        return (Comp)this.CompArray.Get(index);
    }





    private bool SetCompIndex(int value)
    {
        Comp view;

        view = this.Get(this.CompIndexData);

        view.Visible = false;



        this.CompIndexData = value;



        view = this.Get(this.CompIndexData);



        view.Set();


        view.Visible = true;



        return true;
    }






    public int CompIndex
    {
        get
        {
            return this.CompIndexData;
        }
        set
        {
            this.SetCompIndex(value);
        }
    }




    public int CompCount
    {
        get
        {
            return this.CompArray.Count;
        }
        set
        {

        } 
    }



    
    private int CompIndexData { get; set; }





    private Array CompArray { get; set; }





    public Edit Edit { get; set; }



    public ClassView ClassView { get; set; }
}