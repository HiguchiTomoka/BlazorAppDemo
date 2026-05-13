window.renderWorkoutChart = (labels, data) => {

    // 線グラフのコンテキストの取得
    const ctx =
        document.getElementById('workoutChart');

    // Chart.jsのインスタンスを作成
    new Chart(ctx, {

        type: 'line',

        data: {
            labels: labels,

            datasets: [{
                label: 'Bench Press',

                data: data,

                tension: 0.3
            }]
        },

        options: {
            responsive: true
        }
    });
}

window.renderMuscleChart = (labels, data) => {

    const ctx =
        document.getElementById('muscleChart');

    new Chart(ctx, {

        type: 'doughnut',

        data: {

            labels: labels,

            datasets: [{
                data: data
            }]
        },

        options: {
            responsive: true
        },

        plugins: {
            legend: {
                position: 'bottom'
            }
        }
    });
}