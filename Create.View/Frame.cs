namespace Create.View;




public class Frame : ViewFrame
{
    public override bool Init()
    {
        this.Title = "Create";





        base.Init();




        
        this.Grid = new Grid();

        this.Grid.Frame = this;

        this.Grid.Init();
        

        this.Edit = this.Grid.Edit;



        this.View = this.Grid;





        return true;
    }



    public Grid Grid { get; set; }



    public Edit Edit { get; set; }
}