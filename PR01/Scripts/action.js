function render() {
    $.ajax({
        type: 'get',
        url: 'employees/Create',
        data: {
            'field1': 'hello',
            'field2': 'hello1'
        },
        success: function (response) {
            $("#div1").html(response);
        },
        error: function () {
            alert("error");
        }
    });

}



function getDep() {
    $.ajax({
        type: 'POST',
        url: '/Test/GetDepartment',
        data: {
            'nombre': $('#nombre').val()
        },
        success: function (response) {
            alert(response[0].descripcion);
            $("#nombre2").html(response[0].descripcion);
        },
        error: function () {
            alert("error");
        }
    });

}