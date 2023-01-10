namespace Create.Exe;



class Exe : ExeExe
{
    protected override int ExecuteWork()
    {
        M m;


        m = new M();


        m.Init();



        int o;


        o = m.Execute();



        return o;
    }





    static int Main()
    {
        Exe exe;


        exe = new Exe();


        exe.Init();



        int o;


        o = exe.Execute();


        return o;
    }
}