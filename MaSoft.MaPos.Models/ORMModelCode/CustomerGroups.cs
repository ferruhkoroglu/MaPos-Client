using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace MaSoft.MaPos.Models.MaPos
{

    public partial class CustomerGroups
    {
        public CustomerGroups(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
