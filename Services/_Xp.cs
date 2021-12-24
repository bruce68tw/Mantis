using Base.Services;

namespace Mantis.Services
{
    //project service
    public static class _Xp
    {
        //public const string MyVer = "20201228f";     //for my.js/css
        public static string MyVer = _Date.NowSecStr(); //for my.js/css
        public const string LibVer = "20210325";        //for lib.js/css

        public static string GetTplPath(string fileName)
        {
            return _Fun.DirRoot + "_template\\" + fileName;
        }

    }//class
}