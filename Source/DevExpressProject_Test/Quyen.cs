using System;

namespace DevExpressProject_Test
{
    public class QuyenInfoAttribute : Attribute
    {
        public string Name { get; set; }
        public string Descoript { get; set; }
    }
    public class InfoAttribute : Attribute
    {
        public string Name { get; set; }

        public string Descoript { get; set; }        
    }

    public class Quyen : IEntity<Quyen>
    {
        #region ==Quyen ==
        [Info(Name="Admin",Descoript="")]
        [QuyenInfo(Name = "Admin", Descoript = "")]
        public const string TenQuyen = "";
        #endregion
    }
    public class IEntity<Tkey> where Tkey:class,new()
    {
        public Tkey te = new Tkey();
        public Tkey Id { get; set; }
    }
}
