namespace Create.View;






class TokenTypeList : Object
{
    public static TokenTypeList This { get; } = CreateGlobal();




    private static TokenTypeList CreateGlobal()
    {
        TokenTypeList global;


        global = new TokenTypeList();


        global.Init();


        return global;
    }





    public override bool Init()
    {
        base.Init();



        Infra infra;

        infra = Infra.This;



        this.Default = this.AddType(infra.CreateColor(0xff, 0, 0, 0));


        this.Keyword = this.AddType(infra.CreateColor(0xff, 0, 0, 0xff));


        this.Int = this.AddType(infra.CreateColor(0xff, 0x80, 0x00, 0x00));


        this.String = this.AddType(infra.CreateColor(0xff, 0x80, 0x00, 0x00));


        this.ClassName = this.AddType(infra.CreateColor(0xff, 0x00, 0x80, 0x80));




        return true;
    }






    public TokenType Default { get; private set; }




    public TokenType Keyword { get; private set; }




    public TokenType Int { get; private set; }




    public TokenType String { get; private set; }




    public TokenType ClassName { get; private set; }








    private ulong Count { get; set; }









    private TokenType AddType(DrawColor color)
    {
        TokenType type;



        type = new TokenType();



        type.Init();



        type.Intent = this.Count;



        type.Color = color;




        this.Count = this.Count + 1;






        TokenType ret;


        ret = type;


        return ret;
    }
}