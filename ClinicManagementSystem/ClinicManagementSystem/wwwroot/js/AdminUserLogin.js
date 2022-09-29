$(document).ready(function () {
    alert("login");

    var $EmailIdRegEx = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{2,10})(\]?)$/;
    var $PasswordRegEx = /^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^\w\s]).{8,12}$/;

     var TxtEmailIdFlag = false, TxtPasswordFlag = false;




    $("#EmailIdSearch").bind("blur", function (e) {
        if ($("#EmailIdSearch").val() == "") {
            TxtEmailIdFlag = false;
            $("#EmailIdSearchValidate").empty();
            $("#EmailIdSearchValidate").html('(*) EmailId Name Required..!!');
        }
        else {
            $("#EmailIdSearchValidate").empty();
            if (!$("#EmailIdSearch").val().match($EmailIdRegEx)) {
                $("#EmailIdSearchValidate").html('Invalid EmailId..!!');
                TxtEmailIdFlag = false;
            }
            else {
                $("#EmailIdSearchValidate").empty();
                TxtEmailIdFlag = true;
            }
        }
    });

    $("#PwdSearch").bind("blur", function (e) {
        if ($("#PwdSearch").val() == "") {
            TxtPasswordFlag = false;
            $("#PwdSearchValidate").empty();
            $("#PwdSearchValidate").html('(*) Password Required..!!');
        }
        else {
            $("#PwdSearchValidate").empty();
            if (!$("#PwdSearch").val().match($PasswordRegEx)) {
                $("#PwdSearchValidate").html('Invalid Password..!!');
                TxtPasswordFlag = false;
            }
            else {
                $("#PwdSearchValidate").empty();
                TxtPasswordFlag = true;
            }
        }
    });

    $("#BtnUpdateRecord").click(function () {
        if ($("#EmailIdSearch").val() == "") {
            TxtEmailIdFlag = false;
            $("#EmailIdSearchValidate").empty();
            $("#EmailIdSearchValidate").html('(*) EmailId Name Required..!!');
        }
        else {
            $("#EmailIdSearchValidate").empty();
            if (!$("#EmailIdSearch").val().match($EmailIdRegEx)) {
                $("#EmailIdSearchValidate").html('Invalid EmailId..!!');
                TxtEmailIdFlag = false;
            }
            else {
                $("#EmailIdSearchValidate").empty();
                TxtEmailIdFlag = true;
            }
        }
 


        if ($("#PwdSearch").val() == "") {
            TxtPasswordFlag = false;
            $("#PwdSearchValidate").empty();
            $("#PwdSearchValidate").html('(*) Password Required..!!');
        }
        else {
            $("#PwdSearchValidate").empty();
            if (!$("#PwdSearch").val().match($PasswordRegEx)) {
                $("#PwdSearchValidate").html('Invalid Password..!!');
                TxtPasswordFlag = false;
            }
            else {
                $("#PwdSearchValidate").empty();
                TxtPasswordFlag = true;
            }
        }
        if (TxtEmailIdFlag == true && TxtPasswordFlag == true) {
            SignIn();

        }
        else {
            alert("Invalid Inputs..!!")
        }
    });







});

function SignIn() {
    alert("Sign in called");
    var user = new Object();
    user.EmailId = $("#EmailIdSearch").val().trim();
    user.Password = $("#PwdSearch").val().trim();
    alert(user);

    $.ajax({
        type: "POST",
        cache: false,
        dataType: "json",
        url: "/Index/LoginUser",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(user),
        success: function (response) {
            debugger
            if (response.success = "success") {
                alert("logged in");
                $("input").val("");
            /*    $("DDL_User").val("U");*/
                alert("Done!!!");
            }
        },
        error: function (response) {
            alert("ERROR");
        }

    });

};



