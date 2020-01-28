
function GetPolicies(pageName)
{
    $.ajax({
        type: "GET",
        url: "https://localhost:44394/api/policy/getpolicies",
        contentType: "application/json; charset=utf-8",
        async: true,
        crossDomain: true,
        success: function (data) {

            $.each(data, function (i, item) {

                var riskType = "";
                if (item.Risktype == 0)
                    riskType = "Low";
                else if (item.Risktype == 1)
                    riskType = "Medium";
                else if (item.Risktype == 2)
                    riskType = "Medium-High";
                else if (item.Risktype == 3)
                    riskType = "High";

                var rows = "<tr>" +
                    "<td id='Id' style='display:none;'>" + item.Id + "</td>" +
                    "<td id='Name'>" + item.Name + "</td>" +
                    "<td id='Description'>" + item.Description + "</td>" +
                    "<td id='CoverageType'>" + item.CoverageType + "</td>" +
                    "<td id='EffectiveDate'>" + item.EffectiveDate + "</td>" +
                    "<td id='CoveragePeriod'>" + item.CoveragePeriod + "</td>" +
                    "<td id='Price'>" + item.Price + "</td>" +
                    "<td id='Risktype'>" + riskType + "</td>";

                    if (pageName == "home")
                    {
                        rows += "<td><a class='editCurrent' href='#'>Edit</a></td>" +
                            "<td><a class='deleteCurrent' href='#'>Delete</a></td>";
                    }
                    else if (pageName == "assign")
                    {
                        rows += "<td><a class='assignCurrent' href='#'>Assign</a></td>";
                    }
                   
                    rows += "</tr>";
                $('#policyTable').append(rows);

            }); //End of foreach Loop


            SetEditPolicyEvent();
            SetDeletePolicyEvent();
            SetAssignPolicyEvent();

        }, //End of AJAX Success function

        failure: function (data) {
            alert(JSON.stringify(data));
        }, //End of AJAX failure function
        error: function (data) {
            alert(JSON.stringify(data));
        } //End of AJAX error function

    });
}

function GetPolicyById(policyId, callbackFunction)
{
    $.ajax({
        type: "GET",
        url: "https://localhost:44394/api/policy/" + policyId,
        contentType: "application/json; charset=utf-8",
        async: true,
        crossDomain: true,
        success: function (data) {

            callbackFunction.call(this, data);

        }, //End of AJAX Success function

        failure: function (data) {
            alert(JSON.stringify(data));
        }, //End of AJAX failure function
        error: function (data) {
            alert(JSON.stringify(data));
        } //End of AJAX error function

    });
}

function CreatePolicy(createModal) {
    var selectedDate = createModal.find(".inputGetEffectiveDate").val();

    $.ajax({
        type: "POST",
        url: "https://localhost:44394/api/policy/",
        contentType: "application/json; charset=utf-8",
        async: true,
        crossDomain: true,
        data: '{"Name": "' + createModal.find(".inputGetName").val() + '", "Description": "' + createModal.find(".inputGetDescription").val() + '","CoverageType": ' + createModal.find(".inputGetCoverage").val() + ',"EffectiveDate": "' + selectedDate +'","CoveragePeriod": ' + createModal.find(".inputGetCoveragePeriod").val() + ', "Price": ' + createModal.find(".inputGetPrice").val() + ',"Risktype": ' + createModal.find(".inputGetRisktype").children("option:selected").val() + '}',
        success: function (data) {
            alert("Policy Created!!");
            location.reload();
        }, //End of AJAX Success function

        failure: function (data) {
            alert(JSON.stringify(data));
        }, //End of AJAX failure function
        error: function (data) {
            if (data.status == 401 && data.statusText == "Unauthorized") {
                alert(data.responseJSON);
                return;
            }

            alert(JSON.stringify(data));
        } //End of AJAX error function

    });
}

function UpdatePolicy(createModal) {
    $.ajax({
        type: "PUT",
        url: "https://localhost:44394/api/policy/",
        contentType: "application/json; charset=utf-8",
        async: true,
        crossDomain: true,
        data: '{"Id":' + createModal.find(".inputGetId").val()+', "Name": "' + createModal.find(".inputGetName").val() + '", "Description": "' + createModal.find(".inputGetDescription").val() + '","CoverageType": ' + createModal.find(".inputGetCoverage").val() + ',"EffectiveDate": "2020-02-26T00:06:42.9062617-06:00","CoveragePeriod": ' + createModal.find(".inputGetCoveragePeriod").val() + ', "Price": ' + createModal.find(".inputGetPrice").val() + ',"Risktype": ' + createModal.find(".inputGetRisktype").children("option:selected").val() + '}',
        success: function (data)
        {

            alert("Policy Edited!!");
            location.reload();


        }, //End of AJAX Success function

        failure: function (data) {
            alert(JSON.stringify(data));
        }, //End of AJAX failure function
        error: function (data) {
            if (data.status == 401 && data.statusText == "Unauthorized") {
                alert(data.responseJSON);
                return;
            }

            alert(JSON.stringify(data));
        } //End of AJAX error function

    });
}

function DeletePolicy(idToRemove)
{
    $.ajax({
        type: "DELETE",
        url: "https://localhost:44394/api/policy/" + idToRemove,
        contentType: "application/json; charset=utf-8",
        async: true,
        crossDomain: true,
        success: function (data) {

            alert("Policy Deleted!!");
            location.reload();

        }, //End of AJAX Success function

        failure: function (data) {
            alert(JSON.stringify(data));
        }, //End of AJAX failure function
        error: function (data) {
            alert(JSON.stringify(data));
        } //End of AJAX error function

    });
}

function GetCustomers(callbackFunction) {
    $.ajax({
        type: "GET",
        url: "https://localhost:44394/api/customer/getcustomers",
        contentType: "application/json; charset=utf-8",
        crossDomain: true,
        async: true,
        success: function (data) {

            callbackFunction.call(this, data);
          
        }, //End of AJAX Success function

        failure: function (data) {
            alert(JSON.stringify(data));
        }, //End of AJAX failure function
        error: function (data) {
            alert(JSON.stringify(data));
        } //End of AJAX error function

    });
}

function LoginIn() {
    $.ajax({
        type: "POST",
        url: "https://localhost:44394/api/user/",
        contentType: "application/json; charset=utf-8",
        async: true,
        crossDomain: true,
        data: '{"userId":"user1", Password:"123456"}',
        success: function (data) {


           // alert(JSON.stringify(data));

           
           
        }, //End of AJAX Success function

        failure: function (data) {
            alert(JSON.stringify(data));
        }, //End of AJAX failure function
        error: function (data) {
            alert(JSON.stringify(data));
        } //End of AJAX error function

    });
}

function SetEditPolicyEvent()
{
    // set the event to open update modal
    $('#policyTable').find(".editCurrent").click(function () {
        var currentRowId = $(this).parent().parent().find("#Id").text();
        var updateModal = $('#updateModal');

        GetPolicyById(currentRowId, function (selectedPolicyData) {
            updateModal.find(".inputGetId").val(currentRowId);
            updateModal.find(".inputGetName").val(selectedPolicyData.Name);
            updateModal.find(".inputGetDescription").val(selectedPolicyData.Description);
            updateModal.find(".inputGetCoverage").val(selectedPolicyData.CoverageType);
            //updateModal.find(".inputGetEffectiveDate").val(selectedPolicyData.EffectiveDate);
            updateModal.find(".inputGetCoveragePeriod").val(selectedPolicyData.CoveragePeriod);
            updateModal.find(".inputGetPrice").val(selectedPolicyData.Price);
            updateModal.find(".inputGetRisktype").val(selectedPolicyData.Risktype);
        });

        updateModal.modal('show');
    });
}

function SetDeletePolicyEvent()
{
    $('#policyTable').find(".deleteCurrent").click(function () {
        var currentRowId = $(this).parent().parent().find("#Id").text();
        var deleteModal = $('#DeleteModal');
        deleteModal.find(".inputGetId").val(currentRowId);
        deleteModal.modal('show');
    });
}

function SetAssignPolicyEvent() {
    // set the event to open update modal
    $('#policyTable').find(".assignCurrent").click(function () {
        var currentRowId = $(this).parent().parent().find("#Id").text();
        var assignModal = $('#assignModal');
        var inputGeCustomerId = $("#assignModal").find(".inputGeCustomerId");

        GetCustomers(function (data) {
            $.each(data, function (i, item) {

                inputGeCustomerId.append($('<option>', { value: item.Id, text: item.Name }));

            }); //End of foreach Loop
            
        });

        assignModal.find(".inputToAssign").val(currentRowId);
        assignModal.modal('show');
    });
}

function SetDeallocatePolicyEvent()
{
    var deallocateModal = $('#deallocateModal');
    $('#assignedPoliciesTable').find(".deallocateCurrent").click(function ()
    {
        var currentRowId = $(this).parent().parent().find("#Id").text();
        deallocateModal.find(".inputGetId").val(currentRowId);
        deallocateModal.modal('show');

    });
    
}

function GetAssignedPolicies()
{
      $.ajax({
            type: "GET",
            url: "https://localhost:44394/api/PolicyAssignment/GetAssignedPolicies",
            contentType: "application/json; charset=utf-8",
            async: true,
            crossDomain: true,
            success: function (data) {
                $.each(data, function (i, item)
                {
                    var rows = "<tr>" +
                        "<td id='Id'>" + item.Id + "</td>" +
                        "<td id='CustomerId'>" + item.CustomerId + "</td>" +
                        "<td id='CustomerName'>" + item.CustomerName + "</td>" +
                        "<td id='PolicyId'>" + item.PolicyId + "</td>" +
                        "<td id='PolicyName'>" + item.PolicyName + "</td>" +
                        "<td><a class='deallocateCurrent' href='#'>Deallocate</a></td>" +
                        "</tr>";
                    $('#assignedPoliciesTable').append(rows);
                });
                SetDeallocatePolicyEvent();

            }, //End of AJAX Success function

            failure: function (data) {
                alert(JSON.stringify(data));
            }, //End of AJAX failure function
            error: function (data) {
                alert(JSON.stringify(data));
            } //End of AJAX error function

        });
}

function CreateAssignedPolicy(customerId, policyId)
{
    $.ajax({
        type: "POST",
        url: "https://localhost:44394/api/PolicyAssignment/",
        contentType: "application/json; charset=utf-8",
        async: true,
        crossDomain: true,
        data: '{"CustomerId":' + customerId + ',"PolicyId":' + policyId + ',"Status":true}',
        success: function (data) {
            alert("Policy Assigned!!");
            location.reload();
        }, //End of AJAX Success function

        failure: function (data) {
            alert(JSON.stringify(data));
        }, //End of AJAX failure function
        error: function (data)
        {
            alert(JSON.stringify(data));
        } //End of AJAX error function

    });
}

function DeallocatePolicy(id) {
    $.ajax({
        type: "DELETE",
        url: "https://localhost:44394/api/PolicyAssignment/"+id,
        contentType: "application/json; charset=utf-8",
        async: true,
        crossDomain: true,
        success: function (data) {
            alert("Policy Deallocated!!");
            location.reload();
        }, //End of AJAX Success function

        failure: function (data) {
            alert(JSON.stringify(data));
        }, //End of AJAX failure function
        error: function (data) {
            alert(JSON.stringify(data));
        } //End of AJAX error function

    });
}