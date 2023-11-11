

$('#btnAdd').click(function () {
    $('#myModal').modal('show');

});

function Insert() {
    var formData = new Object();
    formData.id = $('#Id').val();
    formData.Logo = $('#Logo').val();
    formData.Name = $('#Name').val();
    formData.Description = $('#Description').val();

    $.ajax({
        url: '/Cinemas/CreateWithModal',
        data: formData,
        type: 'post',
        success: function (response) {
            if (response && response.status === "failure" && response.formErrors) {
                alert('Unable to save data');

                $(".text-danger").html("");

                $.each(response.formErrors, function () {
                    $("[data-valmsg-for=" + this.key + "]").html(this.errors.join("<br>"));
                });
               
            }
            else {
                HideModal();
                alert(response);
                location.reload();
            }
        },
        error: function (response) {
            alert('Unable to save dataa');
        }
       
    });


}

function HideModal() {
    $('#myModal').modal('hide');
}