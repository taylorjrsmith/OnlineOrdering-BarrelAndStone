// Decompiled with JetBrains decompiler
// Type: BlazingPizza.Address
// Assembly: BlazingPizza.Shared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828454DF-6818-4B53-832D-B72D96F2EA56
// Assembly location: C:\Users\Taylor\Downloads\BlazingPizza.Shared.dll

using System.ComponentModel.DataAnnotations;

namespace BlazingPizza
{
  public class Address
  {
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [MaxLength(100)]
    public string Line1 { get; set; }

    [MaxLength(100)]
    public string Line2 { get; set; }

    [Required]
    [MaxLength(50)]
    public string City { get; set; }

    [Required]
    [MaxLength(20)]
    public string Region { get; set; }

    [Required]
    [MaxLength(20)]
    public string PostalCode { get; set; }
  }
}
