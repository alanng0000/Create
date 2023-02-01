namespace Create.View;




public class Frame : ViewFrame
{
    public override bool Init()
    {
        this.Title = "Create";





        base.Init();




        
        this.Grid = new MainGrid();

        this.Grid.Frame = this;

        this.Grid.Init();
        


        this.View = this.Grid;





        return true;
    }



    public MainGrid Grid { get; set; }
}