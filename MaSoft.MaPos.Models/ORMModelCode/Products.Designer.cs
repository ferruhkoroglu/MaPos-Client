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

    public partial class Products : XPLiteObject
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
        int fId;
        [Indexed(Name = @"Idx_ID", Unique = true)]
        public int Id
        {
            get { return fId; }
            set { SetPropertyValue<int>(nameof(Id), ref fId, value); }
        }
        string fProductName;
        [Indexed(Name = @"Idx_ProductName", Unique = true)]
        [Size(50)]
        public string ProductName
        {
            get { return fProductName; }
            set { SetPropertyValue<string>(nameof(ProductName), ref fProductName, value); }
        }
        int fProductGroupId;
        public int ProductGroupId
        {
            get { return fProductGroupId; }
            set { SetPropertyValue<int>(nameof(ProductGroupId), ref fProductGroupId, value); }
        }
        int fIsVisibleForPos;
        public int IsVisibleForPos
        {
            get { return fIsVisibleForPos; }
            set { SetPropertyValue<int>(nameof(IsVisibleForPos), ref fIsVisibleForPos, value); }
        }
        int fUnitInfo;
        public int UnitInfo
        {
            get { return fUnitInfo; }
            set { SetPropertyValue<int>(nameof(UnitInfo), ref fUnitInfo, value); }
        }
        int fIsActivated;
        public int IsActivated
        {
            get { return fIsActivated; }
            set { SetPropertyValue<int>(nameof(IsActivated), ref fIsActivated, value); }
        }
        string fBarcode;
        [Size(50)]
        public string Barcode
        {
            get { return fBarcode; }
            set { SetPropertyValue<string>(nameof(Barcode), ref fBarcode, value); }
        }
        string fColorName;
        [Size(20)]
        public string ColorName
        {
            get { return fColorName; }
            set { SetPropertyValue<string>(nameof(ColorName), ref fColorName, value); }
        }
        int fMillId;
        public int MillId
        {
            get { return fMillId; }
            set { SetPropertyValue<int>(nameof(MillId), ref fMillId, value); }
        }
    }

}