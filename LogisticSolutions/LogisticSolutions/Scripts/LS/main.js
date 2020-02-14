$(document).ready(function () {
    $('.menu > li > a').click(function () {
        $('.menu li').removeClass('active');
        $(this).closest('li').addClass('active');
        var checkElement = $(this).next();
        if ((checkElement.is('ul')) && (checkElement.is(':visible'))) {
            $(this).closest('li').removeClass('active');
            checkElement.slideUp('normal');
        }
        if ((checkElement.is('ul')) && (!checkElement.is(':visible'))) {
            $('.menu ul:visible').slideUp('normal');
            checkElement.slideDown('normal');
        }
        if ($(this).closest('li').find('ul').children().length == 0) {
            return true;
        } else {
            return false;
        }
    });


   


    $('#example').DataTable({
        "scrollX": true,
        "bSort": false,
        "bLengthChange": false,
        //dom: 'Bfrtip',
        "bFilter": false,
        //buttons: [
        //    'copy', 'csv', 'excel', 'pdf', 'print'
        //]
    });

    
    $("#example_previous").html($('<i/>', { class: 'fas fa-caret-left' }))
    $("#example_next").html($('<i/>', { class: 'fas fa-caret-right' }))

   

});

//MenuBtn
$(".MobileMenuBtn").click(function () {
    $(".MobileSideBar").toggleClass("MobileSideBaractive")
});
function fnLogout() {
    window.location.href = "/Account/Logout";
}

//ChangePassword
function ChangePassword() {
    debugger;
    var COldPassword = $("#COldPassword").val();
    var CPassword = $("#CPassword").val();
    var CConfirmPassword = $("#CConfirmPassword").val();
    var confirmPasswordCheck = false;
    var passwordCheck = false;
    if (COldPassword == "") {
        $("#COldPassword").css({ "border-color": "red" });
        $("#COldPasswordL").text("Feild cannot be empty");

    }
    else {

        $("#COldPassword").css({ "border-color": "#ced4da" });
        $("#COldPasswordL").text("");

    }

    if (CPassword == "") {
        $("#CPassword").css({ "border-color": "red" });
        $("#CPasswordL").text("Feild cannot be empty");



    }
    else {
        passwordValidaion(CPassword);
        if (passwordCheck == true) {
            $("#CPassword").css({ "border-color": "#ced4da" });
            $("#CPasswordL").text("");


        }
        else {
            $("#CPassword").css({ "border-color": "red" });
            $("#CPasswordL").text("Password must be atlest 8 characters with one Small and capital letters");


        }

    }

    if (CConfirmPassword == "") {
        $("#CConfirmPassword").css({ "border-color": "red" });
        $("#CConfirmPasswordL").text("Feild cannot be empty");

    }
    else {
        $("#CConfirmPassword").css({ "border-color": "red" });

        ConfirmPasswordValidation(CPassword);
        if (confirmPasswordCheck == true) {
            $("#CConfirmPassword").css({ "border-color": "#ced4da" });
            $("#CConfirmPasswordL").text("");

        }
        else {
            $("#CConfirmPassword").css({ "border-color": "red" });
            $("#CConfirmPasswordL").text("Not Match");

        }


    }

    if (COldPassword != "" && CPassword != "" && CConfirmPassword != "" && confirmPasswordCheck == true && confirmPasswordCheck == true) {

        $.ajax({
            url: "/Home/ChangePassword",
            type: "POST",
            dataType: "JSON",
            data: { COldPassword, CPassword },
            beforeSend: function () {

                $("#CreateUser").text("Loading - Please Wait..");
                $("#CreateUser").css("disabled", true);
            },
            success: function (result) {
                if (result == true) {
                    $("#COldPasswordL").text("");
                }
                else {

                    $("#COldPasswordL").text("Sorry Old Passsword is Incorrect");
                }
            },
            error: function (error) {
                console.log(error);
            },
            complete: function () {



            }
        })
    }



    function passwordValidaion(Password) {
        var lowerCaseLetters = /[a-z]/g;
        var upperCaseLetters = /[A-Z]/g;
        var numbers = /[0-9]/g;

        if (Password.match(lowerCaseLetters) && Password.match(upperCaseLetters) && Password.match(numbers) && Password.length >= 8) {
            passwordCheck = true;
        }



    }

    function ConfirmPasswordValidation(Password) {
        if (Password == CConfirmPassword) {
            confirmPasswordCheck = true

        }
    }

}


//ModelWindow
function ClickForModal() {
    $("#ClikeMeToOpen").click();
}
function ClickForModalCareer() {
    $("#ClikeMeToOpenCareer").click();
}


//SetBillingValues...For User Page
function setBillingValue() {


    $('#UsePrev').val();
    if ($('#UsePrev').is(":checked")) {
        var Adress1 = $("#Adress1").val();
        var Adress2 = $("#Adress2").val();
        var Adress3 = $("#Adress3").val();
        var Adress4 = $("#Adress4").val();
        var City = $("#City").val();
        var State = $("#State").val();
        var PostalCode = $("#PostalCode").val();
        var Country = $("#Country").val();
        $("#ShippingAdress1").val(Adress1);
        $("#ShippingAdress2").val(Adress2);
        $("#ShippingAdress3").val(Adress3);
        $("#ShippingAdress4").val(Adress4);
        $("#ShippingCity").val(City);
        $("#ShippingState").val(State);
        $("#ShippingPostalCode").val(PostalCode);
        $("#ShippingCountry").val(Country);
    }

    else {

        $("#ShippingAdress1").val("");
        $("#ShippingAdress2").val("");
        $("#ShippingAdress3").val("");
        $("#ShippingAdress4").val("");
        $("#ShippingCity").val("");
        $("#ShippingState").val("");
        $("#ShippingPostalCode").val("");
        $("#ShippingCountry").val("");
    }
}



//CareerBillingValues

function setCBillingValue() {

    debugger;
    $('#CUsePrev').val();
    if ($('#CUsePrev').is(":checked")) {
        var Adress1 = $("#CAdress1").val();
        var Adress2 = $("#CAdress2").val();
        var Adress3 = $("#CAdress3").val();
        var Adress4 = $("#CAdress4").val();
        var City = $("#CCity").val();
        var State = $("#CState").val();
        var PostalCode = $("#CPostalCode").val();
        var Country = $("#CCountry").val();
        $("#CShippingAdress1").val(Adress1);
        $("#CShippingAdress2").val(Adress2);
        $("#CShippingAdress3").val(Adress3);
        $("#CShippingAdress4").val(Adress4);
        $("#CShippingCity").val(City);
        $("#CShippingState").val(State);
        $("#CShippingPostalCode").val(PostalCode);
        $("#CShippingCountry").val(Country);
    }

    else {

        $("#CShippingAdress1").val("");
        $("#CShippingAdress2").val("");
        $("#CShippingAdress3").val("");
        $("#CShippingAdress4").val("");
        $("#CShippingCity").val("");
        $("#CShippingState").val("");
        $("#CShippingPostalCode").val("");
        $("#CShippingCountry").val("");
    }
}


//CareerBillingValues



function setABillingValue() {

    debugger;
    $('#AUsePrev').val();
    if ($('#AUsePrev').is(":checked")) {
        var Adress1 = $("#AAdress1").val();
        var Adress2 = $("#AAdress2").val();
        var Adress3 = $("#AAdress3").val();
        var Adress4 = $("#AAdress4").val();
        var City = $("#ACity").val();
        var State = $("#AState").val();
        var PostalCode = $("#APostalCode").val();
        var Country = $("#ACountry").val();
        $("#AShippingAdress1").val(Adress1);
        $("#AShippingAdress2").val(Adress2);
        $("#AShippingAdress3").val(Adress3);
        $("#AShippingAdress4").val(Adress4);
        $("#AShippingCity").val(City);
        $("#AShippingState").val(State);
        $("#AShippingPostalCode").val(PostalCode);
        $("#AShippingCountry").val(Country);
    }

    else {

        $("#AShippingAdress1").val("");
        $("#AShippingAdress2").val("");
        $("#AShippingAdress3").val("");
        $("#AShippingAdress4").val("");
        $("#AShippingCity").val("");
        $("#AShippingState").val("");
        $("#AShippingPostalCode").val("");
        $("#AShippingCountry").val("");
    }
}




//ReceivingOrder

function CreateROrder() {
    var ROFormValidate = $("#FormReceiveOrder").kendoValidator().data("kendoValidator");
    if (!ROFormValidate.validate()) {
        return false;
    }



}



//PurchaseOrder
function CreatePurchaseO() {
    var ROFormValidate = $("#FormPurchaseOrder").kendoValidator().data("kendoValidator");
    if (!ROFormValidate.validate()) {
        return false;
    }
}


//ShippingOrder
function CreateShippingO() {
    var ROFormValidate = $("#FormShippingOrder").kendoValidator().data("kendoValidator");
    if (!ROFormValidate.validate()) {
        return false;
    }



} 


//UserCreate
function CreateUsers() {

    var ROFormValidate = $("#FormUser").kendoValidator().data("kendoValidator");
    if (!ROFormValidate.validate()) {
        return false;
    }


}

//AccountCreate
function CreateAccount() {

    var ROFormValidate = $("#FormAccount").kendoValidator().data("kendoValidator");
    if (!ROFormValidate.validate()) {
        return false;
    }


}

//Dashboard Charts


$.ajax({
    url: "/Home/DonutChart",
    type: "POST",
    dataType: "JSON",

    success: function (result) {
        debugger;
        //Graph1

        Highcharts.chart('graph1', {

            title: {
                text: ''
            },

            xAxis: {
                tickInterval: 1,
                type: 'logarithmic'
            },

            yAxis: {
                type: 'logarithmic',
                minorTickInterval: 0.1
            },

            tooltip: {
                headerFormat: '',
                pointFormat: 'x = {point.x}, y = {point.y}'
            },

            series: [{
                data: result.parcels,
                pointStart: 1,
                color: "#00e6ac",
                name: 'All Parcels'

            }]
        });

        //Graph1Ends

        //Graph2
        Highcharts.chart('graph2', {

            title: {
                text: ''
            },

            xAxis: {
                tickInterval: 1,
                type: 'logarithmic'
            },

            yAxis: {
                type: 'logarithmic',
                minorTickInterval: 0.1
            },

            tooltip: {
                headerFormat: '<b>{All Parcel}</b><br />',
                pointFormat: 'x = {point.x}, y = {point.y}'
            },

            series: [{
                data: result.order,
                pointStart: 1,
                color: "#FFB64D",
                name: 'All Orders'

            }]
        });

        //Graph2Ends

        //Graph3
        Highcharts.chart('graph3', {

            title: {
                text: ''
            },

            xAxis: {
                tickInterval: 1,
                type: 'logarithmic'
            },

            yAxis: {
                type: 'logarithmic',
                minorTickInterval: 0.1
            },

            tooltip: {
                headerFormat: '<b>{series.name}</b><br />',
                pointFormat: 'x = {point.x}, y = {point.y}'
            },

            series: [{
                data: result.receiving,
                pointStart: 1,
                color: "#4099FF",
                name: 'All Receiving'

            }]
        });

        //Graph3Ends
        //Graph4
        Highcharts.chart('graph4', {

            title: {
                text: ''
            },

            xAxis: {
                tickInterval: 1,
                type: 'logarithmic'
            },

            yAxis: {
                type: 'logarithmic',
                minorTickInterval: 0.1
            },

            tooltip: {
                headerFormat: '<b>{series.name}</b><br />',
                pointFormat: 'x = {point.x}, y = {point.y}'
            },

            series: [{
                data: result.users,
                pointStart: 1,
                color: "#FF5370",
                name: 'All Users'
            }]
        });

        //Graph4Ends

        //Graph5
        Highcharts.chart('graph5', {
            chart: {
                type: 'spline'
            },
            title: {
                text: 'Daily Send and receive orders'
            },
            //subtitle: {
            //    text: 'Source: WorldClimate.com'
            //},
            xAxis: {
                categories: ['Mon', 'Tue', 'Wed', 'Thursday', 'Friday', 'Saturday', 'Sunday']
            },
            yAxis: {
                title: {
                    text: 'Orders'
                },
                labels: {
                    formatter: function () {
                        return this.value + '°';
                    }
                }
            },
            tooltip: {
                crosshairs: true,
                shared: true
            },
            plotOptions: {
                spline: {
                    marker: {
                        radius: 4,
                        lineColor: '#3B53DB',
                        lineWidth: 1
                    }
                }
            },
            series: [{
                name: 'Upcomming',
                //marker: {
                //    symbol: 'square'
                //},
                data: result.sROrderY

            }, {
                name: 'Incomming',
                //marker: {
                //    symbol: 'diamond'
                //},
                data: result.sROrderX
            }]
        });

        //Graph5Ends
        //Graph6
        // Create the chart

        Highcharts.chart('graph6', {
            chart: {
                type: 'column'
            },
            title: {
                text: 'Monthly receive Orders'
            },
            //subtitle: {
            //    text: 'Click the columns to view versions. Source: <a href="http://statcounter.com" target="_blank">statcounter.com</a>'
            //},
            accessibility: {
                announceNewData: {
                    enabled: true
                }
            },
            xAxis: {
                type: 'category'
            },
            yAxis: {
                title: {
                    text: 'Receiving Orders'
                }

            },
            legend: {
                enabled: false
            },
            plotOptions: {
                series: {
                    borderWidth: 0,
                    dataLabels: {
                        enabled: true,
                        format: '{point.y:.1f}%'
                    }
                }
            },

            tooltip: {
                headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
                pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y:.2f}%</b> of total<br/>'
            },

            series: [
                {
                    name: "Months",
                    colorByPoint: true,
                    data: [

                        {
                            name: "Jan",
                            y: result.mROrderY[0],
                            drilldown: "Jan"
                        },
                        {
                            name: "Feb",
                            y: result.mROrderY[1],
                            drilldown: "Feb"
                        },
                        {
                            name: "March",
                            y: result.mROrderY[2],
                            drilldown: "March"
                        },
                        {
                            name: "April",
                            y: result.mROrderY[3],
                            drilldown: "April"
                        },
                        {
                            name: "May",
                            y: result.mROrderY[4],
                            y: 4.02,
                            drilldown: "May"
                        },
                        {
                            name: "June",
                            y: result.mROrderY[5],
                            drilldown: "June"
                        },
                        {
                            name: "July",
                            y: result.mROrderY[6],
                            drilldown: "July"
                        },
                        {
                            name: "Aug",
                            y: result.mROrderY[7],
                            drilldown: "Aug"
                        }, {
                            name: "Sept",
                            y: result.mROrderY[8],
                            drilldown: "Sept"
                        }, {
                            name: "Oct",
                            y: result.mROrderY[9],
                            drilldown: "Oct"
                        }, {
                            name: "Nov",
                            y: result.mROrderY[10],
                            drilldown: "Nov"
                        }, {
                            name: "Dec",
                            y: result.mROrderY[11],
                            drilldown: "Dec"
                        },

                    ]
                }
            ],
        });
        //Graph6Ends


        //Graph7
        // Create the chart

        Highcharts.chart('graph7', {
            chart: {
                type: 'column'
            },
            title: {
                text: 'Monthly Shipping Orders'
            },
            //subtitle: {
            //    text: 'Click the columns to view versions. Source: <a href="http://statcounter.com" target="_blank">statcounter.com</a>'
            //},
            accessibility: {
                announceNewData: {
                    enabled: true
                }
            },
            xAxis: {
                type: 'category'
            },
            yAxis: {
                title: {
                    text: 'Shipping Orders'
                }

            },
            legend: {
                enabled: false
            },
            plotOptions: {
                series: {
                    borderWidth: 0,
                    dataLabels: {
                        enabled: true,
                        format: '{point.y:.1f}%'
                    }
                }
            },

            tooltip: {
                headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
                pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y:.2f}%</b> of total<br/>'
            },

            series: [
                {
                    name: "Months",
                    colorByPoint: true,
                    data: [

                        {
                            name: "Jan",
                            y: result.mSOrderY[0],
                            drilldown: "Jan"
                        },
                        {
                            name: "Feb",
                            y: result.mSOrderY[1],
                            drilldown: "Feb"
                        },
                        {
                            name: "March",
                            y: result.mSOrderY[2],
                            drilldown: "March"
                        },
                        {
                            name: "April",
                            y: result.mSOrderY[3],
                            drilldown: "April"
                        },
                        {
                            name: "May",
                            y: result.mSOrderY[4],
                            y: 4.02,
                            drilldown: "May"
                        },
                        {
                            name: "June",
                            y: result.mSOrderY[5],
                            drilldown: "June"
                        },
                        {
                            name: "July",
                            y: result.mSOrderY[6],
                            drilldown: "July"
                        },
                        {
                            name: "Aug",
                            y: result.mSOrderY[7],
                            drilldown: "Aug"
                        }, {
                            name: "Sept",
                            y: result.mSOrderY[8],
                            drilldown: "Sept"
                        }, {
                            name: "Oct",
                            y: result.mSOrderY[9],
                            drilldown: "Oct"
                        }, {
                            name: "Nov",
                            y: result.mSOrderY[10],
                            drilldown: "Nov"
                        }, {
                            name: "Dec",
                            y: result.mSOrderY[11],
                            drilldown: "Dec"
                        },

                    ]
                }
            ],
        });
        //Graph7Ends

        function renderIcons() {

            // Move icon
            if (!this.series[0].icon) {
                this.series[0].icon = this.renderer.path(['M', -8, 0, 'L', 8, 0, 'M', 0, -8, 'L', 8, 0, 0, 8])
                    .attr({
                        stroke: '#303030',
                        'stroke-linecap': 'round',
                        'stroke-linejoin': 'round',
                        'stroke-width': 2,
                        zIndex: 10
                    })
                    .add(this.series[2].group);
            }
            this.series[0].icon.translate(
                this.chartWidth / 2 - 10,
                this.plotHeight / 2 - this.series[0].points[0].shapeArgs.innerR -
                (this.series[0].points[0].shapeArgs.r - this.series[0].points[0].shapeArgs.innerR) / 2
            );

            // Exercise icon
            if (!this.series[1].icon) {
                this.series[1].icon = this.renderer.path(
                    ['M', -8, 0, 'L', 8, 0, 'M', 0, -8, 'L', 8, 0, 0, 8,
                        'M', 8, -8, 'L', 16, 0, 8, 8]
                )
                    .attr({
                        stroke: '#ffffff',
                        'stroke-linecap': 'round',
                        'stroke-linejoin': 'round',
                        'stroke-width': 2,
                        zIndex: 10
                    })
                    .add(this.series[2].group);
            }
            this.series[1].icon.translate(
                this.chartWidth / 2 - 10,
                this.plotHeight / 2 - this.series[1].points[0].shapeArgs.innerR -
                (this.series[1].points[0].shapeArgs.r - this.series[1].points[0].shapeArgs.innerR) / 2
            );

            // Stand icon
            if (!this.series[2].icon) {
                this.series[2].icon = this.renderer.path(['M', 0, 8, 'L', 0, -8, 'M', -8, 0, 'L', 0, -8, 8, 0])
                    .attr({
                        stroke: '#303030',
                        'stroke-linecap': 'round',
                        'stroke-linejoin': 'round',
                        'stroke-width': 2,
                        zIndex: 10
                    })
                    .add(this.series[2].group);
            }

            this.series[2].icon.translate(
                this.chartWidth / 2 - 10,
                this.plotHeight / 2 - this.series[2].points[0].shapeArgs.innerR -
                (this.series[2].points[0].shapeArgs.r - this.series[2].points[0].shapeArgs.innerR) / 2
            );
        }

        Highcharts.chart('graph8', {

            chart: {
                type: 'solidgauge',
                height: '110%',
                events: {
                    render: renderIcons
                }
            },

            title: {
                text: 'Revenue Statistics',
                style: {
                    fontSize: '24px'
                }
            },

            tooltip: {
                borderWidth: 0,
                backgroundColor: 'none',
                shadow: false,
                style: {
                    fontSize: '16px'
                },
                valueSuffix: '%',
                pointFormat: '{series.name}<br><span style="font-size:2em; color: {point.color}; font-weight: bold">{point.y}</span>',
                positioner: function (labelWidth) {
                    return {
                        x: (this.chart.chartWidth - labelWidth) / 2,
                        y: (this.chart.plotHeight / 2) + 15
                    };
                }
            },

            pane: {
                startAngle: 0,
                endAngle: 360,
                background:
                    [
                        { // Track for Move
                            outerRadius: '112%',
                            innerRadius: '88%',
                            backgroundColor: Highcharts.Color(Highcharts.getOptions().colors[0])
                                .setOpacity(0.3)
                                .get(),
                            borderWidth: 0
                        },



                    ]
            },

            yAxis: {
                min: 0,
                max: 100,
                lineWidth: 0,
                tickPositions: []
            },

            plotOptions: {
                solidgauge: {
                    dataLabels: {
                        enabled: false
                    },
                    linecap: 'round',
                    stickyTracking: false,
                    rounded: true
                }
            },

            series: [
                {
                    name: 'Revenue',
                    data: [{
                        color: Highcharts.getOptions().colors[0],
                        radius: '112%',
                        innerRadius: '88%',
                        y: result.revenue
                    }]
                },




            ]
        });
    },
    error: function (error) {
        console.log(error);
    },
})


