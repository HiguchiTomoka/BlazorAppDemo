/*
  [概要]
  PFC比を円グラフで示します
*/
window.pfcChartInstance = null;

window.renderPFCRatioChart = (protein, fat, carbs) => {
    // PFCそれぞれのカロリー算出
    const proteinCal = protein * 4;
    const fatCal = fat * 9;
    const carbsCal = carbs * 4;

    // 合計カロリー
    const totalCarolies = proteinCal + fatCal + carbsCal;

    // コンテキスト取得
    const ctx = document.getElementById('pfcRatio');

    // 既存グラフ破棄
    if (window.pfcChartInstance) {
        window.pfcChartInstance.destroy();
    }

    // グラフ設定
    const config = {
        // グラフタイプ(pie:円グラフ,doughnut:ドーナツ円グラフ)
        type: 'doughnut',

        data: {
            labels: ['Protein', 'Fat', 'Carbs'],

            datasets: [{
                data: [proteinCal, fatCal, carbsCal],

                backgroundColor: [
                    '#135389',
                    '#922951',
                    '#F4B400'
                ],

                borderWidth: 2
            }]
        },

        options: {
            responsive: true,

            plugins: {

                legend: {
                    position: 'bottom'
                },

                tooltip: {

                    callbacks: {
                        label: function (context) {

                            const label = context.label || '';

                            const value = Number(context.raw || 0);

                            const total =
                                context.dataset.data
                                    .reduce((a, b) => a + Number(b), 0);

                            const percentage =
                                ((value / total) * 100).toFixed(1);

                            let gram = 0;

                            if (label === 'Protein')
                                gram = protein;

                            else if (label === 'Fat')
                                gram = fat;

                            else if (label === 'Carbs')
                                gram = carbs;

                            return [
                                `${label}`,
                                `${value} kcal`,
                                `${percentage}%`,
                                `${gram} g`
                            ];
                        }
                    }
                }
            }
        }
    }

    // グラフのインスタンス生成
    window.pfcChartInstance = new Chart(ctx, config);
};

/*
  [概要]
  目標摂取値を棒グラフで示します
*/
window.renderDailyNutritionIntakeChart =
    (protein, proteinTarget, fat, fatTarget, carbs, carbsTarget) => {

    // コンテキストの取得
    const ctx = document.getElementById('goalChart');

    // 既存グラフの破棄
    if (window.goalChartInstance) {
        window.goalChartInstance.destroy();
    }

    // グラフ設定
    const config = {
        type: 'bar',

        data: {
            labels: [
                    'Protein',
                    'Fat',
                    'Carbs'
            ],

            datasets: [
                {
                    label: '現在',

                    data: [
                        protein,
                        fat,
                        carbs
                    ],

                    backgroundColor: '#135389',
                    borderRadius: 10
                },

                {
                    label: '目標',

                    data: [
                        proteinTarget,
                        fatTarget,
                        carbsTarget
                    ],

                    backgroundColor: '#922951',
                    borderRadius: 10
                }
            ]
        },

        options: {
            responsive: true,
            maintainAspectRatio: false,
            // indexAxis:yで横軸棒グラフになる
            indexAxis: 'y',

            plugins: {

                legend: {
                    position: 'bottom'
                },
                // ツールチップの表示内容
                tooltip: {
                    callbacks: {
                        label: function (context) {
                            return `${context.dataset.label} : ${context.raw} g`;
                        }
                    }
                }
            },

            scales: {
                x: {
                    beginAtZero: true,
                    ticks: {
                        callback: function (value) {
                            return value + ' g';
                        }
                    }
                }
            }
        }
    }

    // グラフのインスタンス生成
    window.goalChartInstance = new Chart(ctx, config);
}

/*
[概要]
摂取カロリー推移を線グラフで示します
*/
window.renderTrendChart =
    (sundayCal, mondayCal, tuesdayCal, wednesdayCal, thursdayCal, fridayCal, saturdayCal) => {

    // ラベルの日付を選択
    // 今週の開始日（日曜日）
    const today = new Date();

    const startOfWeek = new Date(today);
    startOfWeek.setDate(today.getDate() - today.getDay());

    // 今週の日付を格納する配列
    const thisWeek = [];

    for (let i = 0; i < 7; i++) {
        const day = new Date(startOfWeek);
        day.setDate(startOfWeek.getDate() + i);

        // MM/dd形式に変換
        const month = String(day.getMonth() + 1).padStart(2, '0');
        const date = String(day.getDate()).padStart(2, '0');

        thisWeek.push(`${month}/${date}`);
    }

    // コンテキスト取得
    const ctx = document.getElementById('trendChart');

    // 既存グラフの破棄
    if (window.trendChartInstance) {
        window.trendChartInstance.destroy();
    }

    // グラフ設定
    const config = {
        type: 'line',
        data: {
            labels: thisWeek,

            datasets: [
                {
                    label: '摂取カロリー',
                    data: [sundayCal, mondayCal, tuesdayCal, wednesdayCal, thursdayCal, fridayCal, saturdayCal],
                    borderColor: '#135389',
                    backgroundColor: 'rgba(19, 83, 137, 0.2)',
                    tension: 0.3,
                    fill: true,
                    pointRadius: 5,
                    pointHoverRadius: 8
                }
            ]
        },

        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    position: 'bottom'
                },
                tooltip: {
                    callbacks: {
                        label: function (context) {
                            return `${context.raw} kcal`;
                        }
                    }
                }
            },

            // スケール()
            scales: {
                // 縦軸の設定
                y: {
                    ticks: {
                        callback: function (value) {
                            return value + ' kcal';
                        }
                    }
                }
            }
        }
    }
    window.trendChartInstance = new Chart(ctx, config);
};