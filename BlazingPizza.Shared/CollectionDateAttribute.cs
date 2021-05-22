// Decompiled with JetBrains decompiler
// Type: BlazingPizza.CollectionDateAttribute
// Assembly: BlazingPizza.Shared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828454DF-6818-4B53-832D-B72D96F2EA56
// Assembly location: C:\Users\Taylor\Downloads\BlazingPizza.Shared.dll

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazingPizza
{
  internal class CollectionDateAttribute : ValidationAttribute
  {
    protected override ValidationResult IsValid(
      object value,
      ValidationContext validationContext)
    {
      if (!(Convert.ToDateTime(value) < DateTime.Now))
        return ValidationResult.Success;
      return new ValidationResult("Please select a valid timeslot", (IEnumerable<string>) new string[1]
      {
        validationContext.MemberName
      });
    }
  }
}
