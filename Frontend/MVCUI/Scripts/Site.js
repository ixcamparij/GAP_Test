
function GetPolicies()
{
    $.ajax({
        type: "GET",
        url: "https://localhost:44394/api/policy/getpolicies",
        contentType: "application/json; charset=utf-8",
        async: true,
        crossDomain: true,
        success: function (data) {

            $.each(data, function (i, item) {
                var rows = "<tr>" +
                    "<td id='Id'>" + item.Id + "</td>" +
                    "<td id='Name'>" + item.Name + "</td>" +
                    "<td id='Description'>" + item.Description + "</td>" +
                    "<td id='Coverage Type'>" + item.CoverageType + "</td>" +
                    "<td id='Effective Date'>" + Date(item.EffectiveDate,
                        "dd-MM-yyyy") + "</td>" +
                    "<td id='CoveragePeriod'>" + item.CoveragePeriod + "</td>" +
                    "<td id='Price'>" + item.Price + "</td>" +
                    "<td id='Risktype'>" + item.Risktype + "</td>" +
                    "<td><a class='editCurrent' href='#'>Edit</a></td>" +
                    "<td><a class='deleteCurrent' href='#'>Delete</a></td>" +
                    "</tr>";
                $('#policyTable').append(rows);

            }); //End of foreach Loop


            SetEditPolicyEvent();
            SetDeletePolicyEvent();

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
    //alert(createModal.find(".inputGetEffectiveDate").val());

    $.ajax({
        type: "POST",
        url: "https://localhost:44394/api/policy/",
        contentType: "application/json; charset=utf-8",
        async: true,
        crossDomain: true,
        data: '{"Name": "' + createModal.find(".inputGetName").val() + '", "Description": "' + createModal.find(".inputGetDescription").val() + '","CoverageType": ' + createModal.find(".inputGetCoverage").val() + ',"EffectiveDate": "2020-02-26T00:06:42.9062617-06:00","CoveragePeriod": ' + createModal.find(".inputGetCoveragePeriod").val() + ', "Price": ' + createModal.find(".inputGetPrice").val() + ',"Risktype": ' + createModal.find(".inputGetRisktype").children("option:selected").val() + '}',
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

function GetCustomers() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44394/api/customer/getcustomers",
        contentType: "application/json; charset=utf-8",
        crossDomain: true,
        async: true,
        success: function (data) {

            $.each(data, function (i, item) {
                var rows = "<tr>" +
                    "<td id='Id'>" + item.Id + "</td>" +
                    "<td id='Name'>" + item.Name + "</td>" +
                    "</tr>";
                $('#customerTable').append(rows);

            }); //End of foreach Loop
          
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