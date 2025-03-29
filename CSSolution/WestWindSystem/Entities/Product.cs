﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WestWindSystem.Entities;

[Index("CategoryID", Name = "CategoriesProducts")]
[Index("CategoryID", Name = "CategoryID")]
[Index("ProductName", Name = "ProductName")]
[Index("SupplierID", Name = "SupplierID")]
[Index("SupplierID", Name = "SuppliersProducts")]
public partial class Product
{
    //if the pkey is not an IDENTITY pkey you will need to add additional
    //  annotation parameter(s) to your key annotation
    // DatabaseGenerated()
    //  values: DatabaseGeneratedOption.None (not a IDENTITY field, user must supply the pkey)
    //          DatabaseGeneratedOption.IDENTITY (pkey is an IDENTITY field, default, can be added by is optional)
    //          DatabaseGeneratedOption.Computed (this is used on attributes that are computed from
    //                                              other record attributes, not seen on Keys
    //                                               Assume you have attributes price and quantity
    //                                                      you could compute totalcost = price * quantity
    //                                             this field does not actually contain data and the entity
    //                                                 will not expected data to be supplied)
    [Key]
    public int ProductID { get; set; }

    [Required(ErrorMessage ="Product name is a required field. Cannot be empty.")]
    [StringLength(40, ErrorMessage ="Product name is limited to 40 characters.")]
    public string ProductName { get; set; }

    public int SupplierID { get; set; }

    public int CategoryID { get; set; }

    [Required(ErrorMessage = "Quantity per unit is a required field. Cannot be empty.")]
    [StringLength(20, ErrorMessage = "Quantity per unit is limited to 20 characters.")]
    public string QuantityPerUnit { get; set; }

    [Range(1,short.MaxValue,ErrorMessage ="Minimum Order quantity is 1 to 32767")]
    public short? MinimumOrderQuantity { get; set; }

    [Range(0.0,double.MaxValue,ErrorMessage = "Unit price cannot be negative.")]
    [Column(TypeName = "money")]
    public decimal UnitPrice { get; set; }

    [Range(0,int.MaxValue,ErrorMessage ="Unit per Order cannot be negative.")]
    public int UnitsOnOrder { get; set; }

    public bool Discontinued { get; set; }

    //if the datatype of your virtual property is the name of a class
    //  then the property is pointing to the "parent" class
    [ForeignKey("CategoryID")]
    [InverseProperty("Products")]
    public virtual Category Category { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<ManifestItem> ManifestItems { get; set; } = new List<ManifestItem>();

    //if the datatype of your virtual property is a collection (ICollection) of a class
    //  then the property is pointing to the "child" class
    [InverseProperty("Product")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    [ForeignKey("SupplierID")]
    [InverseProperty("Products")]
    public virtual Supplier Supplier { get; set; }
}