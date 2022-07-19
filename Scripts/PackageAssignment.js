$(document).ready(function () {
    $('#package_id').on('change', function () {
        LoadPackage();
    });
});
function LoadPackage() {
    var packageId = $('#package_id');
    if (!packageId.val()) {
        $('#package_fee').val(0);
        $('#session_adj').val(0);
        $('#expiry_date').val('');
        return;
    }
    packageId = packageId.val();

    $.ajax({
        type: "GET",
        url: "/Assignmentt/GetPackage",
        data: { 'PackageId': packageId },
        success: function (data) {
            //console.log(data);
            if (data != null) {

                //$("#inherentassessment").jsonToForm(data);
                $('#package_fee').val(data.package_fee);
                $('#session_adj').val(data.session_adj);
                $('#expiry_date').val(data.expiry_date);
                
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            
        }
    });
}