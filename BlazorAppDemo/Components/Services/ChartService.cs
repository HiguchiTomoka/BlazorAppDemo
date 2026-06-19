using Microsoft.JSInterop;

namespace BlazorAppDemo.Components.Services;

/// <summary>
/// グラフの描画を管理するサービスです
/// ※引数に「IJSRuntime」を渡すことにより、明示的にDIを書かなくてもDI可能
/// </summary>
public class ChartService(IJSRuntime js)
{
    // PFC円グラフ
    public async Task RenderPfcChart(
        decimal protein,
        decimal fat,
        decimal carbs)
    {
        await js.InvokeVoidAsync(
            "renderPFCRatioChart",
            protein,
            fat,
            carbs);
    }

    // 目標比較グラフ
    public async Task RenderGoalChart(
        decimal protein,
        decimal proteinTarget,
        decimal fat,
        decimal fatTarget,
        decimal carbs,
        decimal carbsTarget)
    {
        await js.InvokeVoidAsync(
            "renderDailyNutritionIntakeChart",

            protein,
            proteinTarget,

            fat,
            fatTarget,

            carbs,
            carbsTarget);
    }

    // 摂取推移グラフ
    public async Task RenderTrendChart(
        int sundayCal, int mondayCal, int tuesdayCal, int wednesdayCal,
        int thursdayCal, int fridayCal, int saturdayCal)
    {
        await js.InvokeVoidAsync("renderTrendChart",
            sundayCal, mondayCal, tuesdayCal, wednesdayCal, thursdayCal, fridayCal, saturdayCal);
    }
}