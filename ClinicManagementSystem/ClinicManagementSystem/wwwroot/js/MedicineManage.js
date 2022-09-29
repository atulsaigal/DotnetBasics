$(document).ready(function () {

    //alert("Medicine JQuery  is Working");
    UserDataTableFill("", "");

    var TxtMedicineNameFlag = false, TxtManufacturerFlag = false, TxtPriceFlag = false, TxtStockFlag = false;

    var specialKeys = new Array();
    specialKeys.push(8);
    specialKeys.push(9);
    specialKeys.push(46);

    specialKeys.push(16);
    specialKeys.push(20);

    specialKeys.push(37);
    specialKeys.push(39);


    $(document).on('click', '.EditMedicine', function () {
        //alert("edit function");
        UserDataTableFill($(this).attr('data-UserMedicineEdit').trim(), "Where medicineId=");
    });

    $(document).on('click', '.DeleteCLS', function () {
        if (confirm("Are You Sure To Delete Record..??")) {
            DeleteMedicine(parseInt($(this).attr('data-DeleteMedicineId')));
        }
        else {
            alert(".....")
        }
    })

    //Create New Account - Sign Up.


    $("#TxtMedicineName").bind("blur", function (e) {
        if ($("#TxtMedicineName").val() == "") {
            TxtMedicineNameFlag = false;
            $("#TxtMedicineNameValidate").empty();
            $("#TxtMedicineNameValidate").html('*Please Enter Medicine Name..!!');
        }
        else {

            $("#TxtFNameValidate").empty();
            TxtMedicineNameFlag = true;
        }
    });


    $("#TxtManufacturerName").bind("blur", function (e) {
        if ($("#TxtManufacturerName").val() == "") {
            TxtManufacturerFlag = false;
            $("TxtManufacturerNameValidate").empty();
            $("#TxtManufacturerNameValidate").html('*Please Enter Manufacturer Name..!!');
        }
        else {

            $("#TxtManufacturerNameValidate").empty();
            TxtManufacturerFlag = true;
        }
    });



    $("#TxtPrice").bind("keypress", function (e) {
        var keyCode = e.which ? e.which : e.keyCode
        var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
        $("#TxtPriceValidate").html(ret ? "" : "(*) Invalid Input..!!");
        return ret;
    });

    $("#TxtPrice").bind("blur", function (e) {
        $("#TxtPriceValidate").empty();
        if ($("#TxtPrice").val() == '') {
            TxtPriceFlag = false;
            $("#TxtPrice").html('(*) Price Required..!!');
        }
        else {

            $("#TxtPriceValidate").empty();
            TxtPriceFlag = true;
        }

        return TxtPriceFlag;
    });


    $("#TxtStock").bind("keypress", function (e) {
        var keyCode = e.which ? e.which : e.keyCode
        var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
        $("#TxtStockValidate").html(ret ? "" : "(*) Invalid Input..!!");
        return ret;
    });

    $("#TxtStock").bind("blur", function (e) {
        $("#TxtStockValidate").empty();
        if ($("#TxtStock").val() == '') {
            TxtStockFlag = false;
            $("#TxtStockValidate").html('(*) Price Required..!!');
        }
        else {

            $("#TxtStockValidate").empty();
            TxtStockFlag = true;
        }

        return TxtStockFlag;
    });



    $("#BtnUpdateRecord").click(function () {
        if ($("#TxtMedicineName").val() == "") {
            TxtMedicineNameFlag = false;
            $("#TxtMedicineNameValidate").empty();
            $("#TxtMedicineNameValidate").html('*Please Enter Medicine Name..!!');
        }
        else {

            $("#TxtFNameValidate").empty();
            TxtMedicineNameFlag = true;
        }

        if ($("#TxtManufacturerName").val() == "") {
            TxtManufacturerFlag = false;
            $("TxtManufacturerNameValidate").empty();
            $("#TxtManufacturerNameValidate").html('*Please Enter Manufacturer Name..!!');
        }
        else {

            $("#TxtManufacturerNameValidate").empty();
            TxtManufacturerFlag = true;
        }

        if ($("#TxtPrice").val() == '') {
            TxtPriceFlag = false;
            $("#TxtPriceValidate").html('(*) Price Required..!!');
        }
        else {

            $("#TxtPriceValidate").empty();
            TxtPriceFlag = true;
        }

        if ($("#TxtStock").val() == '') {
            TxtStockFlag = false;
            $("#TxtStockValidate").html('(*) Stock Required..!!');
        }
        else {

            $("#TxtStockValidate").empty();
            TxtStockFlag = true;
        }


        if (TxtMedicineNameFlag == true && TxtManufacturerFlag == true && TxtPriceFlag == true && TxtStockFlag == true) {
            alert("this is button click event");
            UpdateRecord();

        }
        else {
            alert("Invalid Inputs..!!")
        }
    });

});


function UserDataTableFill(orderby, whereclause) {
    alert("UserDataTableFill ajax is calling");
   
    $.ajax({
        
        type: "GET",
        url: "/Medicine/GetMed",
        data: { "orderby": orderby, "whereclause": whereclause },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
       
            //alert(response.data.length);
            if (whereclause == 'Where medicineId=') {
                $("#TxtMedicineName").val(response.data[0].medicineName);
                $("#TxtManufacturerName").val(response.data[0].medicineManufacturer);
                $("#TxtPrice").val(response.data[0].medicinePrice);
                $("#TxtDate").val(response.data[0].medicineExpiryDate);
                $("#TxtStock").val(response.data[0].medicineStock);
                $("#BtnUpdateRecord").attr('EditMedicineId', response.data[0]["medicineId"]);
            }
            else {
                $("#table14 tbody").empty();
                for (var i = 0; i < response.data.length; i++) {
                    var tr_str = '';

                    tr_str = "<tr class='datatable-row' id=" + response.data[i]["medicineId"] + ">" +
                        "<td class='datetable-cell'><span style='width:100px'>" + (i + 1) + "</span></td>" +
                        "<td class='datetable-cell'><span style='width:100px'>" + response.data[i]["medicineName"] + "</span></td>" +
                        "<td class='datetable-cell'><span style='width:70px'>" + response.data[i]["medicineManufacturer"] + "</span></td>" +
                        "<td class='datetable-cell'><span style='width:80px'>" + response.data[i]["medicinePrice"] + "</span></td>" +
                        "<td class='datetable-cell'><span style='width:80px'>" + response.data[i]["medicineExpiryDate"] + "</span></td>" +
                        "<td class='datetable-cell'><span style='width:80px'>" + response.data[i]["medicineStock"] + "</span></td>" +
                        "<td class='datetable-cell'><a data-UserMedicineEdit=" + response.data[i]["medicineId"] + " class='EditMedicine' data-toggle='modal' data-target='#EditMedicineRecord'><i class='fa fa-2x fa-edit'></i></a></td > " +
                        "<td class='datetable-cell'><a data-DeleteMedicineId=" + response.data[i]["medicineId"] + " class='DeleteCLS'><i class='fa fa-2x fa-times-circle'></i></a></td > " +
                        "</tr>";

                    $("#table14 tbody").append(tr_str);
                }
            }
        },
        error: function () {
            alert("UnExpected error occured sorry for inconvinience!!!");
        }
    });
}

function UpdateRecord() {
    alert("Ajax");
   

    var medicine = new Object();
    medicine.medicineId = ($("#BtnUpdateRecord").attr('EditMedicineId'));
    medicine.medicineName = $("#TxtMedicineName").val().trim();
    medicine.medicineManufacturer = $("#TxtManufacturerName").val().trim();
    medicine.medicinePrice = $("#TxtPrice").val().trim();
    medicine.medicineExpiryDate = $("#TxtDate").val().trim();
    medicine.medicineStock = $("#TxtStock").val().trim();
    //alert(user);
    /*debugger*/
    $.ajax({
        type: "POST",
        cache: false,
        dataType: "json",
        url: "/Medicine/AddMedicine",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(medicine),
        success: function (response) {
            if (response.success = "success") {
                alert("data Updated Successfully");
                $("input").val("");
                UserDataTableFill("", "");
                $("#EditMedicineRecord .close").click();
            }
        },
        error: function (response) {
            alert("ERROR");
        }

    });

};

function DeleteMedicine(id) {
    //alert(id);


    var obj = new Object();
    obj.medicineId = id;
    //alert(obj);

    //debugger
    $.ajax({
        url: "/Medicine/DeleteMedicine",
        type: 'POST',
        dataType: "json",
        contentType: "application/json; charset-utf-8",
        data: JSON.stringify(obj),
        success: function () {
            alert("Data Deleted....");
            UserDataTableFill("", "");
        },
        error: function (jqXHR, textStatus, err) {
            alert('text status ' + textStatus + ', err ' + err)
        }
    });

    return true;
}