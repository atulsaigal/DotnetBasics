

$(document).ready(function () {


    var $FNameLNameRegEx = /^([a-zA-Z]{2,20})$/;
    var $EmailIdRegEx = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{2,10})(\]?)$/;
    var $PasswordRegEx = /^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^\w\s]).{8,12}$/;
   

    var TxtFNameFlag = false, TxtLNameFlag = false, TxtEmailIdFlag = false;

   

    $("#FNameSearch").bind("keypress", function (e) {
        var keyCode = e.which;
        var ret = ((keyCode >= 65 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122));
        $("#FNameSearchValidate").html(ret ? "" : "(*) Invalid Input..!!");
        return ret;
    });

    $("#FNameSearch").bind("blur", function (e) {
        if ($("#FNameSearch").val() == "") {
            TxtFNameFlag = false;
            $("#FNameSearchValidate").empty();
            $("#FNameSearchValidate").html('(*) First Name Required..!!');
        }
        else {
            $("#FNameSearchValidate").empty();
            if (!$("#FNameSearch").val().match($FNameLNameRegEx)) {
                $("#FNameSearchValidate").html('Invalid First Name..!!');
                TxtFNameFlag = false;
            }
            else {
                $("#FNameSearchValidate").empty();
                TxtFNameFlag = true;
            }
        }
    });

    $("#LNameSearch").bind("keypress", function (e) {
        var keyCode = e.which;
        var ret = ((keyCode >= 65 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122));
        $("#LNameSearchValidate").html(ret ? "" : "(*) Invalid Input..!!");
        return ret;
    });

    $("#LNameSearch").bind("blur", function (e) {
        if ($("#LNameSearch").val() == "") {
            TxtLNameFlag = false;
            $("#LNameSearchValidate").empty();
            $("#LNameSearchValidate").html('(*) Last Name Required..!!');
        }
        else {
            $("#LNameSearchValidate").empty();
            if (!$("#LNameSearch").val().match($FNameLNameRegEx)) {
                $("#LNameSearchValidate").html('Invalid Last Name..!!');
                TxtLNameFlag = false;
            }
            else {
                $("#LNameSearchValidate").empty();
                TxtLNameFlag = true;
            }
        }
    });

    $("#EmailIdSearch").bind("blur", function (e) {
        if ($("#EmailIdSearch").val() == "") {
            TxtLNameFlag = false;
            $("#EmailIdSearchValidate").empty();
            $("#EmailIdSearchValidate").html('(*) EmailId Required..!!');
        }
        else {
            $("#EmailIdSearchValidate").empty();
            if (!$("#EmailIdSearch").val().match($EmailIdRegEx)) {
                $("#EmailIdSearchValidate").html('Invalid EmailId..!!');
                TxtLNameFlag = false;
            }
            else {
                $("#EmailIdSearchValidate").empty();
                TxtLNameFlag = true;
            }
        }
    });

    $("#PwdSearch").bind("blur", function (e) {
        if ($("#PwdSearch").val() == "") {
            TxtLNameFlag = false;
            $("#PwdSearchValidate").empty();
            $("#PwdSearchValidate").html('(*) Password Required..!!');
        }
        else {
            $("#PwdSearchValidate").empty();
            if (!$("#PwdSearch").val().match($PasswordRegEx)) {
                $("#PwdSearchValidate").html('Invalid Password..!!');
                TxtLNameFlag = false;
            }
            else {
                $("#PwdSearchValidate").empty();
                TxtLNameFlag = true;
            }
        }
    });

    $("#BtnUpdateRecord").click(function () {
        if ($("#FNameSearch").val() == "") {
            $("#FNameSearchValidate").empty();
            $("#FNameSearchValidate").html('(*) First Name Required..!!');
        }
        else {
            $("#FNameSearchValidate").empty();
            if (!$("#FNameSearch").val().match($FNameLNameRegEx)) {
                $("#FNameSearchValidate").html('Invalid First Name..!!');
                TxtFNameFlag = false;
            }
            else {
                $("#FNameSearchValidate").empty();
                TxtFNameFlag = true;
            }
        }
        if ($("#LNameSearch").val() == "") {
            $("#LNameSearchValidate").empty();
            $("#LNameSearchValidate").html('(*) Last Name Required..!!');
        }
        else {
            $("#LNameSearchValidate").empty();
            if (!$("#LNameSearch").val().match($FNameLNameRegEx)) {
                $("#LNameSearchValidate").html('Invalid Last Name..!!');
                TxtLNameFlag = false;
            }
            else {
                $("#LNameSearchValidate").empty();
                TxtLNameFlag = true;
            }
        }
        
        if ($("#EmailIdSearch").val() == "") {
            $("#EmailIdSearchValidate").empty();
            $("#EmailIdSearchValidate").html('(*) Email Id Required..!!');
        }
        else {
            $("#EmailIdSearchValidate").empty();
            if (!$("#EmailIdSearch").val().match($EmailIdRegEx)) {
                TxtEmailIdFlag = false;
                $("#EmailIdSearchValidate").html('Invalid Email Id..!!');
            }
            else {
                $("#EmailIdSearchValidate").empty();
                TxtEmailIdFlag = true;
            }
        }

        if (TxtFNameFlag == true && TxtLNameFlag == true && TxtEmailIdFlag == true) {
            SignUp();

        }
        else {
            alert("Invalid Inputs..!!")
        }
    });


});


function SignUp() {
    alert("Ajax");
    var user = new Object();
    user.UserId = 0;
    user.FirstName = $("#FNameSearch").val().trim();
    user.LastName = $("#LNameSearch").val().trim();
    user.EmailId = $("#EmailIdSearch").val().trim();
    user.Password = $("#PwdSearch").val().trim();
    user.UserRole = $("#DDL_Role").val().trim();
    user.IsActive = 'Y';
    alert(user);
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
                $("DDL_User").val("U");
                alert("Done!!!");
            }
        },
        error: function (response) {
            alert("ERROR");
        }

    });

};

