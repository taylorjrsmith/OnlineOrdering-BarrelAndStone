// Decompiled with JetBrains decompiler
// Type: BlazingPizza.ComponentsLibrary.Map.Map
// Assembly: BlazingPizza.ComponentsLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9F0B2C41-5A2F-4E20-B33D-F6EB8A38E2FF
// Assembly location: C:\Users\Taylor\Downloads\wwwroot (1)\BlazingPizza.ComponentsLibrary.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazingPizza.ComponentsLibrary.Map
{
  public class Map : ComponentBase
  {
    private string elementId = "map-" + Guid.NewGuid().ToString("D");

    protected override void BuildRenderTree(RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "id", this.elementId);
      __builder.AddAttribute(2, "style", "height: 100%; width: 100%;");
      __builder.CloseElement();
    }

    [Parameter]
    public double Zoom { get; set; }

    [Parameter]
    public List<Marker> Markers { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender) => await this.JSRuntime.InvokeVoidAsync("deliveryMap.showOrUpdate", (object) this.elementId, (object) this.Markers);

    [Inject]
    private IJSRuntime JSRuntime { get; set; }
  }
}
