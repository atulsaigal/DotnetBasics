

$(document).ready(function () {

    //Global Variable Declaration.

    var $FNameLNameRegEx = /^([a-zA-Z]{2,20})$/;
    var $PasswordRegEx = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z]{8,12}$/;
    var $EmailIdRegEx = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{2,10})(\]?)$/;
    

    $("#BtnUpdateRecord").click(function () {
        if ($("#TxtFName").val() == "") {
            $("#TxtFNameValidate").empty();
            $("#TxtFNameValidate").html('(*) First Name Required..!!');
        }
        else {
            $("#TxtFNameValidate").empty();
            if (!$("#TxtFName").val().match($FNameLNameRegEx)) {
                $("#TxtFNameValidate").html('Invalid First Name..!!');
                TxtFNameFlag = false;
            }
            else {
                $("#TxtFNameValidate").empty();
                TxtFNameFlag = true;
            }
        }
        if ($("#TxtLName").val() == "") {
            $("#TxtLNameValidate").empty();
            $("#TxtLNameValidate").html('(*) Last Name Required..!!');
        }
        else {
            $("#TxtLNameValidate").empty();
            if (!$("#TxtLName").val().match($FNameLNameRegEx)) {
                $("#TxtLNameValidate").html('Invalid Last Name..!!');
                TxtLNameFlag = false;
            }
            else {
                $("#TxtLNameValidate").empty();
                TxtLNameFlag = true;
            }
        }
        
        if ($("#TxtEmailId").val() == "") {
            $("#TxtEmailIdValidate").empty();
            $("#TxtEmailIdValidate").html('(*) Email Id Required..!!');
        }
        else {
            $("#TxtEmailIdValidate").empty();
            if (!$("#TxtEmailId").val().match($EmailIdRegEx)) {
                TxtEmailIdFlag = false;
                $("#TxtEmailIdValidate").html('Invalid Email Id..!!');
            }
            else {
                $("#TxtEmailIdValidate").empty();
                TxtEmailIdFlag = true;
            }
        }

      

        if (TxtFNameFlag == true && TxtLNameFlag == true && TxtEmailIdFlag == true) {
            UpdateRecord();
        }
        else {
            alert("Invalid Inputs..!!")
        }
    });

});



function UpdateRecord() {
    alert("Ajax");
    
    var user = new Object();
    user.UserId = ($("#BtnUpdateRecord").attr('EditUserId'));
    user.FirstName = $("#TxtFName").val().trim();
    user.LastName = $("#TxtLName").val().trim();
    user.EmailId = $("#TxtEmailId").val().trim();
    user.UserRole = $("#DDL_User").val().trim();
    alert(user);
    debugger;
    $.ajax({
        type: "POST",
        cache: false,
        dataType: "json",
        url: "/Index/RegisterForm",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(user),
        success: function (response) {
            if (response.success = "success") {
                alert("data Inserted Successfully");
                $("input").val("");
                $("#DDL_User").val("U");
                UserDataTableFill("", "");
                $("#EditUserRecord .close").click();

                alert("Done!!!");
            }
        },
        error: function (response) {
            alert("ERROR");
        }

    });

};




