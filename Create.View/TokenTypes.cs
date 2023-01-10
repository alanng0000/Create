namespace Develop.View;






class TokenTypes : Object
{
    public static TokenTypes This { get; } = CreateGlobal();




    private static TokenTypes CreateGlobal()
    {
        TokenTypes global;


        global = new TokenTypes();


        global.Init();


        return global;
    }





    public override bool Init()
    {
        base.Init();




        this.Default = this.AddType(DrawColor.FromArgb(0xff, 0, 0, 0));


        this.Keyword = this.AddType(DrawColor.FromArgb(0xff, 0, 0, 0xff));


        this.String = this.AddType(DrawColor.FromArgb(0xff, 0xa3, 0x15, 0x15));


        this.ClassName = this.AddType(DrawColor.FromArgb(0xff, 0x26, 0x7f, 0x99));




        return true;
    }






    public TokenType Default { get; private set; }




    public TokenType Keyword { get; private set; }




    public TokenType String { get; private set; }




    public TokenType ClassName { get; private set; }








    private ulong Count { get; set; }





    private TokenType AddType(DrawColor color)
    {
        TokenType type;



        type = new TokenType();



        type.Init();



        type.Id = this.Count;



        type.Color = color;




        this.Count = this.Count + 1;






        TokenType ret;


        ret = type;


        return ret;
    }
}