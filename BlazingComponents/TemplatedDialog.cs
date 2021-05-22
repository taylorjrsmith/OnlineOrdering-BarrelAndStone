// Decompiled with JetBrains decompiler
// Type: BlazingComponents.TemplatedDialog
// Assembly: BlazingComponents, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4684B8FA-B58F-4126-BBBD-AB15B32CB405
// Assembly location: C:\Users\Taylor\Downloads\wwwroot (1)\BlazingComponents.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlazingComponents
{
  public class TemplatedDialog : ComponentBase
  {
    protected override void BuildRenderTree(RenderTreeBuilder __builder)
    {
      if (!this.Show)
        return;
      __builder.AddContent(0, "    ");
      __builder.OpenElement(1, "div");
      __builder.AddAttribute(2, "class", "dialog-container");
      __builder.AddMarkupContent(3, "\r\n        ");
      __builder.OpenElement(4, "div");
      __builder.AddAttribute(5, "class", "dialog");
      __builder.AddMarkupContent(6, "\r\n            ");
      __builder.AddContent(7, this.ChildContent);
      __builder.AddMarkupContent(8, "\r\n        ");
      __builder.CloseElement();
      __builder.AddMarkupContent(9, "\r\n    ");
      __builder.CloseElement();
      __builder.AddMarkupContent(10, "\r\n");
    }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public bool Show { get; set; }
  }
}
