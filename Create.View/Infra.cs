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








    public PortPort CreatePort()
    {
        PortModuleName name;

        name = this.CreatePortModuleName("Demo");




        PortImportList importList;

        importList = new PortImportList();

        importList.Init();



        Constant constant;

        constant = Constant.This;



        importList.Add(this.CreateImport(constant.SystemObjectName));



        importList.Add(this.CreateImport(constant.SystemBoolName));


        importList.Add(this.CreateImport(constant.SystemIntName));


        importList.Add(this.CreateImport(constant.SystemStringName));





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