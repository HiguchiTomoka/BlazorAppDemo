using Microsoft.JSInterop;

namespace BlazorAppDemo.Components.Services;

/// <summary>
/// グラフの描画を管理するサービスです
/// </summary>
public class ChartService
{
    private readonly IJSRuntime _js;

    public ChartService(IJSRuntime js)
    {
        _js = js;
    }

    // PFC円グラフ
    public async Task RenderPfcChart(
        decimal protein,
        decimal fat,
        decimal carbs)
    {
        await _js.InvokeVoidAsync(
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
        await _js.InvokeVoidAsync(
            "renderDailyNutritionIntakeChart",

            protein,
            proteinTarget,

            fat,
            fatTarget,

            carbs,
            carbsTarget);
    }

    // 摂取推移グラフ
    public async Task RenderTrendChart()
    {
        await _js.InvokeVoidAsync("renderTrendChart");
    }
}