function selectView(view) {
    $('.display').not('#' + view + "Display").hide();
    $('#' + view + "Display").show();
}

function getData() {
    $.ajax({
        type: "GET",
        url: "/api/facility",
        success: function (data) {
            $('#tableBody').empty();
            for (var i = 0; i < data.length; i++) {
                $('#tableBody').append('<tr><td><input id="id" name="id" type="radio"'
                    + 'value="' + data[i].Id + '" /></td>'
                    + '<td>' + data[i].FacilityName + '</td>'
                    + '<td>' + data[i].FacilityGroup + '</td></tr>');
            }
            if ($('input:radio') != null && $('input:radio')[0] != null)
                $('input:radio')[0].checked = "checked";
            selectView("summary");
        }
    });
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
                    url: "/api/facility/" + selectedRadio.attr('value'),
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
                    url: "/api/facility/" + selectedRadio.attr('value'),
                    success: function (data) {
                        $('#editFacilityId').val(data.Id);
                        $('#editFacilityName').val(data.FacilityName);
                        $('#editFacilityGroup').val(data.FacilityGroup);
                        selectView("edit");
                    }
                });
                break;
            case "submitEdit":
                $.ajax({
                    type: "POST",
                    //url: "/api/facility/" + selectedRadio.attr('value'),
                    url: "/api/facility",
                    data: $('#editForm').serialize(),
                    success: function (result) {
                        if (result) {
                            var cells = selectedRadio.closest('tr').children();
                            cells[1].innerText = $('#editFacilityName').val();
                            cells[2].innerText = $('#editFacilityGroup').val();
                            selectView("summary");
                        }
                    }
                });
                break;
        }
    });
});