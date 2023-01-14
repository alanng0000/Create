namespace Create.View;






class Infra : Object
{
    public static Infra This { get; } = CreateGlobal();




    private static Infra CreateGlobal()
    {
        Infra global;


        global = new Infra();


        global.Init();


        return global;
    }





    public DrawPos CreatePos(int left, int up)
    {
        DrawPos pos;

        pos = new DrawPos();

        pos.Init();

        pos.Left = left;

        pos.Up = up;


        return pos;
    }




    public DrawSize CreateSize(int width, int height)
    {
        DrawSize size;

        size = new DrawSize();

        size.Init();

        size.Width = width;

        size.Height = height;


        return size;
    }





    public DrawRect CreateRect(DrawPos pos, DrawSize size)
    {
        DrawRect rect;

        rect = new DrawRect();

        rect.Init();

        rect.Pos = pos;

        rect.Size = size;


        return rect;
    }





    public DrawColor CreateColor(byte alpha, byte red, byte green, byte blue)
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



    public DrawColorBrush CreateColorBrush(DrawColor color)
    {
        DrawColorBrush brush;

        brush = new DrawColorBrush();

        brush.Color = color;

        brush.Init();


        return brush;
    }





    public PortPort CreatePort()
    {
        PortModuleName name;

        name = this.CreatePortModuleName("Demo");




        PortImportList importList;

        importList = new PortImportList();

        importList.Init();


        this.ImportList = importList;




        Constant constant;

        constant = Constant.This;



        this.AddImport(constant.SystemObjectName);


        this.AddImport(constant.SystemBoolName);


        this.AddImport(constant.SystemIntName);


        this.AddImport(constant.SystemStringName);





        PortExportList exportList;

        exportList = new PortExportList();

        exportList.Init();




        PortEntry entry;
        
        entry = new PortEntry();

        entry.Init();
        



        PortPort port;

        port = new PortPort();

        port.Init();

        port.Name = name;

        port.Import = importList;

        port.Export = exportList;

        port.Entry = entry;




        PortPort ret;

        ret = port;

        return ret;
    }






    private PortImportList ImportList { get; set; }




    private bool AddImport(string varClass)
    {
        PortImport import;

        import = this.CreateImport(varClass);


        this.ImportList.Add(import);


        return true;
    }





    private PortImport CreateImport(string varClass)
    {
        PortImport import;


        import = new PortImport();


        import.Init();





        Constant constant;


        constant = Constant.This;




        PortModuleName module;

        module = this.CreatePortModuleName(constant.SystemName);




        PortModuleVer ver;

        ver = new PortModuleVer();

        ver.Init();

        ver.Value = constant.SystemVer;



        PortClassName aa;

        aa = this.CreatePortClassName(varClass);


        PortClassName ab;

        ab = this.CreatePortClassName(varClass);




        import.Module = module;

        import.Ver = ver;

        import.Class = aa;

        import.Name = ab;




        PortImport ret;

        ret = import;

        return ret;
    }





    private PortModuleName CreatePortModuleName(string name)
    {
        PortModuleName a;

        a = new PortModuleName();

        a.Init();

        a.Value = name;



        PortModuleName ret;

        ret = a;

        return ret;
    }





    private PortClassName CreatePortClassName(string name)
    {
        PortClassName a;

        a = new PortClassName();

        a.Init();

        a.Value = name;



        PortClassName ret;

        ret = a;

        return ret;
    }
}