$(function () {
    $.ajax({
        type: "GET",
        url: "/Main/getuserdetails",
        dataType: "json",
        success: function (result) {
            console.log(result);
            var obj = {
                width: "100%",
                autoRow: true,
                resizable: false,
                title: "Users",
                showBottom: true,
                scrollModel: { autoFit: true },
                dataModel: { data: result }
            };
            obj.colModel = [
                { title: "First Name", dataType: "string", dataIndx: "FName", width: '10%', resizable: false },
                { title: "Middle Name", dataType: "string", dataIndx: "MName", width: '10%' },
                { title: "Last Name", dataType: "string", dataIndx: "LName", width: '10%' },
                { title: "Email", dataType: "string", dataIndx: "Email", width: '25%' },
                { title: "Username", dataType: "string", dataIndx: "Username", width: '10%' },
                { title: "Phone", dataType: "string", dataIndx: "PhoneNo", width: '10%' },
                { title: "Password", dataType: "string", dataIndx: "Password", width: '15%' },
                { title: "Ward", dataType: "string", dataIndx: "Ward", width: '9%' }
            ];
            obj.pageModel = { rPP: 20, type: "local" };
            $("#grid_json").pqGrid(obj);
        },
        error: function (req, status, error) {
            console.log(status);
        }
    });
});    