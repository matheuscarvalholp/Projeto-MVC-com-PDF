$(document).ready(function () {
    $("#atualizar").click(function () { 
    $.ajax({
        url: "/Arquivo/Atualizar",
        data: {
            id: $("#id").val(),
            status: $("#status").val()
        },
        success: function (){
        }
        })
    })
});