
$('#btnAdd').on('click', function () {

    $('#myForm').trigger("reset");
    $('#myModal').modal('show');
    $('#modaltitle').text("Add Item");


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
function HideDeleteModal() {
    $('#deleteModal').modal('hide');

}

function Edit(id) {

    $('#modaltitle').text("Update Item");
    console.log("test")
    $.ajax({
        url: 'Cinemas/Edit?id=' + id,
        type: 'GET',
        contentType: 'application/json;charset=utf-8',
        datatype: 'json',
        success: function (response) {
            if (response === null || response === undefined) {
                alert('Unable to read the data.');

            }
            else if (response.length === 0) {
                alert('Data not available with id ' + id);
            }
            else {
                console.log(response);
                console.log($('#Save'));
                console.log($('#Name'));
                
                let json_response = response; 
                $('#myModal').modal('show');
                $('#Save').css('display', 'none');
                $('#Update').css('display', 'block');
                $('#Id').val(json_response.id);
                $('#Logo').val(json_response.logo);
                $('#Name').val(json_response.name);
                $('#Description').val(json_response.description);
            }
        },
        error: function (response) {
            alert('Unable to read data err.');
        }
    });
}


function Update() {

    console.log("ajuns");
    var formData = new Object();
    formData.id = $('#Id').val();
    formData.Logo = $('#Logo').val();
    formData.Name = $('#Name').val();
    formData.Description = $('#Description').val();

    console.log(formData.id);

    $.ajax({
        url: '/Cinemas/Update',
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



function Remove(id) {

    console.log("test")
    $.ajax({
        url: 'Cinemas/Delete?id=' + id,
        type: 'GET',
        contentType: 'application/json;charset=utf-8',
        datatype: 'json',
        success: function (response) {
            if (response === null || response === undefined) {
                alert('Unable to read the data.');

            }
            else if (response.length === 0) {
                alert('Data not available with id ' + id);
            }
            else {
                console.log(response);
                console.log($('#Save'));
                console.log($('#Name'));
                console.log(response.id);
                
                $('#deleteModal').modal('show');
                $('#Save').css('display', 'none');
                $('#Update').css('display', 'block');
                $('#id').val(response.id);
                $('#LogoId').val(response.logo);
                $('#NameId').val(response.name);
                $('#descriptionId').val(response.description);
            }
        },
        error: function (response) {
            alert('Unable to read data err.');
        }
    });

}
function Delete() {



}