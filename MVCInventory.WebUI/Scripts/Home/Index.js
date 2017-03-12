function selectView(view) {
    $('.display').not('#' + view + "Display").hide();
    $('#' + view + "Display").show();
}

function getData() {
    $.ajax({
        type: "GET",
        url: "/api/building",
        success: function(data) {
            $('#tableBody').empty();
            for (var i = 0; i < data.length; i++) {
                $('#tableBody')
                    .append('<tr><td><input id="id" name="id" type="radio"' +
                        'value="' +
                        data[i].Id +
                        '" /></td>' +
                        '<td>' +
                        data[i].BuildingName +
                        '</td>' +
                        '<td>' +
                        data[i].Property +
                        '</td></tr>');
            }
            if ($('input:radio') != null && $('input:radio')[0] != null)
                $('input:radio')[0].checked = "checked";
            selectView("summary");
        }
    });

    //$('#employees').empty();
    //$.getJSON("/api/building",
    //    function(data) {
    //        $.each(data,
    //            function(i, building) {
    //                var content = building.ID + ' ' + building.BuildingName;
    //                $('#tableBody').append($('<li/>'), { text: content });
    //            });
    //    });
}


$(document).ready(function () {
    selectView("summary");
    getData();
    
    $("button").click(function (e) {
        var selectedRadio = $('input:radio:checked');
        switch (e.target.id) {
            case "refresh":
                getData();
                break;
            case "delete":
                $.ajax({
                    type: "DELETE",
                    url: "/api/building/" + selectedRadio.attr('value'),
                    success: function (data) {
                        selectedRadio.closest('tr').remove();
                    }
                });
                break;
            case "add":
                selectView("add");
                break;
            case "edit":
                $.ajax({
                    type: "GET",
                    url: "/api/building/" + selectedRadio.attr('value'),
                    success: function (data) {
                        $('#editBuildingId').val(data.Id);
                        $('#editBuildingName').val(data.BuildingName);
                        $('#editProperty').val(data.Property);
                        selectView("edit");
                    }
                });
                break;
            case "submitEdit":
                $.ajax({
                    type: "PUT",
                    // url: "/api/building/" + selectedRadio.attr('value'),
                    url: "/api/building",
                    data: $('#editForm').serialize(),
                    success: function (result) {
                        if (result) {
                            var cells = selectedRadio.closest('tr').children();
                            cells[1].innerText = $('#editBuildingName').val();
                            cells[2].innerText = $('#editProperty').val();
                            selectView("summary");
                        }
                    }
                });
                break;
        }
    });
});