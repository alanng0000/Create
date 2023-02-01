namespace Create.View;





public class Main : ViewGrid
{
    public Frame Frame { get; set; }




    public override bool Init()
    {
        base.Init();




        this.Size.Width = this.Frame.Size.Width;


        this.Size.Height = this.Frame.Size.Height;



        this.Dest.Size.Width = this.Size.Width;


        this.Dest.Size.Height = this.Size.Height;





        
        this.Edit = new Edit();




        this.ClassView = new ClassView();






        this.CompArray = new Array();


        this.CompArray.Count = 2;


        this.CompArray.Init();




        this.AddComp(this.Edit);



        this.AddComp(this.ClassView);






        ViewGridRow row;

        row = new ViewGridRow();

        row.Init();

        row.Height = this.Size.Height;





        ViewGridCol col;

        col = new ViewGridCol();

        col.Init();

        col.Width = this.Size.Width;







        this.Row.Add(row);


        this.Col.Add(col);




        this.InitChild();






        this.Comp = this.Get(0);





        return true;
    }




    private bool InitChild()
    {
        Infra infra;

        infra = Infra.This;


        int count;

        count = this.CompCount;


        int i;

        i = 0;


        while (i < count)
        {
            Comp comp;

            comp = this.Get(i);




            ViewGridChild child;

            child = new ViewGridChild();

            child.Init();


            infra.GridRangeOne(child.Range, 0, 0);


            child.View = comp;




            this.Child.Add(child);




            i = i + 1;
        }



        return true;
    }





    private int Index { get; set; }





    private bool AddComp(Comp a)
    {
        a.Index = this.Index;


        a.Frame = this.Frame;


        a.Init();


        a.Visible = false;




        this.CompArray.Set(a.Index, a);



        this.Index = this.Index + 1;



        return true;
    }
    




    public Comp Get(int index)
    {
        return (Comp)this.CompArray.Get(index);
    }





    private bool SetComp(Comp value)
    {
        Comp view;


        view = this.CompData;


        view.Visible = false;




        this.CompData = value;



        view = this.CompData;



        view.Set();


        view.Visible = true;



        return true;
    }






    public Comp Comp
    {
        get
        {
            return this.CompData;
        }
        set
        {
            this.SetComp(value);
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



    
    private Comp CompData { get; set; }





    private Array CompArray { get; set; }





    public Edit Edit { get; set; }



    public ClassView ClassView { get; set; }
}