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




        this.Default = this.AddType(this.CreateColor(0xff, 0, 0, 0));


        this.Keyword = this.AddType(this.CreateColor(0xff, 0, 0, 0xff));


        this.String = this.AddType(this.CreateColor(0xff, 0xa3, 0x15, 0x15));


        this.ClassName = this.AddType(this.CreateColor(0xff, 0x26, 0x7f, 0x99));




        return true;
    }






    public TokenType Default { get; private set; }




    public TokenType Keyword { get; private set; }




    public TokenType String { get; private set; }




    public TokenType ClassName { get; private set; }








    private ulong Count { get; set; }





    private DrawColor CreateColor(byte alpha, byte red, byte green, byte blue)
    {
        DrawColor color;

        color = new DrawColor();

        color.Init();

        color.Alpha = alpha;

        color.Red = red;

        color.Green = green;

        color.Blue = blue;


        return color;
    }




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