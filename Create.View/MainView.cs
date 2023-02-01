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






        this.CompIndex = 0;





        return true;
    }




    private bool InitChild()
    {
        int count;

        count = this.CompArray.Count;


        int i;

        i = 0;


        while (i < count)
        {
            Comp comp;

            comp = this.Get(i);




            

            Infra infra;

            infra = Infra.This;




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