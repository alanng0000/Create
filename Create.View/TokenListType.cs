namespace Create.View;




class TokenListType : Object
{
    public override bool Init()
    {
        base.Init();



        this.ByteList = new ByteList();


        this.ByteList.Init();



        return true;
    }




    public int Count
    {
        get
        {
            return this.ByteList.Count;
        }
    }




    public bool SetCount(int value)
    {
        this.ByteList.SetCount(value);


        return true;
    }





    public TokenType Get(int index)
    {
        byte ob;

        ob = this.ByteList.Data[index];



        TokenTypeList typeList;

        typeList = TokenTypeList.This;



        TokenType type;
        
        type = typeList.All[ob];


        return type;
    }





    public bool Set(int index, TokenType tokenType)
    {
        InfraConvert convert;

        convert = InfraConvert.This;



        byte ob;

        ob = convert.Byte(tokenType.Intent);



        this.ByteList.Data[index] = ob;


        return true;
    }






    private ByteList ByteList { get; set; }
}