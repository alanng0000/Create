namespace Create.View;




public class Frame : ViewFrame
{
    public override bool Init()
    {
        this.Title = "Create";





        base.Init();




        
        this.Main = new MainView();

        this.Main.Frame = this;

        this.Main.Init();
        


        this.View = this.Main;





        return true;
    }



    public MainView Main { get; set; }
}