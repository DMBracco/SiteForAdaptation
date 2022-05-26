
window.onload = function () {
    let today = new Date();
    let weekAgo = new Date();
    weekAgo.setDate(today.getDate() - 7);
    today = today.toISOString().substring(0, 10);;
    weekAgo = weekAgo.toISOString().substring(0, 10);;

    document.getElementById("chartDateEnd").value = today;
    document.getElementById("chartDateStart").value = weekAgo;
    GetEmployeeStatics();

    //document.getElementById("chartManagerDateEnd").value = today;
    //document.getElementById("chartManagerDateStart").value = weekAgo;
    GetManagerStatics();

    //document.getElementById("chartUsersDateEnd").value = today;
    //document.getElementById("chartUsersDateStart").value = weekAgo;
    GetUserStatics();

    //document.getElementById("pieChartCompanyDateEnd").value = today;
    //document.getElementById("pieChartCompanyDateStart").value = weekAgo;
    GetCompanyStatics();

    ChartVisits();
};

var chartBtn = document.querySelector('#chartBtn');
chartBtn.addEventListener('click', function () {
    GetEmployeeStatics();
    GetManagerStatics();
    GetUserStatics();
    GetCompanyStatics();
    ChartVisits();
});

// #region chartEmployee

//var chartEmployeeBtn = document.querySelector('#chartEmployeeBtn');
//chartEmployeeBtn.addEventListener('click', function () {
//    GetEmployeeStatics();
//});

function GetEmployeeStatics() {
    const url = '/admin/home/getEmployeeStatics';
    const data = {
        dateStart: document.getElementById("chartDateStart").value,
        dateEnd: document.getElementById("chartDateEnd").value
    };

    try {
        const response = fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
            .then((response) => {
                return response.json();
            })
            .then((data) => {
                console.log('Успех:', data);
                ChartEmployee(data);
                ChartBeginners(data); //////////////////////////////////sdfvcdsvcd
            });
    } catch (error) {
        console.error('Ошибка:', error);
    }
}

function ChartEmployee(data) {
    let labelArray = [];
    let dataArray = [];

    data.forEach(element => {
        labelArray.push(element.name.split('T')[0])
        dataArray.push(element.count)
    });

    var newDiv = document.getElementById("myChartEmployeeDiv");
    newDiv.innerHTML = '<canvas id="myChartEmployee"></canvas>';

    var ctx = document.getElementById("myChartEmployee");

    myChartEmployee = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labelArray,
            datasets: [{
                label: 'Сотрудники',
                backgroundColor: '#efefef',
                borderColor: '#efefef',
                data: dataArray,
            }]
        },
        options: {}
    });
}

// #endregion

// #region chartManager

//var chartEmployeeBtn = document.querySelector('#chartManagerBtn');
//chartEmployeeBtn.addEventListener('click', function () {
//    GetManagerStatics();
//});

function GetManagerStatics() {
    const url = '/admin/home/GetManagerStatics';
    const data = {
        dateStart: document.getElementById("chartDateStart").value,
        dateEnd: document.getElementById("chartDateEnd").value
    };

    try {
        const response = fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
            .then((response) => {
                return response.json();
            })
            .then((data) => {
                console.log('Успех:', data);
                ChartManager(data);
                chartContinuing(data);
            });
    } catch (error) {
        console.error('Ошибка:', error);
    }
}

function ChartManager(data) {
    let labelArray = [];
    let dataArray = [];

    data.forEach(element => {
        labelArray.push(element.name.split('T')[0])
        dataArray.push(element.count)
    });

    var newDiv = document.getElementById("myChartManagerDiv");
    newDiv.innerHTML = '<canvas id="myChartManager"></canvas>';

    var ctx = document.getElementById("myChartManager");

    myChartEmployee = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labelArray,
            datasets: [{
                label: 'Руководители',
                backgroundColor: '#efefef',
                borderColor: '#efefef',
                data: dataArray,
            }]
        },
        options: {}
    });
}

// #endregion

// #region chartUsers

//var chartEmployeeBtn = document.querySelector('#chartUsersBtn');
//chartEmployeeBtn.addEventListener('click', function () {
//    GetUserStatics();
//});

function GetUserStatics() {
    const url = '/admin/home/GetUserStatics';
    const data = {
        dateStart: document.getElementById("chartDateStart").value,
        dateEnd: document.getElementById("chartDateEnd").value
    };

    try {
        const response = fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
            .then((response) => {
                return response.json();
            })
            .then((data) => {
                console.log('Успех:', data);
                ChartUsers(data);
                chartPast(data);
                ChartVisits(data);
            });
    } catch (error) {
        console.error('Ошибка:', error);
    }
}

function ChartUsers(data) {
    let labelArray = [];
    let dataArray = [];

    data.forEach(element => {
        labelArray.push(element.name.split('T')[0])
        dataArray.push(element.count)
    });

    var newDiv = document.getElementById("chartUsersDiv");
    newDiv.innerHTML = '<canvas id="chartUsers"></canvas>';

    var ctx = document.getElementById("chartUsers");

    const myChartEmployee = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labelArray,
            datasets: [{
                label: 'Все пользователи',
                backgroundColor: '#efefef',
                borderColor: '#efefef',
                data: dataArray,
            }]
        },
        options: {}
    });
}

// #endregion

// #region chartUsers

//var chartEmployeeBtn = document.querySelector('#pieChartCompanyBtn');
//chartEmployeeBtn.addEventListener('click', function () {
//    GetCompanyStatics();
//});

function GetCompanyStatics() {
    const url = '/admin/home/GetCompanyStatics';
    const data = {
        dateStart: document.getElementById("chartDateStart").value,
        dateEnd: document.getElementById("chartDateEnd").value
    };

    try {
        const response = fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
            .then((response) => {
                return response.json();
            })
            .then((data) => {
                console.log('Успех:', data);
                PieChart(data);
            });
    } catch (error) {
        console.error('Ошибка:', error);
    }
}

function PieChart(data) {
    let labelArray = [];
    let dataArray = [];

    data.forEach(element => {
        labelArray.push(element.name)
        dataArray.push(element.count)
    });
    var newDiv = document.getElementById("pieChartCompanyDiv");
    newDiv.innerHTML = '<canvas id="pieChartCompany"></canvas>';

    var ctx = document.getElementById("pieChartCompany");

    const myChartEmployee = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: labelArray,
            datasets: [{
                data: dataArray,
                backgroundColor: [
                    '#FF00FF',
                    '#FF0000',
                    '#FFFF00',
                    '#1E90FF',
                    '#00FF00',
                    '#00FFFF',
                    '#0000FF',
                    '#800080',
                    '#800000',
                    '#808000',
                    '#008000',
                    '#008080',
                    '#000080',
                    '#7B68EE',
                    '#FFA500',
                    '#00FA9A',
                    '#B22222',
                    '#E0FFFF',
                    '#D2691E',
                ],
            }]
        },
        options: {}
    });
}
// #endregion

// #region chartVisits

function ChartVisits(data) {

    let labelArray = [];
    let dataArray = [];

    data.forEach(element => {
        labelArray.push(element.name.split('T')[0])
        dataArray.push(element.count)
    });

    const dataChart = {
        labels: labelArray,
        datasets: [
            {
                label: 'Время',
                data: dataArray,
                borderColor: "#E32636",
                backgroundColor: "#E32636",
            }
        ]
    };

    const config = {
        type: 'bar',
        data: dataChart,
        options: {
            indexAxis: 'y',
        },
    };

    var ctx = document.getElementById("chartVisits");

    const myChartEmployee = new Chart(ctx, config);
}

// #endregion

// #region chartBeginners

function ChartBeginners(data) {
    let labelArray = [];
    let dataArray = [];

    data.forEach(element => {
        labelArray.push(element.name.split('T')[0])
        dataArray.push(element.count)
    });

    var newDiv = document.getElementById("myChartBeginnersDiv");
    newDiv.innerHTML = '<canvas id="myChartBeginners"></canvas>';

    var ctx = document.getElementById("myChartBeginners");

    myChartBeginners = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labelArray,
            datasets: [{
                label: 'Пользователи',
                backgroundColor: '#efefef',
                borderColor: '#efefef',
                data: dataArray,
            }]
        },
        options: {}
    });
}

// #endregion

// #region chartContinuing

function chartContinuing(data) {
    let labelArray = [];
    let dataArray = [];

    data.forEach(element => {
        labelArray.push(element.name.split('T')[0])
        dataArray.push(element.count)
    });

    var newDiv = document.getElementById("myChartContinuingDiv");
    newDiv.innerHTML = '<canvas id="myChartContinuing"></canvas>';

    var ctx = document.getElementById("myChartContinuing");

    myChartContinuing = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labelArray,
            datasets: [{
                label: 'Пользователи',
                backgroundColor: '#efefef',
                borderColor: '#efefef',
                data: dataArray,
            }]
        },
        options: {}
    });
}

// #endregion

// #region chartPast

function chartPast(data) {
    let labelArray = [];
    let dataArray = [];

    data.forEach(element => {
        labelArray.push(element.name.split('T')[0])
        dataArray.push(element.count)
    });

    var newDiv = document.getElementById("myChartPastDiv");
    newDiv.innerHTML = '<canvas id="myChartPast"></canvas>';

    var ctx = document.getElementById("myChartPast");

    myChartPast = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labelArray,
            datasets: [{
                label: 'Пользователи',
                backgroundColor: '#efefef',
                borderColor: '#efefef',
                data: dataArray,
            }]
        },
        options: {}
    });
}

// #endregion