// File: wwwroot/chart/chart.js

function initializeRevenueChart(canvasId) {
    // This is the function that gets called from Index.cshtml
    const ctx = document.getElementById(canvasId);

    // You can replace the hardcoded data with fetch() later
    const data = {
        labels: ['Q1', 'Q2', 'Q3', 'Q4'], 
        datasets: [{
            label: 'Monthly Revenue',
            data: [45000, 52000, 38000, 65000], 
            backgroundColor: 'rgba(53, 162, 235, 0.6)',
            borderColor: 'rgba(53, 162, 235, 1)',
            borderWidth: 1
        }]
    };

    new Chart(ctx, {
        type: 'bar',
        data: data,
        options: {
            responsive: true,
            plugins: {
                title: { display: true, text: 'Project Revenue Dashboard' }
            },
            scales: { y: { beginAtZero: true } }
        }
    });
}