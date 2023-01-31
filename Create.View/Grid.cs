namespace Create.View;





class Grid : ViewGrid
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





        ViewGridCol col;

        col = new ViewGridCol();

        col.Init();

        col.Width = this.Size.Width;





        
        
        this.Edit = new Edit();



        this.Edit.Frame = this.Frame;



        this.Edit.Init();




        ViewGridChild editChild;

        editChild = new ViewGridChild();

        editChild.Init();

        editChild.Range.Start.Row = 0;

        editChild.Range.Start.Col = 0;

        editChild.Range.End.Row = 1;

        editChild.Range.End.Col = 1;


        editChild.View = this.Edit;




        this.Row.Add(row);


        this.Col.Add(col);



        this.Child.Add(editChild);




        this.Dest.Size.Width = this.Size.Width;


        this.Dest.Size.Height = this.Size.Height;




        return true;
    }





    public Edit Edit { get; set; }
}