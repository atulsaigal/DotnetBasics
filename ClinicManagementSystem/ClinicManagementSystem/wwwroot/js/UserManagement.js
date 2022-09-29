$(document).ready(function () {
    alert("UserManagment JQuery  is Working");
    UserDataTableFill("", "");




    $(document).on('click', '.EditRecordCLS', function () {
        //alert("edit function");
        UserDataTableFill($(this).attr('data-UserIdEdit').trim(), "Where UserId=");
    });


    $(document).on('click', '.EditStatusCLS', function () {
        if (confirm("Are You Sure To Change View Status..??")) {
            if ($(this).attr('data-UserStatus') == "N") {
                $(this).find("i").removeClass("fa-times-circle");
                $(this).find("i").addClass("fa-check-square");
                $(this).find("i").css("color", "#228B22");
                $(this).attr("data-UserStatus", "Y");
                UpdateUserStatus(parseInt($(this).attr('data-UserStatusId')), $(this).attr("data-UserStatus"));
            } else {
                $(this).find("i").removeClass("fa-check-square");
                $(this).find("i").addClass("fa-times-circle");
                $(this).find("i").css("color", "#ff0000");
                $(this).attr("data-UserStatus", "N");
                UpdateUserStatus(parseInt($(this).attr('data-UserStatusId')), $(this).attr("data-UserStatus"));
            }
        }
    });
})

function UserDataTableFill(orderby, whereclause) {
    alert("UserDataTableFill ajax is calling");
    
    $.ajax({
        type: "GET",
        url: "/Index/GetAllUserData",
        data: { "orderby": orderby, "whereclause": whereclause },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.data.length);
        
            

            if (whereclause == 'Where UserId=') {
                $("#TxtFName").val(response.data[0].firstname);
                $("#TxtLName").val(response.data[0].lastname);
                $("#TxtEmailId").val(response.data[0].emailId);
                $("#DDL_User").val(response.data[0].userRole);
                $("#BtnUpdateRecord").attr('EditUserId', response.data[0]["userId"]);
            }
            else {



                $("#table14 tbody").empty();
                for (var i = 0; i < response.data.length; i++) {
                    var tr_str = '';
                    var Status = null;
                    var userrole = null;
                    if (response.data[i]["isActive"] == "Y") {
                        Status = "<i style='color:#228B22' class='fa fa-2x fa-check-square'></i>";
                    }
                    else {
                        Status = "<i style='color:#ff0000' class='fa fa-2x fa-times-circle'></i>";
                    }
                    if (response.data[i]["userRole"] == "U") {
                        userrole = "<i class='fa fa-2x fa-user' style='color:black'></i>";
                    }
                    else {
                        userrole = "<i class='fa fa-2x fa-user-circle' style='color:black'></i>";
                    }




                    tr_str = "<tr class='datatable-row' id=" + response.data[i]["UserId"] + ">" +
                        "<td class='text-center'><span style='width:100px'>" + (i + 1) + "</span></td>" +
                        "<td class='text-center'><span style='width:100px'>" + response.data[i]["firstname"] + "</span></td>" +
                        "<td class='text-center'><span style='width:70px'>" + response.data[i]["lastname"] + "</span></td>" +
                        "<td class='text-center'><span style='width:80px'>" + response.data[i]["emailId"] + "</span></td>" +
                        /*  "<td class='datatable-cell'><span style='width:80px'>" + response.data[i]["userRole"] + "</span></td>" +*/

                        /* "<td class='datatable-cell'><span style='width:80px'>" + response.data[i]["isActive"] + "</span></td>" +*/
                        "<td class='text-center'><a data-UserRoleId=" + response.data[i]["userId"] + " data-UserStatus=" + response.data[i]["userRole"] + " class='EditRoleCLS'>" + userrole + "</a></td>" +

                        "<td class='text-center'><a data-UserStatusId=" + response.data[i]["userId"] + " data-UserStatus=" + response.data[i]["isActive"] + " class='EditStatusCLS'>" + Status + "</a></td>" +
                        "<td class='text-center'><a data-UserIdEdit=" + response.data[i]["userId"] + " class='EditRecordCLS' data-toggle='modal' data-target='#EditUserRecord'><i class='fa fa-2x fa-pencil-square-o'></i></a></td>" +


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

function UpdateUserStatus(id, status) {
    alert(id);
    alert(status);

    var obj = new Object();
    obj.UserId = id;
    obj.isActive = status;
    alert(obj);

    debugger
    $.ajax({
        url: "/Index/UpdateUserStatus",
        type: 'POST',
        dataType: "json",
        contentType: "application/json; charset-utf-8",
        data: JSON.stringify(obj),
        success: function () {
            alert("Data Updated");
        },
        error: function (jqXHR, textStatus, err) {
            alert('text status ' + textStatus + ', err ' + err)
        }
    });

    return true;
}