﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace MaSoft.MaPos.Models.MaPos
{

    public partial class Terminals : XPLiteObject
    {
        int fRowID;
        [Key(true)]
        public int RowID
        {
            get { return fRowID; }
            set { SetPropertyValue<int>(nameof(RowID), ref fRowID, value); }
        }
        DateTime fRowAddDateTime;
        public DateTime RowAddDateTime
        {
            get { return fRowAddDateTime; }
            set { SetPropertyValue<DateTime>(nameof(RowAddDateTime), ref fRowAddDateTime, value); }
        }
        int fRowAddUserNo;
        public int RowAddUserNo
        {
            get { return fRowAddUserNo; }
            set { SetPropertyValue<int>(nameof(RowAddUserNo), ref fRowAddUserNo, value); }
        }
        DateTime fRowEditDateTime;
        public DateTime RowEditDateTime
        {
            get { return fRowEditDateTime; }
            set { SetPropertyValue<DateTime>(nameof(RowEditDateTime), ref fRowEditDateTime, value); }
        }
        int fRowEditUserNo;
        public int RowEditUserNo
        {
            get { return fRowEditUserNo; }
            set { SetPropertyValue<int>(nameof(RowEditUserNo), ref fRowEditUserNo, value); }
        }
        int fID;
        [Indexed(Name = @"Idx_Id", Unique = true)]
        public int ID
        {
            get { return fID; }
            set { SetPropertyValue<int>(nameof(ID), ref fID, value); }
        }
        string fTerminalName;
        [Indexed(Name = @"Idx_Name")]
        [Size(50)]
        public string TerminalName
        {
            get { return fTerminalName; }
            set { SetPropertyValue<string>(nameof(TerminalName), ref fTerminalName, value); }
        }
        string fDescription;
        [Size(250)]
        public string Description
        {
            get { return fDescription; }
            set { SetPropertyValue<string>(nameof(Description), ref fDescription, value); }
        }
        int fIsDefault;
        public int IsDefault
        {
            get { return fIsDefault; }
            set { SetPropertyValue<int>(nameof(IsDefault), ref fIsDefault, value); }
        }
    }

}