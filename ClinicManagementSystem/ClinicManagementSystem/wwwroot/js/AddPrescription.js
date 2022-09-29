$(document).ready(function () {
    alert("prescription Js working Properly.!!!");
    PatientDataTableFill("", "");



    $(document).on('click', '.AddPrescription', function () {
        alert("pres function");
        PresDataTableFill($(this).attr('data-PatientPrescriptionId').trim(), "Where PatientId=");
    });



    $("#BtnAddPrescription").click(function () {
        AddPrescription();
    });
});



function PatientDataTableFill(orderby, whereclause) {
    alert("PatientDataTableFill Function is calling.!!!!")
    debugger;
    $.ajax({
        type: "GET",
        url: "/PatientReg/GetAllPatientData",
        data: { "orderby": orderby, "whereclause": whereclause },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.data.length);
            debugger;
            if (whereclause == "where PatientId=") {
                $("#TxtFName").val(response.data[0].firstname);
                $("#TxtLName").val(response.data[0].lastname);
                $("#TxtEmailId").val(response.data[0].emailID);
                $("#TxtContactNo").val(response.data[0].contactNo);
                $("#TxtAddress").val(response.data[0].address);
                $("#DDL_Followup").val(response.data[0].isFollowUp);
                $("#TxtDisease").val(response.data[0].symptoms);

                $("#BtnUpdateRecord").attr('EditUserId', response.data[0]["patientId"]);

            }
            $("#UserTableBody").empty();
            for (var i = 0; i < response.data.length; i++) {



                var tr_str = '';
                var Delete = null;
                Delete = "<i style='color:red' class=' fa fa-2x fa-trash'</i>";





                tr_str = "<tr class='datatable-row' id=" + response.data[i]["patientId"] + ">" +
                    "<td class='text-center'><span style='width:100px'>" + (i + 1) + "</span></td>" +
                    "<td class='text-center'><span style='width:100px'>" + response.data[i]["firstname"] + "</span></td>" +
                    "<td class='text-center'><span style='width:70px'>" + response.data[i]["lastname"] + "</span></td>" +
                    "<td class='text-center'><span style='width:80px'>" + response.data[i]["emailID"] + "</span></td>" +
                    "<td class='text-center'><span style='width:80px'>" + response.data[i]["symptoms"] + "</span></td>" +
                    "<td class='text-center'><span style='width:80px'>" + response.data[i]["contactNo"] + "</span></td>" +
                    "<td class='text-center'><span style='width:80px'>" + response.data[i]["address"] + "</span></td>" +
                    "<td class='text-center'><span style='width:80px'>" + response.data[i]["isFollowUp"] + "</span></td>" +
                    "<td class='text-center'><a data-PatientPrescriptionId=" + response.data[i]["patientId"] + " class='AddPrescription' data-toggle='modal' data-target='#AddPatientPrescription'><i class='fa fa-2x fa-edit'></i></a></td>" +

                    "</tr>";

                $("#tbl1 tbody").append(tr_str);
            }

        },
        error: function () {
            alert("unexpected error is occured!!!!");
        }



    });
}
function PresDataTableFill(orderby, whereclause) {
    alert("press funct");
    debugger;




    $.ajax({
        type: "GET",
        url: "/PatientReg/GetAllPatientData",
        data: { "orderby": orderby, "whereclause": whereclause },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            debugger;



            if (whereclause == 'Where PatientId=') {
                $("#TxtPFName").val(response.data[0].firstname);
                $("#TxtPLName").val(response.data[0].lastname);
                $("#TxtDisease").val(response.data[0].symptoms);
                $("#BtnAddPrescription").attr('PatientPrescriptionId', response.data[0]["patientId"]);
            }
            //else {



            // $("#table14 tbody").empty();
            // for (var i = 0; i < response.data.length; i++) {
            // var tr_str = '';
            // var Status = null;
            // Status = "<i style='color:red' class='fa fa-2x fa-times-circle'></i>";




            // tr_str = "<tr class='datatable-row' id=" + response.data[i]["patientId"] + ">" +
            // "<td class='text-center'><span style='width:100px'>" + (i + 1) + "</span></td>" +
            // "<td class='text-center'><span style='width:100px'>" + response.data[i]["firstname"] + "</span></td>" +
            // "<td class='text-center'><span style='width:70px'>" + response.data[i]["lastname"] + "</span></td>" +
            // "<td class='text-center'><span style='width:80px'>" + response.data[i]["symptoms"] + "</span></td>" +
            // "<td class='text-center'><a data-PatientPrescriptionId=" + response.data[i]["patientId"] + " class='AddPrescription' data-toggle='modal' data-target='#AddPatientPrescription'><i class='fa fa-2x fa-pencil-square-o'></i></a></td>" +
            // "</tr>";



            // $("#table14 tbody").append(tr_str);
            // }
            //}





        },
        error: function () {
            alert("UnExpected error occured sorry for inconvinience!!!");
        }
    });
}



function AddPrescription() {
    alert("AddPresc");


    var P = new Object();
    P.patientId = $("#BtnAddPrescription").attr('PatientPrescriptionId');
    P.medicineName = $("#TxtMedName").val().trim();
    P.Quantity = $("#TxtMedQuantity").val().trim();
    debugger;
    $.ajax({
        type: "POST",
        cache: false,
        dataType: "json",
        url: "/Prescription/AddPrescription",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(P),
        success: function (response) {
            if (response.success = "success") {
                alert("data Added Successfully");
                $("#TxtMedName").val("");
                $("#TxtMedQuantity").val("");
            }
        },
        error: function (response) {
            alert("ERROR");
        }



    });

}