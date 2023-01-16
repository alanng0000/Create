namespace Create.View;






class ClassNameTraverse : Traverse
{
    public Edit Edit { get; set; }





    public override bool Init()
    {
        return true;
    }





    public override bool ExecuteClassName(ClassName className)
    {
        if (this.Null(className))
        {
            return true;
        }




        int index;


        index = className.Range.Start;




        TokenTypeList typeList;

        typeList = TokenTypeList.This;

        


        this.Edit.SetTokenType(index, typeList.ClassName);





        return true;
    }
}