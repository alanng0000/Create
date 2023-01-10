namespace Develop.View;




public class Frame : ViewFrame
{
    public override bool Init()
    {
        base.Init();





        this.Edit = new Edit();



        this.Edit.Frame = this;



        this.Edit.Init();





        this.View = this.Edit;





        return true;
    }





    public Edit Edit { get; set; }
}